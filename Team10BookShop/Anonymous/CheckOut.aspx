<%@ Page Title="Cart Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CheckOut.aspx.cs" Inherits="Team10BookShop.CheckOut" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Cart Item</h1>
    <div class="panel panel-default">
            <asp:GridView ID="CartGridView" runat="server" AutoGenerateColumns="False" Width="676px" OnRowDeleting="OnRowDeleting">
                <%--divClass--%>
                
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
                
                <asp:CommandField ShowDeleteButton="True" HeaderText="Delete"/>                
            </Columns>
            </asp:GridView>

               
        </div>
        </>
        <br />
        <div>
            Total price is S$<asp:Label ID="PriceLabel" runat="server" Text="Label"></asp:Label>.
        </div>
        <br />
        <div>
            <%--Changes--%>
            
            <asp:Button ID="BackButton" runat="server" Text="Back" cssClass="btn btn-primary" OnClick="BackButton_Click"/>
            <asp:Button ID="ConfirmButton" runat="server" Text="Confirm" OnClick="ConfirmButton_Click" cssClass="btn btn-primary" />
        </div>
        
</asp:Content>