CREATE TABLE [dbo].[Guests] (
    [Id]    INT   IDENTITY(1,1) NOT NULL primary key ,
    [fio]   NVARCHAR (50) NULL,
    [email] VARCHAR (50)  NULL,
    [phone] VARCHAR (50)  NULL,
	[flag] VARCHAR (50)  NULL,
);



SET IDENTITY_INSERT [dbo].[Guests] ON
INSERT INTO [dbo].[Guests] ([Id], [fio], [email], [phone], [flag]) VALUES (1, N'Иванов Иван Иванович', N'evguen@rambler.ru', N'89056785', N'0')
INSERT INTO [dbo].[Guests] ([Id], [fio], [email], [phone], [flag]) VALUES (2, N'Сидоров Сергей Сергеевич', N'sidor@yandex.ru', N'89066678', N'1')
INSERT INTO [dbo].[Guests] ([Id], [fio], [email], [phone], [flag]) VALUES (3, N'Петров петр ', N'peter@mail.com', N'3333333', N'2')
INSERT INTO [dbo].[Guests] ([Id], [fio], [email], [phone], [flag]) VALUES (4, N'Спиридонов', N'ty@yuyu.net', N'8911907867', N'0')
INSERT INTO [dbo].[Guests] ([Id], [fio], [email], [phone], [flag]) VALUES (5, N'Назарет', N'ee@ii.org', N'89054567', N'2')
INSERT INTO [dbo].[Guests] ([Id], [fio], [email], [phone], [flag]) VALUES (6, N'Стивенсон', N'sss@uuu.org', N'66666', N'1')
SET IDENTITY_INSERT [dbo].[Guests] OFF

