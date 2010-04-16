using System;
using System.Web.UI.WebControls;

namespace Helper
{
	/// <summary>
	/// Summary description for HelperTextBox.
	/// </summary>
	public class HelperTextBox
	{
		private HelperTextBox() {}

		public static TextBox GetTextBox(string id, TextBoxMode textMode, int width, int rowCount, string css)
		{
			TextBox tb = new TextBox();
			tb.ID = id;
			tb.TextMode = textMode;
			tb.Width = width;
			tb.Rows = rowCount;
			tb.CssClass = css;
			return tb;
		}
	}
}
