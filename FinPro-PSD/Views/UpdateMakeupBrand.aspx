<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Layout.Master" AutoEventWireup="true" CodeBehind="UpdateMakeupBrand.aspx.cs" Inherits="FinPro_PSD.Views.UpdateMakeupBrand" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%if (Session["user"] != null)
        {
    %>
    <%if (((FinPro_PSD.Models.User)Session["user"]).UserRole == "admin")
        { %>
    <h2>Update Makeup Brand</h2>

    <div>
        <asp:Button ID="BackBtn" runat="server" Text="Back" OnClick="BackBtn_Click" />
        <div>
            <asp:Label ID="MakeupBrandIdLbl" runat="server" Text="Id"></asp:Label>
            <asp:TextBox ID="MakeupBrandIdTbx" runat="server" ReadOnly="true"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="MakeupBrandNameLbl" runat="server" Text="Name"></asp:Label>
            <asp:TextBox ID="MakeupBrandNameTbx" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="MakeupBrandRatingLbl" runat="server" Text="Rating"></asp:Label>
            <asp:TextBox ID="MakeupBrandRatingTbx" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="MakeupBrandErrorLbl" runat="server" Text="[Error Label]" Visible="false"></asp:Label>
        </div>
        <div>
            <asp:Button ID="UpdateMakeupBrandBtn" runat="server" Text="Update" OnClick="UpdateMakeupBrandBtn_Click" />
        </div>
    </div>
    <%} %>
    <%} %>
</asp:Content>
