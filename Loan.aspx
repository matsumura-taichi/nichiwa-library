<%@ Page Title="Loan Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Loan.aspx.vb" Inherits="Loan" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>貸出情報</h1>
        <p><asp:LinkButton ID="LinkLoanAdd" runat="server">追加</asp:LinkButton></p>
        <p><asp:LinkButton ID="LinkOutPutSetting" runat="server">CSV出力バッチ設定</asp:LinkButton></p>
        <asp:GridView ID="Grid_Loans" runat="server" AutoGenerateColumns="False" DataKeyNames="LOAN_NO">
            <Columns>
                <asp:BoundField DataField="LOAN_NO" HeaderText="貸出番号" ReadOnly="True" SortExpression="LOAN_NO" />
                <asp:BoundField DataField="BOOK_NAME" HeaderText="書籍名" SortExpression="BOOK_NAME" />
                <asp:BoundField DataField="EMP_NAME" HeaderText="社員名" SortExpression="EMP_NAME" />
                <asp:BoundField DataField="LENT_DATE" HeaderText="貸出日時" SortExpression="LENT_DATE" />
                <asp:BoundField DataField="RETURN_DATE" HeaderText="返却日時" SortExpression="RETURN_DATE" />
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>
