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
using wgiAdUnionSystem.BLL;

public partial class admin_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Control title = Page.LoadControl("pageControl/title.ascx");
        title.ID = "uc_title";
        (title.FindControl("ltrTitle") as Literal).Text = "广告联盟|后台管理|登录";
        this.holderheader.Controls.Add(title);

        Control ft = Page.LoadControl("pageControl/footer.ascx");
        ft.ID = "uc_footer";
        this.holderfoot.Controls.Add(ft);

    }

    protected void btn_login(object sender, EventArgs e)
    {
        string sessioncode = "";
        try
        {
            if (Session["CheckCode"] != null && Session["CheckCode"].ToString() == "") return;
            else sessioncode = Session["CheckCode"].ToString();
        }
        catch (Exception)
        {
            this.Page.Response.Redirect("login.aspx");
        }

        if (sessioncode.ToLower().Equals(txtCode.Text.ToLower()))
        {
            UserPrincipal principal = new UserPrincipal(txtUser.Text, txtPass.Text);

            if (!principal.Identity.IsAuthenticated)
            {
                lblLoginMessage.Visible = true;
                switch (principal.CheckStatus)
                {
                    case 1:
                        lblLoginMessage.Text = "用户名不正确！";
                        break;
                    case 2:
                        lblLoginMessage.Text = "用户名密码错误！";
                        break;
                    case 3:
                        lblLoginMessage.Text = "您的账户已被锁定！";
                        break;
                }
            }

            else
            {

                //如果用户通过验证,则将用户信息保存在缓存中,以备后用
                //在实际中,朋友们可以尝试使用用户验证票的方式来保存用户信息,这也是.NET内置的用户处理机制

                Context.User = principal;
                string userdata = "";

                wgiAdUnionSystem.BLL.wgi_sysuser bll = new wgiAdUnionSystem.BLL.wgi_sysuser();
                DataTable dt = bll.GetListByUsername(principal.Identity.Name).Tables[0];

                if (dt != null && dt.Rows.Count > 0)
                {
                    userdata = "admin|" + dt.Rows[0]["id"].ToString() + "|" + dt.Rows[0]["username"].ToString() + "|" + dt.Rows[0]["email"].ToString();
                }

                string uid = dt.Rows[0]["id"].ToString();
                string uname = dt.Rows[0]["username"].ToString();

                try
                {
                    wgiAdUnionSystem.Model.wgi_loginlog logs = new wgiAdUnionSystem.Model.wgi_loginlog();
                    //logs.logid = int.Parse(uid);
                    logs.logip = CommonData.GetIp(this.Page);
                    logs.logname = uname;
                    logs.logtime = DateTime.Now;
                    logs.usertype = 0;//0表示系统管理员

                    new wgiAdUnionSystem.BLL.wgi_loginlog().Add(logs);

                }
                catch (Exception ex)
                {
                    Response.Write(Helper.HelperString.getAlertJumpString("内部错误", "login.aspx"));
                }

                FlowControl.SaveLoginInfo(principal.Identity.Name, userdata);
                //Response.Redirect("/member/Default.aspx");

                if (!string.IsNullOrEmpty(Request.QueryString["url"])) Response.Redirect(Request["url"]);
                else Response.Redirect("default.aspx");

            }
        }
        else
        {
            lblLoginMessage.Visible = true;
            lblLoginMessage.Text = "验证码错误！";
        }
    }
}
