class AdditionsHandler {
    constructor() {
        this.additions = JSON.parse(document.getElementById("HF_Additions").value);

        for (var i = 0; i < this.additions.length; i++) {
            var perDayText = "";

            if (this.additions[i].IsDailyPayment) {
                perDayText = " pr. dag";
            }

            document.getElementById("dv_orderTab3").innerHTML +=
                "<div class='form-group mt-3'>" +
                "<label class='form-label'>" + this.additions[i].Name + " (" + this.additions[i].Price + ",-" + perDayText + ")</label>" +
                "<input class='form-control' type='number' id='nb_addition" + i + "' name='quantity' min='0' max='20' onchange='onNumberBoxChange(this);'>" +
                "</div>";
        }
    }
    getAdditionsAmount() {
        var additionAmount = 0;
        for (var i = 0; i < this.additions.length; i++) {
            additionAmount += parseInt(document.getElementById("nb_addition" + i).value);
        }
        return additionAmount;
    }
    getAdditions() {
        var selectedAdditions = [];

        for (var i = 0; i < this.additions.length; i++) {
            var additionAmount = parseInt(document.getElementById("nb_addition" + i).value);

            for (var j = 0; j < additionAmount; j++) {
                selectedAdditions.push(this.additions[i])
            }
        }
        return selectedAdditions;
    }
    sessionDefault() {
        for (var i = 0; i < this.additions.length; i++) {
            sessionStorage.setItem("addition" + i, "0");
        }
        //sessionStorage.setItem("spotType1", this.spotType1.checked);
    }
    sessionSave() {
        for (var i = 0; i < this.additions.length; i++) {
            sessionStorage.setItem("addition" + i, document.getElementById("nb_addition" + i).value);
        }
        //sessionStorage.setItem("spotType1", this.spotType1.checked);
    }
    sessionLoad() {
        for (var i = 0; i < this.additions.length; i++) {
            document.getElementById("nb_addition" + i).value = sessionStorage.getItem("addition" + i);
        }
 
    }
}