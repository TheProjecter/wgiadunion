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

public partial class member_changepwd : System.Web.UI.Page
{
    private int userid;

    protected void Page_Load(object sender, EventArgs e)
    {
        validateMember userobj = MasterPageOpration.getMasterControl(this.Page.Master, "Muser");
        if (userobj.suser.userid != 0) userid = userobj.suser.userid;
        else Response.Redirect("/member/Default.aspx?url=" + Request.CurrentExecutionFilePath);
    }

    protected void submit_click(object sender, EventArgs e)
    {
        wgiAdUnionSystem.BLL.wgi_sitehost bll = new wgiAdUnionSystem.BLL.wgi_sitehost();
        string oldpwd = this.txtold.Text;
        string newpwd = this.txtnew.Text;
        if (oldpwd != newpwd)
        {
            try
            {
                bll.updatePwd(userid, newpwd);
                FlowControl.Logout();
                ScriptManager.RegisterClientScriptBlock(this, GetType(), DateTime.Now.ToString(), "alert('密码修改成功，请重新登录');location.href='/member/';", true);
            }
            catch (Exception)
            {
                Response.Write("操作失败，<a href=\"#\" onclick=\"history.go(-1);\">点此返回</a>");
                Response.End();
            }
        }
    }
}
