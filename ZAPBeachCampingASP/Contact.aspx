<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="ZAPBeachCampingASP.Contact" %>

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
                                <a class="nav-link nav-selected" href="Home.aspx">Forside</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="Booking.aspx">Booking</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="AboutUs.aspx">Om os</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="Contact.aspx">Kontakt</a>
                            </li>
                        </ul>
                    </div>
                </div>
            </nav>

            <div class="container-fluid">
                <div class="row" style="margin: 20px 20px;">


                    <div class="form-group col-xs-12 col-sm-10 col-md-6 box-padding">
                        <label for="exampleInputEmail1" class="form-label mt-4 text-size">Navn</label>
                        <input class="form-control" id="name-input" placeholder="Navn" />

                        <label for="exampleInputEmail1" class="form-label mt-4 text-size">Telefon</label>
                        <input class="form-control " id="phone-number" placeholder="Telefon nummer" />

                        <label for="exampleInputEmail1" class="form-label mt-4 contact-text-size">Email address</label>
                        <input type="email" class="form-control " id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Enter email" />

                        <label for="exampleTextarea" class="form-label mt-4 text-size">Message</label>
                        <textarea class="form-control" id="message" rows="3" placeholder="Skriv besked"></textarea>
                    </div>

                    <div class="col-xs-12 col-sm-10 col-md-6 box-padding">
                        <h2 class="color-id-1">Find os her</h2>
                        <p><iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d1149883.5929327388!2d9.466432563581018!3d55.74345038104961!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x0%3A0xf800a10ad4bfa766!2sGuden%C3%A5ens%20Camping%20Silkeborg!5e0!3m2!1sda!2sdk!4v1624043311390!5m2!1sda!2sdk" width="100%" height="430px" style="border:0;" allowfullscreen="" loading="lazy"></iframe></p>
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
