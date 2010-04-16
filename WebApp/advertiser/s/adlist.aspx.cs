using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class advertiser_s_adlist :advertiserPage
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

        Helper.HelperDropDownList.BindData(ddlDisplayType, CommonData.GetAdvertiseDisplayType(), "name", "value", -1);

        Helper.HelperDropDownList.BindData(ddlPayType, CommonData.GetAdvertisePayType(), "name", "value", -1);

        BindGrid();
    }

    protected void BindGrid()
    {
        odsData.SelectParameters["compid"].DefaultValue = base.companyid.ToString();
        odsData.SelectParameters["paytype"].DefaultValue = ddlPayType.SelectedValue;
        odsData.SelectParameters["display"].DefaultValue = ddlDisplayType.SelectedValue;
        odsData.SelectParameters["beg"].DefaultValue = txtstart.Text;
        odsData.SelectParameters["end"].DefaultValue = txtend.Text;
        odsData.SelectParameters["title"].DefaultValue = txtTitle.Text;
        gridList.DataSourceID = odsData.ID;
        gridList.DataBind();
    }
    protected void gridList_DataBound(object sender, EventArgs e)
    {
        foreach(GridViewRow gvr in gridList.Rows)
        {
            gvr.Cells[2].Text = CommonData.GetAdvTypeDisplayName(gvr.Cells[2].Text);
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        BindGrid();
    }
}
