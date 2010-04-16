using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SysManage_User_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }
        else
        {
            if (hidact.Value == "del")
            {
                DeleteData();
                hidact.Value = "";
            }
            else if (hidact.Value == "docell")
            {
                string[] parms = hidparams.Value.Split(":".ToCharArray());
                txtName.Text = "您点击了第" + parms[0] + "行第" + parms[1] + "列的单元格！";
                hidact.Value = "";
                hidparams.Value = "";
            }
        }
    }
    protected void DeleteData()
    {
        string ids = string.Empty;
        for (int i = 0; i < gridList.Rows.Count; i++)
        {
            CheckBox cbox = (CheckBox)gridList.Rows[i].FindControl("item");
            if (cbox.Checked)
            {
                ids += i.ToString() + ",";
            }
        }
        txtName.Text = "删除数据" + ids;
    }

    protected void btn_Command(object sender, CommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "ExportExcel":
                gridList.Export("excel");
                break;
            case "ExportWord":
                gridList.Export("word", Wgi.Web.UI.Controls.ExportFormat.DOC);
                break;
            case "ExportText":
                gridList.Export("text", Wgi.Web.UI.Controls.ExportFormat.TXT);
                break;
        }
    }

    protected void gridList_DataBound(object sender, EventArgs e)
    {
        //添加表格属性
        string josinString = "{RowPro:[{\"onclick\":\"doRow(this,{0})\"}],ColPro:[{\"ondblclick\":\"doCell(this,{0},{1})\"}]}";
        Helper.HelperGridView.AddGridViewPropoter((GridView)gridList, josinString);
    }
    protected void gridList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "RightMenuClick")
        {
            this.txtName.Text = "你点击了第" + e.CommandArgument.ToString() + "行";
        }
    }

    
}
