using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel;

namespace Wgi.Web.UI.Controls
{
    /// <summary>
    /// RichGridView类的属性部分
    /// </summary>
    public partial class RichGridView
    {
        private string _mouseOverCssClass;
        /// <summary>
        /// 鼠标经过行时行的 CSS 类名
        /// </summary>
        [
        Browsable(true),
        Description("鼠标经过行时行的 CSS 类名"), 
        Category("扩展")
        ]
        public virtual string MouseOverCssClass
        {
            get { return _mouseOverCssClass; }
            set { _mouseOverCssClass = value; }
        }
    }
}
