using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Untt_test.Models;

namespace Untt_test.Controllers
{
    public class HomeController : Controller
    {
       
       
        public ActionResult Index()
        {
            IList<GuestList>  guestList = new List<GuestList>();
            using (tempdbEntities2 ent = new tempdbEntities2())
            {
                var res = ent.Guests.OrderBy(x => x.Id).Select(r => new { Id = r.Id, fio = r.fio, email = r.email, phone = r.phone, flag = r.flag }).ToList();
                foreach (var item in res)
                    guestList.Add(new GuestList() { Id = item.Id, fio = item.fio, email = item.email, phone = item.phone, flag = item.flag });

                ViewData["guest"] = guestList;
            }
            return View();        
        }

        public ActionResult GuestList(string flag, int id = 0, string ser = null)
        {

            if (flag == "btn-primary")
            {
                using (tempdbEntities2 ent = new tempdbEntities2())
                {
                    var res = ent.Guests.Where(o => o.flag == "2").OrderBy(x => x.Id).Select(r => new { Id = r.Id, fio = r.fio, email = r.email, phone = r.phone, flag = r.flag }).ToList();
                    foreach (var item in res)
                    {
                        Guests updatedGuestListCancel = (from c in ent.Guests
                                                         where c.Id == item.Id
                                                         select c).FirstOrDefault();
                        updatedGuestListCancel.flag = "1";
                        ent.SaveChanges();
                    }
                }
            }

            if (flag == "btn glyphicon-minus btn-sm")
            {
                using (tempdbEntities2 ent = new tempdbEntities2())
                {
                    Guests up = (from c in ent.Guests
                                 where c.Id == id
                                 select c).FirstOrDefault();

                    up.flag = "1";
                    ent.SaveChanges();
                }

            }

            if (flag == "btn glyphicon-plus btn-sm")
            {
                using (tempdbEntities2 ent = new tempdbEntities2())
                {
                    Guests updatedGuestListPlus = (from c in ent.Guests
                                                   where c.Id == id
                                                   select c).FirstOrDefault();

                    updatedGuestListPlus.flag = "0";
                    ent.SaveChanges();

                }
            }

            IList<GuestList> guestList = new List<GuestList>();          
            using (tempdbEntities2 en = new tempdbEntities2())
            {
                var result = en.Guests.OrderBy(x => x.Id).Select(r => new { r.Id, r.fio, r.email, r.phone, r.flag }).ToList();

                if (flag == "0")
                    result = en.Guests.Where(o => o.flag == flag).OrderBy(x => x.Id).Select(r => new { r.Id, r.fio, r.email, r.phone, r.flag }).ToList();
                if (flag == "1")
                    result = en.Guests.Where(o => o.flag == flag).OrderBy(x => x.Id).Select(r => new { r.Id, r.fio, r.email, r.phone, r.flag }).ToList();

                foreach (var item in result)
                    guestList.Add(new GuestList() { Id = item.Id, fio = item.fio, email = item.email, phone = item.phone, flag = item.flag });
            }
            ViewData["guest"] = guestList;


            if (flag == "glyphicon glyphicon-search")
            {
                IList<GuestList> guest = new List<GuestList>();
                using (tempdbEntities2 enn = new tempdbEntities2())
                {                    

                    var re = enn.Guests.Where(x => (x.fio.StartsWith(ser) || x.email.StartsWith(ser) || x.phone.StartsWith(ser)));
                    foreach (var item in re)
                        guest.Add(new GuestList() { Id = item.Id, fio = item.fio, email = item.email, phone = item.phone, flag = item.flag });

                }
                ViewData["guest"] = guest;                                
            }           

            return PartialView(); 
        }       
    }
}