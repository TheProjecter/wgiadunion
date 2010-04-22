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
using wgiAdUnionSystem.BLL;

public partial class member_gencode : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            initData();
            //Response.Write("Request.Url：" + Request.Url + "<br />");
            //Response.Write("Request.Path：" + Request.Path + "<br />");
            //Response.Write("Request.CurrentExecutionFilePath：" + Request.CurrentExecutionFilePath + "<br />");
            //Response.Write("Request.FilePath：" + Request.FilePath + "<br />");
            //Response.Write("Request.PathInfo：" + Request.PathInfo + "<br />");
            //Response.Write("Request.PhysicalApplicationPath：" + Request.PhysicalApplicationPath + "<br />");
            //Response.Write("Request.PhysicalPath：" + Request.PhysicalPath + "<br />");
            //Response.Write("Request.RawUrl：" + Request.RawUrl + "<br />");
            //Response.Write("Request.Serviables[\"url\"]：" + Request.ServerVariables["url"] + "<br />");
            //Response.Write("Request.Url.host：" + Request.Url.Host + "<br />");
            //Response.Write("Request.Url.Port：" + Request.Url.Port + "<br />");
        }
    }

    private void initData()
    {
        validateMember userobj = MasterPageOpration.getMasterControl(this.Page.Master, "Muser");
        //得到网站列表
        wgi_usersite bll = new wgi_usersite();
        Helper.HelperDropDownList.BindData(ddlsite, bll.getListByUserId(userobj.suser.userid).Tables[0], "sitename", "siteid",0);
        ddlsite.Items.Insert(0, new ListItem("--请选择--", ""));
        ddlsite.SelectedIndex = 0;

        //得到广告主数据
        hidadhost.Value = Request["host"];
        hidadid.Value = Request["id"];
        hidadtype.Value = Request["adtype"];
        hidpaytype.Value = Request["paytype"];

        //预览区
        lbltest.Text = "<b>请先选择网站！</b><br />";
    
    }

    protected void btnAddSite(object sender, EventArgs e)
    {
        Response.Redirect("/member/sites.aspx");
    }

    protected void genCode(object sender, EventArgs e)
    {
        if (ddlsite.SelectedIndex == 0) 
        {
            this.lbltest.Text = "<b>请先选择网站！</b><br />";
            this.txtgcode.Text = "";
            return;
        }
        validateMember userobj = MasterPageOpration.getMasterControl(this.Page.Master, "Muser");
        
        //生成广告代码
        string ad = hidadid.Value;
        string adhost=hidadhost.Value;
        string site = ddlsite.SelectedValue;// userobj.siteid;
        string uname=userobj.suser.userid.ToString();
        int adtype = 0;
        int paytype = 0;
        try  //假如不带参数过来，int.Parse会抛错，正好利用它判断是否正常访问本页
        {
            adtype = int.Parse(hidadtype.Value);
            paytype = int.Parse(hidpaytype.Value);
        }
        catch (Exception)
        {
            Response.Redirect("/member/default.aspx");
        }

        Uri thisurl = Request.Url;
        //thisurl = thisurl.Remove(thisurl.IndexOf('?'));
        string port = thisurl.Port == 80 ? "" : (":" + thisurl.Port.ToString());
        string url = "http://" + thisurl.Host + port + "/click/click.aspx";
        url += "?shopid=" + adhost + "&adid=" + ad + "&siteid=" + site + "&userid=" + uname + "&paytype=" + paytype;

        string url_ctr = "http://" + thisurl.Host + port + "/click/";

        wgiAdUnionSystem.BLL.wgi_adv bll = new wgi_adv();
        wgiAdUnionSystem.Model.wgi_adv model = bll.GetModel(int.Parse(ad));
        string adcont = model.advcont;

        //计费模式
        switch (paytype)
        {
            case 1:
                //广告类型
                switch (adtype)
                {
                    case 1:
                        url += "&adtype=1";
                        //预览
                        this.lbltest.Text = "<a href=\"" + url + "&preview=1" + "\" target=\"_blank\">" + adcont + "</a>";
                        url = "<a href=\""+url+"\" target=\"_blank\">"+adcont+"</a>";
                        break;
                    case 2:
                        url += "&adtype=2";
                        //取出图片预设宽高
                        string w = model.advwidth.ToString();
                        string h = model.advheight.ToString();
                        //预览
                        this.lbltest.Text = "<a href=\"" + url + "&preview=1" + "\" target=\"_blank\"><img src=\"" + adcont + "\" alt=\"\" style=\"border:none; width:"+w+"px; height:"+h+"px\" /></a>";
                        url = "<a href=\"" + url + "\" target=\"_blank\"><img src=\"" + adcont + "\" alt=\"\" style=\"border:none; width:" + w + "px; height:" + h + "px\" /></a>";
                        break;
                    case 3:
                        break;
                    default:
                        break;
                }
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            default:
                break;
        }
        //接上统计露出数字串
        url += "<img src='http://" + thisurl.Host + port + "/click/showCtr.aspx' alt='' style='display:none;' />";
        this.txtgcode.Text = url;


    }
    
}
