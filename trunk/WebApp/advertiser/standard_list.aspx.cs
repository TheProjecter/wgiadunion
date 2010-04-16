using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class advertiser_standard_list : advertiserPage
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
        odsData.SelectParameters["beg_date"].DefaultValue = txtstart.Text;
        odsData.SelectParameters["end_date"].DefaultValue = txtend.Text;
        gridList.DataSourceID = odsData.ID;
        gridList.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        BindGrid();
    }
}
