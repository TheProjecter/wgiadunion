﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class admin_pageControl_title : System.Web.UI.UserControl
{
    private string _title;
    public string title
    {
        get { return _title; }
        set { _title = value; }
    }


    protected void Page_Load(object sender, EventArgs e)
    {

    }
}