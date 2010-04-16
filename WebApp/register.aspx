<%@ Page Language="C#" MasterPageFile="~/Templet/header_footer.master" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="register" Title="中商购物|网站联盟|会员注册" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="step">填写注册信息》等待激活邮件</div>
<h3>联盟会员注册：</h3>
<div class="reginfo">
    <div class="infowraper">
        <p class="ptitle">个人信息</p>
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		username
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtusername" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		password
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtpassword" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		email
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtemail" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		mobile
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtmobile" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	
	<tr>
	<td height="25" width="30%" align="right">
		usertype
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtusertype" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		contact
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtcontact" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		qq
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtqq" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		idcard
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtidcard" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		address
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtaddress" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		zipcode
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtzipcode" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		tel
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txttel" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		balance
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtbalance" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		regdate
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox onselectstart="return false;" onkeypress="return false" id="txtregdate" onfocus="setday(this)"
		 readOnly type="text" size="10" name="Text1" runat="server"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		regip
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtregip" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		lastdate
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox onselectstart="return false;" onkeypress="return false" id="txtlastdate" onfocus="setday(this)"
		 readOnly type="text" size="10" name="Text1" runat="server"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		lastip
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtlastip" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		status
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtstatus" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
</table>
    
        <p class="ptitle">网站</p>
        <table cellSpacing="0" cellPadding="0" width="100%" border="0">
        <tr><td>aaa</td></tr>
        </table>
    
        <p class="ptitle">结款账户信息</p>
        <table cellSpacing="0" cellPadding="0" width="100%" border="0">
                <tr>
	        <td height="25" width="30%" align="right">
		        accountname
	        ：</td>
	        <td height="25" width="*" align="left">
		        <asp:TextBox id="txtaccountname" runat="server" Width="200px"></asp:TextBox>
	        </td></tr>
	        <tr>
	        <td height="25" width="30%" align="right">
		        accountno
	        ：</td>
	        <td height="25" width="*" align="left">
		        <asp:TextBox id="txtaccountno" runat="server" Width="200px"></asp:TextBox>
	        </td></tr>
	        <tr>
	        <td height="25" width="30%" align="right">
		        bank
	        ：</td>
	        <td height="25" width="*" align="left">
		        <asp:TextBox id="txtbank" runat="server" Width="200px"></asp:TextBox>
	        </td></tr>
	        <tr>
	        <td height="25" width="30%" align="right">
		        branch
	        ：</td>
	        <td height="25" width="*" align="left">
		        <asp:TextBox id="txtbranch" runat="server" Width="200px"></asp:TextBox>
	        </td></tr>
        </table>
    
        <p class="ptitle">联盟协议</p>
        <div align="center" class="divterms">
	
	<p align="center" style="font-size: 14px; margin:10px auto 15px auto;"><strong>个人网站联盟服务协议书</strong></p>
<p align="left" class="pterms">
　　本个人网站联盟服务协议书，是对凡客诚品（北京）科技有限公司（以下简称为“凡客诚品”）及根据本协议注册为凡客诚品个人网站联盟会员的自然人、法人或其他组织之间的权利义务关系之约定。您注册为凡客诚品个人网站联盟会员，即视为您同意接受本协议的约束，并愿意按照本协议的约定享受您的权利，并履行您的义务。您必须保证，您已仔细阅读、完全理解并接受本协议条款。<br>
<strong>第一条 术语定义：</strong><br>
1	用户：通过个人网站联盟会员网站上的推广链接，访问凡客诚品网站并在凡客诚品网站进行商务活动或其它相关活动的因特网用户。<br>
2	推广服务费：按照本协议书第二条，凡客诚品需支付给个人网站联盟会员的费用。<br>
3	RD，Return Day，推广效果认定期，指凡客诚品认可用户有效购买行为的期限，即用户通过个人网站联盟会员设置的推广链接到达凡客诚品网站浏览， 在效果认定期内（比如RD=1天），未通过联盟会员而直接浏览凡客诚品网站（客户须使用同一台电脑方能认定）并产生了购买行为，此行为也被视为认定个人网站联盟会员业绩的有效购买行为。<br>
4	正确推广，联盟会员仅能在其网站中投放凡客诚品未被修改的推广代码带来用户，不可诱导用户，更不可欺骗客户，不可在百度、GOOGLE等搜索引擎上购买“vancl”“凡客诚品”等关键词来推广。不得使用域名中包含“vancl”的域名或与vancl相同或近似的域名，比如vancls或vankl,vancle等，来推广vancl的产品。未经凡客诚品同意，不得以任何形式使用凡客诚品的名称、商标和logo。凡客诚品（北京）科技有限公司对此有最终解释权。<br>
5	可提成订单：用户订单不处于无效、待核、已作废、拒收已入库、等待系统处理、有效待支付等几种状态，且没有使用不允许订单提成的礼品卡，这样的订单为联盟会员可提成订单。<br>
6	允许订单提成的礼品卡：凡客诚品联盟专用的礼品卡，礼品卡的序号中包括SCCL字样。<br>
7	订单金额：订单中包含商品的总金额（折扣后的），不包括订单中用户支付的运费和附加费。<br>
8	附加费：包装费+刺绣费+制版费 （刺绣费+制版费 为团购订单特有）<br>
9	出库金额：发货订单的订单金额之和，包括因换货出库的商品金额。<br>
10	入库金额：退货商品的总金额，包括因换货入库的商品金额。<br>
11	礼品卡金额：支付时使用支付方式为礼品卡和赠送的金额。<br>
12	可提成金额：订单生成30天内的出库金额（即购买的）－订单生成30天内的入库金额（即退掉的）－礼品卡金额。<br>
13	通用条款：是指所有接受本协议约束的法人、自然人及其他组织，在履行本协议过程中应遵守的规定，是本协议不可分割的组成部分，与本协议具有同等法律效力。<br>


