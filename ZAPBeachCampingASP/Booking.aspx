<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Booking.aspx.cs" Inherits="ZAPBeachCampingASP.Booking" %>

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

            <div class="row">
                <div class="col-lg-6">
                    <div class="form-group">
                        <fieldset disabled="">
                            <label class="form-label" for="disabledInput">Disabled input</label>
                            <input class="form-control" id="disabledInput" type="text" placeholder="Disabled input here..." disabled="">
                        </fieldset>
                    </div>

                    <div class="form-group">
                        <fieldset>
                            <label class="form-label mt-4" for="readOnlyInput">Readonly input</label>
                            <input class="form-control" id="readOnlyInput" type="text" placeholder="Readonly input here..." readonly="">
                        </fieldset>
                    </div>

                    <div class="form-group has-success">
                        <label class="form-label mt-4" for="inputValid">Valid input</label>
                        <input type="text" value="correct value" class="form-control is-valid" id="inputValid">
                        <div class="valid-feedback">Success! You've done it.</div>
                    </div>

                    <div class="form-group has-danger">
                        <label class="form-label mt-4" for="inputInvalid">Invalid input</label>
                        <input type="text" value="wrong value" class="form-control is-invalid" id="inputInvalid">
                        <div class="invalid-feedback">Sorry, that username's taken. Try another?</div>
                    </div>

                    <div class="form-group">
                        <label class="col-form-label col-form-label-lg mt-4" for="inputLarge">Large input</label>
                        <input class="form-control form-control-lg" type="text" placeholder=".form-control-lg" id="inputLarge">
                    </div>

                    <div class="form-group">
                        <label class="col-form-label mt-4" for="inputDefault">Default input</label>
                        <input type="text" class="form-control" placeholder="Default input" id="inputDefault">
                    </div>

                    <div class="form-group">
                        <label class="col-form-label col-form-label-sm mt-4" for="inputSmall">Small input</label>
                        <input class="form-control form-control-sm" type="text" placeholder=".form-control-sm" id="inputSmall">
                    </div>

                    <div class="form-group">
                        <label class="form-label mt-4">Input addons</label>
                        <div class="form-group">
                            <div class="input-group mb-3">
                                <span class="input-group-text">$</span>
                                <input type="text" class="form-control" aria-label="Amount (to the nearest dollar)">
                                <span class="input-group-text">.00</span>
                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="form-label mt-4">Floating labels</label>
                        <div class="form-floating mb-3">
                            <input type="email" class="form-control" id="floatingInput" placeholder="name@example.com">
                            <label for="floatingInput">Email address</label>
                        </div>
                        <div class="form-floating">
                            <input type="password" class="form-control" id="floatingPassword" placeholder="Password">
                            <label for="floatingPassword">Password</label>
                        </div>
                    </div>
                </div>
                
                <div class="col-lg-6">

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
