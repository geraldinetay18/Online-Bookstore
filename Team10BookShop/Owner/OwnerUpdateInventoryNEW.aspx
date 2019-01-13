<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OwnerUpdateInventoryNEW.aspx.cs" Inherits="Team10BookShop.OwnerUpdateInventoryNEW" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="OnRowCancelingEdit" OnRowDeleting="OnRowDeleting" OnRowEditing="OnRowEditing" OnRowUpdating="OnRowUpdating" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="1234px" DataKeyNames="BookID">
        <Columns>
            <asp:BoundField DataField="BookID" HeaderText="Book ID" />
            <asp:BoundField DataField="Title" HeaderText="Title" />
            <asp:BoundField DataField="CategoryID" HeaderText="Category ID" />
            <asp:BoundField DataField="ISBN" HeaderText="ISBN" />
            <asp:BoundField DataField="Author" HeaderText="Author" />
            <asp:BoundField DataField="Stock" HeaderText="Stock" />
            <asp:BoundField DataField="Price" DataFormatString="{0:C}" HeaderText="Price" />
            <asp:CommandField InsertText="" NewText="" ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
    <br />
    <br />
        <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="125px">
        </asp:DetailsView>
    </asp:Content>
