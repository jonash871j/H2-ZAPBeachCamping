<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ZAPBeachCampingASP.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%--<link href="\StyleSheets\bootstrap.min.css" rel="stylesheet" />--%>
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
                                <a class="nav-link nav-selected" href="#">Forside</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="Booking.aspx">Booking</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="#">Om os</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="#">Kontakt</a>
                            </li>
                        </ul>
                    </div>
                </div>
            </nav>

            <div class="container-fluid">
                <div class="row" style="margin: 20px 20px;">
                    <div class="col-xs-12 col-sm-10 col-md-4 box-padding">
                        <h2 class="color-id-1">Bedste campingplads</h2>
                        <p class="color-id-2">Vores gæster sætter pris på design, kvalitet og masser af god plads på campingpladsen. Derfor investerer vi hvert år i nye lækre omgivelser og forbedringer, der gør hele campingoplevelsen mindst 6 stjerner værd. Og som de første i Skandinavien tilbyder vi nu XL luksuspladser til dig, der gerne vil have lidt ekstra i ferien. </p>
                    </div>

                    <div class="col-xs-12 col-sm-10 col-md-4 box-padding">
                        <h2 class="color-id-1">En uforglemmelig tur</h2>
                        <p class="color-id-2">Vi ved, at den enkelte campinggæst er lige så unik som sten på stranden, og derfor også har specifikke ønsker til deres ferie. Vi forsøger derfor hele tiden er udvide vores katalog i forhold campingpladser og faciliteter, så vi kan imødekomme så mange som muligt. Vi elsker nemlig, når vores campingplads er fuld af glade mennesker, der bare vil nyde en god ferie i afslappende omgivelser.   </p>
                    </div>

                    <div class="col-xs-12 col-sm-10 col-md-4 box-padding">
                        <h2 class="color-id-1">Camping i midtjylland</h2>
                        <p class="color-id-2">Nogle campinggæster er glade for det enkle og en ferie uden for meget luksus, men vi oplever også at efterspørgslen bliver større og større på campingpladser, der tilbyder lidt ekstra til campingferien. En campingferie behøver nemlig ikke betyde, at I skal dele toilet med andre eller undvære de elektroniske bekvemmeligheder - selvom det er charmerende i sig selv.</p>
                    </div>
                </div>
            </div>

            <div id="slides" class="carousel slide" data-ride="carousel">
                <ul class="carousel-indicators">
                    <li data-target="#slides" data-slide-to="0" class="active"></li>
                    <li data-target="#slides" data-slide-to="1"></li>
                    <li data-target="#slides" data-slide-to="2"></li>
                </ul>

                <div class="carousel-inner">
                    <div class="carousel-item active">
                        <img class="img-fluid w-100" src="\Images\Slider1.jpg" />
                        <div class="carousel-caption image-text-background">
                            <h1 class="display-2">ZAP BEACH CAMPING</h1>
                            <h3>BOOK DIN FERIE</h3>
                            <a href="Booking.aspx" class="btn btn-primary btn-lg">BOOK NU</a>
                        </div>
                    </div>
                    <div class="carousel-item">
                        <img class="img-fluid w-100" src="\Images\Slider2.jpg" />
                        <div class="carousel-caption image-text-background">
                            <h1 class="display-2">ZAP BEACH CAMPING</h1>
                            <h3>BOOK DIN FERIE</h3>
                            <a href="Booking.aspx" class="btn btn-primary btn-lg">BOOK NU</a>
                        </div>
                    </div>
                    <div class="carousel-item">
                        <img class="img-fluid w-100" src="\Images\Slider3.jpg" />
                        <div class="carousel-caption image-text-background">
                            <h1 class="display-2">ZAP BEACH CAMPING</h1>
                            <h3>BOOK DIN FERIE</h3>
                            <a href="Booking.aspx" class="btn btn-primary btn-lg">BOOK NU</a>
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
        </div>
    </form>
</body>
</html>
