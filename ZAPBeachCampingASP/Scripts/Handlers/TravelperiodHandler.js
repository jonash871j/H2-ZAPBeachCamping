class TravelperiodHandler {
    constructor() {
        document.getElementById("dv_travelperiodTab1").style.display = "block";
        document.getElementById("dv_travelperiodTab2").style.display = "none";
    }

    seasonSiteSelectionChanged() {
        if (document.getElementById("cb_seasonSite").checked == true) {
            document.getElementById("dv_travelperiodTab1").style.display = "none";
            document.getElementById("dv_travelperiodTab2").style.display = "block";
        }
        else {
            document.getElementById("dv_travelperiodTab1").style.display = "block";
            document.getElementById("dv_travelperiodTab2").style.display = "none";
        }
    }
}