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

public partial class Controls_login_index : validateMember
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            initData();
        }
    }

    protected void initData()
    {
        this.pnlnotlogin.Visible = false;
        this.pnllogin.Visible = false;
        if (base.Context.User.Identity.IsAuthenticated || base.suser.userid != 0)
        {
            this.lblbank.Text = base.suser.balance.ToString() + "元";
            this.lblname.Text = base.suser.accountname;
            this.lbllast.Text = base.suser.lastdate.ToString();
            this.lbluname.Text = base.suser.username;
            this.pnllogin.Visible = true;
        }
        else
        {
            this.pnlnotlogin.Visible = true;
        }
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
            this.Page.Response.Redirect("/member/Default.aspx");
        }

        if (sessioncode.ToLower().Equals(txtCode.Text.ToLower()))
        {
            UserPrincipal principal = new UserPrincipal(txtUser.Text, txtPass.Text, 2);

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
                        lblLoginMessage.Text = "您的账户尚未被审核通过！";
                        break;
                    case 4:
                        lblLoginMessage.Text = "您的账户已被锁定！";
                        break;
                    default:
                        lblLoginMessage.Text = "未知错误！";
                        break;
                }
            }

            else
            {

                //如果用户通过验证,则将用户信息保存在缓存中,以备后用
                //在实际中,朋友们可以尝试使用用户验证票的方式来保存用户信息,这也是.NET内置的用户处理机制

                Context.User = principal;
                string userdata = "";

                wgiAdUnionSystem.BLL.wgi_sitehost bll = new wgiAdUnionSystem.BLL.wgi_sitehost();
                DataTable dt = bll.GetListByUsername(principal.Identity.Name).Tables[0];

                if (dt != null && dt.Rows.Count > 0)
                {
                    userdata = "member|" + dt.Rows[0]["userid"].ToString() + "|" + dt.Rows[0]["username"].ToString() + "|" + Convert.ToDateTime(dt.Rows[0]["lastdate"]).ToString("yyyy-MM-dd HH:mm:ss") + "|" + dt.Rows[0]["contact"].ToString() + "|" + dt.Rows[0]["balance"].ToString();
                }

                string uid = dt.Rows[0]["userid"].ToString();
                string uname = dt.Rows[0]["username"].ToString();

                try
                {
                    bll.updateLoginTime(int.Parse(uid), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")); //记录学员登录时间 

                    wgiAdUnionSystem.Model.wgi_loginlog logs = new wgiAdUnionSystem.Model.wgi_loginlog();
                    //logs.logid = int.Parse(uid);
                    logs.logip = CommonData.GetIp(this.Page);
                    logs.logname = uname;
                    logs.logtime = DateTime.Now;
                    logs.usertype = 1;//1表示网站主

                    new wgiAdUnionSystem.BLL.wgi_loginlog().Add(logs);

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('内部错误！');location.href='/index.aspx'</script>");
                }
                //Session["sid"] = uid;
                //Session["utype"] = "member";

                FlowControl.SaveLoginInfo(principal.Identity.Name, userdata);
                //Response.Redirect("/member/Default.aspx");
                //setpanel();
                initData();
                string[] userdatas = userdata.Split('|');
                this.lblbank.Text = userdatas[5] + "元";
                this.lbllast.Text = userdatas[3];
                this.lblname.Text = userdatas[4];
                this.lbluname.Text = userdatas[2];
                if (!string.IsNullOrEmpty(Request.QueryString["url"])) this.Page.Response.Redirect(Request["url"]);

            }
        }
        else
        {
            lblLoginMessage.Visible = true;
            lblLoginMessage.Text = "验证码错误！";
        }
    }

    protected void btn_logout(object sender, EventArgs e)
    {
        FlowControl.Logout();
        this.Page.Response.Redirect("/index.aspx");
    }
}
