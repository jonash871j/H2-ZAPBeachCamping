var progressHandler;
var travelperiodHandler;
var campingSettingsHandler;
var orderData;

window.onload = function () {
    progressHandler = new ProgressHandler();
    travelperiodHandler = new TravelperiodHandler();
    campingSettingsHandler = new CampingSettingsHandler();
    orderData = new OrderData();

    var sessionLoader = new SessionLoader();

    if (document.getElementById("MF_Success").value == "true") {
        progressHandler.nextTab();
    }
}
window.onbeforeunload = function () {
    var sessionSaver = new SessionSaver();
};
class SessionSaver {
    constructor() {
        sessionStorage.setItem("orderProgrss", document.getElementById("prb_orderProgrss").style.width);

        sessionStorage.setItem("endDate", document.getElementById("dat_end").value);
        sessionStorage.setItem("startDate", document.getElementById("dat_start").value);

        sessionStorage.setItem("firstName", document.getElementById("tb_firstName").value);
        sessionStorage.setItem("lastName", document.getElementById("tb_lastName").value);
        sessionStorage.setItem("email", document.getElementById("tb_email").value);
        sessionStorage.setItem("address", document.getElementById("tb_address").value);
        sessionStorage.setItem("phoneNumber", document.getElementById("tb_phoneNumber").value);
        sessionStorage.setItem("city", document.getElementById("tb_city").value);
    }
}
class SessionLoader {
    constructor() {
        var orderProgrss = sessionStorage.getItem("orderProgrss");
        if (orderProgrss != null) {
            document.getElementById("prb_orderProgrss").style.width = orderProgrss;
            progressHandler.update();
        }

        document.getElementById("dat_end").value = sessionStorage.getItem("endDate");
        document.getElementById("dat_start").value = sessionStorage.getItem("startDate");

        document.getElementById("tb_firstName").value = sessionStorage.getItem("firstName");
        document.getElementById("tb_lastName").value = sessionStorage.getItem("lastName");
        document.getElementById("tb_email").value = sessionStorage.getItem("email");
        document.getElementById("tb_address").value = sessionStorage.getItem("email");
        document.getElementById("tb_phoneNumber").value = sessionStorage.getItem("phoneNumber");
        document.getElementById("tb_city").value = sessionStorage.getItem("city");
    }
}

class ProgressHandler {
    constructor() {
        document.getElementById("dv_orderTab1").style.display = "block";
        document.getElementById("dv_orderTab2").style.display = "none";
        document.getElementById("dv_orderTab3").style.display = "none";
        document.getElementById("dv_orderTab4").style.display = "none";
        document.getElementById("dv_orderTab5").style.display = "none";
        document.getElementById("BN_Order").style.display = "none";
    }
    nextTab() {
        for (var i = 0; i < 100; i += 25) {
            if (prb_orderProgrss.style.width == i + '%' && prb_orderProgrss.style.width != 100 + '%') {
                prb_orderProgrss.style.width = (i + 25) + '%';
                break;
            }
        }
        this.update();
    }

    previewsTab() {
        var prb_orderProgrss = document.getElementById("prb_orderProgrss");

        for (var i = 100; i >= 0; i -= 25) {
            if (prb_orderProgrss.style.width == i + '%' && prb_orderProgrss.style.width != 0 + '%') {
                prb_orderProgrss.style.width = (i - 25) + '%';
                break;
            }
        }
        this.update();
    }

    update() {
        this.updatePreviewTabButtonState();
        this.updateNextTabButtonState();
        this.updateOrderTab();
    }

    updatePreviewTabButtonState() {
        var prb_orderProgrss = document.getElementById("prb_orderProgrss");
        var bn_previewsTab = document.getElementById("bn_previewsTab");

        if (prb_orderProgrss.style.width == "0%") {
            bn_previewsTab.classList.add("disabled");
        }
        else {
            bn_previewsTab.classList.remove("disabled");
        }
    }
    updateNextTabButtonState() {
        var prb_orderProgrss = document.getElementById("prb_orderProgrss");
        var bn_nextTab = document.getElementById("bn_nextTab");
        var BN_Order = document.getElementById("BN_Order");
        var bn_previewsTab = document.getElementById("bn_previewsTab");

        if (prb_orderProgrss.style.width == "75%") {
            BN_Order.style.display = "block"
            bn_nextTab.style.display = "none"
        }
        else if (prb_orderProgrss.style.width == "100%") {
            BN_Order.style.display = "none"
            bn_nextTab.style.display = "block"

            bn_nextTab.classList.add("disabled");
            bn_previewsTab.classList.add("disabled");
        }
        else {
            BN_Order.style.display = "none"
            bn_nextTab.style.display = "block"
        }
    }
    updateOrderTab() {
        var tab = parseInt(document.getElementById("prb_orderProgrss").style.width) / 25 + 1;

        for (var i = 1; i < 6; i++) {
            if (tab == i) {
                document.getElementById("dv_orderTab" + i).style.display = "block";
            }
            else {
                document.getElementById("dv_orderTab" + i).style.display = "none";
            }
        }
    }
}
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
class CampingSettingsHandler {
    constructor() {
        this.disableTabs();
        document.getElementById("dv_campingSettingsTab1").style.display = "block";
    }

    disableTabs() {
        document.getElementById("dv_campingSettingsTab1").style.display = "none";
        document.getElementById("dv_campingSettingsTab2").style.display = "none";
        document.getElementById("dv_campingSettingsTab3").style.display = "none";
    }
    campingTypeSelectionChanged() {
        this.disableTabs();
        if (document.getElementById("rb_campingType1").checked == true)
            document.getElementById("dv_campingSettingsTab1").style.display = "block";
        else if (document.getElementById("rb_campingType2").checked == true)
            document.getElementById("dv_campingSettingsTab2").style.display = "block";
        else if (document.getElementById("rb_campingType3").checked == true)
            document.getElementById("dv_campingSettingsTab3").style.display = "block";
    }
}
class Customer {
    constructor() {
        this.FirstName = document.getElementById("tb_firstName").value;
        this.LastName = document.getElementById("tb_lastName").value;
        this.Email = document.getElementById("tb_email").value;
        this.Address = document.getElementById("tb_address").value;
        this.PhoneNumber = document.getElementById("tb_phoneNumber").value;
        this.City = document.getElementById("tb_city").value;
    }
}
class Camping {
    constructor() {
        this.StartDate = document.getElementById("dat_start").valueAsDate;
        this.EndDate = document.getElementById("dat_end").valueAsDate;

        const spotTypes = document.querySelectorAll('input[name="spotType"]');
        for (const spotType of spotTypes) {
            if (spotType.checked) {
                this.SpotType = parseInt(spotType.value);
                break;
            }
        }
        const campingTypes = document.querySelectorAll('input[name="campingType"]');
        for (const campingType of campingTypes) {
            if (campingType.checked) {
                this.CampingType = parseInt(campingType.value);
                break;
            }
        }
        const hutTypes = document.querySelectorAll('input[name="hutType"]');
        for (const hutType of hutTypes) {
            if (hutType.checked) {
                this.HutType = parseInt(hutType.value);
                break;
            }
        }
        this.Adult = parseInt(document.getElementById("nb_adult").value);
        this.Child = parseInt(document.getElementById("nb_child").value);
        this.Dog = parseInt(document.getElementById("nb_dog").value);
    }
}
class OrderData {
    constructor() {

    }

    update() {
        document.getElementById('HF_Camping').value = JSON.stringify(new Camping());
        document.getElementById('HF_Customer').value = JSON.stringify(new Customer());
        return true;
    }
}