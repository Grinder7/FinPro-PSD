<%@ Page Title="Profile - MakeMeUpzz" Language="C#" MasterPageFile="~/Views/Layout.Master" AutoEventWireup="true" CodeBehind="ProfilePage.aspx.cs" Inherits="FinPro_PSD.Views.ProfilePage" %>
<%@ MasterType VirtualPath="Layout.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Profile</h1>
        <div>
            <div>
                <asp:Label ID="UsernameLbl" runat="server" Text="Username"></asp:Label>
                <asp:TextBox ID="UsernameTbx" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="EmailLbl" runat="server" Text="Email"></asp:Label>
                <asp:TextBox ID="EmailTbx" runat="server"></asp:TextBox>
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
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="DOBUpdatePanel" runat="server">
                        <ContentTemplate>
                            <asp:Calendar ID="DOBCalendar" runat="server"></asp:Calendar>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div>
                <asp:Label ID="RoleLbl" runat="server" Text="Role"></asp:Label>
                <asp:TextBox ID="RoleTbx" runat="server" ReadOnly="true" />
            </div>
            <div>
                <asp:Label ID="ErrorLbl" runat="server" Text="[Error Label]" Visible="false"></asp:Label>
            </div>
            <div>
                <asp:Button ID="UpdateBtn" runat="server" Text="Update" OnClick="UpdateBtn_Click" />
            </div>
        </div>
        <div>
            <h2>Change Password</h2>
            <div>
                <asp:Label ID="OldPasswordLbl" runat="server" Text="Old Password"></asp:Label>
                <asp:TextBox ID="OldPasswordTbx" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="NewPasswordLbl" runat="server" Text="New Password"></asp:Label>
                <asp:TextBox ID="NewPasswordTbx" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="PasswordErrorLbl" Text="[Error Label]" runat="server" Visible="false" />
            </div>
            <div>
                <asp:Button ID="UpdatePasswordBtn" Text="Update Password" runat="server" OnClick="UpdatePasswordBtn_Click" />
            </div>

        </div>
    </div>
</asp:Content>
