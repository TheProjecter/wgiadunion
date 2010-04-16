using System;
using System.Web.UI.WebControls;

namespace Helper
{
	/// <summary>
	/// HelperLabel
	/// </summary>
	public class HelperLabel
	{
		private static readonly string CSS = "ms-vb";
		private HelperLabel(){}

		public static Label GetLabel(string text)
		{
			return GetLabel(text,CSS);
		}

		public static Label GetLabel(string text, string css)
		{
			Label label = new Label();
			label.Text	= text;
			label.CssClass = css;
			return label;
		}
	}
}
