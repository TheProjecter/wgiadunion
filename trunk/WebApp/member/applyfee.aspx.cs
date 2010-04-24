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
    private int userid;

    protected void Page_Load(object sender, EventArgs e)
    {
        validateMember userobj = MasterPageOpration.getMasterControl(this.Page.Master, "Muser");
        if (userobj.suser.userid != 0)
        {
            userid = userobj.suser.userid;
            if (!IsPostBack) initData();
        }
        else
        {
            if (IsPostBack)
                ScriptManager.RegisterClientScriptBlock(this, GetType(), DateTime.Now.ToString(), "alert('您已登出系统，请重新登录');location.href='/member/Default.aspx?url='" + Request.CurrentExecutionFilePath + ";", true);
        }
    }

    private void initData()
    {
        validateMember userobj = MasterPageOpration.getMasterControl(this.Page.Master, "Muser");

        wgiAdUnionSystem.BLL.wgi_cash bll_cash = new wgiAdUnionSystem.BLL.wgi_cash();
        wgiAdUnionSystem.Model.wgi_cash model_cash = bll_cash.GetModel(userid);

        this.lblmoney.Text = userobj.suser.balance.ToString();
        if (Convert.ToInt32(userobj.suser.balance) < 100) lblapply.Visible = true;
        else
        {

            if (model_cash == null) btnapply.Visible = true;
            else
            {
                int status = (int)model_cash.status;
                lblapply.Text = "<b>您的申请状态：</b>"+ CommonData.getApplyStatusByValue(status.ToString());
                lblapply.Visible = true;
            }
        }
    }

    protected void applyclick(object sender, EventArgs e)
    {
        wgiAdUnionSystem.Model.wgi_cash model = new wgiAdUnionSystem.Model.wgi_cash();
        model.status = 1;
        model.userid = userid;

        new wgiAdUnionSystem.BLL.wgi_cash().Add(model);
        Response.Redirect("applyfee.aspx");
    }

}
