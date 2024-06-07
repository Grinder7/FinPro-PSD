<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Layout.Master" AutoEventWireup="true" CodeBehind="TransactionAdminPage.aspx.cs" Inherits="FinPro_PSD.Views.TransactionAdminPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%if (Session["user"] != null)
        {
    %>
    <%if (((FinPro_PSD.Models.User)Session["user"]).UserRole == "admin")
        { %>
    <asp:GridView runat="server" AutoGenerateColumns="False" ID="TransactionAdminGV" OnRowEditing="TransactionAdminGV_RowEditing" OnSelectedIndexChanged="TransactionAdminGV_SelectedIndexChanged">
        <Columns>
            <asp:BoundField HeaderText="Transaction Number" DataField="TransactionID" />
            <asp:BoundField DataField="User.Username" HeaderText="Username" />
            <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" />
            <asp:BoundField DataField="Status" HeaderText="Status" />
            <asp:CommandField ButtonType="Button" EditText="Change" HeaderText="Change Status" ShowCancelButton="False" ShowEditButton="True" ShowHeader="True" />
            <asp:CommandField ButtonType="Button" HeaderText="Action" SelectText="VIew" ShowHeader="True" ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
    <%}
        } %>

</asp:Content>
