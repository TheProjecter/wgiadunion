using System;
using System.Collections.Generic;
using System.Text;

using System.Web.UI.WebControls;
using System.Web.UI;

namespace Wgi.Web.UI.Controls.RichGridViewFunction
{
    /// <summary>
    /// 扩展功能：根据按钮的CommandName设置其客户端属性
    /// </summary>
    public class ClientButtonFunction : ExtendFunction
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ClientButtonFunction()
            : base()
        {

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="sgv">RichGridView对象</param>
        public ClientButtonFunction(RichGridView sgv)
            : base(sgv)
        {

        }

        /// <summary>
        /// 扩展功能的实现
        /// </summary>
        protected override void Execute()
        {
            this._sgv.RowDataBoundCell += new RichGridView.RowDataBoundCellHandler(_sgv_RowDataBoundCell);
        }

        /// <summary>
        /// RichGridView的RowDataBoundCell事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="gvtc"></param>
        void _sgv_RowDataBoundCell(object sender, GridViewTableCell gvtc)
        {
            TableCell tc = gvtc.TableCell;

            // TableCell里的每个Control
            foreach (Control c in tc.Controls)
            {
                // 如果控件继承自接口IButtonControl
                if (c is IButtonControl)
                {
                    // 从用户定义的ClientButtons集合中分解出ClientButton
                    foreach (ClientButton cb in this._sgv.ClientButtons)
                    {
                        // 如果在ClientButtons中绑定了该按钮的CommandName
                        if (((IButtonControl)c).CommandName == cb.BoundCommandName)
                        {
                            // 替换占位符{0}-CommandArgument；{1}-Text
                            string attributeValue = 
                                String.Format(
                                    cb.AttributeValue,
                                    ((IButtonControl)c).CommandArgument,
                                    ((IButtonControl)c).Text);
                            
                            // 设置按钮的客户端属性
                            Wgi.Web.UI.Controls.Helper.Common.SetAttribute(
                                (IAttributeAccessor)c, 
                                cb.AttributeKey, 
                                attributeValue, 
                                cb.Position);

                            break;
                        }
                    }
                }
            }
        }
    }
}
