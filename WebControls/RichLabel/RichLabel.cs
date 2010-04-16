using System;
using System.Collections.Generic;
using System.Text;

using System.Web.UI.WebControls;
using System.Web.UI;

[assembly: System.Web.UI.WebResource("Wgi.Web.UI.Controls.RichLabel.Resources.ScriptLibrary.js", "text/javascript")]

namespace Wgi.Web.UI.Controls
{
    /// <summary>
    /// RichLabel类，继承自DropDownList
    /// </summary>
    [ToolboxData(@"<{0}:RichLabel runat='server'></{0}:RichLabel>")]
    [System.Drawing.ToolboxBitmap(typeof(Wgi.Web.UI.Controls.Resources.Icon), "RichLabel.bmp")]
    public partial class RichLabel : Label
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public RichLabel()
        {

        }

        /// <summary>
        /// OnPreRender
        /// </summary>
        /// <param name="e">e</param>
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            // 实现Label控件的回发(Postback)功能
            ImplementPostback();
        }
    }
}
