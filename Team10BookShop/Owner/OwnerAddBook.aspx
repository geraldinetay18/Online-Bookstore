<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OwnerAddBook.aspx.cs" Inherits="Team10BookShop.OwnerAddBook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Title -->
    <h1>Add New Book</h1>

    <!-- Input fields -->
    <table>
        <tr>
            <td> <asp:Label ID="lblBookTitle" runat="server" Text="Book Title"></asp:Label></td>
            <td> <asp:TextBox ID="txtBookTitle" runat="server" TabIndex="2" Width="300px"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidatorBookTitle" runat="server" ErrorMessage="Book Title is required" ControlToValidate="txtBookTitle" ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblCategory" runat="server" Text="Category"></asp:Label></td>
            <td> <asp:DropDownList ID="ddCategory" runat="server" TabIndex="3" Height="21px" Width="150px" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="CategoryID">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MyBooks %>" SelectCommand="SELECT [CategoryID], [Name] FROM [Category]"></asp:SqlDataSource>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorCategory" runat="server" ControlToValidate="ddCategory" ErrorMessage="Category is required" ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
       <tr>
           <td style="height: 25px"><asp:Label ID="lblisbn" runat="server" Text="ISBN"></asp:Label></td>
           <td style="height: 25px"> <asp:TextBox ID="txtISBN" runat="server" TabIndex="4" Width="150px" TextMode="Number"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidatorISBN" runat="server" ControlToValidate="txtISBN" EnableTheming="False" ErrorMessage="ISBN is required" ForeColor="Red">*</asp:RequiredFieldValidator>
                   <asp:RegularExpressionValidator ID="RegularExpressionValidatorISBN" runat="server" ControlToValidate="txtISBN" Display="Dynamic" ErrorMessage="Invalid ISBN" ForeColor="Red" ValidationExpression="\d{13}">*</asp:RegularExpressionValidator>
           </td>
       </tr>
        <tr>
            <td><asp:Label ID="lblAuthor" runat="server" Text="Author"></asp:Label></td>
            <td><asp:TextBox ID="txtAuthor" runat="server" TabIndex="5" Width="150px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorAuthor" runat="server" ControlToValidate="txtISBN" ErrorMessage="Author is required" ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblStock" runat="server" Text="Stock"></asp:Label></td>
            <td> <asp:TextBox ID="txtStock" runat="server" TabIndex="6" TextMode="Number" Width="40px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorStock" runat="server" ControlToValidate="txtStock" ErrorMessage="Stock is required" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidatorStock" runat="server" ControlToValidate="txtStock" ErrorMessage="Stock needs to be at least 0" ForeColor="Red" MaximumValue="10000" MinimumValue="0" Type="Integer">*</asp:RangeValidator>
            </td>
        </tr>

        <tr>
            <td><asp:Label ID="lblPrice" runat="server" Text="Price"></asp:Label></td>
            <td><asp:TextBox ID="txtPrice" runat="server" TabIndex="7" TextMode="Number" Width="40px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorPrice" runat="server" ControlToValidate="txtPrice" ErrorMessage="Price is required" ForeColor="Red">*</asp:RequiredFieldValidator>
                     <asp:RangeValidator ID="RangeValidatorPrice" runat="server" ControlToValidate="txtPrice" ErrorMessage="Price needs to be at least 1" ForeColor="Red" MaximumValue="10000" MinimumValue="1" Type="Integer">*</asp:RangeValidator></td>
        </tr>

        <tr>
            <td><asp:Label ID="lblCover" runat="server" Text="Book Cover"></asp:Label></td>
            <td><asp:FileUpload ID="FileUploadImage" runat="server" TabIndex="8" /></td>
        </tr>
    </table>
     
    <!-- File Upload, Confirm button and Errors Display -->
    <asp:Button ID="btnConfirm" runat="server" Text="Confirm" TabIndex="9" OnClick="btnConfirm_Click" />
    <br />
    <asp:Label ID="lblErrorFileUpload" runat="server" ForeColor="Red"></asp:Label>
    <asp:ValidationSummary ID="ValidationSummaryAddBook" runat="server" ForeColor="Red" />
</asp:Content>
