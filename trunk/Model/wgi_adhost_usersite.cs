using System;
namespace wgiAdUnionSystem.Model
{
    /// <summary>
    /// 实体类wgi_adhost_usersite 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class wgi_adhost_usersite
    {
        public wgi_adhost_usersite()
        { }
        #region Model
        private int _auid;
        private int? _companyid;
        private int? _siteid;
        private int? _status;
        private DateTime? _applytime;
        /// <summary>
        /// 
        /// </summary>
        public int auid
        {
            set { _auid = value; }
            get { return _auid; }
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
        public int? siteid
        {
            set { _siteid = value; }
            get { return _siteid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? applytime
        {
            set { _applytime = value; }
            get { return _applytime; }
        }
        #endregion Model

    }
}

