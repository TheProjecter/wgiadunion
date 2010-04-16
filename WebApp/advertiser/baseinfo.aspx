<%@ Page Language="C#" AutoEventWireup="true" CodeFile="baseinfo.aspx.cs" Inherits="advertiser_baseinfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" rev="stylesheet" href="css/style.css" type="text/css" media="all" />

    <script src="../Js/jquery-1.4.min.js" type="text/javascript"></script>

    <script src="../Js/formValidator.js" type="text/javascript"></script>

    <script src="../Js/formValidatorRegex.js" type="text/javascript"></script>

    <script src="../Js/ca/WdatePicker.js" type="text/javascript"></script>

    <script type="text/javascript">

        $(document).ready(function() {
            $.formValidator.initConfig({ formid: "form1", autoSubmit: true, onsuccess: function() { } });
            $("#txtpay").formValidator({ onshow: "(必填)", onfocus: "输入支付佣金的比例！", onerror: "支付比例不能为空！" }).inputValidator({ min: 2, onerror: "文字最少为2个字符！", max: 10, onerror: "文字不能超过10个字！" });
            $("#txtconf").formValidator({ onshow: "(必填)", onfocus: "输入支付佣金的说明！", onerror: "请确认支付佣金不能为空！" }).inputValidator({ min: 5, onerror: "文字最少为5个字符！", max: 30, onerror: "文字不能超过30个字！" });
            $("#txtbegin").focus(function() { WdatePicker({ doubleCalendar: true, readOnly: true, dateFmt: 'yyyy-MM-dd', minDate: '%y-%M-%d', oncleared: function() { $(this).blur(); }, onpicked: function() { $(this).blur(); } }) }).formValidator({ onshow: "(必选)", onfocus: "请选择佣金支付的有效截止时间", oncorrect: "你输入的日期合法" }).inputValidator({ min: "2000-01-01", max: "2020-01-01", type: "time", onerror: "日期必须在\"2000-01-01\"和\"2020-01-01\"之间" });

        });
    </script>

