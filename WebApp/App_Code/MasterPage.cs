﻿using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
///MasterPage 的摘要说明
/// </summary>
public class MasterPageOpration
{
    public MasterPageOpration()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    public static validateMember getMasterControl(MasterPage thispage, string controlID)
    {
        return thispage.FindControl(controlID) as validateMember;
    }

}
