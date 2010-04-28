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

public partial class admin_addSiteUser : ValidatePage
{
    private string uid="";

    protected void Page_Load(object sender, EventArgs e)
    {
        Control title = Page.LoadControl("pageControl/title.ascx");
        title.ID = "uc_title";
        this.holderheader.Controls.Add(title);
        if (!IsPostBack)
        {
            string act = Request.QueryString["act"];
            switch (act)
            { 
                case "add":
                    break;
                case "edit":
                    uid = Request.QueryString["uid"];
                    if (uid == "")
                    {
                        Response.Redirect("login.aspx");
                    }
                    break;
                default:
                    break;

            }
        }
    }

    protected void dosubmit(object sender, CommandEventArgs e)
    { 
        
    }

}
