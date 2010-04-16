/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2005                    */
/* Created on:     2010-4-5 04:21:39                            */
/*==============================================================*/


alter table wgi_adhost
   drop constraint FK_WGI_ADHO_REFERENCE_WGI_IND_
go

alter table wgi_adhost_usersite
   drop constraint FK_WGI_ADHO_REFERENCE_WGI_ADHO
go

alter table wgi_adhost_usersite
   drop constraint FK_WGI_ADHO_REFERENCE_WGI_MYSI
go

alter table wgi_adv
   drop constraint FK_WGI_ADV_REFERENCE_WGI_ADHO
go

alter table wgi_adv_site_host
   drop constraint FK_WGI_ADV__REFERENCE_WGI_ADHO
go

alter table wgi_adv_site_host
   drop constraint FK_WGI_ADV__REFERENCE_WGI_SITE
go

alter table wgi_cash
   drop constraint FK_WGI_CASH_REFERENCE_WGI_SITE
go

alter table wgi_content
   drop constraint FK_WGI_CONT_REFERENCE_WGI_CONT
go

alter table wgi_discount
   drop constraint FK_WGI_DISC_REFERENCE_WGI_ADHO
go

alter table wgi_lostorder
   drop constraint FK_WGI_LOST_REFERENCE_WGI_SITE
go

alter table wgi_lostorder
   drop constraint FK_WGI_LOST_REFERENCE_WGI_ADHO
go

alter table wgi_mysite
   drop constraint FK_WGI_MYSI_REFERENCE_WGI_SITE
go

alter table wgi_order
   drop constraint FK_WGI_ORDE_REFERENCE_WGI_ADHO
go

alter table wgi_order
   drop constraint FK_WGI_ORDE_REFERENCE_WGI_SITE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('wgi_adhost')
            and   type = 'U')
   drop table wgi_adhost
go

if exists (select 1
            from  sysobjects
           where  id = object_id('wgi_adhost_usersite')
            and   type = 'U')
   drop table wgi_adhost_usersite
go

if exists (select 1
            from  sysobjects
           where  id = object_id('wgi_adv')
            and   type = 'U')
   drop table wgi_adv
go

if exists (select 1
            from  sysobjects
           where  id = object_id('wgi_adv_site_host')
            and   type = 'U')
   drop table wgi_adv_site_host
go

if exists (select 1
            from  sysobjects
           where  id = object_id('wgi_cash')
            and   type = 'U')
   drop table wgi_cash
go

if exists (select 1
            from  sysobjects
           where  id = object_id('wgi_contcate')
            and   type = 'U')
   drop table wgi_contcate
go

if exists (select 1
            from  sysobjects
           where  id = object_id('wgi_content')
            and   type = 'U')
   drop table wgi_content
go

if exists (select 1
            from  sysobjects
           where  id = object_id('wgi_discount')
            and   type = 'U')
   drop table wgi_discount
go

if exists (select 1
            from  sysobjects
           where  id = object_id('wgi_ind_type')
            and   type = 'U')
   drop table wgi_ind_type
go

if exists (select 1
            from  sysobjects
           where  id = object_id('wgi_loginlog')
            and   type = 'U')
   drop table wgi_loginlog
go

if exists (select 1
            from  sysobjects
           where  id = object_id('wgi_lostorder')
            and   type = 'U')
   drop table wgi_lostorder
go

if exists (select 1
            from  sysobjects
           where  id = object_id('wgi_mysite')
            and   type = 'U')
   drop table wgi_mysite
go

if exists (select 1
            from  sysobjects
           where  id = object_id('wgi_order')
            and   type = 'U')
   drop table wgi_order
go

if exists (select 1
            from  sysobjects
           where  id = object_id('wgi_sitehost')
            and   type = 'U')
   drop table wgi_sitehost
go

if exists (select 1
            from  sysobjects
           where  id = object_id('wgi_sysuser')
            and   type = 'U')
   drop table wgi_sysuser
go

/*==============================================================*/
/* Table: wgi_adhost                                            */
/*==============================================================*/
create table wgi_adhost (
   companyid            int                  identity,
   id                   int                  null,
   status               int                  null,
   username             varchar(50)          null,
   password             varchar(50)          null,
   email                varchar(150)         null,
   company              nvarchar(100)        null,
   contact              varchar(50)          null,
   tel                  varchar(100)         null,
   qq                   varchar(20)          null,
   mobile               varchar(50)          null,
   fax                  varchar(100)         null,
   address              nvarchar(200)        null,
   zipcode              varchar(20)          null,
   url                  varchar(200)         null,
   intro                text                 null,
   user_type            int                  null,
   owner                varchar(50)          null,
   licence              varchar(150)         null,
   icp                  varchar(150)         null,
   sitename             varchar(100)         null,
   remark               text                 null,
   return_day           varchar(100)         null,
   return_type          varchar(100)         null,
   valid_day            varchar(50)          null,
   regdate              datetime             null,
   regip                varchar(100)         null,
   lastdate             datetime             null,
   lastip               varchar(100)         null,
   balance              decimal(18,2)        null,
   ischeck              int                  null default 0,
   constraint PK_WGI_ADHOST primary key (companyid)
)
go

