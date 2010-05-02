<%@ Page Language="C#" AutoEventWireup="true" CodeFile="adtest.aspx.cs" Inherits="adtest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div style="border:1px solid green; padding:10px; width:700px;"><pre>
    一，在付款时记录
        好处：不会遗漏订单；
        坏处：容易产生垃圾订单（虚假订单会产生无效佣金）</pre>
    <asp:Button ID="btnPay" runat="server" Text="点此支付" OnClick="sendInfo" />
    <br /><pre>
    二，在付款成功后记录，方法有二，银行跳转回时自动记录，或付款成功后由客户主动点击
        好处：每一个佣金/订单记录一定是付过款的
        坏处：容易漏单</pre>
    <asp:Button ID="Button1" runat="server" Text="我已完成支付" OnClick="sendInfo" />
    </div>
    <pre>
        完整的购买流程：
        （各种途径）进入商城
            →浏览商品
                →各种原因离店
                →发现中意商品
                    →添加到购物车
                      →继续浏览商品流程，直到买单页面
                    →直接购买
                        →退换货处理
                          →流程结束
        系统同步动作：
            记录访客来源（直接点击、搜索引擎、别站链接、广告链接），针对广告链接记录cookie
                →记录用户喜好
                    →跳出页面、频率统计
                        →无动作
                            →款到发货
                                →广告客户，回传定单信息
                            →货到付款
                                →记录定单信息→收到客户放款，回传定单信息（相当于成交时没有回传信息，可改成成交即回传，看需求）
                                  →联盟要求支付佣金，人工审核（包括订单真实性以及退换货的订单）
                                  
    （款到发货和货到付款的区别在于，货到付款的单回传订单信息给联盟，是在确认成交后回传，还是入账后回传）
    </pre>
    <br />
    <img src="Images/adunion.png" alt="" />
    </div>
    </form>
</body>
</html>