</head>
<body class="ContentBody">
    <form id="form1" runat="server">
    <div class="MainDiv">
        <table width="99%" border="0" cellpadding="0" cellspacing="0" class="CContent">
            <tr>
                <th class="tablestyle_title">
                    广告主基本资料管理
                </th>
            </tr>
            <tr>
                <td class="CPanel">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                        <tr>
                            <td align="left">
                                &nbsp;
                                <asp:Button ID="btnAdd" runat="server" Text="保存" class="right-button02" OnClick="btnSave_Click" />
                                &nbsp;&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td width="100%">
                                <p>
                                    <asp:Label ID="lblmsg" runat="server" Style="color: Red"></asp:Label></p>
                                <fieldset style="height: 100%;">
                                    <legend>负责人联系信息</legend>
                                    <ul class="adinfo">
                                        <li><span class="rowTitle">姓　　名：</span><asp:TextBox ID="txtpay" runat="server"></asp:TextBox><span
                                            id="txtpayTip"></span></li>
                                        <li><span class="rowTitle">邮　　件：</span><asp:TextBox ID="txtconf" runat="server"></asp:TextBox><span
                                            id="txtconfTip"></span></li>
                                        <li><span class="rowTitle">电　　话：</span><asp:TextBox ID="txtbegin" runat="server"></asp:TextBox><span
                                            id="txtbeginTip"></span></li>
                                              <li><span class="rowTitle">手　　机：</span><asp:TextBox ID="TextBox7" runat="server"></asp:TextBox><span
                                            id="Span11"></span></li>
                                            <li><span class="rowTitle">在线联系：</span><asp:TextBox ID="TextBox6" runat="server"></asp:TextBox><span
                                            id="Span10"></span></li>
                                    </ul>
                                </fieldset>
                                <fieldset style="height: 100%;">
                                    <legend>公司资料信息</legend>
                                    <ul class="adinfo">
                                        <li><span class="rowTitle">公司名称：</span><asp:TextBox ID="TextBox3" runat="server"></asp:TextBox><span
                                            id="Span5"></span></li>
                                            <li><span class="rowTitle">公司地址：</span><asp:TextBox ID="TextBox5" runat="server"></asp:TextBox><span
                                            id="Span9"></span></li>
                                        <li><span class="rowTitle">法人姓名：</span><asp:TextBox ID="TextBox4" runat="server"
                                            Width="200px"></asp:TextBox><span id="Span6"></span></li>
                                        <li><span class="rowTitle">法人身份证：</span><span id="Span7"></span></li>
                                         <li><span class="rowTitle">营业执照号：</span><span
                                            id="Span8"></span></li>
                                    </ul>
                                </fieldset>
                                <fieldset style="height: 100%;">
                                    <legend>广告主网站内容</legend>
                                    <ul class="adinfo">
                                        <li><span class="rowTitle">网站名称：</span><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><span
                                            id="Span1"></span></li>
                                        <li><span class="rowTitle">网站地址：</span><asp:TextBox ID="TextBox2" runat="server"
                                            Width="200px"></asp:TextBox><span id="Span2"></span></li>
                                        <li><span class="rowTitle">网站分类：</span><select name="category_code"><option value=""
                                            selected>请选择网站分类</option>
                                            <option value="02">DIY娱乐/休闲</option>
                                            <option value="33">IT硬件/软件/服务</option>
                                            <option value="14">办公用品</option>
                                            <option value="30">财经/税务/保险</option>
                                            <option value="13">餐饮/饮料</option>
                                            <option value="19">成人用品</option>
                                            <option value="09">宠物/玩具</option>
                                            <option value="43">地方门户/信息港</option>
                                            <option value="47">电视购物</option>
                                            <option value="32">电信/电子/邮政</option>
                                            <option value="39">电子刊物</option>
                                            <option value="35">法律/政治/军事</option>
                                            <option value="31">房地产/租房</option>
                                            <option value="07">服装/服饰</option>
                                            <option value="25">公司/企业/协会</option>
                                            <option value="20">广告/营销</option>
                                            <option value="08">化妆品/美容</option>
                                            <option value="22">会议/展览/活动</option>
                                            <option value="16">机票/酒店</option>
                                            <option value="12">家居/电器</option>
                                            <option value="17">健身/体育/运动</option>
                                            <option value="04">交友/婚介/聊天</option>
                                            <option value="26">教育/培训</option>
                                            <option value="29">金融/投资/理财</option>
                                            <option value="38">科学/技术</option>
                                            <option value="06">礼品/鲜花</option>
                                            <option value="05">论坛/社区</option>
                                            <option value="28">贸易/商业</option>
                                            <option value="24">门户/综合</option>
                                            <option value="11">母婴/幼儿</option>
                                            <option value="10">女性/内衣</option>
                                            <option value="42">票务</option>
                                            <option value="41">其他</option>
                                            <option value="27">汽车用品</option>
                                            <option value="23">人才/招聘</option>
                                            <option value="37">社会/文化</option>
                                            <option value="15">手机/数码</option>
                                            <option value="03">图书/音像</option>
                                            <option value="48">网络调查</option>
                                            <option value="40">网址大全</option>
                                            <option value="46">网赚</option>
                                            <option value="36">文学/艺术</option>
                                            <option value="45">下载</option>
                                            <option value="50">箱包/鞋类/配饰</option>
                                            <option value="21">新闻/媒体</option>
                                            <option value="44">虚拟/卡类</option>
                                            <option value="18">医药/保健</option>
                                            <option value="34">音乐/mp3</option>
                                            <option value="01">游戏/小游戏</option>
                                            <option value="49">珠宝首饰</option>
                                            <option value="00">综合百货</option>
                                        </select><span id="Span3"></span></li>
                                         <li><span class="rowTitle">网站简介：</span><asp:TextBox ID="txtintro" runat="server" 
                                                 Width="80%" Height="60px"></asp:TextBox><span
                                            id="Span4"></span></li>
                                    </ul>
                                </fieldset>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        </td> </tr> </table>
    </div>
    </form>
</body>
</html>
