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
using LTP.Common;

public partial class member_sites : System.Web.UI.Page
{
	private int userid;
	
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            validateMember userobj = MasterPageOpration.getMasterControl(this.Page.Master, "Muser");
			if(userobj.suser.userid!=0) 
            {
                userid=userobj.suser.userid;
                initData();
            }
			else Response.Redirect("/member/Default.aspx?url="+ Request.CurrentExecutionFilePath);
        }
    }

    protected void initData()
    {
        this.odsData.SelectParameters["userid"].DefaultValue = userid.ToString();
        this.gridList.DataSourceID = this.odsData.ID;
        this.gridList.DataBind();
    }

}
