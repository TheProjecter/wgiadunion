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

    private int pagesize = 5;

    protected void Page_Load(object sender, EventArgs e)
    {
        uLoadControl.initPage(Page, 3, "Dashboard - Admin", plhdTitle, plhdHeader, plhdSlide, plhdFooter);
        if (!IsPostBack)
        {
            initData("1=1");
        }

    }

    private void initData(string strWhere)
    {
        ods.SelectParameters["strWhere"].DefaultValue = strWhere;

        PagedDataSource ps = new PagedDataSource();
        int currentPage = int.Parse(txtcurrentPage.Text);
        ps.DataSource = ods.Select();
        ps.AllowPaging = true;
        ps.CurrentPageIndex = currentPage - 1;
        ps.PageSize = pagesize;
        this.txtTotalRecord.Text = ps.DataSourceCount.ToString();
        this.txtTotalPage.Text = ps.PageCount.ToString();

        gridList.DataSource = ps;
        gridList.DataBind();

        //分页按钮控制
        bnpage.Enabled = true;
        bppage.Enabled = true;
        if (ps.PageCount == currentPage)
        {
            bnpage.Enabled = false;
        }
        if (currentPage == 1)
        {
            bppage.Enabled = false;
        }

        this.hiduid.Value = base.user.id.ToString();
    }

    protected void prePage(object sender, EventArgs e)
    {
        txtcurrentPage.Text = (int.Parse(txtcurrentPage.Text) - 1).ToString();
        initData("1=1");
    }

    protected void nextPage(object sender, EventArgs e)
    {
        txtcurrentPage.Text = (int.Parse(txtcurrentPage.Text) + 1).ToString();
        initData("1=1");
    }

    protected void gopage_click(object sender, EventArgs e)
    {
        txtcurrentPage.Text = (int.Parse(txtcurrentPage.Text)).ToString();
        initData("1=1");
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
        Response.Redirect(Request.CurrentExecutionFilePath);
    }

    protected void gridList_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (gridList.SortDirection == SortDirection.Ascending)
        {
            initData("1=1 order by " + e.SortExpression + " desc");
        }
        else
        {
            initData("1=1 order by "+e.SortExpression);
        }
    }
}
