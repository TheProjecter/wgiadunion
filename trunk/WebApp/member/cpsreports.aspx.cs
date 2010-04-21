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

public partial class member_cpsreports : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            initData();
        }
    }

    private void initData()
    {

        Helper.HelperDropDownList.BindData(ddlyejitype, CommonData.getYejiType(), "name", "value", 0);
    }

    protected void getStatics(object sender, EventArgs e)
    {
        string showitems = Request["showitem"];//获取需要显示的列
       
    }

}
