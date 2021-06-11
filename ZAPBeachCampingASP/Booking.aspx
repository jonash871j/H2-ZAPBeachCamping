<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Booking.aspx.cs" Inherits="ZAPBeachCampingASP.Booking" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="\StyleSheets\bootstrap.css" rel="stylesheet" />
    <link href="\StyleSheets\bootstrap.min.css" rel="stylesheet" />
    <link href="\StyleSheets\main.css" rel="stylesheet" />

    <script src="\Scripts\OrderScript.js"></script>
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
                                <a class="nav-link" href="Home.aspx">Forside</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link nav-selected" href="#">Booking</a>
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

            <div class="row box-padding">
                <div class="col-lg-2 col-md-1"></div>
                <div class="col-lg-8 col-md-10">
                    <div class="alert alert-dismissible alert-light p-5">

                        <div class="row">
                            <div class="col-2"></div>
                            <div class="col-2"><strong>1. Rejseperiode</strong></div>
                            <div class="col-2"><strong>2. Dine valg</strong></div>
                            <div class="col-2"><strong>3. Dine Oplysninger</strong></div>
                            <div class="col-2"><strong>4. Fakture</strong></div>
                            <div class="col-2"></div>
                        </div>


                        <div class="row">
                            <div class="col-2">
                                <button type="button" class="btn btn-primary" style="float: right;">Tilbage</button>
                            </div>
                            <div class="col-8">
                                <div class="progress mt-2">
                                    <div class="progress-bar progress-bar-striped progress-bar-animated" role="progressbar" aria-valuenow="75" aria-valuemin="0" aria-valuemax="100" style="width: 25%;"></div>
                                </div>
                            </div>
                            <div class="col-2">
                                <button type="button" class="btn btn-primary">Næste</button>
                            </div>
                        </div>

                        <hr />
                        <div class="row box-padding">
                            <div class="col-6">
                                <div id="order-tab-1">
                                    <h4>Vælg ankomst dato</h4>
                                    <input class="form-control" type="date" id="start" name="trip-start" value="2018-07-22" min="2018-01-01" max="2018-12-31">

                                    <h4 class="mt-4">Vælg hjem dato</h4>
                                    <input class="form-control" type="date" id="end" name="trip-end" value="2018-07-22" min="2018-01-01" max="2018-12-31">
                                </div>
                                <div id="order-tab-2" class="block: none;">
                                    <h4>Side 2</h4>
                                </div>
                                <div id="order-tab-3" class="block: none;">
                                    <h4>Side 3</h4>
                                </div>
                                <div id="order-tab-4" class="block: none;">
                                    <h4>Side 4</h4>
                                </div>
                            </div>
                            <div class="col-6">
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-2 col-md-1"></div>
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
