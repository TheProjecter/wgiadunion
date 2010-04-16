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

public partial class ajaxHandler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        switch (Request["act"]) { 
            case "checkpwd":
                checkpwd();
                break;
            default:
                break;
        }
    }

    private void checkpwd() {
        Response.ContentType = "txt/html";
        Response.Clear();
        wgiAdUnionSystem.BLL.wgi_sitehost bll = new wgiAdUnionSystem.BLL.wgi_sitehost();
        int userid = Convert.ToInt32(Request["userid"]);
        string pwd= Request["pwd"];
        string orignal = bll.GetModel(userid).password;
        if (orignal == pwd) Response.Write("1");
        else Response.Write("0");
        Response.End();
    }
}