<strong>第二条 个人网站联盟会员操作流程</strong><br>
1 您首先在阅读、理解并接受本协议的基础上，进行注册，一旦注册成功，您将被视为凡客诚品个人网站联盟会员，享受个人网站联盟会员的权利，并履行个人网站联盟会员的义务。<br>
2 您成为凡客诚品个人网站联盟会员后，您将获得凡客诚品个人网站联盟会员账号及密码，请您在注册成功后，立即修改您的登录密码，并妥善保管；因为您的原因造成密码遗失，因此而产生的损失，将会由您自行承担。<br>
3 您在登录凡客诚品网站个人网站联盟会员账号后，应立即填写您的完整资料，包括但不限于您的银行结算账号（目前仅支持工商银行支付），您应真实、准确、完整的提供该信息，如因您提供的银行账号信息不完整、错误而导致凡客诚品无法向您进行结算的，将由您自行承担相应责任。<br>
4 您注册为凡客诚品个人网站联盟会员后，可自行在您的网站上上载凡客诚品产品广告代码，但您必须保证不得对凡客诚品的产品代码进行任何形式的修改。<br>
5用户可通过您在您的网站上设置的凡客诚品的广告链接，访问凡客网，凡客诚品将根据系统统计及本协议的约定计算您的推广费用。<br>
6 您应明确：凡客诚品现行退换货周期为30日，凡客诚品有权根据客观情况及自身经营状况变更退换货周期，该种变更无须获得您的同意，凡客诚品仅须在发生此种变更时提前5日以电子邮件或网站公告形式通知您。<br>
7凡客诚品若提高/降低推广服务费的支付标准，将提前5日以电子邮件或网站公告形式告知您，您如对凡客诚品变更后的推广服务费支付标准有异议的，应于收到通知之日起5日内以电子邮件或书面方式提出；如在您收到通知邮件后5日内未进行回复，也未提出任何异议的，视为您认可凡客诚品的该等变更，新的推广费标准将于您收到电子邮件之日起5日后或在公告所载日期生效；新的推广服务费支付标准生效后，自生效之日起，双方以新的支付标准进行结算。<br>

<strong>第三条 推广服务费及支付</strong><br>
 1	凡客诚品与您，自您成功注册为凡客诚品个人网站联盟会员之日起建立CPS（COST PER SALES，即按实际销售提成推广服务费模式）推广合作关系。推广服务费的支付条件比例由凡客诚品确定；您注册为凡客诚品个人网站联盟会员的行为即表示您完全接受本条款之约束。<br>
