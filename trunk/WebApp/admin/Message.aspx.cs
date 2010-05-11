using System;
using System.Collections;
using System.Collections.Generic;
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

public partial class admin_Message : ValidatePage
{
    private wgiAdUnionSystem.BLL.wgi_notice bll = new wgiAdUnionSystem.BLL.wgi_notice();
    private wgiAdUnionSystem.Model.wgi_notice model = new wgiAdUnionSystem.Model.wgi_notice();

    protected void Page_Load(object sender, EventArgs e)
    {
        uLoadControl.initPage(Page, 4, "Dashboard - Admin", plhdTitle, plhdHeader, plhdSlide, plhdFooter);
        if (!IsPostBack)
        {
            initData();
        }
    }

    private void initData()
    {
        string sql = "a.objid<>-1 and a.objtype<>-1 ";
        sql += hidquery.Value;
        sql += " order by a.pubdate desc";
        ods.SelectParameters["strWhere"].DefaultValue = sql;
        gridList.DataSource = ods;
        gridList.DataBind();

        Helper.HelperDropDownList.BindData(ddlobjtype, CommonData.getUsertype(), "name", "value", 0);
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
        string query = "";
        lblsearch.Text = "搜索内容<";
        lblsearch.Text += "&nbsp;发送给：" + ddlobjtype.SelectedItem.Text;
        query += " and a.objtype=" + ddlobjtype.Text;
        if (txtobjname.Text.Trim() != "")
        {
            lblsearch.Text += "&nbsp;用户名：" + txtobjname.Text;
            int uid = -1;
            if (ddlobjtype.Text.Trim() == "0")
            {
                List<wgiAdUnionSystem.Model.wgi_sitehost> o = new wgiAdUnionSystem.BLL.wgi_sitehost().GetModelList(" username='" + txtobjname.Text + "' ");
                if (o.Count() > 0)
                {
                    uid = o.SingleOrDefault().userid;
                }
            }
            else if (ddlobjtype.Text.Trim() == "1")
            {
                List<wgiAdUnionSystem.Model.wgi_adhost> o = new wgiAdUnionSystem.BLL.wgi_adhost().GetModelList(" username='" + txtobjname.Text + "' ");
                if (o.Count() > 0)
                {
                    uid = o.SingleOrDefault().companyid;
                }
            }
            query += " and a.objid=" + uid + " ";
        }
        if (txttitle.Text.Trim() != "")
        {
            lblsearch.Text += "标题：" + txttitle.Text + " ";
            query = " and a.title like '%" + txttitle.Text + "%' ";
        }
        if (txtstart.Text.Trim() != "" || txtend.Text.Trim() != "")
        {
            lblsearch.Text += "发布时间：";
            if (txtstart.Text.Trim() == "")
            {
                lblsearch.Text += txtend.Text + "之前";
                query += " and a.pubdate<'" + txtend.Text + "' ";
            }
            else if (txtend.Text.Trim() == "")
            {
                lblsearch.Text += txtstart.Text + "之后";
                query += " and a.pubdate>'" + txtstart.Text + "' ";
            }
            else
            {
                lblsearch.Text += Convert.ToDateTime(txtstart.Text).ToString("yyyy-MM-dd") + "-" + Convert.ToDateTime(txtend.Text).ToString("yyyy-MM-dd") + "之间";
                query += " and a.pubdate > '" + txtstart.Text + "' and a.pubdate < '" + txtend.Text + "' ";
            }
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
        txtend.Text = txtstart.Text = txttitle.Text = hidquery.Value = lblsearch.Text = txtobjname.Text = "";
        ddlobjtype.SelectedIndex = 0;
        initData();
    }

    protected string getUserName(string objid, string objtype)
    {
        string name = "";
        if (objtype == "0")
        {
            name = new wgiAdUnionSystem.BLL.wgi_sitehost().GetModel(int.Parse(objid)).username;
        }
        else if (objtype == "1")
        {
            name = new wgiAdUnionSystem.BLL.wgi_adhost().GetModel(int.Parse(objid)).username;
        }
        return name;
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
        DropDownList ddlpagesize = sender as DropDownList;
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