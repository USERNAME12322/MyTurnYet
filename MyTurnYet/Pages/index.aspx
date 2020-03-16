<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="MyTurnYet.Pages.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Startsidan</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="../Style/bootstrap.min.css" rel="stylesheet" />
    <link href="../Style/Main.css" rel="stylesheet" />

    <%--<script type="text/javascript">
        function preventBack() { window.history.forward(); }
        setTimeout("preventBack()", 0);
        window.onunload = function () { null };
    </script>--%>
</head>
<body>
    <form id="form1" runat="server">

        <div id="booking" class="section">
            <div class="section-center">
                <div class="container">
                    <div class="row">
                        <div class="col align-self-start">
                            <div class="booking-cta">
                                <h1>Registera dina barn!</h1>
                                <h3>Välkommen till vår webbsida här kan du registera dina barn enkelt i vår lekstad medan du handlar.
                                </h3>
                            </div>
                        </div>
                        <div class="col align-self-start col-md-9">
                            <div class="booking-form">
                                <form>
                                    <%-- Epost--%>
                                    <div class="form-group">
                                        <span class="form-label">E-Post</span>
                                        <input class="form-control" runat="server" id="epost" type="email" placeholder="Skriv din Email">
                                    </div>
                                    <%--Lösenord--%>
                                    <div class="form-group">
                                        <span class="form-label">Lösenord</span>
                                        <input class="form-control" type="password" runat="server" id="pass" placeholder="Skriv ditt Lösenord">
                                    </div>
                                    <%-- Knappar--%>
                                    <div class="form-btn">
                                        <button class="submit-btn" runat="server" id="LogIn_Btn">Logga In</button>
                                        <button class="submit-btn" runat="server" id="Crt_Btn">Skapa Ett konto</button>
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