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

public partial class member_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        validateMember obj=this.Page.Master.FindControl("Muser") as validateMember;
        obj.nocheck = true;//授权未通过导向的页面不能重复导向，否则会死循环，所以用nocheck这个标志来判断
    }
}
