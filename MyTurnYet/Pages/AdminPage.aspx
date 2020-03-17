<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="MyTurnYet.Pages.AdminPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Personal Sidan</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="../Style/bootstrap.min.css" rel="stylesheet" />
    <link href="../Style/Main.css" rel="stylesheet" />

    <script>
        function refreshPage() {
            window.location.reload();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="booking" class="section">
            <asp:Button runat="server" BorderStyle="Solid" ID="logut_btn" BorderWidth="2" BackColor="Red" CssClass="col-lg-12 pull-right" Text="Logga Ut" />

            <%-- Registerade-barn form--%>
            <asp:Panel runat="server" ID="Panel_notfound" Visible="false">
                <div class="col-md-12 text-center">

                    <asp:Label runat="server" ID="lbl_1" Font-Size="XX-Large"></asp:Label>
                    <br />
                    <asp:Label runat="server" ID="lbl_2"></asp:Label>
                    <center>
                     <asp:Image ID="notfound_img" CssClass="img-responsive" runat="server" />
                       </center>
                </div>
            </asp:Panel>

            <asp:Panel runat="server" ID="Panel_found" Visible="false">
                <div class="col-md-12 text-center">

                    <asp:Label runat="server" ID="lbl_3" Font-Size="XX-Large"></asp:Label>
                    <br />
                    <asp:Label runat="server" ID="lbl_4" Font-Size="X-Large" Font-Underline="true"></asp:Label>
                </div>
            </asp:Panel>
            <asp:GridView ID="GridView1" CssClass="grid col-md-12" runat="server" AutoGenerateColumns="false"
                CellPadding="4" AllowSorting="false" DataKeyNames="ID" ForeColor="#333333" OnRowCommand="GridView1_RowCommand" GridLines="Both">
                <%--Design--%>
                <AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>

                <EditRowStyle BackColor="#999999"></EditRowStyle>

                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>

                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>

                <PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>

                <RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

                <SortedAscendingCellStyle BackColor="#E9E7E2"></SortedAscendingCellStyle>

                <SortedAscendingHeaderStyle BackColor="#506C8C"></SortedAscendingHeaderStyle>

                <SortedDescendingCellStyle BackColor="#FFFDF8"></SortedDescendingCellStyle>

                <SortedDescendingHeaderStyle BackColor="#6F8DAE"></SortedDescendingHeaderStyle>

                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="lbl_delete"
                                CommandArgument='<%# Eval("ID") %>' CommandName="DeleteRow">Bekräfta</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="FName" HeaderText="Barnets Förnamn" SortExpression="FName"></asp:BoundField>
                    <asp:BoundField DataField="LName" HeaderText="Barnets Efternamn" SortExpression="LName"></asp:BoundField>
                    <asp:BoundField DataField="Age" HeaderText="Barnets Ålder" SortExpression="Age"></asp:BoundField>
                    <asp:BoundField DataField="Time" HeaderText="Registerings Tiden" SortExpression="Time"></asp:BoundField>
                </Columns>
            </asp:GridView>
            <br />

            <%-- Inlämnade-barn form--%>
            <asp:Panel runat="server" ID="Panel1" Visible="false">
                <div class="col-md-12 text-center">

                    <asp:Label runat="server" ID="Label1" Font-Size="XX-Large"></asp:Label>
                    <br />
                    <asp:Label runat="server" ID="Label2"></asp:Label>
                    <center>
                     <asp:Image ID="Image1" CssClass="img-responsive" runat="server" />
                       </center>
                </div>
            </asp:Panel>

            <asp:Panel runat="server" ID="Panel2" Visible="false">
                <div class="col-md-12 text-center">

                    <asp:Label runat="server" ID="Label3" Font-Size="XX-Large"></asp:Label>
                    <br />
                    <asp:Label runat="server" ID="Label4" Font-Size="X-Large" Font-Underline="true"></asp:Label>
                </div>
            </asp:Panel>
            <asp:GridView ID="GridView2" CssClass="grid col-md-12" runat="server" AutoGenerateColumns="false"
                CellPadding="4" AllowSorting="false" OnRowCommand="GridView2_RowCommand" DataKeyNames="ID" ForeColor="#333333" GridLines="Both">
                <%--Design--%>
                <AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>

                <EditRowStyle BackColor="#999999"></EditRowStyle>

                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>

                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>

                <PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>

                <RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

                <SortedAscendingCellStyle BackColor="#E9E7E2"></SortedAscendingCellStyle>

                <SortedAscendingHeaderStyle BackColor="#506C8C"></SortedAscendingHeaderStyle>

                <SortedDescendingCellStyle BackColor="#FFFDF8"></SortedDescendingCellStyle>

                <SortedDescendingHeaderStyle BackColor="#6F8DAE"></SortedDescendingHeaderStyle>

                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="lbl_delete"
                                CommandArgument='<%# Eval("ID") %>' CommandName="DeleteRow">Hämtats</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="FName" HeaderText="Barnets Förnamn" SortExpression="FName"></asp:BoundField>
                    <asp:BoundField DataField="LName" HeaderText="Barnets Efternamn" SortExpression="LName"></asp:BoundField>
                    <asp:BoundField DataField="Age" HeaderText="Barnets Ålder" SortExpression="Age"></asp:BoundField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>