2	只有按本协议规定的可提成订单参与提成并计算您可获得的推广费。<br>
3   双方推广服务费确认和说明：在推广期内，凡客诚品每月按双方合作产生的实际可提成订单金额向您支付推广费，分成比例为:<br>
（1）vip/svip账户内所有商品订单均按可提成订单金额的5%支付推广费。<br>
（2）普通账户内的“特例品”或者“非vancl品牌商品”（统称为“特殊商品”），按照可提成订单金额的5%支付推广费；<br>
（3）普通账户内的其他非特殊商品（除（2）项约定之外的其他商品）按照可提成订单金额的15%比例支付推广费。<br>
综上：网站联盟会员每月获得的推广服务费=（普通账户内非特殊商品可提成订单金额*15%）+（普通账户内特殊商品可提成订单金额*5%）+（vip/svip账户内可提成订单金额*5%）<br>
4	结算：<br>
4.1	凡客诚品在第三个月的前三个工作日统计并制作您的第一个月收益报表，并提供给您。<br>
4.2	您如对凡客诚品提供的收益报表存在异议，应在收到收益报表之日起3个工作日内以电子邮件或传真方式提出；如在前述期限内未提出的，则视为您完全认同凡客诚品提供的收益报表，凡客诚品将据此与您进行结算。<br>
4.3	如您在规定的期限内提出异议的，则凡客诚品将与您共同对异议订单进行核对，并以此次核对结果为最终结算依据。<br>
4.4	凡客诚品于第三个月的第15个工作日前后向您支付第一个月的推广费，以此类推，之后每月第15个工作日前后向您支付推广费。<br>
4.5 您应明确：如果每月凡客诚品向您支付的推广费超过人民币800元整，则凡客诚品将会根据国家法律的规定，对超过800元的部分按照国家规定代扣劳务税后，向您支付剩余款项。<br>
4.6	凡客诚品与您共同确认：每月的起结金额为人民币肆拾元整，不到肆拾元的，将累积到下一结算周期一并结算。<br>

<strong>第四条 凡客诚品的责任和义务</strong><br>
 1	凡客诚品保证不会通过个人网站联盟会员之推广销售非法商品。如果因凡客诚品违反上述内容而造成的一切后果，将由凡客诚品自行承担。<br>
2	凡客诚品将按照本协议的约定向个人网站联盟会员支付推广费。<br>
3	凡客诚品有权自行决定与其自身经营相关的政策、规定，如该种决定可能影响到本协议的履行的，凡客诚品将依据本协议约定的时间及方式，提前通知个人网站联盟会员；个人网站联盟会员不能接受凡客诚品政策及规定变更的，应通知凡客诚品，并自新的政策及规定生效之日本协议终止。<br>
4	对于通过个人网站联盟会员推广而购买凡客诚品产品的顾客，凡客诚品负责发货、退换货、维修、售后服务等与销售商品相关的行为。<br>
5	凡客诚品根据自身判断，认为个人网站联盟会员正在进行或即将进行可能损害凡客诚品利益的活动时，有权立即冻结该个人网站联盟会员的联盟账号，并有权要求个人网站联盟会员立即停止一切与凡客诚品相关的活动，个人网站联盟会员应在收到凡客诚品通知之日起，立即停止相关活动并中断、删除所有与凡客诚品相关的推广链接。<br>
6	凡客诚品指定的个人网站联盟负责人及联系方式如下：<br>
          负责人：刘可可<br>
          电子邮箱： liukeke@vancl.cn <br>
          电    话：010-83607650-8036<br>
          传    真：010-83607699<br>
 上述人员发生变化时，凡客诚品将提前5个工作日以电子邮件或网站公告形式通知个人网站联盟会员。<br>
7	凡客诚品有权经提前10天以电子邮件或网站公告、站内信息等形式通知个人网站联盟会员而终止本协议，协议的终止不影响双方此前已经发生的权利义务关系。本协议终止后，凡客诚品有权撤销个人网站联盟会员之联盟账号。<br>

<strong>第五条 个人网站联盟会员的责任和义务</strong><br>
 1	为了服务的顺利、平稳进行，个人网站联盟会员应尽最大努力保证平台运行的稳定性。<br>
2	个人网站联盟会员在提供服务时如有下列行为，凡客诚品有权立即终止本协议：<br>
2.1	未经凡客诚品同意，将服务过程中得到的信息向第三者公开或转发。<br>
2.2	申请破产并开始清算、公司停业整顿期间或有不履行债务等的不良记录。<br>
2.3	因停业、倒闭等理由停止支付的。<br>
2.4	在与本服务运营有关的事项范围内，个人网站联盟会员违反有关法律法规时。<br>
2.5	客观上被视为与犯罪有关的行为。<br>
2.6	其他明显的非正当行为。<br>
3	个人网站联盟会员在提供服务时获取的凡客诚品各项信息，未经凡客诚品同意不得泄漏给第三方,有相关法律法规规定或国家政府部门要求的情况时除外。<br>
4	按照诚实守信的原则，个人联盟网站只能以合同中明确规定的正确的方式推广，否则凡客诚品可就违规当月业绩不予结算。<br>
5	凡客诚品有特殊要求时，双方另立协议。<br>
6	广告创意的所有权在于提供者，未经提供者的同意，个人网站联盟会员不得以盈利为目的擅自使用。<br>

