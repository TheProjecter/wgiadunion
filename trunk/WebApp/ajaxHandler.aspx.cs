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
using System.IO;

public partial class ajaxHandler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        switch (Request["act"]) { 
            case "checkpwd":
                checkpwd();
                break;
            case "checkSitehostUsername":
                checkSitehostUsername();
                break;
            case "checkAdminUsername":
                checkAdminUsername();
                break;
            case "getmsgs":
                getmsgs();
                break;
            default:
                break;
        }
    }

    private void checkpwd()
    {
        Response.ContentType = "txt/html";
        Response.Clear();

        wgiAdUnionSystem.BLL.wgi_sitehost bll = new wgiAdUnionSystem.BLL.wgi_sitehost();
        int userid = Convert.ToInt32(Request["userid"]);
        string pwd = Request["pwd"];
        string orignal = bll.GetModel(userid).password;
        if (orignal == pwd) Response.Write("1");

        else Response.Write("0");
        Response.End();  
    }

    private void checkSitehostUsername()
    {
        Response.ContentType = "txt/html";
        Response.Clear();
        wgiAdUnionSystem.BLL.wgi_sitehost bll = new wgiAdUnionSystem.BLL.wgi_sitehost();
        string name = Request["username"];

        if (bll.GetListByUsername(name).Tables[0].Rows.Count > 0) Response.Write("0");
        else Response.Write("1");
        Response.End();
    }

    private void checkAdminUsername()
    {
        Response.ContentType = "txt/html";
        Response.Clear();
        wgiAdUnionSystem.BLL.wgi_sysuser bll = new wgiAdUnionSystem.BLL.wgi_sysuser();
        string name = Request["username"];

        if (bll.GetListByUsername(name).Tables[0].Rows.Count > 0) Response.Write("0");
        else Response.Write("1");
        Response.End();
    }

    private void getmsgs()
    {
        Response.ContentType = "txt/html";
        Response.Clear();

        int id;
        if(!int.TryParse(Request["id"],out id))
        {
            Response.Write("读取数据失败！");
            Response.End();
        }

        wgiAdUnionSystem.BLL.wgi_notice bll=new wgiAdUnionSystem.BLL.wgi_notice ();
        wgiAdUnionSystem.Model.wgi_notice model=bll.GetModel(id);

        //取出消息内容
        string cont=model.notice;

        //更改阅读状态
        try
        {
            string utype = Request.QueryString["utype"];
            if (utype == "none")
            {
                bll.UpdateReadStatus(id.ToString(), 1);
            }
            else
            {
                int usertype = int.Parse(utype);
                int userid = int.Parse(Request.QueryString["uid"]);

                wgiAdUnionSystem.BLL.wgi_noticestat bllstat = new wgiAdUnionSystem.BLL.wgi_noticestat();
                wgiAdUnionSystem.Model.wgi_noticestat modelstat = new wgiAdUnionSystem.Model.wgi_noticestat();

                if (bllstat.GetList(" userid=" + userid + " and usertype=" + usertype + " and noticeid=" + id).Tables[0].Rows.Count == 0)
                {
                    modelstat.deleted = 0;
                    modelstat.noticeid = id;
                    modelstat.unread = 1;
                    modelstat.userid = userid;
                    modelstat.usertype = usertype;
                    bllstat.Add(modelstat);
                }
                else
                {
                    bllstat.UpdateRead(id, 1, userid, 0);
                }
            }
        }
        catch (Exception)
        {
            Response.Write("读取数据失败！");
            Response.End();
        }

        Response.Write(cont);
        Response.End();   
    }

}
