<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Layout.Master" AutoEventWireup="true" CodeBehind="ManageMakeup.aspx.cs" Inherits="FinPro_PSD.Views.ManageMakeup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%if (Session["user"] != null)
        {
    %>
    <%if (((FinPro_PSD.Models.User)Session["user"]).UserRole == "admin")
        { %>
    <div>
        <asp:Button ID="InsertMakeupBtn" runat="server" Text="Insert Makeup" OnClick="InsertMakeupBtn_Click" />
        <asp:Button ID="InsertMakeupTypeBtn" runat="server" Text="Insert Makeup Type" OnClick="InsertMakeupTypeBtn_Click" />
        <asp:Button ID="InsertMakeupBrandBtn" runat="server" Text="Insert Makeup Brand" OnClick="InsertMakeupBrandBtn_Click" />
        <br />
    </div>
    <div>
        <asp:GridView runat="server" ID="MakeupGv" EmptyDataText="No Makeup" OnRowEditing="GridView_RowEditingMakeup" OnRowDeleting="GridView_RowDeletingMakeup" DataKeyNames="MakeupID">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ButtonType="Button" ShowHeader="True" HeaderText="Actions"></asp:CommandField>
            </Columns>
        </asp:GridView>
        <br />
    </div>
    <div>
        <asp:GridView runat="server" ID="MakeupTypeGv" EmptyDataText="No MakeupType" OnRowEditing="GridView_RowEditingMakeupType" OnRowDeleting="GridView_RowDeletingMakeupType" DataKeyNames="MakeupTypeID">
            <Columns>
                <asp:CommandField ShowCancelButton="False" ShowDeleteButton="True" ShowEditButton="True" ButtonType="Button" ShowHeader="True" HeaderText="Actions"></asp:CommandField>
            </Columns>
        </asp:GridView>

        <br />

    </div>
    <div>
        <asp:GridView runat="server" ID="MakeupBrandGv" EmptyDataText="No MakeupBrand" OnRowEditing="GridView_RowEditingMakeupBrand" OnRowDeleting="GridView_RowDeletingMakeupBrand" DataKeyNames="MakeupBrandID">
            <Columns>
                <asp:CommandField ShowCancelButton="False" ShowDeleteButton="True" ShowEditButton="True" ButtonType="Button" ShowHeader="True" HeaderText="Actions"></asp:CommandField>
            </Columns>
        </asp:GridView>

        <br />
    </div>
    <%} %>
    <%} %>
</asp:Content>