declare @Cmtwgi_adhost varchar(128)
select @Cmtwgi_adhost = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '广告主用户表',
   'user', @Cmtwgi_adhost, 'table', 'wgi_adhost'
go

/*==============================================================*/
/* Table: wgi_adhost_usersite                                   */
/*==============================================================*/
create table wgi_adhost_usersite (
   id                   int                  identity,
   companyid            int                  null,
   siteid               int                  null,
   audit                int                  null,
   constraint PK_WGI_ADHOST_USERSITE primary key (id)
)
go

/*==============================================================*/
/* Table: wgi_adv                                               */
/*==============================================================*/
create table wgi_adv (
   advid                int                  identity,
   companyid            int                  null,
   advname              varchar(100)         null,
   advtype              int                  null,
   advcont              text                 null,
   advlink              varchar(200)         null,
   advwidth             int                  null,
   advheight            int                  null,
   advuptime            datetime             null,
   advstatus            int                  null default 1,
   advstart             datetime             null,
   advend               datetime             null,
   advinvalid           int                  null,
   advpaytype           int                  null default 1,
   constraint PK_WGI_ADV primary key (advid)
)
go

/*==============================================================*/
/* Table: wgi_adv_site_host                                     */
/*==============================================================*/
create table wgi_adv_site_host (
   id                   int                  identity,
   companyid            int                  null,
   userid               int                  null,
   constraint PK_WGI_ADV_SITE_HOST primary key (id)
)
go

/*==============================================================*/
/* Table: wgi_cash                                              */
/*==============================================================*/
create table wgi_cash (
   id                   int                  identity,
   userid               int                  null,
   cash                 decimal(18,2)        null,
   applydate            datetime             null,
   status               int                  null,
   leftcash             decimal(18,2)        null,
   memo_user            nvarchar(50)         null,
   memo_admin           nvarchar(50)         null,
   constraint PK_WGI_CASH primary key (id)
)
go

/*==============================================================*/
/* Table: wgi_contcate                                          */
/*==============================================================*/
create table wgi_contcate (
   id                   int                  identity,
   cname                varchar(20)          null,
   constraint PK_WGI_CONTCATE primary key (id)
)
go

/*==============================================================*/
/* Table: wgi_content                                           */
/*==============================================================*/
create table wgi_content (
   id                   int                  not null,
   title                varchar(100)         null,
   content              ntext                null,
   author               varchar(50)          null,
   showindex            int                  null,
   pubtime              datetime             null,
   isshow               int                  null,
   constraint PK_WGI_CONTENT primary key (id)
)
go

/*==============================================================*/
/* Table: wgi_discount                                          */
/*==============================================================*/
create table wgi_discount (
   id                   int                  identity,
   companyid            int                  null,
   titile               varchar(50)          null,
   content              nvarchar(200)        null,
   endtime              datetime             null,
   constraint PK_WGI_DISCOUNT primary key (id)
)
go

/*==============================================================*/
/* Table: wgi_ind_type                                          */
/*==============================================================*/
create table wgi_ind_type (
   id                   int                  not null,
   pid                  int                  null,
   indname              varchar(20)          null,
   constraint PK_WGI_IND_TYPE primary key (id)
)
go

/*==============================================================*/
/* Table: wgi_loginlog                                          */
/*==============================================================*/
create table wgi_loginlog (
   logid                int                  not null,
   usertype             int                  null,
   logtime              datetime             null,
   logip                varchar(60)          null,
   logname              varchar(50)          null,
   constraint PK_WGI_LOGINLOG primary key (logid)
)
go

/*==============================================================*/
/* Table: wgi_lostorder                                         */
/*==============================================================*/
create table wgi_lostorder (
   id                   int                  identity,
   companyid            int                  null,
   userid               int                  null,
   orderno              varchar(100)         null,
   adhostname           varchar(100)         null,
   buytime              datetime             null,
   itemno               varchar(200)         null,
   consumer             varchar(50)           null,
   applyreason          text                 null,
   applytime            datetime             null,
   lostreason           nvarchar(100)        null,
   result               nvarchar(100)        null,
   status               int                  null,
   constraint PK_WGI_LOSTORDER primary key (id)
)
go

