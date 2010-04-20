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
        int.TryParse(Request["shopid"], out shopid);
        int.TryParse(Request["adid"], out adidid);
        int.TryParse(Request["userid"], out userid);
        int.TryParse(Request["siteid"], out siteidid);
        int.TryParse(Request["paytype"], out paytype);
        int.TryParse(Request["adtype"], out adtype);

        //写入数据库
    }
}
