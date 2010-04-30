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

public partial class admin_Finace : ValidatePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        uLoadControl.initPage(Page, 2, "Dashboard - Admin", plhdTitle, plhdHeader, plhdSlide, plhdFooter);
        if (!IsPostBack)
        {
            initData();
        }

    }

    private void initData()
    {
        string sqlWhere = "1=1";
        sqlWhere += hidquery.Value;
        ods.SelectParameters["strWhere"].DefaultValue = sqlWhere;
        gridList.DataSourceID = "ods";
        gridList.DataBind();
    }

    protected void row_bound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && ((e.Row.RowState & DataControlRowState.Edit) > 0))
        {
            DropDownList ddl = e.Row.FindControl("ddlstatus") as DropDownList;
            (e.Row.Cells[0].Controls[0] as TextBox).ReadOnly = true;
            (e.Row.Cells[1].Controls[0] as TextBox).ReadOnly = true;
            (e.Row.Cells[2].Controls[0] as TextBox).ReadOnly = true;
            string status = gridList.DataKeys[e.Row.RowIndex]["status"].ToString();
            Helper.HelperDropDownList.BindData(ddl, CommonData.getApplyStatus(), "name", "value", 0);
            ddl.SelectedValue = status;
        }
    }

    protected void update_status(object sender, GridViewUpdateEventArgs e)
    {
        int index = gridList.EditIndex;
        e.NewValues["status"] = (gridList.Rows[index].FindControl("ddlstatus") as DropDownList).Text;
        ods.UpdateParameters["id"].DefaultValue = e.Keys["id"].ToString();
        ods.UpdateParameters["status"].DefaultValue = e.NewValues["status"].ToString();
        ods.Update();
        gridList.DataSourceID = "ods";
        gridList.DataBind();
        Response.Redirect("Finace.aspx");
        e.Cancel = true;
    }

    protected void search_click(object sender, EventArgs e)
    {
        string sql = "";

        lblsearch.Text = "搜索内容<";
        if (txtname.Text.Trim() != "")
        {
            lblsearch.Text += "姓名：" + txtname.Text + " ";
            sql += " and b.contact like '%" + txtname.Text + "%'";
        }
        if (txtusername.Text.Trim() != "")
        {
            lblsearch.Text += "用户名：" + txtusername.Text + " ";
            sql += " and b.username='" + txtusername.Text + "'";
        }
        if (txtemail.Text.Trim() != "")
        {
            lblsearch.Text += "email：" + txtemail.Text + " ";
            sql += " and b.email='" + txtemail.Text + "'";
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
        hidquery.Value = sql;
        initData();

    }

    protected void clearsearch(object sender, EventArgs e)
    {
        lbtnclear.Visible = false;
        txtusername.Text = txtemail.Text = txtname.Text = hidquery.Value = lblsearch.Text = "";
        initData();
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
        DropDownList ddlpagesize = sender as DropDownList;
        gridList.PageSize = int.Parse(ddlpagesize.SelectedValue);
        initData();
    }

    protected void renderview(object sender, EventArgs e)
    {
        GridViewRow gvr = (sender as GridView).BottomPagerRow;
        if (gvr != null)//始终显示页码
        {
            gvr.Visible = true;
        }

        PagedDataSource ps = new PagedDataSource();
        ps.DataSource = ods.Select();
        try//初始化下拉列表
        {
            (gvr.FindControl("ddlPageSize") as DropDownList).SelectedValue = gridList.PageSize.ToString();
        }
        catch (ArgumentOutOfRangeException ae)
        {
            (gvr.FindControl("ddlPageSize") as DropDownList).SelectedIndex = 0;
        }
        //得到纪录总条数
        (gvr.FindControl("lblTotalRecord") as Label).Text = ps.DataSourceCount.ToString();

        this.hidcurpage.Value = (gridList.PageIndex + 1).ToString();
    }
    #endregion
}
