using System;
using System.Collections.Generic;
using System.Text;

using System.Web.UI.WebControls;
using System.Web.UI;
using System.ComponentModel;
using Wgi.Web.UI.Controls.RichTreeViewFunction;

#if DEBUG
[assembly: System.Web.UI.WebResource("Wgi.Web.UI.Controls.RichTreeView.Resources.ScriptLibraryDebug.js", "text/javascript")]
#else
[assembly: System.Web.UI.WebResource("Wgi.Web.UI.Controls.RichTreeView.Resources.ScriptLibrary.js", "text/javascript")]
#endif

namespace Wgi.Web.UI.Controls
{
    /// <summary>
    /// RichTreeView类，继承自TreeView
    /// </summary>
    [ToolboxData(@"<{0}:RichTreeView runat='server'></{0}:RichTreeView>")]
    [System.Drawing.ToolboxBitmap(typeof(Wgi.Web.UI.Controls.Resources.Icon), "RichTreeView.bmp")]
    public partial class RichTreeView : TreeView
    {
        // 需要扩展的功能对象容器
        private List<ExtendFunction> _efs = new List<ExtendFunction>();

        /// <summary>
        /// OnInit
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            this.PreRender += new EventHandler(RichTreeView_PreRender);

            // 将需要扩展的功能对象添加到功能扩展列表里
            if (this._allowCascadeCheckbox)
                this._efs.Add(new CascadeCheckboxFunction());

            // 遍历需要实现的功能扩展，并实现它
            foreach (ExtendFunction ef in this._efs)
            {
                ef.RichTreeView = this;
                ef.Complete();
            }

            base.OnInit(e);
        }

        /// <summary>
        /// RichTreeView的PreRender事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void RichTreeView_PreRender(object sender, EventArgs e)
        {
            // 注册所需脚本
            if (!this.Page.ClientScript.IsClientScriptIncludeRegistered(this.GetType(), "yy_stv_scriptLibrary"))
            {
                this.Page.ClientScript.RegisterClientScriptInclude
                (
                    this.GetType(),
                    "yy_stv_scriptLibrary",
                    this.Page.ClientScript.GetWebResourceUrl
                    (
                        #if DEBUG
                        this.GetType(), "Wgi.Web.UI.Controls.RichTreeView.Resources.ScriptLibraryDebug.js"
                        #else
                        this.GetType(), "Wgi.Web.UI.Controls.RichTreeView.Resources.ScriptLibrary.js"
                        #endif
                    )
                );
            }
        }
    }
}
