using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Helper
{
	/// <summary>
	/// Summary description for HelperListBox.
	/// </summary>
	public class HelperListBox
	{
		private HelperListBox() {}

		public static ListBox GetListBox(string id, int rowCount, DataView dv, string dataValueField, string dataTextField, ListSelectionMode mode)
		{
			ListBox listBox = new ListBox();
			listBox.ID = id;
			listBox.Rows = rowCount;
			listBox.SelectionMode = mode;
			listBox.DataSource = dv;
			listBox.DataValueField = dataValueField;
			listBox.DataTextField = dataTextField;
			listBox.DataBind();
			return listBox;
		}
	}
}
