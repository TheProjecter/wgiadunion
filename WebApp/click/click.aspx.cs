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
        if (Request["preview"] == "1") return;

        //step1:从网址辨认点击源
        int shopid,adid,siteid,paytype,adtype;
        shopid=adid=siteid=paytype=adtype=-1;
        try 
	    {	        
            shopid= int.Parse( Request["shopid"]);
            adid=int.Parse(Request["adid"]);
            siteid=int.Parse(Request["siteid"]);
            paytype=int.Parse(Request["paytype"]);
            adtype=int.Parse(Request["adtype"]);
    		
	    }
	    catch (Exception)
	    {
            Response.Redirect("/member/default.aspx");
	    }
        string uname= Request["username"];

        //点击计数

        string adurl = new wgiAdUnionSystem.BLL.wgi_adv().GetModel(adid).advlink;
        //本次点击重定向到广告主自设的cookie记录页，并传过去从广告ID得到的广告地址
        string destination = "cookie.aspx";
        destination += "?union=wgiadunion&siteid=" + siteid + "&url=" + adurl;
        Response.Clear();
        Response.Redirect(destination);
        Response.End();
    }
}
