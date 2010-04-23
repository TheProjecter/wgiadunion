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

public partial class member_notices : System.Web.UI.Page
{

    private int pagesize = 10;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            initData();
        }
    }

    private void initData()
    {
        DataSet ds = new wgiAdUnionSystem.BLL.wgi_notice().GetAllList();
        int page = 1;
        try
        {
            page = int.Parse(Request["page"]);
        }
        catch (Exception)
        {

            page = 1;
        }

        PagedDataSource ps = new PagedDataSource();
        ps.DataSource = ds.Tables[0].DefaultView;
        ps.AllowPaging = true;
        ps.PageSize = pagesize;
        if (page > ps.PageCount) page = 1;
        ps.CurrentPageIndex = page-1;

        this.rptpager.DataSource = ps;
        this.rptpager.DataBind();

        //生成分页代码
        string url = Request.Url.ToString();

        lblpager.Text = Pager.getPagerstring(ps,url,1,3);

    }

    protected string getClassName(string s)
    {
        if (s == "0") return "class=\"unread\"";
        else return "";

    }

}
