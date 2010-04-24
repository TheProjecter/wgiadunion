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

public partial class member_messages : System.Web.UI.Page
{

    private int pagesize = 10;
    private int userid;

    protected void Page_Load(object sender, EventArgs e)
    {
        validateMember userobj = MasterPageOpration.getMasterControl(this.Page.Master, "Muser");
        if (userobj.suser.userid != 0)
        {
            userid = userobj.suser.userid;
            if (!IsPostBack) initData(userid);
        }
        else
        {
            if (IsPostBack)
                ScriptManager.RegisterClientScriptBlock(this, GetType(), DateTime.Now.ToString(), "alert('您已登出系统，请重新登录');location.href='/member/Default.aspx?url='" + Request.CurrentExecutionFilePath + ";", true);
        }
    }

    private void initData(int uid)
    {

        DataSet ds = new wgiAdUnionSystem.BLL.wgi_notice().getLIstOfPrivate(uid);
        int page;
        if (!int.TryParse(Request["page"], out page))
        {
            page = 1;
        }

        PagedDataSource ps = new PagedDataSource();
        ps.DataSource = ds.Tables[0].DefaultView;
        ps.AllowPaging = true;
        ps.PageSize = pagesize;
        if (page > ps.PageCount) page = 1;
        ps.CurrentPageIndex = page-1;

        this.rptpager.DataSource = ps;
        this.rptpager.DataBind();

        //生成分页代码
        string url = Request.Url.ToString();

        lblpager.Text = Pager.getPagerstring(ps,url,1,3);

    }

    protected string getClassName(string s)
    {
        if (s == "0") return "class=\"unread\"";
        else return "";

    }

    protected string getSenderName(string id)
    {
        if (id == "-1") return "系统管理员";
        else return "<a href=\"#\">用户</a>";
    }

    //删除
    protected void delclick(object sender, EventArgs e)
    {
        string ids = Request["lists"];
        try
        {
            new wgiAdUnionSystem.BLL.wgi_notice().Delete(ids);
            ScriptManager.RegisterClientScriptBlock(this, GetType(), DateTime.Now.ToString(), "alert('删除成功');location=location;", true);
            
        }
        catch (Exception)
        {
            Response.Write(Helper.HelperString.getAlertJumpString("内部错误！",Request.Url.ToString()));
        }
    }

    //设为已读
    protected void markread(object sender, EventArgs e)
    {
        string ids = Request["lists"];
        try
        {
            new wgiAdUnionSystem.BLL.wgi_notice().UpdateReadStatus(ids, 1);
            ScriptManager.RegisterClientScriptBlock(this, GetType(), DateTime.Now.ToString(), "location=location;", true);
        }
        catch (Exception)
        {
            Response.Write(Helper.HelperString.getAlertJumpString("内部错误！", Request.Url.ToString()));
        }

    }

    //设为未读
    protected void markunread(object sender, EventArgs e)
    {
        string ids = Request["lists"];
        try
        {
            new wgiAdUnionSystem.BLL.wgi_notice().UpdateReadStatus(ids, 0);
            ScriptManager.RegisterClientScriptBlock(this, GetType(), DateTime.Now.ToString(), "location=location;", true);
        }
        catch (Exception)
        {
            Response.Write(Helper.HelperString.getAlertJumpString("内部错误！", Request.Url.ToString()));
        }

    }

}
