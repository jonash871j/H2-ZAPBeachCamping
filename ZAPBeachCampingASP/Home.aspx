<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ZAPBeachCampingASP.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="\StyleSheets\bootstrap.css" rel="stylesheet" />
    <link href="\StyleSheets\bootstrap.min.css" rel="stylesheet" />
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

            <nav class="navbar navbar-expand-lg navbar-dark bg-primary">
                <div class="container-fluid">
                    <a class="navbar-brand" href="#">Forside</a>
                    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarColor01" aria-controls="navbarColor01" aria-expanded="false" aria-label="Toggle navigation">
                        <span class="navbar-toggler-icon"></span>
                    </button>

                    <div class="collapse navbar-collapse" id="navbarColor01">
                        <ul class="navbar-nav me-auto">
                            <li class="nav-item">
                                <a class="nav-link" href="#">Booking</a>
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
                        <p class="color-id-2">Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi. Nam liber tempor cum soluta nobis eleifend option congue nihil imperdiet doming id quod mazim placerat facer possim assum. Typi non habent claritatem insitam; est usus legentis in iis qui facit eorum claritatem. </p>
                    </div>

                    <div class="col-xs-12 col-sm-10 col-md-4 box-padding">
                        <h2 class="color-id-1">En uforglemmelig tur</h2>
                        <p class="color-id-2">Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi. Nam liber tempor cum soluta nobis eleifend option congue nihil imperdiet doming id quod mazim placerat facer possim assum. Typi non habent claritatem insitam; est usus legentis in iis qui facit eorum claritatem. </p>
                    </div>

                    <div class="col-xs-12 col-sm-10 col-md-4 box-padding">
                        <h2 class="color-id-1">Camping i midtjylland</h2>
                        <p class="color-id-2">Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi. Nam liber tempor cum soluta nobis eleifend option congue nihil imperdiet doming id quod mazim placerat facer possim assum. Typi non habent claritatem insitam; est usus legentis in iis qui facit eorum claritatem. </p>
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
                            <button type="button" class="btn btn-primary btn-lg">BOOK NU</button>
                        </div>
                    </div>
                    <div class="carousel-item">
                        <img class="img-fluid w-100" src="\Images\Slider2.jpg" />
                        <div class="carousel-caption image-text-background">
                            <h1 class="display-2">ZAP BEACH CAMPING</h1>
                            <h3>BOOK DIN FERIE</h3>
                            <button type="button" class="btn btn-primary btn-lg">BOOK NU</button>
                        </div>
                    </div>
                    <div class="carousel-item">
                        <img class="img-fluid w-100" src="\Images\Slider3.jpg" />
                        <div class="carousel-caption image-text-background">
                            <h1 class="display-2">ZAP BEACH CAMPING</h1>
                            <h3>BOOK DIN FERIE</h3>
                            <button type="button" class="btn btn-primary btn-lg">BOOK NU</button>
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
