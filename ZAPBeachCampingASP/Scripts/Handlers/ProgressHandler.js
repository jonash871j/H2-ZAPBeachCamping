
class ProgressHandler {
    constructor() {
        this.sessionDefault();
    }
    nextTab() {
        for (var i = 0; i < 100; i += 25) {
            if (prb_orderProgrss.style.width == i + '%' && prb_orderProgrss.style.width != 100 + '%') {
                prb_orderProgrss.style.width = (i + 25) + '%';
                break;
            }
        }
        if (prb_orderProgrss.style.width == "25%" && travelperiodHandler.seasonSite.checked) {
            this.nextTab();
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
        if (prb_orderProgrss.style.width == "25%" && travelperiodHandler.seasonSite.checked) {
            this.previewsTab();
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
    sessionDefault() {
        document.getElementById("dv_orderTab1").style.display = "block";
        document.getElementById("dv_orderTab2").style.display = "none";
        document.getElementById("dv_orderTab3").style.display = "none";
        document.getElementById("dv_orderTab4").style.display = "none";
        document.getElementById("dv_orderTab5").style.display = "none";
        document.getElementById("BN_Order").style.display = "none";
    }
}
