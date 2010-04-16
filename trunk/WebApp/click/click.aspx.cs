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
        int shopid= int.Parse( Request["shopid"]);
        int adid=int.Parse(Request["adid"]);
        string uname= Request["username"];
        int siteid=int.Parse(Request["siteid"]);
        int paytype=int.Parse(Request["paytype"]);
        int adtype=int.Parse(Request["adtype"]);

        //点击计数


        //本次点击重定向到广告主自设的cookie记录页，并传过去从广告ID得到的广告地址
        string destination = "";
        Response.Redirect("cookie.aspx?");
    }
}
