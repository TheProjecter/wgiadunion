using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Helper
{
	/// <summary>
	/// HelperDatagrid
	/// </summary>
	public class HelperDatagrid
	{
		private HelperDatagrid(){}

		/// <summary>
		/// Bind datagrid with sorting dataview.
		/// </summary>
		/// <param name="ds">DataSet</param>
		/// <param name="dataGrid">DataGrid</param>
		/// <param name="sortField">Sorting Field</param>
		/// <param name="keyField">DataGrid's Key Field</param>
		public static void BindAndSort(DataSet ds,DataGrid dataGrid,string sortField,string keyField) 
		{
			DataView dataView	= ds.Tables[0].DefaultView;
			dataView.Sort = sortField;
			dataGrid.DataSource = dataView;
			dataGrid.DataKeyField=keyField;
			dataGrid.DataBind();
		}

		/// <summary>
		/// Bind datagrid with sorting dataview.
		/// </summary>
		/// <param name="dv">DataView</param>
		/// <param name="dataGrid">DataGrid</param>
		/// <param name="sortField">Sorting Field</param>
		/// <param name="keyField">DataGrid's Key Field</param>
		public static void BindAndSort(DataView dv,DataGrid dataGrid,string sortField,string keyField) 
		{
			if(dv != null)
				dv.Sort = sortField;
			dataGrid.DataSource = dv;
			dataGrid.DataKeyField=keyField;
			dataGrid.DataBind();
		}

		/// <summary>
		/// Change DataRow style once your mouse move over or out it.
		/// Then go to the url you wanted.
		/// </summary>
		/// <param name="e">DataGridItemEventArgs</param>
		public static void RowClick(DataGridItemEventArgs e)
		{
			e.Item.Attributes.Add("onmouseover","OnItem_Active(this);");
			e.Item.Attributes.Add("onmouseout","OnItem_InActive(this);");
		}

		/// <summary>
		/// Change datarow style once your mouse move over or out it.
		/// Then go to the url you wanted.
		/// </summary>
		/// <param name="e">DataGridItemEventArgs</param>
		/// <param name="url">The url you wanted to go</param>
		/// <param name="urlParm">Url parameters</param>
		/// <param name="urlParmValue">Parameters' values</param>
		public static void RowClick(DataGridItemEventArgs e,string url,string urlParmValue,string title)
		{
			e.Item.Attributes.Add("onmouseover","OnItem_Active(this);this.style.cursor='hand';");
			e.Item.Attributes.Add("onmouseout","OnItem_InActive(this);");
			e.Item.Attributes.Add("onclick","javascript:window.location='"+url+urlParmValue+"'");
			e.Item.Attributes.Add("id", urlParmValue);
			if(title != string.Empty) e.Item.Attributes.Add("title",title);
		}

		public static void RowClick(DataGridItemEventArgs e,string id)
		{
			e.Item.Attributes.Add("id", id);
		}

		/// <summary>
		/// Change datarow style once your mouse move over or out it.
		/// Then go to the url you wanted.
		/// </summary>
		/// <param name="e">DataGridItemEventArgs</param>
		/// <param name="url">The url you wanted to go</param>
		/// <param name="urlParm">Url parameters</param>
		/// <param name="urlParmValue">Parameters' values</param>
		public static void RowClickHideShow(string DataGridID,DataGridItemEventArgs e,string id,string title)
		{
			e.Item.Attributes.Add("onmouseover","OnItem_Active(this);this.style.cursor='hand';");
			e.Item.Attributes.Add("onmouseout","OnItem_InActive(this);");
			e.Item.Attributes.Add("onclick","AddTableRow('TimeSheetGrid',"+e.Item.ItemIndex+","+id+");");
			if(title != string.Empty) e.Item.Attributes.Add("title",title);
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
		public static void CellClick(DataGridItemEventArgs e,int cellIndex,string url,string urlParm,string urlParmValue)
		{
			e.Item.Cells[cellIndex].Attributes.Add("onmouseover","this.style.cursor='hand'");
			e.Item.Cells[cellIndex].Attributes.Add("onclick","javascript:window.location='"+url+"?"+urlParm+"="+urlParmValue+"'");
		}

		public static void SortAndShowArrow(DataGrid datagrid,string sortOrder,int asc,string imgArrow,string imgRArrow)
		{
			foreach(DataGridColumn column in datagrid.Columns)
			{
				column.HeaderText = column.HeaderText.Replace(imgArrow,"").Replace(imgRArrow,"");
				if(sortOrder == column.SortExpression)
				{
					if(asc == 0) column.HeaderText = column.HeaderText+imgRArrow;
					if(asc == 1) column.HeaderText = column.HeaderText+imgArrow;
				}
			}	
		}

		public static void RowClick_Edit(DataGridItemEventArgs e,int editButtonIndex)
		{
			e.Item.Attributes.Add("onmouseover","OnItem_Active(this);this.style.cursor='hand';");
			e.Item.Attributes.Add("onmouseout","OnItem_InActive(this);");
			e.Item.Attributes.Add("onclick","__doPostBack('"+((LinkButton)e.Item.Cells[editButtonIndex].Controls[0]).ClientID.Replace("__","$_")+"','')");
		}
	}
}
