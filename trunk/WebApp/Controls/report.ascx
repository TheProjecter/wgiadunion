<%@ Control Language="C#" AutoEventWireup="true" CodeFile="report.ascx.cs" Inherits="Controls_report" %>

    <link href="../Css/mem_modify.css" rel="stylesheet" type="text/css" />
    
    <p><span>查询期间：</span>
                <asp:TextBox ID="txtstart" runat="server" Width="90px" CssClass="Wdate" onclick=" WdatePicker({ doubleCalendar: true,readOnly:true, dateFmt: 'yyyy-MM-dd'})"></asp:TextBox>
<span>至</span>
                  <asp:TextBox ID="txtend" runat="server"  Width="90px" CssClass="Wdate" onclick=" WdatePicker({ doubleCalendar: true,readOnly:true, dateFmt: 'yyyy-MM-dd'})"></asp:TextBox> 
                &nbsp;
                <asp:LinkButton ID="lbtntoday" runat="server" Text="[今天]"></asp:LinkButton>
                <asp:LinkButton ID="lbtnyesterday" runat="server" Text="[昨天]"></asp:LinkButton>
                <asp:LinkButton ID="lbntweek" runat="server" Text="[本周]"></asp:LinkButton>
                <asp:LinkButton ID="lbtnlastweek" runat="server" Text="[上周]"></asp:LinkButton>
                <asp:LinkButton ID="lbtnmonth" runat="server" Text="[本月]"></asp:LinkButton>
                <asp:LinkButton ID="lbtnlastmonth" runat="server" Text="[上月]"></asp:LinkButton>
            </p>
            <p><span>增加过滤：</span>
                广告主：<asp:TextBox ID="txtadhost" runat="server"></asp:TextBox>
                网站：<asp:DropDownList ID="ddlsite" runat="server"></asp:DropDownList>
            </p>