<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ZAPBeachCampingASP.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="\StyleSheets\bootstrap.css" rel="stylesheet" />
    <link href="\StyleSheets\bootstrap.min.css" rel="stylesheet" />
    <link href="\StyleSheets\main.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
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

            <div class="carousel-inner">
                <div class="carousel-item active">

                    <img class="img-fluid w-100" src="\Images\Slider1.jpg" />
                    <div class="carousel-caption">
                        <div class="opacity-2">
                            <h1 class="display-2">ZAP BEACH CAMPING</h1>
                            <h3>BOOK DIN FERIE</h3>
                            <button type="button" class="btn btn-primary btn-lg">BOOK NU</button>
                        </div>
                    </div>
                </div>
                <div class="carousel-item">
                    <img src="\Images\Slider2.jpg" />
                </div>
                <div class="carousel-item">
                    <img src="\Images\Slider3.jpg" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
