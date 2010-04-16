using System;
using System.Collections.Generic;
using System.Text;

namespace Wgi.Web.UI.Controls.RichGridViewFunction
{
    /// <summary>
    /// 扩展功能类，抽象类
    /// </summary>
    public abstract class ExtendFunction
    {
        /// <summary>
        /// RichGridView对象变量
        /// </summary>
        protected RichGridView _sgv;

        /// <summary>
        /// 构造函数
        /// </summary>
        public ExtendFunction()
        {
            
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="sgv">RichGridView对象</param>
        public ExtendFunction(RichGridView sgv)
        {
            this._sgv = sgv;
        }

        /// <summary>
        /// RichGridView对象
        /// </summary>
        public RichGridView RichGridView
        {
            get { return this._sgv; }
            set { this._sgv = value; }
        }

        /// <summary>
        /// 实现扩展功能
        /// </summary>
        public void Complete()
        {
            if (this._sgv == null)
            {
                throw new ArgumentNullException("RichGridView", "扩展功能时未设置RichGridView对象");
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
