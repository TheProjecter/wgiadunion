using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class advertiser_order_invalid : advertiserPage
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
        BindGrid();
    }
    protected void BindGrid()
    {
        odsData.SelectParameters["compid"].DefaultValue = base.companyid.ToString();
        odsData.SelectParameters["status"].DefaultValue = "2";
        odsData.SelectParameters["orderno"].DefaultValue = txtorderno.Text;
        odsData.SelectParameters["buyer"].DefaultValue = txtbuyer.Text;
        gridList.DataSourceID = odsData.ID;
        gridList.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        BindGrid();
    }
}
