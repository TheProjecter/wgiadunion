using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using wgiAdUnionSystem.IDAL;
namespace wgiAdUnionSystem.DAL
{
    /// <summary>
    /// 数据访问类wgi_order。
    /// </summary>
    public class wgi_order : Iwgi_order
    {
        public wgi_order()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            string strsql = "select max(orderid)+1 from wgi_order";
            Database db = DatabaseFactory.CreateDatabase();
            object obj = db.ExecuteScalar(CommandType.Text, strsql);
            if (obj != null && obj != DBNull.Value)
            {
                return int.Parse(obj.ToString());
            }
            return 1;
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int orderid)
        {
            Database db = DatabaseFactory.CreateDatabase();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wgi_order where orderid=@orderid ");
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "orderid", DbType.Int32, orderid);
            int cmdresult;
            object obj = db.ExecuteScalar(dbCommand);
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(wgiAdUnionSystem.Model.wgi_order model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wgi_order(");
            strSql.Append("companyid,username,orderno,orderamt,ordertime,consumer,itemno,payamt,ischeck,ispay,reason,paytime)");

            strSql.Append(" values (");
            strSql.Append("@companyid,@username,@orderno,@orderamt,@ordertime,@consumer,@itemno,@payamt,@ischeck,@ispay,@reason,@paytime)");
            strSql.Append(";select @@IDENTITY");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "companyid", DbType.Int32, model.companyid);
            db.AddInParameter(dbCommand, "username", DbType.String, model.username);
            db.AddInParameter(dbCommand, "orderno", DbType.String, model.orderno);
            db.AddInParameter(dbCommand, "orderamt", DbType.Decimal, model.orderamt);
            db.AddInParameter(dbCommand, "ordertime", DbType.DateTime, model.ordertime);
            db.AddInParameter(dbCommand, "consumer", DbType.String, model.consumer);
            db.AddInParameter(dbCommand, "itemno", DbType.String, model.itemno);
            db.AddInParameter(dbCommand, "payamt", DbType.Decimal, model.payamt);
            db.AddInParameter(dbCommand, "ischeck", DbType.Int32, model.ischeck);
            db.AddInParameter(dbCommand, "ispay", DbType.Int32, model.ispay);
            db.AddInParameter(dbCommand, "reason", DbType.String, model.reason);
            db.AddInParameter(dbCommand, "paytime", DbType.DateTime, model.paytime);
            int result;
            object obj = db.ExecuteScalar(dbCommand);
            if (!int.TryParse(obj.ToString(), out result))
            {
                return 0;
            }
            return result;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(wgiAdUnionSystem.Model.wgi_order model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wgi_order set ");
            strSql.Append("companyid=@companyid,");
            strSql.Append("username=@username,");
            strSql.Append("orderno=@orderno,");
            strSql.Append("orderamt=@orderamt,");
            strSql.Append("ordertime=@ordertime,");
            strSql.Append("consumer=@consumer,");
            strSql.Append("itemno=@itemno,");
            strSql.Append("payamt=@payamt,");
            strSql.Append("ischeck=@ischeck,");
            strSql.Append("ispay=@ispay,");
            strSql.Append("reason=@reason,");
            strSql.Append("paytime=@paytime");
            strSql.Append(" where orderid=@orderid ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "orderid", DbType.Int32, model.orderid);
            db.AddInParameter(dbCommand, "companyid", DbType.Int32, model.companyid);
            db.AddInParameter(dbCommand, "username", DbType.String, model.username);
            db.AddInParameter(dbCommand, "orderno", DbType.String, model.orderno);
            db.AddInParameter(dbCommand, "orderamt", DbType.Decimal, model.orderamt);
            db.AddInParameter(dbCommand, "ordertime", DbType.DateTime, model.ordertime);
            db.AddInParameter(dbCommand, "consumer", DbType.String, model.consumer);
            db.AddInParameter(dbCommand, "itemno", DbType.String, model.itemno);
            db.AddInParameter(dbCommand, "payamt", DbType.Decimal, model.payamt);
            db.AddInParameter(dbCommand, "ischeck", DbType.Int32, model.ischeck);
            db.AddInParameter(dbCommand, "ispay", DbType.Int32, model.ispay);
            db.AddInParameter(dbCommand, "reason", DbType.String, model.reason);
            db.AddInParameter(dbCommand, "paytime", DbType.DateTime, model.paytime);
            db.ExecuteNonQuery(dbCommand);

        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int orderid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wgi_order ");
            strSql.Append(" where orderid=@orderid ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "orderid", DbType.Int32, orderid);
            db.ExecuteNonQuery(dbCommand);

        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public wgiAdUnionSystem.Model.wgi_order GetModel(int orderid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select orderid,companyid,username,orderno,orderamt,ordertime,consumer,itemno,payamt,ischeck,ispay,reason,paytime from wgi_order ");
            strSql.Append(" where orderid=@orderid ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "orderid", DbType.Int32, orderid);
            wgiAdUnionSystem.Model.wgi_order model = null;
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                if (dataReader.Read())
                {
                    model = ReaderBind(dataReader);
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select orderid,companyid,username,orderno,orderamt,ordertime,consumer,itemno,payamt,ischeck,ispay,reason,paytime ");
            strSql.Append(" FROM wgi_order ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("UP_GetRecordByPage");
            db.AddInParameter(dbCommand, "tblName", DbType.String, "wgi_order");
            db.AddInParameter(dbCommand, "fldName", DbType.String, "ID");
            db.AddInParameter(dbCommand, "PageSize", DbType.Int32, PageSize);
            db.AddInParameter(dbCommand, "PageIndex", DbType.Int32, PageIndex);
            db.AddInParameter(dbCommand, "IsReCount", DbType.Boolean, 0);
            db.AddInParameter(dbCommand, "OrderType", DbType.Boolean, 0);
            db.AddInParameter(dbCommand, "strWhere", DbType.String, strWhere);
            return db.ExecuteDataSet(dbCommand);
        }*/

        /// <summary>
        /// 获得数据列表（比DataSet效率高，推荐使用）
        /// </summary>
        public List<wgiAdUnionSystem.Model.wgi_order> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select orderid,companyid,username,orderno,orderamt,ordertime,consumer,itemno,payamt,ischeck,ispay,reason,paytime ");
            strSql.Append(" FROM wgi_order ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<wgiAdUnionSystem.Model.wgi_order> list = new List<wgiAdUnionSystem.Model.wgi_order>();
            Database db = DatabaseFactory.CreateDatabase();
            using (IDataReader dataReader = db.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public wgiAdUnionSystem.Model.wgi_order ReaderBind(IDataReader dataReader)
        {
            wgiAdUnionSystem.Model.wgi_order model = new wgiAdUnionSystem.Model.wgi_order();
            object ojb;
            ojb = dataReader["orderid"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.orderid = (int)ojb;
            }
            ojb = dataReader["companyid"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.companyid = (int)ojb;
            }
            model.username = dataReader["username"].ToString();
            model.orderno = dataReader["orderno"].ToString();
            ojb = dataReader["orderamt"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.orderamt = (decimal)ojb;
            }
            ojb = dataReader["ordertime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ordertime = (DateTime)ojb;
            }
            model.consumer = dataReader["consumer"].ToString();
            model.itemno = dataReader["itemno"].ToString();
            ojb = dataReader["payamt"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.payamt = (decimal)ojb;
            }
            ojb = dataReader["ischeck"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ischeck = (int)ojb;
            }
            ojb = dataReader["ispay"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ispay = (int)ojb;
            }
            model.reason = dataReader["reason"].ToString();
            ojb = dataReader["paytime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.paytime = (DateTime)ojb;
            }
            return model;
        }

        #endregion  成员方法

        /// <summary>
        /// 查询广告订单信息
        /// </summary>
        /// <param name="compid">广告主ID</param>
        /// <param name="status">订单核对状态</param>
        /// <param name="orderno">订单编号</param>
        /// <param name="buyer">订单购买人</param>
        /// <returns></returns>
        public DataTable GetAdvOrderList(int compid, int status, string orderno, string buyer)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select orderid,companyid,wgi_order.username,orderno,orderamt,ordertime,consumer,itemno,payamt,ischeck,ispay,reason,paytime ");
            strSql.Append(" FROM wgi_order left join wgi_sitehost sh on wgi_order.username=sh.username");
            strSql.Append(" where companyid=" + compid + " and ischeck=" + status);
            if (!string.IsNullOrEmpty(orderno))
            {
                strSql.AppendLine(" and orderno='" + orderno + "'");
            }
            if (!string.IsNullOrEmpty(buyer))
            {
                strSql.AppendLine(" and wgi_order.consumer like '%" + buyer + "%'");
            }
            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString()).Tables[0];

        }

        /// <summary>
        /// 查询获得订单的数据列表
        /// </summary>
        /// <param name="compid">广告主ID</param>
        /// <param name="status">订单核对状态</param>
        /// <param name="member">联盟会员名称</param>
        /// <param name="orderno">订单编号</param>
        /// <param name="buyer">订单购买人</param>
        /// <param name="sdate">查询订单起始时间</param>
        /// <param name="edate">查询订单结束时间</param>
        /// <returns></returns>
        public DataTable GetAdvOrderList(int compid, int status, string member,string orderno, string buyer, string sdate, string edate)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select orderid,companyid,wgi_order.username,orderno,orderamt,ordertime,consumer,itemno,payamt,ischeck,ispay,reason,paytime ");
            strSql.Append(" FROM wgi_order left join wgi_sitehost sh on wgi_order.username=sh.username");
            strSql.Append(" where companyid=" + compid + " and ischeck=" + status);
            if (!string.IsNullOrEmpty(orderno))
            {
                strSql.AppendLine(" and orderno='" + orderno + "'");
            }
            if (!string.IsNullOrEmpty(buyer))
            {
                strSql.AppendLine(" and wgi_order.consumer like '%" + buyer + "%'");
            }
            if (!string.IsNullOrEmpty(sdate))
            {
                strSql.AppendLine(" and ordertime >='" + sdate + "'");
            }
            if (!string.IsNullOrEmpty(edate))
            {
                strSql.AppendLine(" and ordertime <='" + edate + "'");
            }
            if (!string.IsNullOrEmpty(member))
            {
                strSql.AppendLine(" and wgi_order.username like '%" + member + "%'");
            }
            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString()).Tables[0];

        }

        /// <summary>
        /// 修改订单的核对状态
        /// </summary>
        /// <param name="compid">广告主ID</param>
        /// <param name="orderid">订单ID</param>
        /// <param name="status">订单核对状态</param>
        /// <returns></returns>
        public int SetAdvOrderStatus(int orderid, int status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wgi_order set  ischeck=" + status + " where orderid=" + orderid);

            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteNonQuery(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 核对订单操作
        /// </summary>
        /// <param name="orderid">订单ID</param>
        /// <param name="status">0表未核对/1表示有效/2表示无效订单</param>
        /// <param name="reason">填写无效订单的理由</param>
        /// <returns></returns>
        public int CheckAdvOrderStatus(int orderid, int status, string reason)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wgi_order set ischeck=" + status + ",reason='" + reason + "' where orderid=" + orderid);

            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteNonQuery(CommandType.Text, strSql.ToString());
        }
    }
}

