﻿using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.ComponentModel;
using System.Web.UI;

namespace Wgi.Web.UI.Controls
{
    /// <summary>
    /// ClientButton集合类
    /// 注意要继承自CollectionBase
    /// </summary>
    [ToolboxItem(false)]
    [ParseChildren(true)]
    public class ClientButtons : CollectionBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ClientButtons()
            : base()
        {

        }

        /// <summary>
        /// 实现IList接口
        /// 获取或设置指定索引处的元素。
        /// </summary>
        /// <param name="index">要获得或设置的元素从零开始的索引</param>
        /// <returns></returns>
        public ClientButton this[int index]
        {
            get
            {
                return (ClientButton)base.List[index];
            }
            set
            {
                base.List[index] = (ClientButton)value;
            }
        }

        /// <summary>
        /// 实现IList接口
        /// 将某项添加到 System.Collections.IList 中。
        /// </summary>
        /// <param name="item">要添加到 System.Collections.IList 的 System.Object。</param>
        public void Add(ClientButton item)
        {
            base.List.Add(item);
        }

        /// <summary>
        /// 实现IList接口
        /// 从 System.Collections.IList 中移除特定对象的第一个匹配项。
        /// </summary>
        /// <param name="index">要从 System.Collections.IList 移除的 System.Object</param>
        public void Remove(int index)
        {
            if (index > -1 && index < base.Count)
            {
                base.List.RemoveAt(index);
            }
        }
    }
}
