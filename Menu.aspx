<%@ Page Title="Menu Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Menu.aspx.vb" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>メニュー</h1>
        <p>
            <asp:LinkButton ID="LinkLoan" runat="server">貸出情報</asp:LinkButton>
        </p>
        <p>
            <asp:LinkButton ID="LinkBook" runat="server">書籍情報</asp:LinkButton>
        </p>
        <p>
            <asp:LinkButton ID="LinkEmp" runat="server">社員情報</asp:LinkButton>
        </p>
    </div>

</asp:Content>
