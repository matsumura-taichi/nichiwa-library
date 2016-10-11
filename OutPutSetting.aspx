<%@ Page Title="OutPutSetting Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="OutPutSetting.aspx.vb" Inherits="OutPutSetting" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>CSV出力バッチ設定</h1>
        <div>
            【有効・無効】
            <asp:RadioButton ID="enbabled" GroupName="enableConfig" Text="有効" runat="server" />　
            <asp:RadioButton ID="disabled" GroupName="enableConfig" Text="無効" runat="server" />
        </div>
        <div>
            【繰り返し間隔】1
            <asp:DropDownList ID="FreqList" runat="server">
                <asp:ListItem Value="MONTHLY" Text="月"></asp:ListItem>
                <asp:ListItem Value="DAILY" Text="日"></asp:ListItem>
                <asp:ListItem Value="HOURLY" Text="時間"></asp:ListItem>
                <asp:ListItem Value="MINUTELY" Text="分"></asp:ListItem>
            </asp:DropDownList>
            に1回出力
        </div>
        <div>
            【出力時刻】
            <asp:DropDownList ID="HourList" runat="server">
                <asp:ListItem Value="0" Text="0"></asp:ListItem>
                <asp:ListItem Value="1" Text="1"></asp:ListItem>
                <asp:ListItem Value="2" Text="2"></asp:ListItem>
                <asp:ListItem Value="3" Text="3"></asp:ListItem>
                <asp:ListItem Value="4" Text="4"></asp:ListItem>
                <asp:ListItem Value="5" Text="5"></asp:ListItem>
                <asp:ListItem Value="6" Text="6"></asp:ListItem>
                <asp:ListItem Value="7" Text="7"></asp:ListItem>
                <asp:ListItem Value="8" Text="8"></asp:ListItem>
                <asp:ListItem Value="9" Text="9"></asp:ListItem>
                <asp:ListItem Value="10" Text="10"></asp:ListItem>
                <asp:ListItem Value="11" Text="11"></asp:ListItem>
                <asp:ListItem Value="12" Text="12"></asp:ListItem>
                <asp:ListItem Value="13" Text="13"></asp:ListItem>
                <asp:ListItem Value="14" Text="14"></asp:ListItem>
                <asp:ListItem Value="15" Text="15"></asp:ListItem>
                <asp:ListItem Value="16" Text="16"></asp:ListItem>
                <asp:ListItem Value="17" Text="17"></asp:ListItem>
                <asp:ListItem Value="18" Text="18"></asp:ListItem>
                <asp:ListItem Value="19" Text="19"></asp:ListItem>
                <asp:ListItem Value="20" Text="20"></asp:ListItem>
                <asp:ListItem Value="21" Text="21"></asp:ListItem>
                <asp:ListItem Value="22" Text="22"></asp:ListItem>
                <asp:ListItem Value="23" Text="23"></asp:ListItem>
            </asp:DropDownList>:
            <asp:DropDownList ID="MinuteList" runat="server">
                <asp:ListItem Value="0" Text="00"></asp:ListItem>
                <asp:ListItem Value="10" Text="10"></asp:ListItem>
                <asp:ListItem Value="20" Text="20"></asp:ListItem>
                <asp:ListItem Value="30" Text="30"></asp:ListItem>
                <asp:ListItem Value="40" Text="40"></asp:ListItem>
                <asp:ListItem Value="50" Text="50"></asp:ListItem>
            </asp:DropDownList>　
            ※繰り返し間隔が「日」と「月」の場合のみ有効
        </div>
        <div>
            【開始日】
            <asp:Calendar ID="StartDate" runat="server"></asp:Calendar>        
        </div>
        <div>
            【終了日】
            <asp:Calendar ID="EndDate" runat="server"></asp:Calendar>
        </div>
        <div>
            <asp:Button ID="Setting" runat="server" Text="設定" />
        </div>
    </div>

</asp:Content>
