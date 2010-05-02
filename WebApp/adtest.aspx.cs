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
        if (!object.Equals(uc, DBNull.Value) && uc != null)
        {
            /*需要的数据
             * 订单ID
             * 商品ID（可选）
             * 商品链接（可选）
             * 单价
             * 数量
             * 金额
             * 传送数据日期（不同于付款/成效日期，因为这个可以从订单ID追溯到）
             * 订单来源ID（处理成siteid)
             */
            int orderid, itemid, siteid;
            string itemurl, price, amount, total;
            DateTime time = DateTime.Now;

            Response.Write("has cookie");

        }
    }

}
