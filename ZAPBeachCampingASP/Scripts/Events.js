setInterval(function () {
    document.getElementById("h_startDate").innerHTML = travelperiodHandler.getStartDate();
    document.getElementById("h_endDate").innerHTML = travelperiodHandler.getEndDate();

    if (travelperiodHandler.seasonSite.checked == false) {
        document.getElementById("h_adult").innerHTML = document.getElementById("nb_adult").value;
        document.getElementById("h_child").innerHTML = document.getElementById("nb_child").value;
        document.getElementById("h_dog").innerHTML = document.getElementById("nb_dog").value;

        document.getElementById("h_spotType").innerHTML = campingSettingsHandler.getSpotTypeDescription();
        document.getElementById("h_spotSettingsType").innerHTML = campingSettingsHandler.getSpotSettingDescription();
        document.getElementById("h_isGoodView").innerHTML = campingSettingsHandler.getIsGoodViewDescription();
        document.getElementById("h_isPayingForCleaning").innerHTML = campingSettingsHandler.getIsPayingForCleaningDescription();
    }
    else {
        document.getElementById("h_adult").innerHTML = "-";
        document.getElementById("h_child").innerHTML = "-";
        document.getElementById("h_dog").innerHTML = "-";

        document.getElementById("h_spotType").innerHTML = "Campingvogn";
        document.getElementById("h_spotSettingsType").innerHTML = "Stor plads som sæsonplads";
        document.getElementById("h_isGoodView").innerHTML = "Nej";
        document.getElementById("h_isPayingForCleaning").innerHTML = "-";
    }


    document.getElementById("h_additionAmount").innerHTML = additionsHandler.getAdditionsAmount();
}, 100);


function onNumberBoxChange(numberBox) {
    if (numberBox.value == "" || parseInt(numberBox.value) < parseInt(numberBox.min)) {
        numberBox.value = numberBox.min;
    }

    if (parseInt(numberBox.value) > parseInt(numberBox.max)) {
        numberBox.value = numberBox.max;
    }
}