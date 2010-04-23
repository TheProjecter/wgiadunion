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

public partial class click_showCtr : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //统计露出数

        //得到用户id，用户网站id,广告id，广告主id，广告类型
        int shopid, adid, siteid, userid, paytype, adtype;
        if (int.TryParse(Request["shopid"], out shopid) && int.TryParse(Request["adid"], out adid) && int.TryParse(Request["userid"], out userid) && int.TryParse(Request["siteid"], out siteid) && int.TryParse(Request["paytype"], out paytype) && int.TryParse(Request["adtype"], out adtype))
        {
            //写入数据库 
            wgiAdUnionSystem.Model.wgi_adv_statis model = new wgiAdUnionSystem.Model.wgi_adv_statis();
            model.advid = adid;
            model.advtype = paytype;//广告类型即为付费类型，而不是文字、图片之类的类型
            model.companyid = shopid;
            model.ip = CommonData.GetIp(this.Page);
            model.recordtime = DateTime.Now;
            model.siteid = siteid;
            model.statistype = 1;//1表示露出数
            model.userid = userid;

            try
            {
                new wgiAdUnionSystem.BLL.wgi_adv_statis().Add(model);
            }
            catch (Exception)
            {
                //throw:
            }
        }
    }
}
