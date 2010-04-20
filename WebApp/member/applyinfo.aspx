<%@ Page Language="C#" MasterPageFile="~/Templet/memberMaster.master" AutoEventWireup="true" CodeFile="applyinfo.aspx.cs" Inherits="member_applyinfo" Title="中商购物|网站联盟|用户中心" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<!--内容区样式开始-->
	<div class="conthead"><span>您现在的位置：首页&nbsp;>&nbsp;财务管理&nbsp;>&nbsp;申请佣金</span>联盟会员控制面板</div>
	<div class="ctbody_cnt" id="listdiv">
		<h3>网站信息</h3>
		<div>


    <table align="center" border="0" cellpadding="0" cellspacing="0" height="40" 
        width="89%">
        <tr>
            <td valign="center">
                <p>
                    <strong>如果您是第一次申请佣金,请提供以下资料:</strong></p>
            </td>
        </tr>
    </table>
    <table border="0" cellpadding="0" cellspacing="0" width="94%">
        <tr>
            <td background="http://www.linktech.cn/AC/images/shopportal_18.gif" height="6">
            </td>
        </tr>
    </table>
    <table align="center" border="0" cellpadding="0" cellspacing="0" height="25" 
        width="89%">
        <tr>
            <td width="20">
                <img border="0" src="http://www.linktech.cn/images/icon_orange2.gif" /></td>
            <td>
                <b><font style="FONT-SIZE: 9pt">个人网站:需提供本人身份证复印件或扫描图片一份并需注明以下信息:</font></b>
            </td>
        </tr>
    </table>
    <table align="center" bgcolor="#999999" border="0" cellpadding="8" 
        cellspacing="1" width="84%">
        <tr>
            <td bgcolor="#dddddd" width="17%">
                姓名:</td>
            <td bgcolor="#ffffff" width="39%">
                领克特</td>
            <td align="middle" bgcolor="#ffffff" rowspan="10" width="44%">
                <img height="99" src="http://www.linktech.cn/images/ziliao.jpg" width="139" /></td>
        </tr>
        <tr>
            <td bgcolor="#dddddd">
                身份证号:</td>
            <td bgcolor="#ffffff">
                123456789101112</td>
        </tr>
        <tr>
            <td bgcolor="#dddddd">
                联盟会员账号:</td>
            <td bgcolor="#ffffff">
                Linktech</td>
        </tr>
        <tr>
            <td bgcolor="#dddddd" rowspan="4">
                银行信息:</td>
            <td bgcolor="#ffffff">
                银行名称: <em>中国工商银行</em>
            </td>
        </tr>
        <tr>
            <td bgcolor="#ffffff">
                支行名称: <em>朝阳分行</em></td>
        </tr>
        <tr>
            <td bgcolor="#ffffff">
                银行账号: <em>1234567890</em></td>
        </tr>
        <tr>
            <td bgcolor="#ffffff">
                开户人: <em>领克特</em></td>
        </tr>
    </table>
    <br />
    <br />
    <table align="center" border="0" cellpadding="0" cellspacing="0" height="25" 
        width="89%">
        <tr>
            <td width="20">
                <img border="0" src="http://www.linktech.cn/images/icon_orange2.gif" /></td>
            <td>
                <b><font style="FONT-SIZE: 9pt">公司网站：需提供营业执照复印件及<span class="style1">税务登记证复印件</span>或扫描图片一份并需注明以下信息：</font></b>
            </td>
        </tr>
    </table>
    <table align="center" bgcolor="#999999" border="0" cellpadding="8" 
        cellspacing="1" width="84%">
        <tr>
            <td bgcolor="#dddddd" width="17%">
                姓名:</td>
            <td bgcolor="#ffffff" width="39%">
                领克特</td>
            <td align="middle" bgcolor="#ffffff" rowspan="13" width="44%">
                <img height="101" src="http://www.linktech.cn/images/ziliao2.jpg" width="140" /></td>
        </tr>
        <tr>
            <td bgcolor="#dddddd">
                身份证号:</td>
            <td bgcolor="#ffffff">
                123456789101112</td>
        </tr>
        <tr>
            <td bgcolor="#dddddd">
                联盟会员账号:</td>
            <td bgcolor="#ffffff">
                Linktech</td>
        </tr>
        <tr>
            <td bgcolor="#dddddd">
                公司名称:</td>
            <td bgcolor="#ffffff">
                北京领克特信息技术有限公司</td>
        </tr>
        <tr>
            <td bgcolor="#dddddd">
                法人编号:</td>
            <td bgcolor="#ffffff">
                234567891011121</td>
        </tr>
        <tr>
            <td bgcolor="#dddddd">
                工商注册号:</td>
            <td bgcolor="#ffffff">
                345678910111122</td>
        </tr>
        <tr>
            <td bgcolor="#dddddd" rowspan="4">
                银行信息:</td>
            <td bgcolor="#ffffff">
                银行名称: <em>中国工商银行</em>
            </td>
        </tr>
        <tr>
            <td bgcolor="#ffffff">
                支行名称: <em>朝阳分行</em></td>
        </tr>
        <tr>
            <td bgcolor="#ffffff">
                银行账号: <em>1234567890</em></td>
        </tr>
        <tr>
            <td bgcolor="#ffffff">
                开户人: <em>领克特</em></td>
        </tr>
    </table>
    <br />
    <table align="center" border="0" cellpadding="0" cellspacing="0" width="84%">
        <tr>
            <td>
                <span class="style1">*</span> 以上是在复印件需要标注信息的格式.<br />
                　在Linktech收到您的材料后，系统内将提示您：“您的佣金支付有关资料准备完毕”。<br />
                　第二次结算时，不需再此提供以上资料。</td>
        </tr>
    </table>
    <br />
    <br />
    <table align="center" border="0" cellpadding="0" cellspacing="0" width="89%">
        <tr>
            <td>
                <img border="0" src="http://www.linktech.cn/images/icon_orange2.gif" /></td>
            <td>
                <b><font style="FONT-SIZE: 9pt">提供资料方式：</font></b>
            </td>
        </tr>
    </table>
    <table align="center" width="84%">
        <!--<tr>
          <td width=50><li>FAX</li></td>
          <td>:</td>
          <td>010-82842172          </td>
        </tr>-->
        <tr>
            <td>
                <li>Email</li>
            </td>
            <td>
                :</td>
            <td>
                <a href="mailto:ziliao@linktech.cn" 
                    style="COLOR: #000000; FONT-SIZE: 12px; TEXT-DECORATION: none">
                ziliao@linktech.cn</a></td>
        </tr>
        <tr valign="top">
            <td>
                <li>地址 </li>
            </td>
            <td>
                :</td>
            <td>
                北京市朝阳区东三环北路丙2号(三元桥)北京天元港中心B座10层1002室 
            </td>
        </tr>
        <tr valign="top">
            <td>
                <li>邮编</li>
            </td>
            <td>
                :</td>
            <td>
                100027</td>
        </tr>
    </table>

    </div>
</div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="jscode" Runat="Server">
</asp:Content>

