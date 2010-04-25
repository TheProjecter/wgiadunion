using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
///uLoadControl 的摘要说明
/// </summary>
public class uLoadControl
{
    public uLoadControl()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    /// <summary>
    /// 初始化页面
    /// </summary>
    /// <param name="thepage">当前页面对象</param>
    /// <param name="index">页面菜单索引</param>
    /// <param name="title">页面标题</param>
    /// <param name="plhdTitle">标题控件</param>
    /// <param name="plhdHeader">头部控件</param>
    /// <param name="plhdSlide">侧栏控件</param>
    /// <param name="plhdFooter">底部控件</param>
    public static void initPage(Page thepage, int index, string title, PlaceHolder plhdTitle, PlaceHolder plhdHeader, PlaceHolder plhdSlide, PlaceHolder plhdFooter)
    {
        string titleID = "u_title";
        string headerID = "u_header";
        string sliderID = "u_slider";
        string footerID = "u_footer";

        //get menu name
        string menuName = "menu" + index;
        string subMenuName = "subMenu" + index;

        //get title
        Control ctitle = thepage.LoadControl("pageControl/title.ascx");
        ctitle.ID = titleID;
        (ctitle.FindControl("ltrTitle") as Literal).Text = title;
        plhdTitle.Controls.Add(ctitle);

        //get header
        Control cheader = thepage.LoadControl("pageControl/header.ascx");
        cheader.ID = headerID;
        (cheader.FindControl(menuName) as Literal).Text = " class=\"current\"";//高亮父菜单
        cheader.FindControl(subMenuName).Visible = true;//高亮子菜单
        plhdHeader.Controls.Add(cheader);
        
        //get slider
        Control cslider = thepage.LoadControl("pageControl/slidePanel.ascx");
        cslider.ID = sliderID;
        plhdSlide.Controls.Add(cslider);

        //get footer
        Control cfooter = thepage.LoadControl("pageControl/footer.ascx");
        cfooter.ID = footerID;
        plhdFooter.Controls.Add(cfooter);
    }
}
