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

public partial class member_applyfee : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            initData();
        }
    }

    private void initData()
    {
        validateMember userobj = MasterPageOpration.getMasterControl(this.Page.Master, "Muser");

        this.lblmoney.Text = userobj.suser.balance.ToString();
        if (Convert.ToInt32(userobj.suser.balance) < 100) lblapply.Visible = true;
        else btnapply.Visible = true;
    }

    protected void applyclick(object sender, EventArgs e)
    {
        Response.Redirect("applyinfo.aspx");
    }

}
