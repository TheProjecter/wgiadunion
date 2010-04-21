using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.ComponentModel;
using System.Collections.Generic;


public class CommonData
{
    public CommonData()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    public static DataTable GetBaseTable()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("name", typeof(string));
        dt.Columns.Add("value", typeof(string));
        return dt;
    }

    /// <summary>
    /// 获得广告显示的类型
    /// </summary>
    /// <returns></returns>
    public static DataTable GetAdvertiseDisplayType()
    {
        DataTable dt = GetBaseTable();

        dt.Rows.Add("文字广告", "1");
        dt.Rows.Add("图片广告", "2");
        dt.Rows.Add("Flash广告", "3");
        return dt;
    }

    /// <summary>
    /// 根据广告显示类型值返回名称
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static string GetAdvTypeDisplayName(string id)
    {
        return GetAdvertiseDisplayType().Select("value=" + id)[0]["name"].ToString();
    }

    /// <summary>
    /// 获得广告计费模式的类型
    /// </summary>
    /// <returns></returns>
    public static DataTable GetAdvertisePayType()
    {
        DataTable dt = GetBaseTable();

        dt.Rows.Add("CPS-按销售提成", "1");
        dt.Rows.Add("CPC-按点击提成", "2");
        dt.Rows.Add("CPA-按有效注册提成", "3");
        dt.Rows.Add("CPN-按参与人数提成", "4");
        return dt;
    }

    /// <summary>
    /// 获得广告主的广告链接的更新类型
    /// </summary>
    /// <returns></returns>
    public static DataTable GetAdvertiseLinkType()
    {
        DataTable dt = GetBaseTable();

        dt.Rows.Add("外部网址", "1");
        dt.Rows.Add("本地上传", "2");
        return dt;
    }

    /// <summary>
    /// 获得审核的状态文字项目
    /// </summary>
    /// <returns></returns>
    public static DataTable GetAuditStatusItem()
    {
        DataTable dt = GetBaseTable();
        dt.Rows.Add("待审核","0");
        dt.Rows.Add("审核已通过","1");
        dt.Rows.Add("审核未通过", "2");
        return dt;
    }
    /// <summary>
    /// 获得审核的状态文字描述
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static string GetAuditStatusItemName(string id)
    {
        return GetAuditStatusItem().Select("value=" + id)[0]["name"].ToString();
    }

    /// <summary>
    /// 用户状态的列表
    /// </summary>
    /// <returns></returns>
    public static DataTable getAccountStatus()
    {
        DataTable dt = GetBaseTable();
        dt.Rows.Add("尚未审核通过", "0");
        dt.Rows.Add("正常登录", "1");
        dt.Rows.Add("账号锁定", "2");
        return dt;
    }

    public static string getAccountStatusByValue(string v)
    {
        return getAccountStatus().Select("value=" + v)[0]["name"].ToString();
    }

    public static DataTable getSiteType()
    {
        DataTable dt=GetBaseTable();
        dt.Rows.Add("普通网站","0");
        dt.Rows.Add("电子商务网站", "1");
        dt.Rows.Add("网店", "2");
        dt.Rows.Add("博客", "2");
        dt.Rows.Add("其它", "2");
        return dt;
    }

    public static string getSiteTypeByValue(string v)
    {
        return getSiteType().Select("value=" + v)[0]["name"].ToString();
    }

    /// <summary>
    /// 获取客户端IP
    /// </summary>
    /// <returns></returns>
    public static string GetIp(Page page)
    {
        //可以透过代理服务器
        string userIP = page.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (userIP == null || userIP == "")
        {
            //没有代理服务器,如果有代理服务器获取的是代理服务器的IP
            userIP = page.Request.ServerVariables["REMOTE_ADDR"];
        }
        return userIP;
    }

    //业绩
    public static DataTable getYejiType()
    {
        DataTable dt = GetBaseTable();
        dt.Rows.Add("全部业绩", "1");
        dt.Rows.Add("未确认业绩", "2");
        dt.Rows.Add("有效业绩", "3");
        dt.Rows.Add("申请取消的业绩", "4");
        dt.Rows.Add("已取消的业绩", "5");
        dt.Rows.Add("未核对，有效业绩", "6");
        return dt;
    }
}
