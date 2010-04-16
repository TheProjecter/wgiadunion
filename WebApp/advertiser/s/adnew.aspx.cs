using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class manage_s_adnew : advertiserPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitData();
        }
    }

    /// <summary>
    /// 初始化页面数据
    /// </summary>
    private void InitData()
    {
        Helper.HelperDropDownList.BindData(ddlDisplayType, CommonData.GetAdvertiseDisplayType(), "name", "value", -1);

        Helper.HelperDropDownList.BindData(ddlPayType, CommonData.GetAdvertisePayType(), "name", "value", -1);
        Helper.HelperDropDownList.BindData(ddlChange, CommonData.GetAdvertiseLinkType(), "name", "value", -1);
        Helper.HelperDropDownList.BindData(ddlFlash, CommonData.GetAdvertiseLinkType(), "name", "value", -1);
    }

    #region 页面事件

    //广告显示类型变化
    protected void ddlDisplayType_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (ddlDisplayType.SelectedValue)
        {
            case "1":
                mvAdvertises.SetActiveView(viewText);
                break;
            case "2":
                mvAdvertises.SetActiveView(viewPic);
                break;
            case "3":
                mvAdvertises.SetActiveView(viewFlash);
                break;
        }
    }

    //保存广告内容
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        wgiAdUnionSystem.BLL.wgi_adv badv = new wgiAdUnionSystem.BLL.wgi_adv();
        wgiAdUnionSystem.Model.wgi_adv madv = new wgiAdUnionSystem.Model.wgi_adv();
        madv.companyid = base.companyid;
        //广告参数
        madv.advname = txtname.Text;//关键描述
        madv.advstart = Helper.HelperDateTime.InputDateTime(txtbegin.Text);//开始时间
        madv.advend = Helper.HelperDateTime.InputDateTime(txtend.Text);//截止时间
        madv.advuptime = DateTime.Now;//添加时间
        madv.advpaytype = Helper.HelperDigit.ConvertToInt32(ddlPayType.SelectedValue, 1);//付费类型
        madv.advtype = Helper.HelperDigit.ConvertToInt32(ddlDisplayType.SelectedValue, 1);//显示类型

        madv.advstatus = 1;//默认审核通过
        madv.advinvalid = 1;//默认投放状态

        switch (madv.advtype)
        {
            case 1://文字广告
                madv.advlink = txtUrl.Text;
                madv.advcont = txtTilte.Text;
                break;
            case 2://图片广告
                madv.advlink = txtPicUrl.Text;
                if (ddlChange.SelectedIndex == 0)//外部地址
                {
                    madv.advcont = txtRemotePic.Text;
                }
                else
                {
                    //madv.advcont =fupload.s //上传图片地址
                }
                break;
            case 3://FLASH广告
                madv.advlink = txtSwfUrl.Text;

                if (ddlFlash.SelectedIndex == 0)//外部地址
                {
                    madv.advcont = txtRemoteSwf.Text;
                }
                else
                {
                    //madv.advcont =fupload.s //上传FLASH地址
                }

                break;
        }
        try
        {
            //新增一条广告资源
            int advid = badv.Add(madv);

            if (advid > 0)
            {
                Response.Redirect("adlist.aspx");
            }
            else
            {
                lblmsg.Text = "保存操作失败！";
            }
        }
        catch (Exception E)
        {
            lblmsg.Text = E.Message;
        }
    }

    #endregion

    #region 页面业务逻辑

    #endregion

}
