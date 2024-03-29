﻿using System;
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
        private string _boundRowClickCommandName;
        /// <summary>
        /// 行的单击事件需要绑定的CommandName
        /// </summary>
        [
        Browsable(true),
        Description("行的单击事件需要绑定的CommandName"), 
        Category("扩展")
        ]
        public virtual string BoundRowClickCommandName
        {
            get { return _boundRowClickCommandName; }
            set { _boundRowClickCommandName = value; }
        }
    }
}
