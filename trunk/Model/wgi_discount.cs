using System;
namespace wgiAdUnionSystem.Model
{
    /// <summary>
    /// 实体类wgi_discount 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class wgi_discount
    {
        public wgi_discount()
        { }
        #region Model
        private int _id;
        private int? _companyid;
        private string _payamt;
        private string _payintro;
        private DateTime? _endtime;
        private DateTime? _addtime;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
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
        public string payamt
        {
            set { _payamt = value; }
            get { return _payamt; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string payintro
        {
            set { _payintro = value; }
            get { return _payintro; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? endtime
        {
            set { _endtime = value; }
            get { return _endtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? addtime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        #endregion Model

    }
}

