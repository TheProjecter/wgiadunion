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

public partial class Controls_report : System.Web.UI.UserControl
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

        wgiAdUnionSystem.BLL.wgi_usersite bll = new wgiAdUnionSystem.BLL.wgi_usersite();
        Helper.HelperDropDownList.BindData(ddlsite, bll.getListByUserId(userobj.suser.userid).Tables[0], "sitename", "siteid", 0);
        ddlsite.Items.Insert(0, new ListItem("请选择...", "-1"));
        ddlsite.SelectedIndex = 0;
        txtstart.Text = DateTime.Today.Date.ToString("yyyy-MM") + "-01";
        txtend.Text = DateTime.Today.Date.ToString("yyyy-MM-dd");
    }
}
