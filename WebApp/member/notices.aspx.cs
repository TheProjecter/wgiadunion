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
using System.Collections.Generic;

public partial class member_notices : System.Web.UI.Page
{

    private int pagesize = 10;
    protected int userid;
    private wgiAdUnionSystem.BLL.wgi_noticestat bllstat = new wgiAdUnionSystem.BLL.wgi_noticestat();
    private wgiAdUnionSystem.Model.wgi_noticestat modelstat = new wgiAdUnionSystem.Model.wgi_noticestat();

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
        DataSet ds = new wgiAdUnionSystem.BLL.wgi_notice().getListOfPublic(0, userid);
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
        ps.CurrentPageIndex = page - 1;

        this.rptpager.DataSource = ps;
        this.rptpager.DataBind();

        //生成分页代码
        string url = Request.Url.ToString();

        lblpager.Text = Pager.getPagerstring(ps, url, 1, 3);

    }

    protected string getClassName(string s)
    {
        if (s == "0") return "class=\"unread\"";
        else return "";

    }

    //删除
    protected void delclick(object sender, EventArgs e)
    {
        string ids = Request["lists"];
        try
        {
            string[] s = ids.Split(',');
            foreach (string item in s)
            {
                if (bllstat.GetList(" userid=" + userid + " and usertype=" + 0 + " and noticeid=" + item).Tables[0].Rows.Count == 0)
                {
                    modelstat.deleted = 1;
                    modelstat.noticeid = int.Parse(item);
                    modelstat.unread = 1;
                    modelstat.userid = userid;
                    modelstat.usertype = 0;
                    bllstat.Add(modelstat);
                }
                else
                {
                    bllstat.UpdateDelete(int.Parse(item), userid, 0);
                }
            }
            ScriptManager.RegisterClientScriptBlock(this, GetType(), DateTime.Now.ToString(), "alert('删除成功');location=location;", true);

        }
        catch (Exception ex)
        {
            Response.Write(Helper.HelperString.getAlertJumpString("内部错误！", Request.Url.ToString()));
        }
    }

    //设为已读
    protected void markread(object sender, EventArgs e)
    {
        string ids = Request["lists"];
        try
        {
            string[] s = ids.Split(',');
            foreach (string item in s)
            {
                if (bllstat.GetList(" userid=" + userid + " and usertype=" + 0 + " and noticeid=" + item).Tables[0].Rows.Count == 0)
                {
                    modelstat.deleted = 0;
                    modelstat.noticeid = int.Parse(item);
                    modelstat.unread = 1;
                    modelstat.userid = userid;
                    modelstat.usertype = 0;
                    bllstat.Add(modelstat);
                }
                else
                {
                    bllstat.UpdateRead(int.Parse(item), 1, userid, 0);
                }
            }
            ScriptManager.RegisterClientScriptBlock(this, GetType(), DateTime.Now.ToString(), "location=location;", true);
        }
        catch (Exception ex)
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
            string[] s = ids.Split(',');
            foreach (string item in s)
            {
                if (bllstat.GetList(" userid=" + userid + " and usertype=" + 0 + " and noticeid=" + item).Tables[0].Rows.Count == 0)
                {
                    modelstat.deleted = 0;
                    modelstat.noticeid = int.Parse(item);
                    modelstat.unread = 0;
                    modelstat.userid = userid;
                    modelstat.usertype = 0;
                    bllstat.Add(modelstat);
                }
                else
                {
                    bllstat.UpdateRead(int.Parse(item), 0, userid, 0);
                }
            }
            ScriptManager.RegisterClientScriptBlock(this, GetType(), DateTime.Now.ToString(), "location=location;", true);
        }
        catch (Exception)
        {
            Response.Write(Helper.HelperString.getAlertJumpString("内部错误！", Request.Url.ToString()));
        }

    }

}
