using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel;
using System.Web.UI;

namespace Wgi.Web.UI.Controls
{
    /// <summary>
    /// RichGridView类的属性部分
    /// </summary>
    public partial class RichGridView
    {
        private string _boundRowDoubleClickCommandName;
        /// <summary>
        /// 行的双击事件需要绑定的CommandName
        /// </summary>
        [
        Browsable(true),
        Description("行的双击事件需要绑定的CommandName"),
        Category("扩展")
        ]
        public virtual string BoundRowDoubleClickCommandName
        {
            get { return _boundRowDoubleClickCommandName; }
            set { _boundRowDoubleClickCommandName = value; }
        }
    }
}
