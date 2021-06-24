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

    <script src="\Scripts\Handlers\CampingSettingsHandler.js"></script>
    <script src="\Scripts\Handlers\CustomerHandler.js"></script>
    <script src="\Scripts\Handlers\TravelperiodHandler.js"></script>
    <script src="\Scripts\Handlers\ProgressHandler.js"></script>
    <script src="\Scripts\Handlers\AdditionsHandler.js"></script>
    <script src="\Scripts\CSMapper.js"></script>
    <script src="\Scripts\OrderScript.js"></script>
    <script src="\Scripts\OrderView.js"></script>
    <script src="\Scripts\DateLimitScript.js"></script>
    <script src="\Scripts\Events.js"></script>
</head>
<body>

    <%-- Error modal-dialog --%>
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <div class="modal fade" id="mod_error">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title">
                                    <asp:Label runat="server" ID="LB_ModalTitle" />
                                </h5>
                                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close" data-dismiss="modal">
                                    <span aria-hidden="true"></span>
                                </button>
                            </div>
                            <div class="modal-body">
                                <p>
                                    <asp:Label runat="server" ID="LB_ModalBody" />
                                </p>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-primary" data-dismiss="modal">Luk</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%-- Banner --%>
    <form id="form1" runat="server">
        <%-- Client to server data --%>
        <input type="button" id="bn_defaultButton" />
        <input type="hidden" name="HF_Customer" id="HF_Customer" value="" />
        <input type="hidden" name="HF_BookingOptions" id="HF_BookingOptions" value="" />

        <%-- Server to client data --%>
        <asp:HiddenField runat="server" ID="HF_Additions" />
        <asp:HiddenField runat="server" ID="MF_Success" />

        <div class="container-fluid px-0">
            <div class="row mx-0">
                <div class="col-12 px-0">
                    <img class="img-fluid w-100" src="\Images\Banner.jpg" />
                </div>
            </div>

            <%-- Nav bar --%>
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
                                <a class="nav-link" href="AboutUs.aspx">Om os</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="Contact.aspx">Kontakt</a>
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
                                <asp:Button runat="server" ID="BN_Order" CssClass="btn btn-primary" OnClick="BN_Order_Click" OnClientClick="return updateCSMapperHiddenElements();" Text="Bestil" />
                            </div>
                        </div>

                        <hr />
                        <div class="row box-padding">
                            <div class="col-6">
                                <%-- Tab 1: Travelperiod --%>
                                <div id="dv_orderTab1">
                                    <div id="dv_travelperiodTab1">
                                        <h4>Vælg ankomst dato</h4>
                                        <input class="form-control" type="date" id="dat_start" name="trip-start">

                                        <h4 class="mt-4">Vælg hjem dato</h4>
                                        <input class="form-control" type="date" id="dat_end" name="trip-end">
                                    </div>
                                    <div id="dv_travelperiodTab2">
                                        <h4>Sæsonplads</h4>
                                        <div class="form-check disabled">
                                            <label class="form-check-label">
                                                <input type="radio" class="form-check-input" name="rb_seasonSettings" id="rb_seasonSettings1" onclick="travelperiodHandler.updateSettings();">
                                                Forår 1. april til 30. juni (4.100,-)
                                            </label>
                                        </div>
                                        <div class="form-check disabled">
                                            <label class="form-check-label">
                                                <input type="radio" class="form-check-input" name="rb_seasonSettings" id="rb_seasonSettings2" onclick="travelperiodHandler.updateSettings();">
                                                Sommer 1. april til 30. semptember (9.300,-)
                                            </label>
                                        </div>
                                        <div class="form-check disabled">
                                            <label class="form-check-label">
                                                <input type="radio" class="form-check-input" name="rb_seasonSettings" id="rb_seasonSettings3" onclick="travelperiodHandler.updateSettings();">
                                                Efterår 15. august til 31. oktober (2.900,-)
                                            </label>
                                        </div>
                                        <div class="form-check disabled">
                                            <label class="form-check-label">
                                                <input type="radio" class="form-check-input" name="rb_seasonSettings" id="rb_seasonSettings4" onclick="travelperiodHandler.updateSettings();">
                                                Vinter 1. oktober til 31. marts (3.500,-)
                                            </label>
                                        </div>
                                    </div>
                                    <div class="form-check mt-4">
                                        <input class="form-check-input" type="checkbox" value="" id="cb_seasonSite" onclick="travelperiodHandler.showActiveTab();" />
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
                                                <input type="radio" class="form-check-input" name="spotType" id="rb_spotType1" onclick="campingSettingsHandler.showActiveSpotTab();">
                                                Campingvogn
                                            </label>
                                        </div>
                                        <div class="form-check">
                                            <label class="form-check-label">
                                                <input type="radio" class="form-check-input" name="spotType" id="rb_spotType2" onclick="campingSettingsHandler.showActiveSpotTab();">
                                                Telt
                                            </label>
                                        </div>
                                        <div class="form-check disabled">
                                            <label class="form-check-label">
                                                <input type="radio" class="form-check-input" name="spotType" id="rb_spotType3" onclick="campingSettingsHandler.showActiveSpotTab();">
                                                Hytte
                                            </label>
                                        </div>
                                    </fieldset>
                                    <h4 class="mt-4">Vælg camping indstilling</h4>
                                    <fieldset class="form-group">
                                        <div id="dv_campingSettingsTab1">
                                            <div class="form-check disabled">
                                                <label class="form-check-label">
                                                    <input type="radio" class="form-check-input" name="campingType" id="rb_campingType1" onclick="campingSettingsHandler.showActiveSpotTab();">
                                                    Lille plads (pr. dag høj: 60,- lav: 50,-)
                                                </label>
                                            </div>
                                            <div class="form-check disabled">
                                                <label class="form-check-label">
                                                    <input type="radio" class="form-check-input" name="campingType" id="rb_campingType2" onclick="campingSettingsHandler.showActiveSpotTab();">
                                                    Stor plads (pr. dag høj: 80,- lav: 65,-)
                                                </label>
                                            </div>
                                        </div>
                                        <div id="dv_campingSettingsTab2">
                                            <div class="form-check disabled">
                                                <label class="form-check-label">
                                                    <input type="radio" class="form-check-input" name="tentType" id="rb_tentType1" onclick="campingSettingsHandler.showActiveSpotTab();">
                                                    Telt plads (pr. dag høj: 35,- lav: 45,-)
                                                </label>
                                            </div>
                                        </div>
                                        <div id="dv_campingSettingsTab3">
                                            <div class="form-check disabled">
                                                <label class="form-check-label">
                                                    <input type="radio" class="form-check-input" name="hutType" id="rb_hutType1" onclick="campingSettingsHandler.showActiveSpotTab();">
                                                    Standard hytte (pr. dag høj: 500,- lav: 350,-)
                                                </label>
                                            </div>
                                            <div class="form-check disabled">
                                                <label class="form-check-label">
                                                    <input type="radio" class="form-check-input" name="hutType" id="rb_hutType2" onclick="campingSettingsHandler.showActiveSpotTab();">
                                                    Luksus hytte (pr. dag høj: 850,- lav: 600,-)
                                                </label>
                                            </div>
                                        </div>
                                    </fieldset>
                                    <fieldset class="form-group mt-3">
                                        <div class="form-check">
                                            <input class="form-check-input" type="checkbox" value="" id="cb_isGoodView">
                                            <label class="form-check-label" for="flexCheckDefault">
                                                Udsigt til vandet (75,- pr. dag)
                                            </label>
                                        </div>
                                        <div class="form-check" id="dv_isPayingForCleaning">
                                            <input class="form-check-input" type="checkbox" value="" id="cb_isPayingForCleaning" />
                                            <label class="form-check-label" for="flexCheckDefault">
                                                Slutrengøring i hytte (150,-)
                                            </label>
                                        </div>
                                    </fieldset>

                                    <h4 for="exampleSelect2" class="form-label mt-4">Antal rejsende</h4>

                                    <div class="row">
                                        <div class="col-4">
                                            <label>Voksne</label>
                                            <input class="form-control" type="number" id="nb_adult" min="0" max="10" onchange="onNumberBoxChange(this);">
                                        </div>
                                        <div class="col-4">
                                            <label>Børn</label>
                                            <input class="form-control" type="number" id="nb_child" min="0" max="10" onchange="onNumberBoxChange(this);">
                                        </div>
                                        <div class="col-4">
                                            <label>Hunde</label>
                                            <input class="form-control" type="number" id="nb_dog" min="0" max="10" onchange="onNumberBoxChange(this);">
                                        </div>

                                    </div>
                                    <label class="mt-3" id="lb_adultDescription">-</label><br />
                                    <label id="lb_childDescription">-</label><br />
                                    <label id="lb_dogDescription">-</label>


                                </div>
                                <%-- Tab 3: Additions --%>
                                <div id="dv_orderTab3">
                                    <h4>Tillægsydelser</h4>
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
                                    <h4>Tak for din bestilling!</h4>
                                    <button type="button" class="btn btn-primary" onclick="session.clear();" style="float: right;">Start forfra</button>
                                </div>
                            </div>
                            <%-- Booking order --%>
                            <div class="col-6">
                                <h4>Din ordre</h4>
                                <div class="mt-3 row">
                                    <div class="col-5">
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
                                    <div class="col-7">
                                        <h6 id="h_startDate">-</h6>
                                        <h6 id="h_endDate">-</h6>
                                        <h6 class="mt-4" id="h_adult">-</h6>
                                        <h6 id="h_child">-</h6>
                                        <h6 id="h_dog">-</h6>
                                        <h6 id="h_spotType" class="mt-4">-</h6>
                                        <h6 id="h_spotSettingsType">-</h6>
                                        <h6 id="h_isGoodView">-</h6>
                                        <h6 id="h_isPayingForCleaning">-</h6>
                                        <h6 class="mt-4" id="h_additionAmount">-</h6>
                                    </div>
                                </div>
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