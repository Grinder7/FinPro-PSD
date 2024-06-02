<%@ Page Title="Update MakeupType" Language="C#" MasterPageFile="~/Views/Layout.Master" AutoEventWireup="true" CodeBehind="UpdateMakeupType.aspx.cs" Inherits="FinPro_PSD.Views.UpdateMakeupType" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%if (Session["user"] != null)
        {
    %>
    <%if (((FinPro_PSD.Models.User)Session["user"]).UserRole == "admin")
        { %>
    <h2>Update Makeup Type</h2>

    <div>
        <asp:Button ID="BackBtn" runat="server" Text="Back" OnClick="BackBtn_Click" />
        <div>
            <asp:Label ID="MakeupTypeIdLbl" runat="server" Text="Id"></asp:Label>
            <asp:TextBox ID="MakeupTypeIdTbx" runat="server" ReadOnly="true"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="MakeupTypeNameLbl" runat="server" Text="Name"></asp:Label>
            <asp:TextBox ID="MakeupTypeNameTbx" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="MakeupTypeErrorLbl" runat="server" Text="[Error Label]" Visible="false"></asp:Label>
        </div>
        <div>
            <asp:Button ID="UpdateMakeupTypeBtn" runat="server" Text="Update" OnClick="UpdateMakeupTypeBtn_Click" />
        </div>
    </div>
    <%} %>
    <%} %>
</asp:Content>