<strong>第六条</strong>  本协议的生效，并不代表凡客诚品与个人网站联盟会员之间存在任何隶属、代理关系，个人网站联盟会员不得以凡客诚品代理商或凡客诚品分支机构、子公司等名义对外进行宣传，亦不得擅自使用凡客诚品商标、名称或LOGO等。<br>

<strong>第七条 免责条款</strong><br>
 1	由于自然灾害或不可抗力（如软件、系统服务设备维护、检修等不得已情况，基础电信业务经营者电信线路服务中止等）等因素无法正常提供服务，双方可免于承担责任。<br>
2	因市场的不可预测性及变化性，及各个人网站联盟会员的操作、经营方式的不同，个人网站联盟会员的收入将不可预测，凡客诚品不能保证个人网站联盟会员获得预期的收入。<br>

<strong>第八条 保密条款</strong><br>
1.个人网站联盟会员知悉自凡客诚品获知或获准使用的硬件、软件、程序、密码、商品名、技术、许可证、专利、商标、LOGO、技术知识和经营过程是凡客诚品的合法所有，个人网站联盟会员对此无任何权利或利益，亦不会向任何第三方透露。<br>
2.个人网站联盟会员在合作期间获知的凡客诚品的商业秘密、技术秘密等须保密的事项，在协议期间及协议终止后两年内不得向任何第三方披露或公开。<br>
3．个人网站联盟会员承诺并保证：其对根据本协议获知的凡客诚品销售数据、销售信息、订单信息、顾客购买行为及本协议内容等进行严格保密，不会向任何第三方透露，亦不会向任何不相关之雇员、代理人、顾问等进行披露；同时，个人网站联盟会员有义务告知其因履行本协议而必须获知该等信息的雇员、联盟方，该等信息是保密信息，并就其雇员、联盟方的侵权或违约行为向凡客诚品承担责任。<br>
4. 以上保密条款并不因本协议的解除和终止而失效。<br>

<strong>第九条 其它</strong><br>
 1	本协议自您成功注册为凡客诚品个人网站联盟会员之日起生效，您停止为凡客诚品进行推广或凡客诚品冻结、撤销您的联盟账号之日或出现本协议约定情形时，本协议终止。<br>
2	一方向另一方发出的通知，以电子邮件形式发送的，自电子邮件成功自发送人处发送之时，视为对方收到该通知；以传真形式发送的，自传真完成发送之时，视为对方收到该通知；以快递形式发送的，以对方签收之日或发出之日起5日后视为对方收到该通知。<br>
3	凡客诚品将通知发送至个人网站联盟会员注册时指定的电子邮箱，或自联盟公告发布之日起3日后，即视为个人网站联盟会员收到凡客诚品通知。<br>
4	未尽事宜，双方应平等、友好协商，以合理解决问题的态度积极解决问题。如协商未果，可就该纠纷向北京市丰台区人民法院提起诉讼。<br>
5	网络联盟营销服务通用条款是本协议不可分割的一部分，该通用条款的有效期间与本协议有效期相同，本协议及该通用条款构成完整协议。
</p>

<p align="center" style="font-size: 14px; margin:10px auto 15px auto;"><strong>网络联盟营销服务通用条款</strong></p>
<p align="left" class="pterms">

