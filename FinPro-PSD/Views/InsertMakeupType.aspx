<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Layout.Master" AutoEventWireup="true" CodeBehind="InsertMakeupType.aspx.cs" Inherits="FinPro_PSD.Views.InsertMakeupType" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%if (Session["user"] != null)
        {
    %>
    <%if (((FinPro_PSD.Models.User)Session["user"]).UserRole == "admin")
        { %>
        <h2>Insert Makeup Type</h2>

    <div>
        <asp:Button ID="BackBtn" runat="server" Text="Back" OnClick="BackBtn_Click" />
    </div>
    <div>
        <div>
            <asp:Label ID="NameLbl" runat="server" Text="Name"></asp:Label>
            <asp:TextBox ID="NameTbx" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="ErrorLbl" runat="server" Text="[Error Label]" Visible="false"></asp:Label>
        </div>
        <div>
            <asp:Button ID="InsertBtn" runat="server" Text="Insert" OnClick="InsertBtn_Click" />
        </div>
    </div>
    <%} %>
    <%} %>
</asp:Content>
