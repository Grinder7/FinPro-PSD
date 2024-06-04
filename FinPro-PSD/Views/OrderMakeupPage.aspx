<%@ Page Title="Order Makeup - MakeMeUpzz" Language="C#" MasterPageFile="~/Views/Layout.Master" AutoEventWireup="true" CodeBehind="OrderMakeupPage.aspx.cs" Inherits="FinPro_PSD.Views.OrderMakeupPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Order Makeup</h1>
        <div>
            <div>
            <asp:Button ID="ClearCartBtn" runat="server" Text="Clear Cart" OnClick="ClearCartBtn_Click"/>
               <asp:Button ID="CheckoutBtn" runat="server" Text="Checkout" OnClick="CheckoutBtn_Click"/>
            </div>
            <p>
                Cart: <span><%: Carts.Count %></span>
            </p>
            <asp:GridView ID="OrderMakeupGv" runat="server" AutoGenerateColumns="false" CellPadding="4">
                <Columns>
                    <asp:BoundField DataField="MakeupName" HeaderText="Name" SortExpression="Name"></asp:BoundField>
                    <asp:BoundField DataField="MakeupPrice" HeaderText="Price" SortExpression="Price"></asp:BoundField>
                    <asp:BoundField DataField="MakeupWeight" HeaderText="Weight (g)" SortExpression="Weight (g)"></asp:BoundField>
                    <asp:BoundField DataField="MakeupType.MakeupTypeName" HeaderText="Type" SortExpression="Type"></asp:BoundField>
                    <asp:BoundField DataField="MakeupBrand.MakeupBrandName" HeaderText="Brand Name" SortExpression="Brand Name"></asp:BoundField>
                    <asp:TemplateField HeaderText="Quantity">
                        <ItemTemplate>
                            <asp:HiddenField ID="MakeupIDHf" runat="server" Value='<%# Eval("MakeupID") %>' />
                            <asp:TextBox ID="QuantityTbx" runat="server" TextMode="Number"></asp:TextBox>
                            <asp:Button ID="OrderBtn" runat="server" Text="Order" OnClick="OrderBtn_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
