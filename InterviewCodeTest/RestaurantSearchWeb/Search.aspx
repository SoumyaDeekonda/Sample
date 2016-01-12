<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="RestaurantSearchWeb.Search" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <link rel="stylesheet" type="text/css" href="Base.css" />

        <div id="main" role="main">
            <div class="1-grid  ">...</div>
            <div class="l-grid search-takeaways-boxed">
                <div class="search-takeaways search-takeaways-large">
                    <div class="l-col l-size1of4 postcodeField">

                        <asp:TextBox ID="where" runat="server" CssClass="text text-large input-full postcode valid" placeholder="Enter postcode"></asp:TextBox>
                    </div>
                    <div class="l-col l-size1of3">
                        <asp:Button ID="Find" runat="server" OnClick="Find_Click" Text="Find takeaways" CssClass="ctaButtonHome" />

                    </div>
                </div>
            </div>
        </div>
        <div>
            <div>
                <asp:GridView ID="RestaurantView" AutoGenerateColumns="False" runat="server" HorizontalAlign="Center" EmptyDataText="No data available." CellPadding="4" Font-Names="helvetica,arial,sans-serif" ForeColor="#333333">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="Name" InsertVisible="False" ReadOnly="True" SortExpression="Name">
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Cuisine Types">
                            <ItemTemplate>
                                <asp:Repeater ID="Repeater1" runat="server" DataSource='<%# Eval("CuisineTypes") %>'>
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem,"Name")  %><br />
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="RatingStars" HeaderText="Rating" InsertVisible="False" ReadOnly="True" SortExpression="RatingStars" />
                    </Columns>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
