
window.onload = function () {
    document.getElementById("dv_orderTab1").style.display = "block";
    document.getElementById("dv_orderTab2").style.display = "none";
    document.getElementById("dv_orderTab3").style.display = "none";
    document.getElementById("dv_orderTab4").style.display = "none";
    document.getElementById("dv_orderTab5").style.display = "none";
}

function NextTab() {
    var prb_orderProgrss = document.getElementById("prb_orderProgrss");

    for (var i = 0; i < 100; i += 25) {
        if (prb_orderProgrss.style.width == i + '%' && prb_orderProgrss.style.width != 100 + '%') {
            prb_orderProgrss.style.width = (i + 25) + '%';
            break;
        }
    }

    updatePreviewTabButtonState();
    updateNextTabButtonState();
    updateOrderTab();
}
function PreviewsTab() {
    var prb_orderProgrss = document.getElementById("prb_orderProgrss");

    for (var i = 100; i >= 0; i -= 25) {
        if (prb_orderProgrss.style.width == i + '%' && prb_orderProgrss.style.width != 0 + '%') {
            prb_orderProgrss.style.width = (i - 25) + '%';
            break;
        }
    }

    updatePreviewTabButtonState();
    updateNextTabButtonState();
    updateOrderTab();
}

function updatePreviewTabButtonState() {
    var prb_orderProgrss = document.getElementById("prb_orderProgrss");
    var bn_previewsTab = document.getElementById("bn_previewsTab");

    if (prb_orderProgrss.style.width == "0%") {
        bn_previewsTab.classList.add("disabled");
    }
    else {
        bn_previewsTab.classList.remove("disabled");
    }
}
function updateNextTabButtonState() {
    var prb_orderProgrss = document.getElementById("prb_orderProgrss");
    var bn_nextTab = document.getElementById("bn_nextTab");
    var bn_previewsTab = document.getElementById("bn_previewsTab");

    if (prb_orderProgrss.style.width == "75%") {
        bn_nextTab.innerText = "Bestil";
    }
    else if (prb_orderProgrss.style.width == "100%") {
        bn_nextTab.classList.add("disabled");
        bn_previewsTab.classList.add("disabled");
    }
    else {
        bn_nextTab.innerText = "Næste";
    }
}
function updateOrderTab() {
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