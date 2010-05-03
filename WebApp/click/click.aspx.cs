using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class click : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //预览链接不操作
        if (Request["preview"] == "1")
        {
            Response.Write("测试成功！请拷贝广告代码至自己的网站合适的位置。");
            return;
        }

        //step1:得到用户id，用户网站id,广告id，广告主id，广告类型，付费类型
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
            model.statistype = 2;//1表示点击数
            model.userid = userid;

            try
            {
                new wgiAdUnionSystem.BLL.wgi_adv_statis().Add(model);
            }
            catch (Exception)
            {
                //throw:
            }

            finally
            { 
                //本次点击重定向到广告主自设的cookie记录页，并传过去从广告ID得到的广告地址
                string adurl = new wgiAdUnionSystem.BLL.wgi_adv().GetModel(adid).advlink;
                string destination = new wgiAdUnionSystem.BLL.wgi_adhost().GetModel(shopid).cookiepage;

                destination += "?union=wgiadunion&siteid=" + siteid + "&userid=" + userid + "&shopid=" + shopid + "&url=" + adurl;
                Response.Clear();
                Response.Redirect(destination);
                Response.End();
            }
        }
	    else
	    {
            Response.Redirect("/member/default.aspx");
	    }
    }
}
