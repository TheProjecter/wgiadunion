using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class advertiser_order_chk : advertiserPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitData();
        }
    }
    protected void InitData()
    {
        txtstart.Text = DateTime.Today.AddMonths(-1).ToString("yyyy-MM-dd");
        txtend.Text = DateTime.Today.ToString("yyyy-MM-dd");
        BindGrid();
    }
    protected void BindGrid()
    {
        odsData.SelectParameters["compid"].DefaultValue = base.companyid.ToString();
        odsData.SelectParameters["status"].DefaultValue = "0";
        odsData.SelectParameters["orderno"].DefaultValue = txtorderno.Text;
        odsData.SelectParameters["buyer"].DefaultValue = txtbuyer.Text;
        odsData.SelectParameters["sdate"].DefaultValue = txtstart.Text + " 0:00:00";
        odsData.SelectParameters["edate"].DefaultValue = txtend.Text + " 23:59:59";
        gridList.DataSourceID = odsData.ID;
        gridList.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        BindGrid();
    }
    protected void gridList_DataBound(object sender, EventArgs e)
    {

    }
    protected void gridList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //获取订单ID
        int oid = Helper.HelperDigit.ConvertToInt32(e.CommandArgument.ToString(), 0);
        if (e.CommandName == "doValid")
        {
            new wgiAdUnionSystem.BLL.wgi_order().CheckAdvOrderStatus(oid, 1, "");
        }
        else if (e.CommandName == "doInvalid")
        {
            gridList.Visible = false;
            Panel1.Visible = true;
            Panel1.ToolTip = oid.ToString();
        }
    }
    protected void btnReason_Click(object sender, EventArgs e)
    {
        int oid = Helper.HelperDigit.ConvertToInt32(Panel1.ToolTip, 0);
        //核定无效订单操作
        if (new wgiAdUnionSystem.BLL.wgi_order().CheckAdvOrderStatus(oid, 2, txtReason.Text) > 0)
        {
            Response.Redirect("order_chk.aspx");
        }
    }
}
