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

public partial class admin_pageControl_header : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.lblusername.Text = Context.User.Identity.Name;
        
    }

    protected void logout_click(object sender, EventArgs e)
    {
        FlowControl.Logout();
        this.Page.Response.Redirect("login.aspx");
    }
}
