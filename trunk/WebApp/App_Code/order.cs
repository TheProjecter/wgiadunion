using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;

/// <summary>
///order 的摘要说明
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
//若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。 
// [System.Web.Script.Services.ScriptService]
public class order : System.Web.Services.WebService
{

    public order()
    {

        //如果使用设计的组件，请取消注释以下行 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    [WebMethod]
    public double Add(double a, double b)
    {
        return a + b;
    }

    [WebMethod]
    public string RecordOrderInfo(int shopid, int userid, string orderno, string comsumer, string itemno, int siteid, double price, double amount, double total, string itemurl)
    {
        wgiAdUnionSystem.Model.wgi_orders model = new wgiAdUnionSystem.Model.wgi_orders();
        model.cash = Convert.ToDecimal(total);
        model.companyid = shopid;
        model.consumer = comsumer;
        model.ischeck = 0;
        model.itemamount = Convert.ToDecimal(amount);
        model.itemno = itemno;
        model.itemprice = Convert.ToDecimal(price);
        //model.orderid = orderid;
        model.orderno = orderno;
        model.reason = "";
        model.siteid = siteid;
        model.time = DateTime.Now;//或传入
        model.userid = userid;

        //计算佣金
        model.pay = Convert.ToDecimal(22);

        //添加订单记录
        new wgiAdUnionSystem.BLL.wgi_orders().Add(model);

        //把佣金计入广告主
        wgiAdUnionSystem.BLL.wgi_sitehost bll = new wgiAdUnionSystem.BLL.wgi_sitehost();
        wgiAdUnionSystem.Model.wgi_sitehost host= bll.GetModel(userid);
        decimal newBlance= Convert.ToDecimal(host.balance) + Convert.ToDecimal(model.pay);
        bll.UpdateBlance(userid, newBlance);

        return newBlance.ToString();
    }

}

