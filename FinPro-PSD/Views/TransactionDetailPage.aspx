<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Layout.Master" AutoEventWireup="true" CodeBehind="TransactionDetailPage.aspx.cs" Inherits="FinPro_PSD.Views.TransactionDetailPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
            <%if (Session["user"] != null)
                {
    %>
    <%if (((FinPro_PSD.Models.User)Session["user"]).UserRole == "customer")
        { %>
        <asp:GridView ID="TransactionDetailGV" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="TransactionID" HeaderText="Transaction Number" />
                <asp:BoundField DataField="Makeup.MakeupName" HeaderText="Name" />
                <asp:BoundField DataField="Makeup.MakeupType.MakeupTypeName" HeaderText="Type" />
                <asp:BoundField DataField="Makeup.MakeupBrand.MakeupBrandName" HeaderText="Brand" />
                <asp:BoundField DataField="Makeup.MakeupBrand.MakeupBrandRating" HeaderText="Brand Rating" />
                <asp:BoundField DataField="Makeup.MakeupPrice" HeaderText="Price" />
                <asp:BoundField DataField="Makeup.makeupWeight" HeaderText="Weight" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
            </Columns>
        </asp:GridView>
        <%}
            } %>
    </div>
</asp:Content>
