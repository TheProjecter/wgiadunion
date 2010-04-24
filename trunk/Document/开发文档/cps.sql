----walker 2010/4/24
--修改wgi_loginlog表，设主键为自增，请自行到数据库更新。。。
--更使用本文件代码


---walker:2010/4/22
--系统通知，网站公告，用户消息表
if exists (select * from sysobjects where id = OBJECT_ID('[wgi_notice]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [wgi_notice]
create table wgi_notice(
	id int identity primary key,--主键id 
	title nvarchar(100) null,--公告标题
	notice ntext null,--公告内容
	pubdate datetime default getdate(),--发布时间
	unread int default 0,	--默认未读
	publisher int default -1, --默认值表示未知系统管理员
	objid int default -1 --默认值表示公告消息，否则跟上接收人ID
)
go

insert into wgi_notice (title,notice) values('关于一月份佣金的补充通知','内容内容<br/>关于一月份佣金的补充通知，每个人发红利300元<br/>关于一月份佣金的补充通知，每个人发红利300元<br/>关于一月份佣金的补充通知，每个人发红利300元<br/>关于一月份佣金的补充通知，每个人发红利300元')

-----------========original===============
create table wgi_adv_statis (
   companyid            int                  null,
   userid               int                  null,
   siteid               int                  null,
   advid                int                  null,
   advtype              int                  null,
   statistype           int                  null,
   recordtime           datetime             null default getdate(),
   ip                   varchar(50)          null
)
go

if exists (select * from sysobjects where id = OBJECT_ID('[wgi_adhost]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [wgi_adhost]

CREATE TABLE [wgi_adhost] (
[companyid] [int]  IDENTITY (1, 1)  NOT NULL,
[status] [int]  NULL,
[username] [varchar]  (50) NULL,
[password] [varchar]  (50) NULL,
[email] [varchar]  (150) NULL,
[company] [nvarchar]  (100) NULL,
[contact] [varchar]  (50) NULL,
[tel] [varchar]  (100) NULL,
[qq] [varchar]  (20) NULL,
[mobile] [varchar]  (50) NULL,
[fax] [varchar]  (100) NULL,
[address] [nvarchar]  (200) NULL,
[zipcode] [varchar]  (20) NULL,
[url] [varchar]  (200) NULL,
[intro] [text]  NULL,
[user_type] [int]  NULL,
[owner] [varchar]  (50) NULL,
[licence] [varchar]  (150) NULL,
[icp] [varchar]  (150) NULL,
[industryid] [int]  NULL,
[sitename] [varchar]  (100) NULL,
[cookiepage] [varchar] (255) NULL,
[remark] [text]  NULL,
[return_day] [varchar]  (100) NULL,
[return_type] [varchar]  (100) NULL,
[valid_day] [varchar]  (50) NULL,
[regdate] [datetime]  NULL,
[regip] [varchar]  (100) NULL,
[lastdate] [datetime]  NULL,
[lastip] [varchar]  (100) NULL,
[balance] [decimal]  (18,2) NULL,
[ischeck] [int]  NULL DEFAULT ((0)))

ALTER TABLE [wgi_adhost] WITH NOCHECK ADD  CONSTRAINT [PK_wgi_adhost] PRIMARY KEY  NONCLUSTERED ( [companyid] )
SET IDENTITY_INSERT [wgi_adhost] ON

INSERT [wgi_adhost] ([companyid],[status],[username],[password],[ischeck],[cookiepage]) VALUES ( 1,0,'wingoi','wingoi',0,'/click/cookie.aspx')

SET IDENTITY_INSERT [wgi_adhost] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[wgi_adhost_usersite]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [wgi_adhost_usersite]

CREATE TABLE [wgi_adhost_usersite] (
[auid] [int]  IDENTITY (1, 1)  NOT NULL,
[companyid] [int]  NULL,
[siteid] [int]  NULL,
[status] [int]  NULL DEFAULT ((1)),
[applytime] [datetime]  NULL)

ALTER TABLE [wgi_adhost_usersite] WITH NOCHECK ADD  CONSTRAINT [PK_wgi_adhost_usersite] PRIMARY KEY  NONCLUSTERED ( [auid] )
SET IDENTITY_INSERT [wgi_adhost_usersite] ON

INSERT [wgi_adhost_usersite] ([auid],[companyid],[siteid],[status]) VALUES ( 1,1,2,1)

SET IDENTITY_INSERT [wgi_adhost_usersite] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[wgi_adv]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [wgi_adv]

CREATE TABLE [wgi_adv] (
[advid] [int]  IDENTITY (1, 1)  NOT NULL,
[companyid] [int]  NULL,
[advname] [varchar]  (100) NULL,
[advtype] [int]  NULL,
[advcont] [text]  NULL,
[advlink] [varchar]  (200) NULL,
[advwidth] [int]  NULL,
[advheight] [int]  NULL,
[advuptime] [datetime]  NULL,
[advstatus] [int]  NULL DEFAULT ((1)),
[advstart] [datetime]  NULL,
[advend] [datetime]  NULL,
[advinvalid] [int]  NULL,
[advpaytype] [int]  NULL DEFAULT ((1)))

ALTER TABLE [wgi_adv] WITH NOCHECK ADD  CONSTRAINT [PK_wgi_adv] PRIMARY KEY  NONCLUSTERED ( [advid] )
SET IDENTITY_INSERT [wgi_adv] ON

INSERT [wgi_adv] ([advid],[companyid],[advtype],[advcont],[advuptime],[advstart],[advpaytype]) VALUES ( 16,1,1,'aaaf','2010-4-6 9:04:19','1900-1-1 0:00:00',1)
INSERT [wgi_adv] ([advid],[companyid],[advtype],[advcont],[advuptime],[advstart],[advpaytype]) VALUES ( 17,1,1,'asffd','2010-4-6 9:33:39','1900-1-1 0:00:00',1)
INSERT [wgi_adv] ([advid],[companyid],[advname],[advtype],[advcont],[advuptime],[advstart],[advpaytype]) VALUES ( 18,1,'中商促销',1,'fdadfsaf','2010-4-6 9:33:58','1900-1-1 0:00:00',1)
INSERT [wgi_adv] ([advid],[companyid],[advname],[advtype],[advlink],[advuptime],[advstart],[advpaytype]) VALUES ( 19,1,'aaf',2,'aaa','2010-4-6 20:00:02','1900-1-1 0:00:00',1)
INSERT [wgi_adv] ([advid],[companyid],[advname],[advtype],[advlink],[advuptime],[advstart],[advpaytype]) VALUES ( 20,1,'aa',2,'http://www.baidu.com','2010-4-6 21:39:28','2010-4-8 21:39:02',1)
INSERT [wgi_adv] ([advid],[companyid],[advname],[advtype],[advcont],[advlink],[advuptime],[advstart],[advpaytype]) VALUES ( 21,1,'af',2,'http://www.baidu.com','http://www.baidu.com','2010-4-6 23:39:50','2010-4-6 23:39:28',1)
INSERT [wgi_adv] ([advid],[companyid],[advname],[advtype],[advcont],[advlink],[advuptime],[advstart],[advpaytype]) VALUES ( 22,1,'q',2,'http://www.baidu.com','http://www.baidu.com','2010-4-6 23:43:24','2010-4-6 23:43:08',1)
INSERT [wgi_adv] ([advid],[companyid],[advname],[advtype],[advlink],[advuptime],[advstart],[advpaytype]) VALUES ( 23,1,'aaf',2,'http://www.baidu.com','2010-4-6 23:43:57','2010-4-6 23:43:47',1)
INSERT [wgi_adv] ([advid],[companyid],[advname],[advtype],[advlink],[advuptime],[advstart],[advpaytype]) VALUES ( 24,1,'aaf',2,'http://www.baidu.com','2010-4-6 23:47:55','2010-4-23 23:47:40',1)
INSERT [wgi_adv] ([advid],[companyid],[advname],[advtype],[advcont],[advlink],[advuptime],[advstart],[advend],[advpaytype]) VALUES ( 25,1,'sadaDASd',1,'dffdsafdsafdsafsdaf','http://www.wingoi.com','2010-4-6 23:58:49','2010-4-6 23:58:31','2010-5-6 23:58:32',1)
INSERT [wgi_adv] ([advid],[companyid],[advname],[advtype],[advcont],[advlink],[advuptime],[advstart],[advend],[advpaytype]) VALUES ( 26,1,'dsafdsa',1,'dsafdsafdsaf','http://www.wingoi.com','2010-4-6 23:59:42','2010-4-22 0:00:00','2010-5-20 0:00:00',1)
INSERT [wgi_adv] ([advid],[companyid],[advname],[advtype],[advcont],[advlink],[advuptime],[advstart],[advend],[advpaytype]) VALUES ( 27,1,'fdsaf',2,'http://www.baidu.com','http://www.baidu.com','2010-4-7 0:07:00','2010-4-7 0:00:00','2010-4-26 0:00:00',1)
INSERT [wgi_adv] ([advid],[companyid],[advname],[advtype],[advcont],[advlink],[advuptime],[advstatus],[advstart],[advend],[advpaytype]) VALUES ( 28,1,'dsfsaf',1,'sadfsaf','http://www.wingoi.com','2010-4-7 3:01:47',1,'2010-4-7 0:00:00','2010-5-20 0:00:00',1)
INSERT [wgi_adv] ([advid],[companyid],[advname],[advtype],[advcont],[advlink],[advuptime],[advstatus],[advstart],[advend],[advinvalid],[advpaytype]) VALUES ( 29,1,'dsafd',2,'http://www.baidu.com','http://www.baidu.com','2010-4-7 3:04:16',1,'2010-4-7 0:00:00','2010-5-10 0:00:00',1,1)
INSERT [wgi_adv] ([advid],[companyid],[advname],[advtype],[advcont],[advlink],[advuptime],[advstatus],[advstart],[advend],[advinvalid],[advpaytype]) VALUES ( 30,1,'dsafdsa',1,'adfdasf','http://www.wingoi.com','2010-4-7 20:28:42',1,'2010-4-7 0:00:00','2010-5-12 0:00:00',1,1)
INSERT [wgi_adv] ([advid],[companyid],[advname],[advtype],[advcont],[advlink],[advuptime],[advstatus],[advstart],[advend],[advinvalid],[advpaytype]) VALUES ( 31,1,'aaa',3,'http://www.baidu.com','http://www.wingoi.com','2010-4-13 13:49:39',1,'2010-4-13 0:00:00','2010-5-18 0:00:00',1,1)

SET IDENTITY_INSERT [wgi_adv] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[wgi_adv_site_host]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [wgi_adv_site_host]

CREATE TABLE [wgi_adv_site_host] (
[id] [int]  IDENTITY (1, 1)  NOT NULL,
[companyid] [int]  NULL,
[userid] [int]  NULL)

ALTER TABLE [wgi_adv_site_host] WITH NOCHECK ADD  CONSTRAINT [PK_wgi_adv_site_host] PRIMARY KEY  NONCLUSTERED ( [id] )
SET IDENTITY_INSERT [wgi_adv_site_host] ON


SET IDENTITY_INSERT [wgi_adv_site_host] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[wgi_cash]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [wgi_cash]

CREATE TABLE [wgi_cash] (
[id] [int]  IDENTITY (1, 1)  NOT NULL,
[userid] [int]  NULL,
[cash] [decimal]  (18,2) NULL,
[applydate] [datetime]  NULL,
[status] [int]  NULL,
[leftcash] [decimal]  (18,2) NULL,
[memo_user] [nvarchar]  (50) NULL,
[memo_admin] [nvarchar]  (50) NULL)

ALTER TABLE [wgi_cash] WITH NOCHECK ADD  CONSTRAINT [PK_wgi_cash] PRIMARY KEY  NONCLUSTERED ( [id] )
SET IDENTITY_INSERT [wgi_cash] ON


SET IDENTITY_INSERT [wgi_cash] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[wgi_contcate]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [wgi_contcate]

CREATE TABLE [wgi_contcate] (
[id] [int]  IDENTITY (1, 1)  NOT NULL,
[cname] [varchar]  (20) NULL)

ALTER TABLE [wgi_contcate] WITH NOCHECK ADD  CONSTRAINT [PK_wgi_contcate] PRIMARY KEY  NONCLUSTERED ( [id] )
SET IDENTITY_INSERT [wgi_contcate] ON


SET IDENTITY_INSERT [wgi_contcate] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[wgi_content]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [wgi_content]

CREATE TABLE [wgi_content] (
[id] [int]  NOT NULL,
[title] [varchar]  (100) NULL,
[content] [ntext]  NULL,
[author] [varchar]  (50) NULL,
[showindex] [int]  NULL,
[pubtime] [datetime]  NULL,
[isshow] [int]  NULL)

ALTER TABLE [wgi_content] WITH NOCHECK ADD  CONSTRAINT [PK_wgi_content] PRIMARY KEY  NONCLUSTERED ( [id] )
if exists (select * from sysobjects where id = OBJECT_ID('[wgi_discount]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [wgi_discount]

CREATE TABLE [wgi_discount] (
[id] [int]  IDENTITY (1, 1)  NOT NULL,
[companyid] [int]  NULL,
[payamt] [varchar]  (50) NULL,
[payintro] [nvarchar]  (200) NULL,
[endtime] [datetime]  NULL,
[addtime] [datetime]  NULL)

ALTER TABLE [wgi_discount] WITH NOCHECK ADD  CONSTRAINT [PK_wgi_discount] PRIMARY KEY  NONCLUSTERED ( [id] )
SET IDENTITY_INSERT [wgi_discount] ON

INSERT [wgi_discount] ([id],[companyid],[payamt],[payintro],[endtime],[addtime]) VALUES ( 1,1,'15%','数码家电类,不包括特价促销活动','2010-12-16 0:00:00','2010-4-7 23:58:04')
INSERT [wgi_discount] ([id],[companyid],[payamt],[payintro],[endtime],[addtime]) VALUES ( 2,1,'10元','有效注册一个用户','2010-11-11 0:00:00','2010-4-8 0:00:43')

SET IDENTITY_INSERT [wgi_discount] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[wgi_ind_type]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [wgi_ind_type]

CREATE TABLE [wgi_ind_type] (
[id] [int]  NOT NULL,
[pid] [int]  NULL,
[indname] [varchar]  (20) NULL)

ALTER TABLE [wgi_ind_type] WITH NOCHECK ADD  CONSTRAINT [PK_wgi_ind_type] PRIMARY KEY  NONCLUSTERED ( [id] )
if exists (select * from sysobjects where id = OBJECT_ID('[wgi_loginlog]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [wgi_loginlog]

CREATE TABLE [wgi_loginlog] (
[logid] [int] NOT NULL  IDENTITY (1, 1),
[usertype] [int]  NULL,
[logtime] [datetime]  NULL,
[logip] [varchar]  (60) NULL,
[logname] [varchar]  (50) NULL)

ALTER TABLE [wgi_loginlog] WITH NOCHECK ADD  CONSTRAINT [PK_wgi_loginlog] PRIMARY KEY  NONCLUSTERED ( [logid] )
if exists (select * from sysobjects where id = OBJECT_ID('[wgi_lostorder]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [wgi_lostorder]

CREATE TABLE [wgi_lostorder] (
[id] [int]  IDENTITY (1, 1)  NOT NULL,
[companyid] [int]  NULL,
[userid] [int]  NULL,
[orderno] [varchar]  (100) NULL,
[adhostname] [varchar]  (100) NULL,
[buytime] [datetime]  NULL,
[itemno] [varchar]  (200) NULL,
[consumer] [varchar]  (50) NULL,
[applyreason] [text]  NULL,
[applytime] [datetime]  NULL,
[lostreason] [nvarchar]  (100) NULL,
[result] [nvarchar]  (100) NULL,
[status] [int]  NULL)

ALTER TABLE [wgi_lostorder] WITH NOCHECK ADD  CONSTRAINT [PK_wgi_lostorder] PRIMARY KEY  NONCLUSTERED ( [id] )
SET IDENTITY_INSERT [wgi_lostorder] ON


SET IDENTITY_INSERT [wgi_lostorder] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[wgi_order]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [wgi_order]

CREATE TABLE [wgi_order] (
[orderid] [int]  IDENTITY (1, 1)  NOT NULL,
[companyid] [int]  NULL,
[username] [varchar]  (50) NULL,
[orderno] [varchar]  (50) NULL,
[orderamt] [decimal]  (18,2) NULL,
[ordertime] [datetime]  NULL,
[consumer] [varchar]  (50) NULL,
[itemno] [varchar]  (200) NULL,
[payamt] [decimal]  (18,2) NULL,
[ischeck] [int]  NULL DEFAULT ((0)),
[ispay] [int]  NULL,
[reason] [varchar]  (200) NULL,
[paytime] [datetime]  NULL)

ALTER TABLE [wgi_order] WITH NOCHECK ADD  CONSTRAINT [PK_wgi_order] PRIMARY KEY  NONCLUSTERED ( [orderid] )
SET IDENTITY_INSERT [wgi_order] ON

INSERT [wgi_order] ([orderid],[companyid],[username],[orderno],[orderamt],[ordertime],[ischeck],[reason]) VALUES ( 1,1,'liusylon','A20100304110',450.00,'2010-4-8 12:23:34',1,'是广告主自己在用的')

SET IDENTITY_INSERT [wgi_order] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[wgi_sitecate]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [wgi_sitecate]

CREATE TABLE [wgi_sitecate] (
[cateid] [int]  IDENTITY (1, 1)  NOT NULL,
[pid] [int]  NULL,
[catename] [varchar]  (50) NULL,
[level] [int]  NULL,
[showindex] [int]  NULL DEFAULT ((1)))

ALTER TABLE [wgi_sitecate] WITH NOCHECK ADD  CONSTRAINT [PK_wgi_sitecate] PRIMARY KEY  NONCLUSTERED ( [cateid] )
SET IDENTITY_INSERT [wgi_sitecate] ON

INSERT [wgi_sitecate] ([cateid],[pid],[catename],[level],[showindex]) VALUES ( 1,0,'娱乐/休闲',0,1)

SET IDENTITY_INSERT [wgi_sitecate] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[wgi_sitehost]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [wgi_sitehost]

CREATE TABLE [wgi_sitehost] (
[userid] [int]  IDENTITY (1, 1)  NOT NULL,
[username] [varchar]  (50) NULL,
[password] [varchar]  (50) NULL,
[email] [varchar]  (150) NULL,
[mobile] [varchar]  (50) NULL,
[accountname] [varchar]  (50) NULL,
[accountno] [varchar]  (50) NULL,
[bank] [varchar]  (50) NULL,
[branch] [varchar]  (50) NULL,
[usertype] [int]  NULL,
[contact] [varchar]  (50) NULL,
[qq] [varchar]  (50) NULL,
[idcard] [varchar]  (50) NULL,
[address] [nvarchar]  (150) NULL,
[zipcode] [varchar]  (20) NULL,
[tel] [varchar]  (30) NULL,
[balance] [decimal]  (18,2) NULL,
[regdate] [datetime]  NULL,
[regip] [varchar]  (60) NULL,
[lastdate] [datetime]  NULL,
[lastip] [varchar]  (60) NULL,
[status] [int]  NULL)

ALTER TABLE [wgi_sitehost] WITH NOCHECK ADD  CONSTRAINT [PK_wgi_sitehost] PRIMARY KEY  NONCLUSTERED ( [userid] )
SET IDENTITY_INSERT [wgi_sitehost] ON

INSERT [wgi_sitehost] ([userid],[username],[password],[email],[mobile],[accountname],[accountno],[bank],[branch],[usertype],[contact],[qq],[idcard],[address],[zipcode],[tel],[balance],[regdate],[lastdate],[status]) VALUES ( 1,'liusylon','123','1','1','1','1','1','1',1,'1','1','1','1','1','1',1.00,'2010-4-13 12:50:20','2010-4-13 13:02:47',1)

SET IDENTITY_INSERT [wgi_sitehost] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[wgi_sysuser]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [wgi_sysuser]

CREATE TABLE [wgi_sysuser] (
[id] [int]  IDENTITY (1, 1)  NOT NULL,
[username] [varchar]  (50) NULL,
[password] [varchar]  (50) NULL,
[email] [varchar]  (150) NULL)

ALTER TABLE [wgi_sysuser] WITH NOCHECK ADD  CONSTRAINT [PK_wgi_sysuser] PRIMARY KEY  NONCLUSTERED ( [id] )
SET IDENTITY_INSERT [wgi_sysuser] ON


SET IDENTITY_INSERT [wgi_sysuser] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[wgi_usersite]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [wgi_usersite]

CREATE TABLE [wgi_usersite] (
[siteid] [int]  IDENTITY (1, 1)  NOT NULL,
[userid] [int]  NULL,
[sitename] [varchar]  (50) NULL,
[url] [varchar]  (100) NULL,
[siteremark] [nvarchar]  (200) NULL,
[ipno] [int]  NULL,
[pvno] [int]  NULL,
[sitetype] [int]  NULL)

ALTER TABLE [wgi_usersite] WITH NOCHECK ADD  CONSTRAINT [PK_wgi_usersite] PRIMARY KEY  NONCLUSTERED ( [siteid] )
SET IDENTITY_INSERT [wgi_usersite] ON

INSERT [wgi_usersite] ([siteid],[userid],[sitename],[url],[ipno],[pvno],[sitetype]) VALUES ( 2,1,'Pie友活动网','http://www.pieyoo.cn',21,12,1)

SET IDENTITY_INSERT [wgi_usersite] OFF


CREATE VIEW [dbo].[view_statis]
AS
SELECT     dbo.wgi_usersite.sitename, dbo.wgi_usersite.url, dbo.wgi_adv_statis.companyid, dbo.wgi_adv_statis.userid, dbo.wgi_adv_statis.siteid, dbo.wgi_adv_statis.advid, 
                      dbo.wgi_adv_statis.advtype, dbo.wgi_adv_statis.statistype, dbo.wgi_adv_statis.recordtime, dbo.wgi_adv_statis.ip, CONVERT(varchar(12), 
                      dbo.wgi_adv_statis.recordtime, 112) AS recordday, dbo.wgi_adhost.sitename AS advsitename, dbo.wgi_adhost.url AS advsiteurl
FROM         dbo.wgi_adv_statis INNER JOIN
                      dbo.wgi_usersite ON dbo.wgi_adv_statis.siteid = dbo.wgi_usersite.siteid INNER JOIN
                      dbo.wgi_adhost ON dbo.wgi_adv_statis.companyid = dbo.wgi_adhost.companyid

GO
