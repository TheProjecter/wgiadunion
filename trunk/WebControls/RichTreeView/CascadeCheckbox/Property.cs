﻿using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel;
using System.Web.UI;

namespace Wgi.Web.UI.Controls
{
    /// <summary>
    /// RichTreeView类的属性部分
    /// </summary>
    public partial class RichTreeView
    {
        private bool _allowCascadeCheckbox;
        /// <summary>
        /// 是否启用联动复选框功能
        /// </summary>
        [
        Browsable(true),
        Description("是否启用联动复选框功能"),
        Category("扩展"),
        DefaultValue(false)
        ]
        public virtual bool AllowCascadeCheckbox
        {
            get { return _allowCascadeCheckbox; }
            set { _allowCascadeCheckbox = value; }
        }

    }
}
