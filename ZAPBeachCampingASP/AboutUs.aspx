<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AboutUs.aspx.cs" Inherits="ZAPBeachCampingASP.AboutUs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="\StyleSheets\bootstrap.css" rel="stylesheet" />
    <link href="\StyleSheets\main.css" rel="stylesheet" />

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="https://use.fontawesome.com/releases/v5.0.8/js/all.js"></script>
</head>
<body>
    <form id="form1" runat="server">

        <div class="container-fluid px-0">
            <div class="row mx-0">
                <div class="col-12 px-0">
                    <img class="img-fluid w-100" src="\Images\Banner.jpg" />
                </div>
            </div>

            <nav class="navbar navbar-expand navbar-dark bg-primary">
                <div class="container-fluid">
                    <div class="collapse navbar-collapse" id="navbarColor01">
                        <ul class="navbar-nav me-auto">
                            <li class="nav-item">
                                <a class="nav-link nav-selected" href="Home.aspx">Forside</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="Booking.aspx">Booking</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="#">Om os</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="Contact.aspx">Kontakt</a>
                            </li>
                        </ul>
                    </div>
                </div>
            </nav>

            <div class="container text-center">
                <div class="row" style="margin: 30px 30px;">
                    <h2 class="color-id-1">Om os
                    </h2>
                    <h3 class="color-id-4">ZAP Beach Camping
                    </h3>
                    <div class="col-md-12 col-md-offset-2">
                        <div class="color-border">
                            &nbsp;
                        </div>
                        <p class="ct-u-size22 ct-u-fontWeight30 marginTop40 text-size text-align-center">
                           Naturskøn campingplads med masser af faciliteter
                            <br />
                            <br />
                            I det skønne naturområde i ZAP Beach Camping i midtjylland ligger campingpladsen i Jesperhus med masser af skønne pladser til din campingvogn, hytter eller telt. Du kan finde en plads på bakkerne i det kuperede terræn eller vælge en plads til campingvognen i et mere fladt område. 
                            <br />
                            <br />
                            Der ligger veludstyrede og moderne servicebygninger fordelt over hele campingpladsen, så du har nem adgang til toilet, bad og køkkenfaciliteter.
                            <br />
                            <br />
                            En ferie på campingpladsen i midtjylland er så meget mere end bare et sted at bo og stille campingvognen. Det er fyldt med masser af gratis aktiviteter, børnevenlige oplevelser og skønne legepladser klar til leg til børnene. 
                        </p>
                    </div>
                </div>
            </div>

            <footer>
                <div class="container-fluid padding">
                    <div class="row text-center">
                        <div class="col-md-4">
                            <hr class="light\">
                            <h5 class="color-id-3">Kontakt oplysninger</h5>
                            <hr class="light\">
                            <p>12 23 45 67</p>
                            <p>Email@gmail.com</p>
                            <p>Humlebivej 10</p>
                            <p>MidtJylland, 9999</p>
                        </div>

                        <div class="col-md-4">
                            <hr class="light\">
                            <h5 class="color-id-3">Åbenningstider</h5>
                            <hr class="light\">
                            <p>Mandag - Fredag: 09 - 17</p>
                            <p>Lørdag: 10 - 16</p>
                            <p>Søndag: Lukket</p>
                        </div>

                        <div class="col-md-4">
                            <hr class="light\">
                            <h5 class="color-id-3">Unused</h5>
                            <hr class="light\">
                            <p>Blank</p>
                            <p>Blank</p>
                            <p>Blank</p>
                        </div>
                        <div class="col-12">
                            <hr class="light\">
                            <h5 class="color-id-3">&copy; ZAB BEACH CAMPING</h5>
                        </div>
                    </div>
                </div>
            </footer>


        </div>
    </form>
</body>
</html>
