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
        private CascadeCheckboxes _cascadeCheckboxes;
        /// <summary>
        /// 联动复选框
        /// </summary>
        [
        Description("联动复选框"),
        Category("扩展"),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
        PersistenceMode(PersistenceMode.InnerProperty)
        ]
        public virtual CascadeCheckboxes CascadeCheckboxes
        {
            get 
            {
                if (_cascadeCheckboxes == null)
                {
                    _cascadeCheckboxes = new CascadeCheckboxes();
                }
                return _cascadeCheckboxes; 
            }
        }
    }
}
