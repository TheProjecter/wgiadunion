﻿using System;
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
        private string _mergeCells;
        /// <summary>
        /// 需要合并单元格的列的索引（用逗号“,”分隔）
        /// </summary>
        [
        Browsable(true),
        Description("需要合并单元格的列的索引（用逗号“,”分隔）"), 
        Category("扩展")
        ]
        public virtual string MergeCells
        {
            get { return _mergeCells; }
            set { _mergeCells = value; }
        }
    }
}
