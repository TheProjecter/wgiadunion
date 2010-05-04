using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class adtest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void sendInfo(object sender, EventArgs e)
    {
        //检查cookie
        HttpCookie uc = Request.Cookies["adunioncookie"];
        if (!object.Equals(uc, DBNull.Value) || uc != null)
        {
            /*需要的数据
             * 商城ID
             * 订单ID
             * 商品ID（可选）
             * 商品链接（可选）
             * 单价
             * 数量
             * 金额
             * 传送数据日期（不同于付款/成效日期，因为这个可以从订单ID追溯到）
             * 订单来源ID（处理成siteid)
             */
            int shopid, siteid, userid;
            string orderno, itemno, itemurl, consumer;
            double price, amount, total;
            DateTime time = DateTime.Now;

            //来自cookie的信息
            string[] infos = new string[] { "" };
            infos = uc.Value.Split(new char[] { '|' });
            shopid = int.Parse(infos[1]);
            siteid = int.Parse(infos[2]);
            userid = int.Parse(infos[3]);

            //来自订单的信息
            orderno = "A3434239BB3";
            itemno = "CC34924";
            itemurl = "testurl";
            price = 355.50;
            amount = 1;
            total = 355.50;
            consumer = "张三";


            //调用webservice
            //Response.Write(new OrderRecord.order().RecordOrderInfo(shopid,orderno,));
            OrderRecord.order o = new OrderRecord.order();
            string b=o.RecordOrderInfo(shopid, userid, orderno, consumer, itemno, siteid, price, amount, total, itemurl);
            Response.Write("该用户账户余额：" + b + "元");
        }
    }

}
