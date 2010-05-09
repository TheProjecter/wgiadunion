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

public partial class admin_ArticalPage : ValidatePage
{

    protected void Page_Load(object sender, EventArgs e)
    {
        //初始页头 
        Control title = Page.LoadControl("pageControl/title.ascx");
        title.ID = "uc_title";
        this.holderheader.Controls.Add(title);

        if (!IsPostBack)
        {
            initData();
        }
    }

    private void initData()
    {
        string act = Request.QueryString["act"];
        string noticeid = Request.QueryString["noticeid"];
        Helper.HelperDropDownList.BindData(ddlobjtype, CommonData.getUsertype(), "name", "value", 0);
        if (act == "add")
        {
            newNotice();
        }
        else if(act=="edit")
        {
            editNotice();
        }
        else if (act=="show")
        {
            showNotice();
        }
        else
        {
            Response.Write("非法进入");
            Response.End();
        }
        if (noticeid == "")
        {
            Response.Write("非法进入");
            Response.End();
        }
    }

    private void showNotice()
    {

    }
    private void newNotice()
    {

    }
    private void editNotice()
    {
        int nid = int.Parse(Request.QueryString["noticeid"]);
        hidnid.Value = nid.ToString();
        wgiAdUnionSystem.Model.wgi_notice model = new wgiAdUnionSystem.BLL.wgi_notice().GetModel(nid);
        if(object.Equals(model,null))
        {
            Response.Write("参数错误");
            Response.End();
        }
        txtcontent.Value=model.notice;
        txttitle.Text=model.title;
        ddlobjtype.SelectedValue=model.objtype.ToString();
    }

    protected void sub_click(object sender, EventArgs e)
    {
        wgiAdUnionSystem.BLL.wgi_notice bll = new wgiAdUnionSystem.BLL.wgi_notice();
        wgiAdUnionSystem.Model.wgi_notice model = new wgiAdUnionSystem.Model.wgi_notice();
        if (Request.QueryString["act"]=="edit") 
        {
            model = bll.GetModel(int.Parse(hidnid.Value));
            model.title = Server.HtmlEncode(txttitle.Text);
            model.notice = txtcontent.Value;
            model.objtype = int.Parse(ddlobjtype.Text);
            model.publisher = base.user.id;
            //model.pubdate = DateTime.Now;//真有重要更新应发新消息

            bll.Update(model);

            ScriptManager.RegisterClientScriptBlock(this, GetType(), DateTime.Now.ToString(), "alert('修改公告成功！');parent.closepop();parent.location=parent.location;", true);
            return;
        }
        model.notice = txtcontent.Value;
        model.objid = -1;//-1表示公告，私人消息会有用户id
        model.objtype = int.Parse(ddlobjtype.Text);
        model.pubdate = DateTime.Now;
        model.publisher = base.user.id;
        model.title = Server.HtmlEncode(txttitle.Text);
        model.unread = 0;

        bll.Add(model);
        ScriptManager.RegisterClientScriptBlock(this, GetType(), DateTime.Now.ToString(), "alert('发布公告成功！');parent.closepop();parent.location=parent.location;", true);
    }
}
