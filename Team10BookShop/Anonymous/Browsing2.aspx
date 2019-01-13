<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Browsing2.aspx.cs" Inherits="Team10BookShop.Anonymous.Browsing2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Update Panel-->
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <!-- Wrapper -->
             <div class="wrapper">

                <!-- Search bar -->
                <div id="booksearchbar" class="jumbotron">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-sm">

                                <span id="search-title">Looking for a book?</span>

                                </div>


                    <asp:DropDownList ID="ddDetails" class="btn btn-primary dropdown-toggle" runat="server">
                        <asp:ListItem >Author</asp:ListItem>
                        <asp:ListItem>Title</asp:ListItem>
                        <asp:ListItem>ISBN</asp:ListItem>
                    </asp:DropDownList>
                      

                    <asp:DropDownList ID="ddCategory" class="btn btn-primary dropdown-toggle" runat="server"  DataTextField="Name" DataValueField="Name" AutoPostBack="True" OnSelectedIndexChanged="ddCategory_SelectedIndexChanged">
                        <asp:ListItem Value="0">All</asp:ListItem>
                        <asp:ListItem Value="1">Children</asp:ListItem>
                        <asp:ListItem Value="2">Technical</asp:ListItem>
                        <asp:ListItem Value="3">Non-Fiction</asp:ListItem>
                        <asp:ListItem Value="4">Finance</asp:ListItem>
                    </asp:DropDownList>
                  </div>
                    <div class="input-group">
                        <asp:TextBox ID="txtSearch" runat="server" class="form-control" placeholder="Search.." ></asp:TextBox>
                        <asp:Button ID="btnSearch" runat="server" class="btn btn-info" Text="Let's Go!" OnClick="btnSearch_Click" />
                        <asp:Label ID="SearchMessage" runat="server" ForeColor="White"></asp:Label>
                    </div>
                </div>

                <!-- Books display-->
                <div id="booksdisplay" class="jumbotron">
                    <div class = "container-fluid">
                        
                    </div>
                    <asp:Panel ID="Panel1" runat="server">
                    
                        <asp:DataList ID="DataList1" runat="server" DataKeyField="BookID" HorizontalAlign="Center" RepeatColumns="3" RepeatDirection="Horizontal" OnItemCommand="DataList1_ItemCommand" CellPadding="50" CellSpacing="50">
                            <ItemTemplate>
                                <div class="book-wrapper" style="text-align:center;">
                                    <div>

                                        <!-- Book top-->
                                         <div class="book-top">
                                             <image  src="../Images/<%# Eval("ISBN") %>.jpg" width="180" height="210" />
                                             <br />
                                             <asp:Label id="TitleLabel" runat="server" Text='<%# Eval("Title") %>' style="font-size:18px; color:lightseagreen; font-weight:bolder;font-family:'Arial Rounded MT'"/>
                                         </div>

                                        <!-- Book middle-->
                                         <div class="book-middle" style="font-size:14px; color:dimgray">
                                            <br />
                                             BookID:
                                            <asp:Label ID="BookIDLabel" runat="server" Text='<%# Eval("BookID") %>' />
                                            <br />
                                            ISBN:
                                            <asp:Label ID="ISBNLabel" runat="server" Text='<%# Eval("ISBN") %>' />
                                            <br />
                                            Author:
                                            <asp:Label ID="AuthorLabel" runat="server" Text='<%# Eval("Author") %>' />
                                            <br />
                                            CategoryID:
                                            <asp:Label ID="CategoryIDLabel" runat="server" Text='<%# Eval("CategoryID") %>' />
                                            <br />
                                             </div>

                                        <!-- Book bottom -->
                                        <div style="font-size:20px; font-weight:bolder;padding-bottom:50px" >
                                            <div style="color:green"> Stock:
                                                <asp:Label ID="StockLabel" runat="server" Text='<%# Eval("Stock") %>' />
                                            </div>
                                        
                                            <div style="color:indianred"> $
                                                <asp:Label ID="PriceLabel" runat="server" Text='<%# Eval("Price") %>' />
                                            </div>
                                            <asp:Button ID="DetailButton" class="btn btn-info" runat="server" Text="View Detail" CommandName="Details" />
                                            <br />
                                            </div> <!-- Book bottom (close) -->
                                    </div><!-- Jumbotron (close)-->
                                </div> <!-- Book wrapper (close)-->
                                </div><!--container-->
                            </ItemTemplate>
                            <SelectedItemStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" />
                         </asp:DataList>
                    </asp:Panel>
                </div> <!-- Book display (close)-->
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
