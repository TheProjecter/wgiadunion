using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Helper;

public partial class SysManage_Hospital_List : ValidatePage
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
        gridList.DataSourceID = odsData.ID;
        gridList.DataBind();

        

    }
    protected void ddlPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddl = sender as DropDownList;
        this.gridList.PageIndex = int.Parse(ddl.SelectedValue);
    }
    protected void gridList_DataBound(object sender, EventArgs e)
    {
        //设置分页
       HelperGridView.InitGridViewPage(gridList,odsData);
        //添加表格属性
      // string josinString = "{RowPro:[{\"onclick\":\"doRow(this);\"}],ColPro:[{\"class\":\"contextTD\",\"onclick\":\"doCell(this);\"}]}";
      // Helper.HelperGridView.AddGridViewPropoter(gridList, josinString);
       HelperGridView.AddGridViewContextMenu(gridList);
    }
    protected void btnDel_Click(object sender, EventArgs e)
    {
        string ids = string.Empty;
        for (int i = 0; i < gridList.Rows.Count; i++)
        {
            CheckBox cbox = (CheckBox)gridList.Rows[i].FindControl("chkItem");
            if (cbox.Checked)
            {
                ids += i.ToString() + ",";
            }
        }
        txtName.Text = "删除数据"+ids;
    }
}
