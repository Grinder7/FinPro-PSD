<%@ Page Title="Login - MakeMeUpzz" Language="C#" MasterPageFile="~/Views/Layout.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="FinPro_PSD.Views.LoginPage1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>Login</h2>

        <div>
            <asp:Label ID="UsernameLbl" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="UsernameTbx" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="PasswordLbl" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="PasswordTbx" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <div>
            <asp:CheckBox ID="RememberChk" runat="server" Text="Remember Me" />
        </div>
        <div>
            <asp:Label ID="ErrorLbl" runat="server" Text="[Error Label]" Visible="false"></asp:Label>
        </div>
        <div>
            <asp:Button ID="LoginBtn" runat="server" Text="Login" OnClick="LoginBtn_Click" />
        </div>
        <div>
            <asp:Label ID="LoginLbl" runat="server" Text="Don't have an account? "></asp:Label>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Views/RegisterPage.aspx">Register</asp:HyperLink>
        </div>
    </div>
</asp:Content>
