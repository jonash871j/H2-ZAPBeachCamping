const SeasonTypeEnum = { "Spring": 1, "Summer": 2, "Atumn": 3, "Winter": 4 }

class TravelperiodHandler {
    constructor() {
        this.travelperiodTab1 = document.getElementById("dv_travelperiodTab1"); // Date picker tab
        this.travelperiodTab2 = document.getElementById("dv_travelperiodTab2"); // Season picker tab
        this.seasonSite = document.getElementById("cb_seasonSite"); 

        this.seasonSettings1 = document.getElementById("rb_seasonSettings1"); // Spring
        this.seasonSettings2 = document.getElementById("rb_seasonSettings2"); // Summer
        this.seasonSettings3 = document.getElementById("rb_seasonSettings3"); // Atumn
        this.seasonSettings4 = document.getElementById("rb_seasonSettings4"); // Winter

        this.travelperiodTab1.style.display = "block";
        this.travelperiodTab2.style.display = "none";

        this.updateSettings();
    }

    updateSettings() {
        if (this.seasonSettings1.checked) this.seasonType = SeasonTypeEnum.Spring;
        if (this.seasonSettings2.checked) this.seasonType = SeasonTypeEnum.Summer;
        if (this.seasonSettings3.checked) this.seasonType = SeasonTypeEnum.Atumn;
        if (this.seasonSettings4.checked) this.seasonType = SeasonTypeEnum.Winter;
        if (this.seasonSite.checked == false) this.seasonType = SeasonTypeEnum.None;
    }

    showActiveTab() {
        if (this.seasonSite.checked == true) {
            this.travelperiodTab1.style.display = "none";
            this.travelperiodTab2.style.display = "block";
        }
        else {
            this.travelperiodTab1.style.display = "block";
            this.travelperiodTab2.style.display = "none";
        }
        this.updateSettings();
    }

    getStartDate() {
        if (this.seasonSite.checked == true) {
            switch (this.seasonType) {
                case SeasonTypeEnum.Spring: return "Forår sæson 1. april";
                case SeasonTypeEnum.Summer: return "Sommer sæson 1. april";
                case SeasonTypeEnum.Atumn: return "Efterår sæson 15. august";
                case SeasonTypeEnum.Winter: return "Vinter sæson 1. oktober";
            }
        }
        else {
            return document.getElementById("dat_start").value;
        }

    }
    getEndDate() {
        if (this.seasonSite.checked == true) {
            switch (this.seasonType) {
                case SeasonTypeEnum.Spring: return "Forår sæson 30. juni";
                case SeasonTypeEnum.Summer: return "Sommer sæson 30. semptember";
                case SeasonTypeEnum.Atumn: return "Efterår sæson 31 oktober";
                case SeasonTypeEnum.Winter: return "Vinter sæson 31 marts";
            }
        }
        else {
            return document.getElementById("dat_end").value;
        }
    }

    sessionDefault() {
        sessionStorage.setItem("seasonSite", "false");

        sessionStorage.setItem("seasonSettings1", "true");
        sessionStorage.setItem("seasonSettings2", "false");
        sessionStorage.setItem("seasonSettings3", "false");
        sessionStorage.setItem("seasonSettings4", "false");

    }
    sessionSave() {
        sessionStorage.setItem("seasonSite", this.seasonSite.checked);

        sessionStorage.setItem("seasonSettings1", this.seasonSettings1.checked);
        sessionStorage.setItem("seasonSettings2", this.seasonSettings2.checked);
        sessionStorage.setItem("seasonSettings3", this.seasonSettings3.checked);
        sessionStorage.setItem("seasonSettings4", this.seasonSettings4.checked);
    }
    sessionLoad() {
        this.seasonSite.checked = sessionStorage.getItem("seasonSite") == "true";

        this.seasonSettings1.checked = sessionStorage.getItem("seasonSettings1") == "true";
        this.seasonSettings2.checked = sessionStorage.getItem("seasonSettings2") == "true";
        this.seasonSettings3.checked = sessionStorage.getItem("seasonSettings3") == "true";
        this.seasonSettings4.checked = sessionStorage.getItem("seasonSettings4") == "true";

        this.showActiveTab();
    }
}