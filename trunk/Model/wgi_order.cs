using System;
namespace wgiAdUnionSystem.Model
{
    /// <summary>
    /// 实体类wgi_order 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class wgi_order
    {
        public wgi_order()
        { }
        #region Model
        private int _orderid;
        private int? _companyid;
        private string _username;
        private string _orderno;
        private decimal? _orderamt;
        private DateTime? _ordertime;
        private string _consumer;
        private string _itemno;
        private decimal? _payamt;
        private int? _ischeck;
        private int? _ispay;
        private string _reason;
        private DateTime? _paytime;
        /// <summary>
        /// 
        /// </summary>
        public int orderid
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? companyid
        {
            set { _companyid = value; }
            get { return _companyid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string username
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string orderno
        {
            set { _orderno = value; }
            get { return _orderno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? orderamt
        {
            set { _orderamt = value; }
            get { return _orderamt; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ordertime
        {
            set { _ordertime = value; }
            get { return _ordertime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string consumer
        {
            set { _consumer = value; }
            get { return _consumer; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string itemno
        {
            set { _itemno = value; }
            get { return _itemno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? payamt
        {
            set { _payamt = value; }
            get { return _payamt; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ischeck
        {
            set { _ischeck = value; }
            get { return _ischeck; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ispay
        {
            set { _ispay = value; }
            get { return _ispay; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string reason
        {
            set { _reason = value; }
            get { return _reason; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? paytime
        {
            set { _paytime = value; }
            get { return _paytime; }
        }
        #endregion Model

    }
}

