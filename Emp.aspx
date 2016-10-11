<%@ Page Title="Emp Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Emp.aspx.vb" Inherits="Emp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>社員情報</h1>
        <p>
            <asp:GridView ID="Grid_Emps" runat="server" AutoGenerateColumns="False" DataKeyNames="EMP_NO">
                <Columns>
                    <asp:BoundField DataField="EMP_NO" HeaderText="社員番号" ReadOnly="True" SortExpression="EMP_NO" />
                    <asp:BoundField DataField="EMP_NAME" HeaderText="社員名" SortExpression="EMP_NAME" />
                    <asp:BoundField DataField="JOB" HeaderText="役職" SortExpression="JOB" />
                </Columns>
            </asp:GridView>
        </p>
    </div>

</asp:Content>
