using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class advertiser_order_valid : advertiserPage
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
        odsData.SelectParameters["status"].DefaultValue = "1";
        odsData.SelectParameters["member"].DefaultValue = txtmember.Text;
        odsData.SelectParameters["orderno"].DefaultValue = txtorderno.Text;
        odsData.SelectParameters["sdate"].DefaultValue = txtstart.Text+" 0:00:00";
        odsData.SelectParameters["edate"].DefaultValue = txtend.Text + " 23:59:59";
        gridList.DataSourceID = odsData.ID;
        gridList.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        BindGrid();
    }
}
