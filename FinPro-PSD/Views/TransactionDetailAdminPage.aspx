<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Layout.Master" AutoEventWireup="true" CodeBehind="TransactionDetailAdminPage.aspx.cs" Inherits="FinPro_PSD.Views.TransactionDetailAdminPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%if (Session["user"] != null)
        {
    %>
    <%if (((FinPro_PSD.Models.User)Session["user"]).UserRole == "admin")
        { %>
    <asp:GridView ID="TransactionDetailAdminGV" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="TransactionID" HeaderText="Transaction Number" />
            <asp:BoundField DataField="Makeup.MakeupName" HeaderText="Name" />
            <asp:BoundField DataField="Makeup.MakeupType.MakeupTypeName" HeaderText="Type" />
            <asp:BoundField DataField="Makeup.MakeupBrand.MakeupBrandName" HeaderText="Brand" />

            <asp:BoundField DataField="Makeup.MakeupBrand.MakeupBrandRating" HeaderText="Brand Rating" />
            <asp:BoundField DataField="Makeup.MakeupPrice" HeaderText="Price" />
            <asp:BoundField DataField="Makeup.MakeupWeight" HeaderText="Weight" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />

        </Columns>
    </asp:GridView>
    <%}
      }%>
</asp:Content>
