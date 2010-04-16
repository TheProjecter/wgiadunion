using System;
using System.Data;
using Jayrock.Json;
using System.Web.UI.WebControls;

namespace Helper
{
    /// <summary>
    /// HelperDatagrid
    /// </summary>
    public class HelperGridView
    {
        private HelperGridView() { }

        /// <summary>
        /// Bind datagrid with sorting dataview.
        /// </summary>
        /// <param name="ds">DataSet</param>
        /// <param name="dataGrid">DataGrid</param>
        /// <param name="sortField">Sorting Field</param>
        /// <param name="keyField">DataGrid's Key Field</param>
        public static void BindAndSort(DataSet ds, GridView dataGrid, string sortField, string keyField)
        {
            DataView dataView = ds.Tables[0].DefaultView;
            dataView.Sort = sortField;
            dataGrid.DataSource = dataView;
            dataGrid.DataMember = keyField;
            dataGrid.DataBind();
        }

        /// <summary>
        /// Bind datagrid with sorting dataview.
        /// </summary>
        /// <param name="dv">DataView</param>
        /// <param name="dataGrid">DataGrid</param>
        /// <param name="sortField">Sorting Field</param>
        /// <param name="keyField">DataGrid's Key Field</param>
        public static void BindAndSort(DataView dv, GridView dataGrid, string sortField, string keyField)
        {
            if (dv != null)
                dv.Sort = sortField;
            dataGrid.DataSource = dv;
            //dataGrid.DataKeyField=keyField;
            dataGrid.DataMember = keyField;
            dataGrid.DataBind();
        }

        /// <summary>
        /// Change DataRow style once your mouse move over or out it.
        /// Then go to the url you wanted.
        /// </summary>
        /// <param name="e">DataGridItemEventArgs</param>
        public static void RowClick(GridViewRowEventArgs e)
        {
            //e.Item.Attributes.Add("onmouseover","OnItem_Active(this);");
            //e.Item.Attributes.Add("onmouseout","OnItem_InActive(this);");
            e.Row.Attributes.Add("onmouseover", "OnItem_Active(this);");
            e.Row.Attributes.Add("onmouseout", "OnItem_InActive(this);");
        }

        /// <summary>
        /// Change datarow style once your mouse move over or out it.
        /// Then go to the url you wanted.
        /// </summary>
        /// <param name="e">DataGridItemEventArgs</param>
        /// <param name="url">The url you wanted to go</param>
        /// <param name="urlParm">Url parameters</param>
        /// <param name="urlParmValue">Parameters' values</param>
        public static void RowClick(GridViewRowEventArgs e, string url, string urlParmValue, string title)
        {
            //e.Item.Attributes.Add("onmouseover","OnItem_Active(this);this.style.cursor='hand';");
            //e.Item.Attributes.Add("onmouseout","OnItem_InActive(this);");
            //e.Item.Attributes.Add("onclick","javascript:window.location='"+url+urlParmValue+"'");
            //e.Item.Attributes.Add("id", urlParmValue);
            //if(title != string.Empty) e.Item.Attributes.Add("title",title);
            e.Row.Attributes.Add("onmouseover", "OnItem_Active(this);this.style.cursor='hand';");
            e.Row.Attributes.Add("onmouseout", "OnItem_InActive(this);");
            e.Row.Attributes.Add("onclick", "javascript:window.location='" + url + urlParmValue + "'");
            e.Row.Attributes.Add("id", urlParmValue);
            if (title != string.Empty) e.Row.Attributes.Add("title", title);
        }

        public static void RowClick(GridViewRowEventArgs e, string id)
        {
            e.Row.Attributes.Add("id", id);
        }

        /// <summary>
        /// Change datarow style once your mouse move over or out it.
        /// Then go to the url you wanted.
        /// </summary>
        /// <param name="e">DataGridItemEventArgs</param>
        /// <param name="url">The url you wanted to go</param>
        /// <param name="urlParm">Url parameters</param>
        /// <param name="urlParmValue">Parameters' values</param>
        public static void RowClickHideShow(string DataGridID, GridViewRowEventArgs e, string id, string title)
        {
            e.Row.Attributes.Add("onmouseover", "OnItem_Active(this);this.style.cursor='hand';");
            e.Row.Attributes.Add("onmouseout", "OnItem_InActive(this);");
            e.Row.Attributes.Add("onclick", "AddTableRow('TimeSheetGrid'," + e.Row.RowIndex + "," + id + ");");
            if (title != string.Empty) e.Row.Attributes.Add("title", title);
        }

        /// <summary>
        /// Change datacell style once your mouse move over or out it.
        /// Then go to the url you wanted
        /// </summary>
        /// <param name="e">DataGridItemEventArgs</param>
        /// <param name="cellIndex">Cell index</param>
        /// <param name="url">The url you wanted to go</param>
        /// <param name="urlParm">Url parameters</param>
        /// <param name="urlParmValue">Parameters' values</param>
        public static void CellClick(GridViewRowEventArgs e, int cellIndex, string url, string urlParm, string urlParmValue)
        {
            //e.Item.Cells[cellIndex].Attributes.Add("onmouseover","this.style.cursor='hand'");
            //e.Item.Cells[cellIndex].Attributes.Add("onclick","javascript:window.location='"+url+"?"+urlParm+"="+urlParmValue+"'");
            e.Row.Cells[cellIndex].Attributes.Add("onmouseover", "this.style.cursor='hand'");
            e.Row.Cells[cellIndex].Attributes.Add("onclick", "javascript:window.location='" + url + "?" + urlParm + "=" + urlParmValue + "'");

        }

