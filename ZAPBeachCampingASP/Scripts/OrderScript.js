var progressHandler;
var travelperiodHandler;
var campingSettingsHandler;
var session;
var customerHandler;
var additionsHandler;

window.onload = function () {
    progressHandler = new ProgressHandler();
    travelperiodHandler = new TravelperiodHandler();
    campingSettingsHandler = new CampingSettingsHandler();
    customerHandler = new CustomerHandler();
    additionsHandler = new AdditionsHandler();
    session = new Session();

    session.load();

    if (document.getElementById("MF_Success").value == "true") {
        progressHandler.nextTab();
    }
}
window.onbeforeunload = function () {
    session.save();
};

class Session {
    constructor() {

    }

    default() {
        sessionStorage.setItem("prb_orderProgrss", "0%");

        sessionStorage.setItem("endDate", "");
        sessionStorage.setItem("startDate", "");

        progressHandler.sessionDefault();
        campingSettingsHandler.sessionDefault();
        additionsHandler.sessionDefault();
        customerHandler.sessionDefault();
        travelperiodHandler.sessionDefault();
    }
    clear() {
        sessionStorage.setItem("firstLoad", "false");
        this.default();
        this.load();
        return true;
    }
    load() {
        if (sessionStorage.getItem("firstLoad") == null || sessionStorage.getItem("firstLoad") == "false") {
            sessionStorage.setItem("firstLoad", "true");
            this.default();
        }

        var orderProgrss = sessionStorage.getItem("prb_orderProgrss");
        if (orderProgrss != null) {
            document.getElementById("prb_orderProgrss").style.width = orderProgrss;
            progressHandler.update();
        }

        document.getElementById("dat_end").value = sessionStorage.getItem("dat_end");
        $('#dat_end').attr('min', sessionStorage.getItem("dat_end_min"));
        document.getElementById("dat_start").value = sessionStorage.getItem("dat_start");

        campingSettingsHandler.sessionLoad();
        additionsHandler.sessionLoad();
        customerHandler.sessionLoad();
        travelperiodHandler.sessionLoad();
    }
    save() {
        sessionStorage.setItem("prb_orderProgrss", document.getElementById("prb_orderProgrss").style.width);

        sessionStorage.setItem("dat_end", document.getElementById("dat_end").value);
        sessionStorage.setItem("dat_end_min", $('#dat_end').attr('min'));
        sessionStorage.setItem("dat_start", document.getElementById("dat_start").value);

        campingSettingsHandler.sessionSave();
        additionsHandler.sessionSave();
        customerHandler.sessionSave();
        travelperiodHandler.sessionSave();
    }
}