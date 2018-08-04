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
        tempdbEntities ef = new tempdbEntities();  

        public ActionResult Index()
        {           

           IList<Guest> guestList = new List<Guest>();           
           
           var  result = ef.GuestList.OrderBy(x => x.Id).Select(r => new {Id = r.Id , fio = r.fio, email = r.email, phone = r.phone, flag = r.flag }).ToList();

            foreach (var item in result)
                guestList.Add(new Guest() {Id= item.Id ,fio = item.fio, email = item.email, phone = item.phone, flag = item.flag });

            ViewData["index"] = guestList;        
            return View();
        
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
            

        public ActionResult GuestList(string flag, int id = 0)
        {

            if (flag == "btn-primary")
            {
                using (tempdbEntities ent = new tempdbEntities())
                {
                    var  res = ent.GuestList.Where(o => o.flag == "2").OrderBy(x => x.Id).Select(r => new {Id = r.Id, fio = r.fio, email = r.email, phone = r.phone, flag = r.flag }).ToList();                        
                    foreach (var item in res)
                    {
                        GuestList updatedGuestListCancel = (from c in ent.GuestList
                                                            where c.Id == item.Id
                                                            select c).FirstOrDefault();
                        updatedGuestListCancel.flag = "1";
                        ent.SaveChanges();                    
                    }                                                           
                }
            }
            
            if (flag == "btn glyphicon-plus btn-sm")
            {
                using (tempdbEntities ent = new tempdbEntities())
                {
                    GuestList updatedGuestListPlus = (from c in ent.GuestList
                                                 where c.Id == id
                                                 select c).FirstOrDefault();
                    
                    updatedGuestListPlus.flag = "0";
                    ent.SaveChanges();

                }
            }

            if (flag == "btn glyphicon-minus btn-sm")
            {
                using (tempdbEntities ent = new tempdbEntities())
                {
                    GuestList updatedGuestListMinus = (from c in ent.GuestList
                                                  where c.Id == id
                                                  select c).FirstOrDefault();
                    updatedGuestListMinus.flag = "1";
                    ent.SaveChanges();
                }
            
            }
            
            IList<Guest> guestList = new List<Guest>();                                                                   
            var  result = ef.GuestList.OrderBy(x => x.Id).Select(r => new { fio = r.fio, email = r.email, phone = r.phone, flag = r.flag }).ToList();
                   
            if(flag == "0" || flag == "1")      
             result = ef.GuestList.Where(o => o.flag == flag ).OrderBy(x => x.Id).Select(r => new { fio = r.fio, email = r.email, phone = r.phone ,flag = r.flag }).ToList();                        
            
            foreach (var item in result)
                guestList.Add(new Guest() { fio = item.fio, email = item.email, phone = item.phone, flag = item.flag});            

            ViewData["guest"] = guestList;            

            return PartialView(); 
        }
       


    }
}