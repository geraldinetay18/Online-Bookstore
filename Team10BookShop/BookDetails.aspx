<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookDetails.aspx.cs" Inherits="Team10BookShop.Book_Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <table class="nav-justified">
        <tr>
            <td style="width: 97px">
                &nbsp;</td>
            <td colspan="2" style="height: 22px">
                &nbsp;</td>
        </tr>
        <tr>
            <td rowspan="8" style="width: 97px">
                <asp:Image ID="Image1" runat="server" />
            </td>
            <td colspan="2" style="height: 22px">
                <asp:Label ID="lbTitle" runat="server" Font-Size="X-Large" Text="Title"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 189px; height: 22px;">Book ID:</td>
            <td style="height: 22px">
                <asp:Label ID="lbBookID" runat="server" Text="BookID"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 189px; height: 22px;">ISBN:</td>
            <td style="height: 22px">
                <asp:Label ID="lbISBN" runat="server" Text="ISBN"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 189px; height: 21px;">Category:</td>
            <td style="height: 21px">
                <asp:Label ID="lbCategory" runat="server" Text="Category"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 189px; height: 22px">Author</td>
            <td style="height: 22px">
                <asp:Label ID="lbAuthor" runat="server" Text="Author"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 189px; height: 22px;">Stock:</td>
            <td style="height: 22px">
                <asp:Label ID="lbStock" runat="server" Text="Stock"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 189px; height: 22px;">Price</td>
            <td style="height: 22px">
                <asp:Label ID="lbPrice" runat="server" Text="Price"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 189px">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <span>
                            <asp:Button ID="btnMinus" runat="server" Text="-" Width="28px" OnClick="btnMinus_Click" />
                        </span>
                        <span>
                            <asp:TextBox ID="txQty" runat="server" Width="101px" AutoPostBack="True" Font-Size="Medium" OnTextChanged="txQty_TextChanged" TextMode="Number"></asp:TextBox>
                        </span>
                        <span>
                            <asp:Button ID="btnPlus" runat="server" Text="+" OnClick="btnPlus_Click" Width="28px" />
                        </span>
                    </ContentTemplate>
                </asp:UpdatePanel>
                
            </td>
            <td>
                <asp:Button ID="btnAddToCart" runat="server" Text="Add To Cart" OnClick="btnAddToCart_Click" />
            </td>
        </tr>
    </table>

    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <br />

</asp:Content>
