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

public partial class member_sites : System.Web.UI.Page
{
	private int userid;
	
    protected void Page_Load(object sender, EventArgs e)
    {
   
        validateMember userobj = MasterPageOpration.getMasterControl(this.Page.Master, "Muser");
		if(userobj.suser.userid!=0) 
        {
            userid=userobj.suser.userid;
            if(!IsPostBack) initData();
        }
		else Response.Redirect("/member/Default.aspx?url="+ Request.CurrentExecutionFilePath);
    }

    protected void initData()
    {
        this.odsData.SelectParameters["userid"].DefaultValue = userid.ToString();
        this.gridList.DataSourceID = this.odsData.ID;
        this.gridList.DataBind();

        //网站类型
        Helper.HelperDropDownList.BindData(ddlsitetype, CommonData.getSiteType(), "name", "value", 0);
    }

    protected void editsite(object sender, CommandEventArgs e)
    {
        string siteid = e.CommandArgument.ToString();
        wgiAdUnionSystem.Model.wgi_usersite model = new wgiAdUnionSystem.BLL.wgi_usersite().GetModel(int.Parse(siteid));
        txtipno.Text = model.ipno.ToString();
        txtpvno.Text = model.pvno.ToString();
        txtremark.Text = model.siteremark;
        txtsitename.Text = model.sitename;
        txturl.Text = model.url;
        ddlsitetype.SelectedValue = model.sitetype.ToString();
        hidsiteid.Value = siteid;
        btnnew.Enabled = false;
        btnedit.Enabled = true;
    }

    protected void btnnew_s(object sender, EventArgs e)
    {
        wgiAdUnionSystem.BLL.wgi_usersite bll = new wgiAdUnionSystem.BLL.wgi_usersite();
        wgiAdUnionSystem.Model.wgi_usersite model = new wgiAdUnionSystem.Model.wgi_usersite();
        string sitename = txtsitename.Text;
        string url = txturl.Text;
        string remark = txtremark.Text;

        int ipno, pvno;
        ipno = pvno = 0;

        int sitetype = int.Parse(ddlsitetype.SelectedValue);

        try
        {
            ipno = int.Parse(txtipno.Text);

        }
        catch (Exception)
        {

            //ScriptManager.RegisterClientScriptBlock(this, GetType(), DateTime.Now.ToString(), "alert('独立IP数请输入数字');", true);
            ipno = 0;
        }
        try
        {
            pvno = int.Parse(txtpvno.Text);

        }
        catch (Exception)
        {
            //ScriptManager.RegisterClientScriptBlock(this, GetType(), DateTime.Now.ToString(), "alert('日均PV数请输入数字');", true);
            pvno = 0;
        }
        model.ipno = ipno;
        model.pvno = pvno;
        model.sitename = sitename;
        model.siteremark = remark;
        model.sitetype = sitetype;
        model.url = url;
        model.userid = userid;

        bll.Add(model);
        ScriptManager.RegisterClientScriptBlock(this, GetType(), DateTime.Now.ToString(), "alert('添加网站成功');window.navigate(location);", true);
    }


    protected void btnsave(object sender, EventArgs e)
    {
        wgiAdUnionSystem.BLL.wgi_usersite bll = new wgiAdUnionSystem.BLL.wgi_usersite();
        wgiAdUnionSystem.Model.wgi_usersite model = new wgiAdUnionSystem.Model.wgi_usersite();
        string sitename = txtsitename.Text;
        string url = txturl.Text;
        string remark = txtremark.Text;

        int ipno, pvno;
        ipno = pvno = 0;

        int sitetype = int.Parse(ddlsitetype.SelectedValue);

        try
        {
            ipno = int.Parse(txtipno.Text);

        }
        catch (Exception)
        {

            //ScriptManager.RegisterClientScriptBlock(this, GetType(), DateTime.Now.ToString(), "alert('独立IP数请输入数字');", true);
            ipno = 0;
        }
        try
        {
            pvno = int.Parse(txtpvno.Text);

        }
        catch (Exception)
        {
            //ScriptManager.RegisterClientScriptBlock(this, GetType(), DateTime.Now.ToString(), "alert('日均PV数请输入数字');", true);
            pvno = 0;
        }
        model.ipno = ipno;
        model.pvno = pvno;
        model.sitename = sitename;
        model.siteremark = remark;
        model.sitetype = sitetype;
        model.url = url;
        model.userid = userid;
        model.siteid = int.Parse(hidsiteid.Value);

        bll.Update(model);
        ScriptManager.RegisterClientScriptBlock(this, GetType(), DateTime.Now.ToString(), "alert('编辑网站成功');window.navigate(location);", true);
    }

}