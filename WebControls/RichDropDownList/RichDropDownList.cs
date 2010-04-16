using System;
using System.Collections.Generic;
using System.Text;

using System.Web.UI.WebControls;
using System.Web.UI;

[assembly: System.Web.UI.WebResource("Wgi.Web.UI.Controls.RichDropDownList.Resources.Icon.bmp", "image/bmp")]

namespace Wgi.Web.UI.Controls
{
    /// <summary>
    /// RichDropDownList类，继承自DropDownList
    /// </summary>
    [ToolboxData(@"<{0}:RichDropDownList runat='server'></{0}:RichDropDownList>")]
    [System.Drawing.ToolboxBitmap(typeof(Wgi.Web.UI.Controls.Resources.Icon), "RichDropDownList.bmp")]
    public partial class RichDropDownList : DropDownList
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public RichDropDownList()
        {

        }

        /// <summary>
        /// 将控件的内容呈现到指定的编写器中
        /// </summary>
        /// <param name="writer">writer</param>
        protected override void RenderContents(HtmlTextWriter writer) 
        {
            // 呈现Option或OptionGroup
            OptionGroupRenderContents(writer);
        }
    }
}
