<%@ Page Title="Book Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Book.aspx.vb" Inherits="Book" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>書籍情報</h1>
        <asp:GridView ID="Grid_Books" runat="server" AutoGenerateColumns="False" DataKeyNames="BOOK_NO">
            <Columns>
                <asp:BoundField DataField="BOOK_NO" HeaderText="書籍番号" ReadOnly="True" SortExpression="BOOK_NO" />
                <asp:BoundField DataField="BOOK_NAME" HeaderText="書籍名" SortExpression="BOOK_NAME" />
                <asp:BoundField DataField="AUTHOR" HeaderText="著者" SortExpression="AUTHOR" />
                <asp:BoundField DataField="PUBLISHER" HeaderText="出版社" SortExpression="PUBLISHER" />
                <asp:BoundField DataField="PUB_DATE" HeaderText="出版年月日" SortExpression="PUB_DATE" />
                <asp:BoundField DataField="LOAN_FLG" HeaderText="在庫状況" SortExpression="LOAN_FLG" />
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>