/*==============================================================*/
/* Table: wgi_mysite                                            */
/*==============================================================*/
create table wgi_mysite (
   userid               int                  null,
   siteid               int                  identity,
   sitename             varchar(50)          null,
   url                  varchar(100)         null,
   siteremark           nvarchar(200)        null,
   ipno                 int                  null,
   pvno                 int                  null,
   sitetype             int                  null,
   constraint PK_WGI_MYSITE primary key (siteid)
)
go

/*==============================================================*/
/* Table: wgi_order                                             */
/*==============================================================*/
create table wgi_order (
   orderid              int                  identity,
   companyid            int                  null,
   userid               int                  null,
   orderno              varchar(50)          null,
   cash                 decimal(18,2)        null,
   time                 datetime             null,
   consumer             varchar(50)          null,
   itemno               varchar(200)         null,
   pay                  decimal(18,2)        null,
   ischeck              int                  null default 0,
   reason               varchar(200)         null,
   checktime            datetime             null,
   constraint PK_WGI_ORDER primary key (orderid)
)
go

/*==============================================================*/
/* Table: wgi_sitehost                                          */
/*==============================================================*/
create table wgi_sitehost (
   userid               int                  identity,
   username             varchar(50)          null,
   password             varchar(50)          null,
   email                varchar(150)         null,
   mobile               varchar(50)          null,
   accountname          varchar(50)          null,
   accountno            varchar(50)          null,
   bank                 varchar(50)          null,
   branch               varchar(50)          null,
   usertype             int                  null,
   contact              varchar(50)          null,
   qq                   varchar(50)          null,
   idcard               varchar(50)          null,
   address              nvarchar(150)        null,
   zipcode              varchar(20)          null,
   tel                  varchar(30)          null,
   balance              decimal(18,2)        null,
   regdate              datetime             null,
   regip                varchar(60)          null,
   lastdate             datetime             null,
   lastip               varchar(60)          null,
   status               int                  null,
   constraint PK_WGI_SITEHOST primary key (userid)
)
go

declare @Cmtwgi_sitehost varchar(128)
select @Cmtwgi_sitehost = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '网站主用户表',
   'user', @Cmtwgi_sitehost, 'table', 'wgi_sitehost'
go

/*==============================================================*/
/* Table: wgi_sysuser                                           */
/*==============================================================*/
create table wgi_sysuser (
   id                   int                  identity,
   username             varchar(50)          null,
   password             varchar(50)          null,
   email                varchar(150)         null,
   constraint PK_WGI_SYSUSER primary key (id)
)
go

alter table wgi_adhost
   add constraint FK_WGI_ADHO_REFERENCE_WGI_IND_ foreign key (id)
      references wgi_ind_type (id)
go

alter table wgi_adhost_usersite
   add constraint FK_WGI_ADHO_REFERENCE_WGI_ADHO foreign key (companyid)
      references wgi_adhost (companyid)
go

alter table wgi_adhost_usersite
   add constraint FK_WGI_ADHO_REFERENCE_WGI_MYSI foreign key (siteid)
      references wgi_mysite (siteid)
go

alter table wgi_adv
   add constraint FK_WGI_ADV_REFERENCE_WGI_ADHO foreign key (companyid)
      references wgi_adhost (companyid)
go

alter table wgi_adv_site_host
   add constraint FK_WGI_ADV__REFERENCE_WGI_ADHO foreign key (companyid)
      references wgi_adhost (companyid)
go

alter table wgi_adv_site_host
   add constraint FK_WGI_ADV__REFERENCE_WGI_SITE foreign key (userid)
      references wgi_sitehost (userid)
go

alter table wgi_cash
   add constraint FK_WGI_CASH_REFERENCE_WGI_SITE foreign key (userid)
      references wgi_sitehost (userid)
go

alter table wgi_content
   add constraint FK_WGI_CONT_REFERENCE_WGI_CONT foreign key (id)
      references wgi_contcate (id)
go

alter table wgi_discount
   add constraint FK_WGI_DISC_REFERENCE_WGI_ADHO foreign key (companyid)
      references wgi_adhost (companyid)
go

alter table wgi_lostorder
   add constraint FK_WGI_LOST_REFERENCE_WGI_SITE foreign key (userid)
      references wgi_sitehost (userid)
go

alter table wgi_lostorder
   add constraint FK_WGI_LOST_REFERENCE_WGI_ADHO foreign key (companyid)
      references wgi_adhost (companyid)
go

alter table wgi_mysite
   add constraint FK_WGI_MYSI_REFERENCE_WGI_SITE foreign key (userid)
      references wgi_sitehost (userid)
go

alter table wgi_order
   add constraint FK_WGI_ORDE_REFERENCE_WGI_ADHO foreign key (companyid)
      references wgi_adhost (companyid)
go

alter table wgi_order
   add constraint FK_WGI_ORDE_REFERENCE_WGI_SITE foreign key (userid)
      references wgi_sitehost (userid)
go

