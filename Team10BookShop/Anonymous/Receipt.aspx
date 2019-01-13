<%@ Page Title="Receipt" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Receipt.aspx.cs" Inherits="Team10BookShop.Receipt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <h1>Order Summary</h1><br />
    <h4>Thank you. Your order has been confirmed.</h4><br />
        <div>
            <asp:GridView ID="PurchaseGridView" runat="server" AutoGenerateColumns="False" Width="676px">
            <Columns>                
                <asp:TemplateField HeaderText="No.">
                <ItemTemplate>
                <%# Container.DataItemIndex+1 %>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Title" HeaderText="Title" />
                <asp:BoundField DataField="Author" HeaderText="Author" />
                <asp:BoundField DataField="ISBN" HeaderText="ISBN" />
                <asp:BoundField DataField="Price" HeaderText="Price" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <image src="../Images/<%# Eval("ISBN") %>.jpg" width="90" height="120"></image>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            </asp:GridView>
        </div>
        <br />
        <div>
            Payment received is S$<asp:Label ID="PriceLabel" runat="server" Text="Label"></asp:Label>.
        </div>
</asp:Content>