本通用条款，适用于所有与凡客诚品签订《联盟协议书》的法人、自然人或其他组织，所有前述人员均应遵守本通用条款之相应规定。本通用条款，作为联盟营销服务协议书的重要组成部分，与其具有同等法律效力。<br>
第1条	凡客诚品网络联盟会员，应遵守凡客诚品关于网络联盟管理的相关规定及政策，包括但不限于双方签订的书面协议书条款、凡客诚品联盟网站发布的联盟管理规定、联盟网站操作规范及流程、凡客诚品以电子邮件或公告形式发布的管理规定等内容。<br>
第2条	网络联盟会员确认：凡客诚品有权根据自身情况，调整联盟网站相关政策及规定、调整本通用条款之内容，凡客诚品调整联盟网站相关政策及规定或调整本通用条款之内容的，将以电子邮件或公告形式通知联盟会员，联盟会员如不同意该等变更，应于收到凡客诚品通知后5个工作日内提出，双方可进行结算，提前终止合约，互不承担违约责任；如联盟会员在收到凡客诚品通知后5个工作日内未提出任何异议，视为联盟会员接受凡客诚品政策及规定之变更；变更于通知注明之日期生效。<br>
第3条	联盟会员在与凡客诚品合作过程中，不得有下列行为：<br>
3.1 未经凡客诚品许可，不得以凡客诚品名义进行任何市场推广活动；不得以任何方式误导消费者，使其误认联盟会员是凡客诚品的子公司、分公司、关联公司、代理商或其他凡客诚品授权的折扣站点等。<br>
3.2 联盟会员链接或向第三方进行推广时发送的凡客诚品网站或网页内容，应是经凡客诚品许可的，不得将任何未经凡客诚品许可或已过期或擅自修改的网站或网页内容进行链接或向第三方进行发送；<br>
3.3 未经凡客诚品许可，不得复制凡客诚品网站内容，不得冒充凡客诚品官方网站，不得使用任何可能导致第三方误认为联盟会员是凡客诚品的文字、图片或使用其他可能导致第三方误认的方式进行推广；<br>
3.4 不得在任何搜索引擎上购买与凡客诚品产品名称或凡客诚品名称、商标、logo、域名相同或近似的关键字（词），或包含前述内容的关键字（词），不得购买凡客诚品已购买的关键字（词）；<br>
3.5 不得注册、使用与凡客诚品商标、名称及域名相同或近似的商标或域名，不得注册、使用包含凡客诚品商标、名称或域名的商标或域名。<br>
3.6 联盟会员所有对凡客诚品的宣传图片、文字均应与凡客诚品发放给联盟渠道的一致，联盟会员自行进行大规模的邮件、短信、礼品卡及特殊促销活动时，必须事先获得凡客诚品书面确认及授权，未经凡客诚品许可，不得进行前述活动。<br>
3.7联盟会员在进行推广时，不得在宣传文字及图片上以任何方式误导客户，提出与凡客诚品网站完全不一致的促销活动，包括但不限于运用不符合事实的“免费、特价、返点”等字样或类似方式。<br>
3.8 如联盟会员经甲方许可，可以以EDM形式或短信群发形式进行推广的，联盟会员进行的推广内容，必须经凡客诚品书面（包括传真和电子邮件形式）确认，且必须在凡客诚品许可的时限内发送，不得超期发送。<br>
第4条	联盟会员应严格管理及控制其旗下会员，应与其会员签署协议书，督促其会员在为凡客诚品进行推广时，遵守凡客诚品相关规定及政策，所有联盟会员应遵守之规定，联盟会员旗下之会员亦应遵守，如联盟会员旗下会员出现违规现象，凡客诚品将依据协议约定，对联盟会员进行相应处罚，并追究联盟会员之违约责任。<br>
第5条	违约责任<br>
5.1 如联盟会员违反双方签署的《联盟协议书》及本通用条款的约定，凡客诚品有权对联盟会员违约违规期间产生的业绩不予结算，并有权视联盟会员违规情节轻重，单方提前终止双方之合作。<br>
5.2 如联盟会员违反《联盟协议书》及本通用条款的约定，其违约违规行为给凡客诚品造成损失或损害的，凡客诚品有权就该等损失或损害要求联盟会员进行赔偿。<br>
5.3 联盟会员应明确：如果联盟会员或联盟会员旗下会员出现本协议第3条之行为，其不但构成对凡客诚品的违约，亦构成对凡客诚品合法权益的侵犯，凡客诚品保留移交司法部门处理的权利。<br>
第6条	其他<br>
6.1 本通用条款是双方《联盟协议书》不可分割的一部分，与其具有同等法律效力；<br>
6.2 联盟会员确认：其已认真阅读本通用条款之内容，并承诺严格遵守本通用条款之规定。<br>

</p>


	</div>
        <p class="readterms"><input type="checkbox" id="cbx_hasread" /><label for="cbx_hasread">我已阅读并接受“合作协议”</label></p>
    <p style="text-align:center">
        <input type="submit" id="btn_giveup" class="redbtn" value="放&nbsp;弃" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <input type="submit" id="btn_submit" class="redbtn" value="注&nbsp;册" />
    </p>
    </div>
    
</div>
</asp:Content>

