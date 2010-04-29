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

public partial class admin_siteUsers : ValidatePage
{
    private wgiAdUnionSystem.BLL.wgi_sitehost bll = new wgiAdUnionSystem.BLL.wgi_sitehost();
    private wgiAdUnionSystem.Model.wgi_sitehost model = new wgiAdUnionSystem.Model.wgi_sitehost();

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
        ods.SelectParameters["username"].DefaultValue = hiduname.Value + " ";
        ods.SelectParameters["realname"].DefaultValue = hidrname.Value + " ";
        ods.SelectParameters["email"].DefaultValue = hidemail.Value + " ";
        ods.SelectParameters["sitename"].DefaultValue = hidsite.Value + " ";
        gridList.DataSourceID = "ods";
        gridList.DataBind();

        this.hiduid.Value = base.user.id.ToString();
    }

    protected void deletes(object sender, EventArgs e)
    {
        bll.Delete(Request["ids"]);
        initData();
        //Response.Redirect(Request.CurrentExecutionFilePath);
    }

    protected void searchResault(object sender, EventArgs e)
    {
        hiduname.Value = txtusername.Text+" ";
        hidrname.Value = txtrealname.Text + " ";
        hidemail.Value = txtemail.Text + " ";
        hidsite.Value = txtsitename.Text + " ";

        lblsearch.Text = "搜索内容<";
        if (txtusername.Text.Trim() != "")
        {
            lblsearch.Text += "用户名：" + txtusername.Text + " ";
        }
        if (txtrealname.Text.Trim() != "")
        {
            lblsearch.Text += "姓名：" + txtrealname.Text + " ";
        }
        if (txtemail.Text.Trim() != "")
        {
            lblsearch.Text += "email：" + txtemail.Text + " ";
        }
        if (txtsitename.Text.Trim() != "")
        {
            lblsearch.Text += "网站名：" + txtsitename.Text;
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
        initData();

    }

    protected void clearsearch(object sender, EventArgs e)
    {
        hiduname.Value = hidemail.Value = hidrname.Value = hidsite.Value = "";
        lbtnclear.Visible = false;
        txtusername.Text = txtemail.Text = txtsitename.Text = txtrealname.Text = lblsearch.Text = "";
        initData();
    }


    #region 自定义分页部分
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
        if (ps.DataSourceCount > 0)
        {
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
    }
    #endregion
}