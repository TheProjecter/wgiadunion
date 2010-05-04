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

public partial class admin_orderDetails : ValidatePage
{
    private string uid = "";

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
        int userid = -1;
        uid = Request.QueryString["uid"];
        if (uid == "" || !int.TryParse(uid, out userid))
        {
            Response.Write("非法进入");
            Response.End();
        }

        wgiAdUnionSystem.BLL.wgi_orders orderbll = new wgiAdUnionSystem.BLL.wgi_orders();
        wgiAdUnionSystem.BLL.wgi_cash cashbll = new wgiAdUnionSystem.BLL.wgi_cash();
        wgiAdUnionSystem.Model.wgi_cash cashmodel = null;

        //根据uid，取出这一次佣金申请的时间（同一时间只处理一单，如有多单，需人工调查）
        //原则是：一个用户在一个佣金申请表里，要么就没有申请纪录，要么除了本次申请以外，其它申请都已被受理（4表示已支付，5表示被打回），凡是出现多条状态为1的，或是上次申请未走完流程又有新申请的，都是有错误的申请
        List<wgiAdUnionSystem.Model.wgi_cash> cash = cashbll.GetModelList("a.userid=" + userid);
        IEnumerable<wgiAdUnionSystem.Model.wgi_cash> s, s1;
        s = cash.Where(p => (int)p.status == 1 || (int)p.status == 2);//表示正在处理流程中的申请
        if (s.Count() > 1)
        {
            Response.Write("该用户数据异常，请排查<br/>原因：<br/>有多条在处理的申请记录");
            Response.End();
        }
        if (s.Count() == 0)
        {
            Response.Write("该用户申请已全部处理");
            Response.End();
        }
        //if (cash.Where(p => (int)p.status > 1 && (int)p.status < 4).Count() > 0)
        //{
        //    Response.Write("该用户数据异常，请排查<br/>原因：<br/>之前有未处理完的申请");
        //    Response.End();
        //}
        string totime = ((DateTime)s.Single().applydate).ToString("yyyy-MM-dd HH:mm:ss");//本次申请时间
        string fromtime = "";//上次申请时间
        string lbltimetext = "";
        //如果上次成功受理，则还需要起始时间
        s = cash.Where(p => (int)p.status > 3).OrderByDescending(p => (DateTime)p.applydate);
        if (s.Count() > 0)
        {
            fromtime = ((DateTime)s.First().applydate).ToString("yyyy-MM-dd HH:mm:ss");
        }
        //如果从未受理过，则取出订单表中该用户的所有数据（理论上不需要判断日期了，因为只有一次申请）

        string sql = "1=1";
        sql += " and userid=" + userid;
        if (fromtime != "")
        {
            sql += " and time > '" + fromtime + "' ";
        }
        sql += " and time < '" + totime + "' ";
        ods.SelectParameters["strWhere"].DefaultValue = sql;
        gridList.DataBind();
        if (fromtime == "")
        {
            lbltimetext = "在&nbsp;<span style='color:red;'>" + totime + "</span>&nbsp;之前产生的订单明细";
        }
        else
        {
            lbltimetext = "在&nbsp;<span style='color:red;'>" + fromtime + "</span>&nbsp;至&nbsp;<span style='color:red;'>" + totime + "</span>&nbsp;期间产生的订单明细";
        }
        this.lbltime.Text = lbltimetext;

        this.hidpagecounter.Value = gridList.PageCount.ToString();
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
