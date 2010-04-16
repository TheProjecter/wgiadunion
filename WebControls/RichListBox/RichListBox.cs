using System;
using System.Collections.Generic;
using System.Text;

using System.Web.UI.WebControls;
using System.Web.UI;

[assembly: System.Web.UI.WebResource("Wgi.Web.UI.Controls.RichListBox.Resources.Icon.bmp", "image/bmp")]

namespace Wgi.Web.UI.Controls
{
    /// <summary>
    /// RichListBox类，继承自ListBox
    /// </summary>
    [ToolboxData(@"<{0}:RichListBox runat='server'></{0}:RichListBox>")]
    [System.Drawing.ToolboxBitmap(typeof(Wgi.Web.UI.Controls.Resources.Icon), "RichListBox.bmp")]
    public partial class RichListBox : ListBox
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public RichListBox()
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
