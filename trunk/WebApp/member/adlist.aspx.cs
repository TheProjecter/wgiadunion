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

public partial class member_adlist : System.Web.UI.Page
{
    protected string adhostid;

    protected void Page_Load(object sender, EventArgs e)
    {
        adhostid = "1";
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
        odsData.SelectParameters["compid"].DefaultValue = adhostid;
        odsData.SelectParameters["paytype"].DefaultValue = ddlPayType.SelectedValue;
        odsData.SelectParameters["display"].DefaultValue = ddlDisplayType.SelectedValue;
        odsData.SelectParameters["beg"].DefaultValue = txtstart.Text;
        odsData.SelectParameters["end"].DefaultValue = txtend.Text;
        odsData.SelectParameters["title"].DefaultValue = txtTitle.Text;
        odsData.SelectParameters["isaudit"].DefaultValue = "1";
        odsData.SelectParameters["ispublished"].DefaultValue = "1";
        gridList.DataSourceID = odsData.ID;
        gridList.DataBind();
    }
    protected void gridList_DataBound(object sender, EventArgs e)
    {
        foreach (GridViewRow gvr in gridList.Rows)
        {
            string advtype = gvr.Cells[1].Text;
            string advcont=gvr.Cells[2].Text;
            //2,3分别表示图片和flash广告，需要处理，其它不动
            switch (advtype)
            { 
                case "2":
                    gvr.Cells[2].Text = "<img onload='checkWidth(this);' src=\"" + advcont + "\" alt=\"\" />";
                    break;
                case "3":
                    break;
                default:
                    break;
            }
            gvr.Cells[1].Text = CommonData.GetAdvTypeDisplayName(advtype);
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        BindGrid();
    }

}
