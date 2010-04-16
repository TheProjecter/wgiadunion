using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel;
using System.Web.UI;

namespace Wgi.Web.UI.Controls
{
    /// <summary>
    /// RichDropDownList类的属性部分
    /// </summary>
    public partial class RichDropDownList
    {
        /// <summary>
        /// 用于添加RichDropDownList的分组项的ListItem的Value值
        /// </summary>
        [
        Browsable(true),
        Description("用于添加DropDownList的分组项的ListItem的Value值"),
        Category("扩展")
        ]
        public virtual string OptionGroupValue
        {
            get
            {
                string s = (string)ViewState["OptionGroupValue"];

                return (s == null) ? "optgroup" : s;
            }
            set
            {
                ViewState["OptionGroupValue"] = value;
            }
        }
    }
}
