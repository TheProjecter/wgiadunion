using System;
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

public partial class admin_Default : ValidatePage
{

    protected void Page_Load(object sender, EventArgs e)
    {
        uLoadControl.initPage(Page, 1, "Dashboard - Admin", plhdTitle, plhdHeader, plhdSlide, plhdFooter);
        if (!IsPostBack)
        {
            (this.FindControl("u_header").FindControl("lblusername") as Label).Text = base.user.username;
        }
    }


}
