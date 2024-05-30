<%@ Page Title="Home - MakeMeUpzz" Language="C#" MasterPageFile="~/Views/Layout.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="FinPro_PSD.Views.HomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <%if (Session["user"] != null)
            { %>
        <asp:Label runat="server" ID="HeaderLbl">Hi <%:((FinPro_PSD.Models.User)Session["user"]).Username %> | Role: <%:((FinPro_PSD.Models.User)Session["user"]).UserRole %></asp:Label>
        <%} %>
        <br />
        <br />
        <%if (Session["user"] != null)
            {
        %>
        <%if (((FinPro_PSD.Models.User)Session["user"]).UserRole == "admin")
            { %>
        <asp:GridView runat="server" ID="UserDataGv" EmptyDataText="No User"></asp:GridView>
        <%} %>
        <%} %>
    </div>
</asp:Content>
