<%@ Page Title="Register - MakeMeUpzz" Language="C#" MasterPageFile="~/Views/Layout.Master" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="FinPro_PSD.Views.RegisterPage1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>Register</h2>
        <div>
            <asp:Label ID="UsernameLbl" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="UsernameTbx" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="EmailLbl" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="EmailTbx" runat="server" TextMode="Email"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="GenderLbl" runat="server" Text="Gender"></asp:Label>
            <div>
                <asp:RadioButtonList ID="GenderRbl" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="Male">&amp;#160 Male</asp:ListItem>
                    <asp:ListItem Value="Female">&amp;#160 Female</asp:ListItem>
                </asp:RadioButtonList>
            </div>
        </div>
        <div>
            <asp:Label ID="DOBLbl" runat="server" Text="Date Of Birth"></asp:Label>
            <div>
                <asp:TextBox runat="server" TextMode="Date" ID="DOBCalendar"/>
                <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="DOBUpdatePanel" runat="server">
                    <ContentTemplate>
                        <asp:Calendar ID="DOBCalendar" runat="server"></asp:Calendar>
                    </ContentTemplate>
                </asp:UpdatePanel>--%>
            </div>
        </div>
        <div>
            <asp:Label ID="PasswordLbl" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="PasswordTbx" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="ConfirmPasswordLbl" runat="server" Text="Confirm Password"></asp:Label>
            <asp:TextBox ID="ConfirmPasswordTbx" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="ErrorLbl" runat="server" Text="[Error Label]" Visible="false"></asp:Label>
        </div>
        <div>
            <asp:Button ID="RegisterBtn" runat="server" Text="Register" OnClick="RegisterBtn_Click" />
        </div>
        <div>
            <asp:Label ID="LoginLbl" runat="server" Text="Already have an account? "></asp:Label>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Views/LoginPage.aspx">Login</asp:HyperLink>
        </div>
    </div>
</asp:Content>
