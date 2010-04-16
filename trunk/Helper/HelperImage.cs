using System;
using System.Web.UI.WebControls;

namespace Helper
{
	/// <summary>
	/// HelperImage
	/// </summary>
	public class HelperImage
	{
		private HelperImage(){}

		public static Image GetImage(string path)
		{
			return GetImage(path,string.Empty);
		}

		public static Image GetImage(string path,string id)
		{
			Image image = new Image();
			if(id.Length >0) image.ID = id;
			image.ImageUrl	= path;
			return image;
		}
	}
}
