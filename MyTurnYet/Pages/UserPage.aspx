<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserPage.aspx.cs" Inherits="MyTurnYet.Pages.UserPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registering sidan</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="../Style/bootstrap.min.css" rel="stylesheet" />
    <link href="../Style/Main.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">

        <div id="booking" class="section">
            <asp:Button runat="server" BorderStyle="Solid" ID="logut_btn" BorderWidth="2" BackColor="Red" CssClass="col-lg-12 pull-right" Text="Logga Ut" />
            <div class="section-center">
                <div class="container">
                    <div class="row">
                        <div class="col-md-12 align-self-start">
                            <div class="booking-cta">
                                <h1>Registera dina barn!</h1>
                            </div>
                        </div>
                        <%--Registering Form--%>
                        <div class="col align-self-start col-md-6">
                            <div class="booking-form">
                                <form>
                                    <%-- Epost--%>
                                    <div class="form-group">
                                        <span class="form-label">Barnets Förnamn:</span>
                                        <input class="form-control" runat="server" type="text" id="Fname" placeholder="Skriv barnets förnamn" />
                                    </div>
                                    <%--Lösenord--%>
                                    <div class="form-group">
                                        <span class="form-label">Barnets Efternamn:</span>
                                        <input class="form-control" runat="server" id="Lname" type="text" placeholder="Skriv barnets efternamn" />
                                    </div>
                                    <div class="form-group">
                                        <span class="form-label">Barnets Ålder(år):</span>
                                        <input class="form-control" runat="server" id="age" type="number" placeholder="Skriv barnets ålder" />
                                    </div>
                                    <%-- Knappar--%>
                                    <div class="form-btn">
                                        <button class="submit-btn" runat="server" id="Confirm_Click">Lägg till</button>
                                    </div>
                                </form>
                            </div>
                        </div>
                        <%--Visning Form--%>
                        <div class="col align-self-start col-lg-6">
                            <%--<div class="booking-form">--%>
                            <form>

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
                                    <div class="col-md-12">

                                        <asp:Label runat="server" ID="lbl_3" Font-Size="XX-Large"></asp:Label>
                                        <br />
                                        <asp:Label runat="server" ID="lbl_4" Font-Size="X-Large" Font-Underline="true"></asp:Label>
                                    </div>
                                </asp:Panel>

                                <div class="egen">
                                    <asp:GridView ID="GridView1" CssClass="grid" runat="server" AutoGenerateColumns="false"
                                        CellPadding="4" DataKeyNames="ID" ForeColor="#333333" OnRowCommand="GridView1_RowCommand" GridLines="None">
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
                                                        CommandArgument='<%# Eval("ID") %>' CommandName="DeleteRow">Ta Bort</asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="FName" HeaderText="Barnets Förnamn" SortExpression="FName"></asp:BoundField>
                                            <asp:BoundField DataField="LName" HeaderText="Barnets Efternamn" SortExpression="LName"></asp:BoundField>
                                            <asp:BoundField DataField="Age" HeaderText="Barnets Ålder" SortExpression="Age"></asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </form>
                            <%--</div>--%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>