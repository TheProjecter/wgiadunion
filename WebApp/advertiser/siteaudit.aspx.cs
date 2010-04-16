using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class advertiser_siteaudit :advertiserPage
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
        Helper.HelperDropDownList.BindData(ddlAudit, CommonData.GetAuditStatusItem(), "name", "value", -1);

        BindGrid();
    }

    protected void BindGrid()
    {
        odsData.SelectParameters["compid"].DefaultValue = base.companyid.ToString();
        odsData.SelectParameters["status"].DefaultValue =ddlAudit.SelectedValue;
        odsData.SelectParameters["sitename"].DefaultValue = txtname.Text;
        gridList.DataSourceID = odsData.ID;
        gridList.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        BindGrid();
    }
    protected void gridList_DataBound(object sender, EventArgs e)
    {
        foreach (GridViewRow gvr in gridList.Rows)
        {
            gvr.Cells[6].Text = CommonData.GetAuditStatusItemName(gvr.Cells[6].Text);
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        //批准通过网站
        DoAuditSite(1);
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        //拒绝网站
        DoAuditSite(2);
    }

    private void DoAuditSite(int status)
    {
        List<string> ids = new List<string>();

        foreach (GridViewRow gvr in gridList.Rows)
        {
            if (((CheckBox)gvr.FindControl("item")).Checked)
            {
                ids.Add(gridList.DataKeys[gvr.RowIndex].Value.ToString());
            }
        }

        if (ids.Count > 0)
        {
          
            wgiAdUnionSystem.BLL.wgi_adhost_usersite bau = new wgiAdUnionSystem.BLL.wgi_adhost_usersite();
            bau.ChangeApplySiteStatus(ids, status);
            //重绑数据
            BindGrid();
        }
    }
}
