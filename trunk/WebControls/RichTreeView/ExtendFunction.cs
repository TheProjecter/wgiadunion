using System;
using System.Collections.Generic;
using System.Text;

namespace Wgi.Web.UI.Controls.RichTreeViewFunction
{
    /// <summary>
    /// 扩展功能类，抽象类
    /// </summary>
    public abstract class ExtendFunction
    {
        /// <summary>
        /// RichTreeView对象变量
        /// </summary>
        protected RichTreeView _stv;

        /// <summary>
        /// 构造函数
        /// </summary>
        public ExtendFunction()
        {
            
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="stv">RichTreeView对象</param>
        public ExtendFunction(RichTreeView stv)
        {
            this._stv = stv;
        }

        /// <summary>
        /// RichTreeView对象
        /// </summary>
        public RichTreeView RichTreeView
        {
            get { return this._stv; }
            set { this._stv = value; }
        }

        /// <summary>
        /// 实现扩展功能
        /// </summary>
        public void Complete()
        {
            if (this._stv == null)
            {
                throw new ArgumentNullException("RichTreeView", "扩展功能时未设置RichTreeView对象");
            }
            else
            {
                Execute();
            }
        }

        /// <summary>
        /// 扩展功能的具体实现
        /// </summary>
        protected abstract void Execute();
    }
}
