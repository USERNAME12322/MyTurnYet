<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateAccount.aspx.cs" Inherits="MyTurnYet.Pages.CreateAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Skapa Ett konto</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="../Style/bootstrap.min.css" rel="stylesheet" />
    <link href="../Style/Main.css" rel="stylesheet" />
</head>
<body>

    <form id="form1" runat="server">
        <asp:HiddenField ID="hfId" runat="server" />

        <div id="booking" class="section">
            <div class="section-center">
                <div class="container">
                    <div class="row">
                        <div class="col align-self-start">
                            <div class="booking-cta">
                                <h1>Skapa Ett Konto!</h1>
                            </div>
                        </div>
                        <div class="col align-self-center">
                            <div class="booking-form">
                                <form>
                                    <%-- Epost--%>
                                    <div class="form-group">
                                        <span class="form-label">E-Post</span>
                                        <input class="form-control" runat="server" type="email" id="epost" placeholder="Skriv din Email">
                                    </div>
                                    <%--Lösenord--%>
                                    <div class="form-group">
                                        <span class="form-label">Lösenord</span>
                                        <input class="form-control" runat="server" id="pass" type="password" placeholder="Skriv ditt Lösenord">
                                    </div>
                                    <%-- Knappar--%>
                                    <div class="form-btn">
                                        <button class="submit-btn" runat="server" id="Confirm_Click">Bekräfta</button>
                                    </div>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>