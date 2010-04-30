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

public partial class admin_Users : ValidatePage
{
    private wgiAdUnionSystem.BLL.wgi_sysuser bll = new wgiAdUnionSystem.BLL.wgi_sysuser();
    private wgiAdUnionSystem.Model.wgi_sysuser model = new wgiAdUnionSystem.Model.wgi_sysuser();

    protected void Page_Load(object sender, EventArgs e)
    {
        uLoadControl.initPage(Page, 3, "Dashboard - Admin", plhdTitle, plhdHeader, plhdSlide, plhdFooter);
        if (!IsPostBack)
        {
            initData();
        }

    }

    private void initData()
    {
        string strWhere = "1=1";
        if (!string.IsNullOrEmpty(hidquery.Value.Trim()))
        {
            strWhere += hidquery.Value;
        }
        ods.SelectParameters["strWhere"].DefaultValue = strWhere;
        gridList.DataSourceID = "ods";
        gridList.DataBind();

        this.hiduid.Value = base.user.id.ToString();
    }


    protected void save_click(object sender, CommandEventArgs e)
    {
        if (e.CommandArgument.ToString() == "add")
        {
            //新增用户
            model.username = txtname.Text;
            model.email = txtemail.Text;
            model.password = txtpwd.Text;

            try
            {
                bll.Add(model);
                ScriptManager.RegisterClientScriptBlock(this, GetType(), DateTime.Now.ToString(), "alert(\"添加用户成功！\");location=location;", true);
            }
            catch (Exception ex)
            {
                Helper.HelperString.getAlertJumpString("服务器错误<br />" + ex.Message, Request.CurrentExecutionFilePath);
            }


        }
        else if (e.CommandArgument.ToString() == "edit")
        {
            //更新用户资料
            try
            {
                int id = int.Parse(hideditid.Value);
                model = bll.GetModel(id);

                model.username = txtname.Text;
                model.email = txtemail.Text;
                model.password = txtpwd.Text;

                bll.Update(model);
                ScriptManager.RegisterClientScriptBlock(this, GetType(), DateTime.Now.ToString(), "alert(\"修改用户资料成功！\");location=location;", true);

                //改变页面控件为新增状态
                //this.lbtnedit.CommandArgument = "add";
                //this.lbtnedit.CssClass = "pageedit";
            }
            catch (Exception ex)
            {
                Helper.HelperString.getAlertJumpString("服务器错误<br />" + ex.Message, Request.CurrentExecutionFilePath);
            }
        }
        else return;
    }

    protected void searchResault(object sender, EventArgs e)
    {
        string query = "";

        lblsearch.Text = "搜索内容<";
        if (txtname.Text.Trim() != "")
        {
            lblsearch.Text += "用户名：" + txtname.Text + " ";
            query += " and username='" + txtname.Text + "'";
        }
        if (txtemail.Text.Trim() != "")
        {
            lblsearch.Text += "email：" + txtemail.Text + " ";
            query += " and email='" + txtemail.Text + "'";
        }
        if (lblsearch.Text == "搜索内容<")
        {
            lblsearch.Text = "";
            lbtnclear.Visible = false;
        }
        else
        {
            lblsearch.Text += ">";
            lbtnclear.Visible = true;
        }
        hidquery.Value = query;
        initData();

    }

    protected void clearsearch(object sender, EventArgs e)
    {
        lbtnclear.Visible = false;
        txtname.Text = txtemail.Text = txtpwd.Text = txtpwdre.Text = lblsearch.Text = hidquery.Value = "";
        initData();
    }

    protected void cancel_click(object sender, EventArgs e)
    {
        this.txtpwd.Attributes.Add("value", "");
        this.txtpwdre.Attributes.Add("value", "");
        this.txtname.Text = "";
        this.txtemail.Text = "";
        this.hideditid.Value = "";
    
    }

    protected void edit_click(object sender, CommandEventArgs e)
    {
        try
        {
            int id = int.Parse(e.CommandArgument.ToString());
            model = bll.GetModel(id);

            this.txtemail.Text = model.email;
            this.txtname.Text = model.username;
            this.txtpwd.Attributes.Add("value", model.password);
            this.txtpwdre.Attributes.Add("value", model.password);
            this.hideditid.Value = id.ToString();

            this.lbtnedit.CommandArgument = "edit";
            this.lbtnedit.Text = "保存";
            this.lbtncancel.Enabled = true;
            this.lbtnedit.CssClass = "pageedit";

        }
        catch (Exception ex)
        {
            Helper.HelperString.getAlertJumpString("服务器错误<br />" + ex.Message, Request.CurrentExecutionFilePath);
        }


    }

    protected void deletes(object sender, EventArgs e)
    { 
        //过滤掉当前管理员的id  //或者由前端js控不送入管理员的id
        bll.Delete(this.hidselected.Value);
        initData();
        //Response.Redirect(Request.CurrentExecutionFilePath);
    }

    #region 自定义分页
    protected void getCustPage(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        btn.CommandName = "Page";
        btn.CommandArgument = ((btn.NamingContainer as GridViewRow).FindControl("txtcurrentPage") as TextBox).Text;
    }

    protected void changepagesize(object sender, EventArgs e)
    { 
        DropDownList ddlpagesize=sender as DropDownList;
        gridList.PageSize = int.Parse(ddlpagesize.SelectedValue);
        initData();
    }

    protected void renderview(object sender, EventArgs e)
    {
        GridViewRow gvr = (sender as GridView).BottomPagerRow;
        if (gvr != null)
        {
            gvr.Visible = true;
        }

        PagedDataSource ps = new PagedDataSource();
        ps.DataSource = ods.Select();
        try
        {
            (gvr.FindControl("ddlPageSize") as DropDownList).SelectedValue = gridList.PageSize.ToString();
        }
        catch (ArgumentOutOfRangeException ae)
        {
            (gvr.FindControl("ddlPageSize") as DropDownList).SelectedIndex = 0;
        }
        (gvr.FindControl("lblTotalRecord") as Label).Text = ps.DataSourceCount.ToString();

        this.hidcurpage.Value = (gridList.PageIndex + 1).ToString();
    }
    #endregion
}
