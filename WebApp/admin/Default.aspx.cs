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

public partial class admin_Default : System.Web.UI.Page
{
    protected string uc_ID="contPage";

    protected void Page_Load(object sender, EventArgs e)
    {
        admin_pages_dashboard dashboard = (admin_pages_dashboard)this.LoadControl("pageControl/dashboard.ascx");
        dashboard.ID = uc_ID;
        this.holder.Controls.Add(dashboard);
    }
}
