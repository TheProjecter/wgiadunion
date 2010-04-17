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
using LTP.Common;

public partial class member_bank : System.Web.UI.Page
{
    private int userid;

    protected void Page_Load(object sender, EventArgs e)
    {
        validateMember userobj = MasterPageOpration.getMasterControl(this.Page.Master, "Muser");
        if (userobj.suser.userid != 0)
        {
            userid = userobj.suser.userid;
            if (!IsPostBack) ShowInfo(userid);
        }
        else
        {
            if (IsPostBack)
                ScriptManager.RegisterClientScriptBlock(this, GetType(), DateTime.Now.ToString(), "alert('您已登出系统，请重新登录');", true);
            Response.Redirect("/member/Default.aspx?url=" + Request.CurrentExecutionFilePath);
        }
    }

    private void ShowInfo(int userid)
    {
        wgiAdUnionSystem.BLL.wgi_sitehost bll = new wgiAdUnionSystem.BLL.wgi_sitehost();
        wgiAdUnionSystem.Model.wgi_sitehost model = bll.GetModel(userid);
        this.txtaccountname.Text = model.accountname;
        this.txtaccountno.Text = model.accountno;
        this.txtbank.Text = model.bank;
        this.txtbranch.Text = model.branch;

    }

    public void btnUpdate_Click(object sender, EventArgs e)
    {

        string strErr = "";
        if (this.txtaccountname.Text == "")
        {
            strErr += "accountname不能为空！\\n";
        }
        if (this.txtaccountno.Text == "")
        {
            strErr += "accountno不能为空！\\n";
        }
        if (this.txtbank.Text == "")
        {
            strErr += "bank不能为空！\\n";
        }
        if (this.txtbranch.Text == "")
        {
            strErr += "branch不能为空！\\n";
        }

        if (strErr != "")
        {
            MessageBox.Show(this, strErr);
            return;
        }

        string accountname = this.txtaccountname.Text;
        string accountno = this.txtaccountno.Text;
        string bank = this.txtbank.Text;
        string branch = this.txtbranch.Text;

        wgiAdUnionSystem.BLL.wgi_sitehost bll = new wgiAdUnionSystem.BLL.wgi_sitehost();

        wgiAdUnionSystem.Model.wgi_sitehost model = bll.GetModel(userid);
        model.accountname = accountname;
        model.accountno = accountno;
        model.bank = bank;
        model.branch = branch;

        ScriptManager.RegisterClientScriptBlock(this, GetType(), DateTime.Now.ToString(), "alert('资料修改成功');", true);
        bll.Update(model);

    }
}
