using System;
using System.Collections.Generic;
using System.Text;

using System.Web.UI.WebControls;
using System.Web.UI;
using Wgi.Web.UI.Controls.RichGridViewFunction;

[assembly: System.Web.UI.WebResource("Wgi.Web.UI.Controls.RichGridView.Resources.Asc.gif", "image/gif")]
[assembly: System.Web.UI.WebResource("Wgi.Web.UI.Controls.RichGridView.Resources.Desc.gif", "image/gif")]
[assembly: System.Web.UI.WebResource("Wgi.Web.UI.Controls.RichGridView.Resources.Icon.bmp", "image/bmp")]

[assembly: System.Web.UI.WebResource("Wgi.Web.UI.Controls.RichGridView.Resources.StyleLibrary.css", "text/css")]

#if DEBUG
[assembly: System.Web.UI.WebResource("Wgi.Web.UI.Controls.RichGridView.Resources.ScriptLibraryDebug.js", "text/javascript")]
#else
[assembly: System.Web.UI.WebResource("Wgi.Web.UI.Controls.RichGridView.Resources.ScriptLibrary.js", "text/javascript")]
#endif

namespace Wgi.Web.UI.Controls
{
    /// <summary>
    /// RichGridView类，继承自GridView
    /// </summary>
    [ToolboxData(@"<{0}:RichGridView runat='server'></{0}:RichGridView>")]
    [System.Drawing.ToolboxBitmap(typeof(Wgi.Web.UI.Controls.Resources.Icon), "RichGridView.bmp")]
    public partial class RichGridView : GridView
    {
        // 需要扩展的功能对象容器
        private List<ExtendFunction> _efs = new List<ExtendFunction>();
        // 数据源对象
        private object _dataSourceObject = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        public RichGridView()
        {

        }

        /// <summary>
        /// OnInit
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            this.PreRender += new EventHandler(RichGridView_PreRender);

            // 将需要扩展的功能对象添加到功能扩展列表里
            if (!String.IsNullOrEmpty(this._mouseOverCssClass))
                this._efs.Add(new MouseOverCssClassFunction());

            if (this._smartSorting != null)
                this._efs.Add(new SmartSortingFunction());

            if (this._clientButtons != null)
                this._efs.Add(new ClientButtonFunction());

            if (this._cascadeCheckboxes != null)
                this._efs.Add(new CascadeCheckboxFunction());

            if (this._fixRowColumn != null)
                this._efs.Add(new FixRowColumnFunction());

            if (this._checkedRowCssClass != null)
                this._efs.Add(new CheckedRowCssClassFunction());

            if (!String.IsNullOrEmpty(this.BoundRowClickCommandName))
                this._efs.Add(new RowClickFunction());

            if (!String.IsNullOrEmpty(this.BoundRowDoubleClickCommandName))
                this._efs.Add(new RowDoubleClickFunction());

            if (this._contextMenus != null)
                this._efs.Add(new ContextMenuFunction());

            if (this._customPagerSettings != null && this.AllowPaging)
                this._efs.Add(new CustomPagerSettingsFunction());

            if (!String.IsNullOrEmpty(this._mergeCells))
                this._efs.Add(new MergeCellsFunction());

            // 遍历需要实现的功能扩展，并实现它
            foreach (ExtendFunction ef in this._efs)
            {
                ef.RichGridView = this;
                ef.Complete();
            }


            ObjectDataSource ods = this.Parent.FindControl(this.DataSourceID) as ObjectDataSource;
            if (ods != null)
            {
                ods.Selected += new ObjectDataSourceStatusEventHandler(ods_Selected);
            }

            base.OnInit(e);
        }

        /// <summary>
        /// OnLoad
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            if (this._dataSourceObject == null)
            {
                _dataSourceObject = this.DataSource;
            }

            base.OnLoad(e);
        }

        /// <summary>
        /// RichGridView的PreRender事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void RichGridView_PreRender(object sender, EventArgs e)
        {
            if (!this.Page.ClientScript.IsClientScriptIncludeRegistered(this.GetType(), "yy_sgv_ScriptLibrary"))
            {
                // 注册所需脚本
                this.Page.ClientScript.RegisterClientScriptInclude
                (
                    this.GetType(),
                    "yy_sgv_ScriptLibrary",
                    this.Page.ClientScript.GetWebResourceUrl
                    (
                        #if DEBUG
                        this.GetType(), "Wgi.Web.UI.Controls.RichGridView.Resources.ScriptLibraryDebug.js"
                        #else
                        this.GetType(), "Wgi.Web.UI.Controls.RichGridView.Resources.ScriptLibrary.js"
                        #endif
                    )
                );

                // for asp.net ajax
                this.Page.ClientScript.RegisterStartupScript(
                    this.GetType(), 
                    "yy_sgv_ScriptLibrary_ajax", 
                    "if (typeof(Sys) != 'undefined') Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function endRequestHandler(sender, e){yy_sgv_ccListener();yy_sgv_crListener();});", 
                    true);

                // 注册所需样式
                System.Web.UI.HtmlControls.HtmlLink link = new System.Web.UI.HtmlControls.HtmlLink();
                link.Attributes["type"] = "text/css";
                link.Attributes["rel"] = "stylesheet";
                link.Attributes["href"] = Page.ClientScript.GetWebResourceUrl(this.GetType(), "Wgi.Web.UI.Controls.RichGridView.Resources.StyleLibrary.css");
                this.Page.Header.Controls.Add(link);
            }

            // this.Page.ClientScript.RegisterClientScriptResource(this.GetType(), "Wgi.Web.UI.Controls.RichGridView.ScriptLibrary.js");
        }

        /// <summary>
        /// RichGridView的对象数据源控件的Selected事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ods_Selected(object sender, ObjectDataSourceStatusEventArgs e)
        {
            if (this._dataSourceObject == null)
            {
                this._dataSourceObject = e.ReturnValue;
            }
        }

        /// <summary>
        /// OnRowDataBound
        /// </summary>
        /// <param name="e">e</param>
        protected override void OnRowDataBound(GridViewRowEventArgs e)
        {
            DataControlRowType rowType = e.Row.RowType;

            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                GridViewTableCell gvtc = new GridViewTableCell(e.Row.Cells[i], i, e.Row.RowType, e.Row.RowState);

                OnRowDataBoundCell(gvtc);
            }

            if (rowType == DataControlRowType.DataRow)
            {
                OnRowDataBoundDataRow(e);
            }

            base.OnRowDataBound(e);
        }

        /// <summary>
        /// Render
        /// </summary>
        /// <param name="writer">writer</param>
        protected override void Render(HtmlTextWriter writer)
        {
            OnRenderBegin(writer);

            base.Render(writer);

            OnRenderEnd(writer);
        }

        /// <summary>
        /// InitializePager
        /// </summary>
        /// <param name="row">一个 System.Web.UI.WebControls.GridViewRow，表示要初始化的页导航行</param>
        /// <param name="columnSpan">页导航行应跨越的列数</param>
        /// <param name="pagedDataSource">一个 System.Web.UI.WebControls.PagedDataSource，表示数据源</param>
        protected override void InitializePager(GridViewRow row, int columnSpan, PagedDataSource pagedDataSource)
        {
            base.InitializePager(row, columnSpan, pagedDataSource);

            OnInitPager(row, columnSpan, pagedDataSource);
        }

        /// <summary>
        /// RichGridView的数据源对象
        /// </summary>
        public new object DataSourceObject
        {
            get { return this._dataSourceObject; }
            set { this._dataSourceObject = value; }
        }
    }
}
