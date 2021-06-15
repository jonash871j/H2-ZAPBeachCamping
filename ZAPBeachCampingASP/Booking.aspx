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
                            <div class="col-2"><strong>2. Campingplads</strong></div>
                            <div class="col-2"><strong>3. Tillægsydelser</strong></div>
                            <div class="col-2"><strong>4. Dine oplysninger</strong></div>
                            <div class="col-2"></div>
                        </div>


                        <div class="row">
                            <div class="col-2">
                                <button id="bn_previewsTab" type="button" class="btn btn-primary disabled" onclick="progressHandler.previewsTab();" style="float: right;">Tilbage</button>
                            </div>
                            <div class="col-8">
                                <div class="progress mt-2" style="background-color: #e3e3e3;">
                                    <div id="prb_orderProgrss" class="progress-bar progress-bar-striped progress-bar-animated" role="progressbar" aria-valuenow="75" aria-valuemin="0" aria-valuemax="100" style="width: 0%;"></div>
                                </div>
                            </div>
                            <div class="col-2">
                                <button id="bn_nextTab" type="button" class="btn btn-primary" onclick="progressHandler.nextTab();">Næste</button>
                                <asp:Button runat="server" ID="TB_Order" CssClass="btn btn-primary"  OnClick="TB_Order_Click" OnClientClick="return orderData.update();" Text="Bestil" />
                                <input type="hidden" name="HF_Customer" id="HF_Customer" value="" />
                            </div>
                        </div>

                        <hr />
                        <div class="row box-padding">
                            <div class="col-6">
                                <%-- Tab 1: Travelperiod --%>
                                <div id="dv_orderTab1">
                                    <div id="dv_travelperiodTab1">
                                        <h4>Vælg ankomst dato</h4>
                                        <input class="form-control" type="date" id="start" name="trip-start" value="2018-07-22" min="2018-01-01" max="2018-12-31">

                                        <h4 class="mt-4">Vælg hjem dato</h4>
                                        <input class="form-control" type="date" id="end" name="trip-end" value="2018-07-22" min="2018-01-01" max="2018-12-31">
                                    </div>
                                    <div id="dv_travelperiodTab2">
                                        <h4>Sæsonplads</h4>
                                        <div class="form-check disabled">
                                            <label class="form-check-label">
                                                <input type="radio" class="form-check-input" name="rb_seasonSettings" id="rb_seasonSettings1" checked="">
                                                Forår 1. april til 30. juni (4.100,-)
                                            </label>
                                        </div>
                                        <div class="form-check disabled">
                                            <label class="form-check-label">
                                                <input type="radio" class="form-check-input" name="rb_seasonSettings" id="rb_seasonSettings2">
                                                Sommer 1. april til 30. semptember (9.300,-)
                                            </label>
                                        </div>
                                        <div class="form-check disabled">
                                            <label class="form-check-label">
                                                <input type="radio" class="form-check-input" name="rb_seasonSettings" id="rb_seasonSettings3">
                                                Efterår 15. august til 31. oktober (2.900,-)
                                            </label>
                                        </div>
                                        <div class="form-check disabled">
                                            <label class="form-check-label">
                                                <input type="radio" class="form-check-input" name="rb_seasonSettings" id="rb_seasonSettings4">
                                                Vinter 1. oktober til 31. marts (3.500,-)
                                            </label>
                                        </div>
                                    </div>
                                    <div class="form-check mt-4">
                                        <input class="form-check-input" type="checkbox" value="" id="cb_seasonSite" onclick="travelperiodHandler.seasonSiteSelectionChanged();" />
                                        <label class="form-check-label" for="flexCheckDefault">
                                            Sæsonplads
                                        </label>
                                    </div>

                                </div>

                                <%-- Tab 2: Campingsite --%>
                                <div id="dv_orderTab2">
                                    <h4>Vælg camping type</h4>
                                    <fieldset class="form-group">
                                        <div class="form-check">
                                            <label class="form-check-label">
                                                <input type="radio" class="form-check-input" name="rb_campingType" id="rb_campingType1" checked="" onclick="campingSettingsHandler.campingTypeSelectionChanged();">
                                                Campingvogn
                                            </label>
                                        </div>
                                        <div class="form-check">
                                            <label class="form-check-label">
                                                <input type="radio" class="form-check-input" name="rb_campingType" id="rb_campingType2" onclick="campingSettingsHandler.campingTypeSelectionChanged();">
                                                Telt
                                            </label>
                                        </div>
                                        <div class="form-check disabled">
                                            <label class="form-check-label">
                                                <input type="radio" class="form-check-input" name="rb_campingType" id="rb_campingType3" onclick="campingSettingsHandler.campingTypeSelectionChanged();">
                                                Hytte
                                            </label>
                                        </div>
                                    </fieldset>
                                    <h4 class="mt-4">Vælg camping indstilling</h4>
                                    <fieldset class="form-group">
                                        <div id="dv_campingSettingsTab1">
                                            <div class="form-check disabled">
                                                <label class="form-check-label">
                                                    <input type="radio" class="form-check-input" name="rb_campingSettings1" id="optionsRadios4" value="option3" value="option1" checked="">
                                                    Lille plads (pr. dag høj: 60,- lav: 50,-)
                                                </label>
                                            </div>
                                            <div class="form-check disabled">
                                                <label class="form-check-label">
                                                    <input type="radio" class="form-check-input" name="rb_campingSettings1" id="optionsRadios5" value="option3">
                                                    Stor plads (pr. dag høj: 80,- lav: 65,-)
                                                </label>
                                            </div>
                                        </div>
                                        <div id="dv_campingSettingsTab2">
                                            <div class="form-check disabled">
                                                <label class="form-check-label">
                                                    <input type="radio" class="form-check-input" name="rb_campingSettings2" id="optionsRadios6" value="option3" checked="">
                                                    Telt plads (pr. dag høj: 35,- lav: 45,-)
                                                </label>
                                            </div>
                                        </div>
                                        <div id="dv_campingSettingsTab3">
                                            <div class="form-check disabled">
                                                <label class="form-check-label">
                                                    <input type="radio" class="form-check-input" name="rb_campingSettings3" id="optionsRadios7" value="option3" checked="">
                                                    Standard hytte (pr. dag høj: 500,- lav: 350,-)
                                                </label>
                                            </div>
                                            <div class="form-check disabled">
                                                <label class="form-check-label">
                                                    <input type="radio" class="form-check-input" name="rb_campingSettings3" id="optionsRadios8" value="option3">
                                                    Luksus hytte (pr. dag høj: 850,- lav: 600,-)
                                                </label>
                                            </div>
                                        </div>
                                    </fieldset>

                                    <h4 for="exampleSelect2" class="form-label mt-4">Antal rejsende</h4>

                                    <div class="row">
                                        <div class="col-4">
                                            <label>Voksne</label>
                                            <input class="form-control" type="number" id="quantity" name="quantity" min="0" max="5" value="1">
                                        </div>
                                        <div class="col-4">
                                            <label>Børn</label>
                                            <input class="form-control" type="number" id="quantity" name="quantity" min="0" max="5" value="1">
                                        </div>
                                        <div class="col-4">
                                            <label>Hunde</label>
                                            <input class="form-control" type="number" id="quantity" name="quantity" min="0" max="5" value="1">
                                        </div>

                                    </div>



                                    <label class="mt-3">Hver voksen koster pr. dag høj: 50,- lav: 50,-</label>
                                    <label>Hver barn koster pr. dag høj: 50,- lav: 50,-</label>
                                    <label>Hver hund koster pr. dag høj: 50,- lav: 50,-</label>

                                </div>
                                <%-- Tab 3: Additions --%>
                                <div id="dv_orderTab3">
                                    <h4>Tillægsydelser</h4>
                                    <div class="form-group mt-3">
                                        <label class="form-label">Morgenkomplet 75,- pr. voksen</label>
                                        <input class="form-control" type="number" id="quantity" name="quantity" min="0" max="5" value="0">
                                    </div>
                                    <div class="form-group mt-3">
                                        <label class="form-label">Morgenkomplet 50,- pr. barn</label>
                                        <input class="form-control" type="number" id="quantity" name="quantity" min="0" max="5" value="0">
                                    </div>
                                    <div class="form-group mt-3">
                                        <label class="form-label">Adgang til badeland badeland 30,- pr. voksen</label>
                                        <input class="form-control" type="number" id="quantity" name="quantity" min="0" max="5" value="0">
                                    </div>
                                    <div class="form-group mt-3">
                                        <label class="form-label">Adgang til badeland 15,- pr. barn</label>
                                        <input class="form-control" type="number" id="quantity" name="quantity" min="0" max="5" value="0">
                                    </div>
                                    <div class="form-group mt-3">
                                        <label class="form-label">Cykelleje 200,- pr dag</label>
                                        <input class="form-control" type="number" id="quantity" name="quantity" min="0" max="5" value="0">
                                    </div>
                                    <fieldset class="form-group mt-3">
                                        <div class="form-check">
                                            <input class="form-check-input" type="checkbox" value="" id="flexCheckDefault">
                                            <label class="form-check-label" for="flexCheckDefault">
                                                Udsigt til vandet (75,- pr. dag)
                                            </label>
                                        </div>
                                        <div class="form-check">
                                            <input class="form-check-input" type="checkbox" value="" id="flexCheckDefault">
                                            <label class="form-check-label" for="flexCheckDefault">
                                                Slutrengøring i hytte (150,-)
                                            </label>
                                        </div>
                                    </fieldset>
                                </div>
                                <%-- Tab 4: Your information --%>
                                <div id="dv_orderTab4">
                                    <h4>Dine oplysninger</h4>
                                    <div class="form-group mt-3">
                                        <label class="form-label">Fornavn</label>
                                        <input id="tb_firstName" class="form-control" placeholder="Intast fornavn">
                                    </div>
                                    <div class="form-group mt-3">
                                        <label class="form-label">Efternavn</label>
                                        <input id="tb_lastName" class="form-control" placeholder="Intast efternavn">
                                    </div>
                                    <div class="form-group mt-3">
                                        <label class="form-label">Email</label>
                                        <input id="tb_email" type="email" class="form-control" placeholder="Intast email">
                                    </div>
                                    <div class="form-group mt-3">
                                        <label class="form-label">Telefonnummer</label>
                                        <input id="tb_phoneNumber" class="form-control" placeholder="Intast telefonnummer">
                                    </div>
                                    <div class="form-group mt-3">
                                        <label class="form-label">Adresse</label>
                                        <input id="tb_address" class="form-control" placeholder="Intast adresse">
                                    </div>
                                    <div class="form-group mt-3">
                                        <label class="form-label">By</label>
                                        <input id="tb_city" class="form-control" placeholder="Intast by">
                                    </div>
                                </div>
                                <%-- Tab 5: Order successful --%>
                                <div id="dv_orderTab5">
                                    <h4>Tak for din besilling!</h4>
                                </div>
                            </div>
                            <%-- Booking order --%>
                            <div class="col-6">
                                <h4>Din ordre</h4>
                                <div class="mt-3 row">
                                    <div class="col-6">
                                        <h6>Ankomst dato: </h6>
                                        <h6>Hjem dato: </h6>
                                        <h6 class="mt-4">Antal voksne: </h6>
                                        <h6>Antal børn: </h6>
                                        <h6>Antal hunde: </h6>
                                        <h6 class="mt-4">Camping type: </h6>
                                        <h6>Camping indstilling: </h6>
                                        <h6>Udsigt til vandet: </h6>
                                        <h6>Slutrengøring i hytte: </h6>
                                        <h6 class="mt-4">Antal tilægsydelser: </h6>
                                    </div>
                                    <div class="col-6">
                                        <h6>22-07-2018</h6>
                                        <h6>22-07-2018</h6>
                                        <h6 class="mt-4">1</h6>
                                        <h6>0</h6>
                                        <h6>0</h6>
                                        <h6 class="mt-4">Campingvogn</h6>
                                        <h6>Stor plads</h6>
                                        <h6>Nej</h6>
                                        <h6>Nej</h6>
                                        <h6 class="mt-4">4</h6>
                                    </div>
                                </div>
                                <h4 class="mt-5" style="text-align: right;">Total 1000,00 kr.</h4>
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
