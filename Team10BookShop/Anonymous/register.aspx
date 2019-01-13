<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="Team10BookShop.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <h2><%: Title %></h2>
    <p>
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
    <h4>Creat a new account</h4>
        <div>
                <asp:Label runat="server" AssociatedControlID="Username" >Username(Email)</asp:Label>
            <div>
                <asp:TextBox runat="server" ID="Username" TextMode="Email"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Username"
                    Display="Dynamic" ErrorMessage="“Username”is necessary." />
        </div></div>
        <div>
            <asp:Label runat="server" AssociatedControlID="Password" >Password</asp:Label>
            <div>
                <asp:TextBox runat="server" ID="Password" TextMode="Password" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                     Display="Dynamic" ErrorMessage="“Password”is necessary." />
                <asp:RegularExpressionValidator runat="server" ID="revCode" ErrorMessage="password must between 6 and 16 characters" 
                    Display="Dynamic" ControlToValidate="PassWord" ValidationExpression="\w{6,16}"></asp:RegularExpressionValidator>
            </div></div>
        <div>
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" >ConfirmPassword</asp:Label>
            <div>
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password"  />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                     Display="Dynamic" ErrorMessage="“ConfirmPassword”is necessary." />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                     Display="Dynamic" ErrorMessage="Password and ConfirmPassword is not the same。" />
            </div></div>
            <div>
                <asp:Button runat="server" OnClick="Register_Click" Text="Register"/>
            </div>
</asp:Content>