        public static void SortAndShowArrow(GridView datagrid, string sortOrder, int asc, string imgArrow, string imgRArrow)
        {
            foreach (DataControlField column in datagrid.Columns)
            {
                column.HeaderText = column.HeaderText.Replace(imgArrow, "").Replace(imgRArrow, "");
                if (sortOrder == column.SortExpression)
                {
                    if (asc == 0) column.HeaderText = column.HeaderText + imgRArrow;
                    if (asc == 1) column.HeaderText = column.HeaderText + imgArrow;
                }
            }
        }

        public static void RowClick_Edit(GridViewRowEventArgs e, int editButtonIndex)
        {
            //e.Item.Attributes.Add("onmouseover","OnItem_Active(this);this.style.cursor='hand';");
            //e.Item.Attributes.Add("onmouseout","OnItem_InActive(this);");
            //e.Item.Attributes.Add("onclick","__doPostBack('"+((LinkButton)e.Item.Cells[editButtonIndex].Controls[0]).ClientID.Replace("__","$_")+"','')");
            e.Row.Attributes.Add("onmouseover", "OnItem_Active(this);this.style.cursor='hand';");
            e.Row.Attributes.Add("onmouseout", "OnItem_InActive(this);");
            e.Row.Attributes.Add("onclick", "__doPostBack('" + ((LinkButton)e.Row.Cells[editButtonIndex].Controls[0]).ClientID.Replace("__", "$_") + "','')");
        }

        /// <summary>
        /// 獲得ObjectDatasource中的數據
        /// </summary>
        /// <param name="ods"></param>
        public static System.Collections.ArrayList GetDataListFromDataSource(System.Web.UI.WebControls.ObjectDataSource ods)
        {
            System.Collections.IEnumerator datacursor = ods.Select().GetEnumerator();

            System.Collections.ArrayList datalist = new System.Collections.ArrayList();
            while (datacursor.MoveNext())
            {
                datalist.Add(datacursor.Current);
            }

            return datalist;
        }

        /// <summary>
        /// 绑定数据时初始化分页
        /// </summary>
        public static void InitGridViewPage(GridView gridList, ObjectDataSource odsData)
        {
            if (gridList.Rows.Count > 0)
            {
                //绑定总页数
                DropDownList ddl = gridList.BottomPagerRow.Cells[0].FindControl("ddlPage") as DropDownList;

                for (int i = 0; i < gridList.PageCount; i++)
                {
                    ddl.Items.Add(new ListItem((i + 1).ToString(), i.ToString()));

                }

                for (int i = 0; i < gridList.Rows.Count; i++)
                {

                    gridList.Rows[i].Attributes.Add("onmouseover", "this.className='table3';this.style.cursor='hand';");
                    gridList.Rows[i].Attributes.Add("onmouseout", "this.className='table4';");
                }
                ddl.SelectedIndex = gridList.PageIndex;

                Label lbltotal = (Label)gridList.BottomPagerRow.Cells[0].FindControl("lblTotalPage");

                lbltotal.Text = Helper.HelperGridView.GetDataListFromDataSource(odsData).Count.ToString();
            }
        }

        /// <summary>
        /// 添加上下文菜单
        /// </summary>
        public static void AddGridViewContextMenu(GridView gridList)
        {
            if (gridList.Rows.Count > 0)
            {
                for (int i = 0; i < gridList.Rows.Count; i++)
                {
                    gridList.Rows[i].Attributes.Add("id", "div" + i);

                    gridList.Rows[i].Attributes.Add("onclick", "doRow(this,"+i+");");

                    for (int j = 0; j < gridList.Rows[i].Cells.Count; j++)
                    {
                        gridList.Rows[i].Cells[j].Attributes.Add("id", "div_" + i + "_" + j);
                        gridList.Rows[i].Cells[j].Attributes.Add("class", "contextTD");
                        gridList.Rows[i].Cells[j].Attributes.Add("onclick", "doCell(this,"+i+","+j+");");
                    }
                }

            }
        }

        /// <summary>
        /// 添加行列的各种属性
        /// </summary>
        public static void AddGridViewPropoter(GridView gridList, string josinString)
        {
            if (gridList.Rows.Count > 0)
            {
                Jayrock.Json.JsonReader reader = new Jayrock.Json.JsonTextReader(new System.IO.StringReader(@josinString));
                JsonObject jsonObj = new JsonObject();
                jsonObj.Import(reader);

                JsonArray rowPro = (JsonArray)jsonObj["RowPro"];
                JsonArray colPro = (JsonArray)jsonObj["ColPro"];

                JsonObject item = null;

                for (int i = 0; i < gridList.Rows.Count; i++)
                {

                    gridList.Rows[i].Attributes.Add("id", "div" + i);

                    //添加行属性
                    item = rowPro.GetObject(0);
                    for (int k = 0; k < item.GetNamesArray().Count; k++)
                    {
                        string n = item.GetNamesArray()[k].ToString();
                        gridList.Rows[i].Attributes.Add(n, string.Format(item[n].ToString(),i));
                    }

                    for (int j = 0; j < gridList.Rows[i].Cells.Count; j++)
                    {
                        gridList.Rows[i].Cells[j].Attributes.Add("id", "div_" + i + "_" + j);

                        //添加单元格属性
                        item = null;
                        item = colPro.GetObject(0);
                        for (int k = 0; k < item.GetNamesArray().Count; k++)
                        {
                            string n = item.GetNamesArray()[k].ToString();
                            gridList.Rows[i].Cells[j].Attributes.Add(n,string.Format(item[n].ToString(),i,j));
                        }
                    }
                }

            }
        }
    }
}
