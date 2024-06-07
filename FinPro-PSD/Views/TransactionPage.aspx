<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Layout.Master" AutoEventWireup="true" CodeBehind="TransactionPage.aspx.cs" Inherits="FinPro_PSD.Views.TransactionPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <%
            if (((FinPro_PSD.Models.User)Session["user"]).UserRole == "customer")
            {
        %>
            <asp:GridView ID="TransactionGV" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="TransactionGV_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="TransactionID" HeaderText="Transaction Number" />
                    <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" />
                    <asp:CommandField ButtonType="Button" HeaderText="Action" SelectText="View" ShowHeader="True" ShowSelectButton="True" />
                </Columns>

            </asp:GridView>
        <%} %>
        
    </div>

</asp:Content>
