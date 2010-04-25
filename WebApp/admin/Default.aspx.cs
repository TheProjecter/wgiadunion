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

public partial class admin_Default : ValidatePage
{

    protected void Page_Load(object sender, EventArgs e)
    {
        getControls();
    }

    //加载页面部件
    private void getControls()
    {
        string headerID = "u_header";
        string sliderID = "u_slider";
        string footerID = "u_footer";

        //get header
        Control cheader = Page.LoadControl("pageControl/header.ascx");
        cheader.ID = headerID;
        plhdHeader.Controls.Add(cheader);

        //get slider
        Control cslider = Page.LoadControl("pageControl/slidePanel.ascx");
        cslider.ID = sliderID;
        plhdSlide.Controls.Add(cslider);

        //get footer
        Control cfooter = Page.LoadControl("pageControl/footer.ascx");
        cfooter.ID = footerID;
        plhdFooter.Controls.Add(cfooter);
    }
}
