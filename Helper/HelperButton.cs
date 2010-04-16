using System;
using System.Web.UI.WebControls;

namespace Helper
{
	/// <summary>
	/// HelperLinkButton
	/// </summary>
	public class HelperButton
	{
		private HelperButton(){}

		public static LinkButton GetLinkButton(string text,string css)
		{
			return GetLinkButton(text,css,string.Empty);
		}

		public static LinkButton GetLinkButton(string text,string css,string id)
		{
			LinkButton linkButton = new LinkButton();
			linkButton.Text = text;
			if(id.Length >0) linkButton.ID = id;
			if(css.Length > 0) linkButton.CssClass = css;
			return linkButton;
		}


		public static Button GetButton(string text,string css)
		{
			Button button = new Button();
			button.Text = text;
			if(css.Length > 0) button.CssClass = css;
			return button;
		}

		public static string GetHrefButton(string text,string css,string script)
		{
			return "<A class='"+css+"' href='javascript:void(0)' "+script+">"+text+"</A>";
		}
	}
}
