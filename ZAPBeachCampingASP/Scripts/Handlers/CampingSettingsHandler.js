const SpotTypeEnum = { "Tent": 1, "Camping": 2, "Hut": 3 }
const CampingTypeEnum = { "Small": 1, "Large": 2, "SeasonLarge": 3 }
const HutTypeEnum = { "Default": 1, "Luxury": 2 }

class CampingSettingsHandler {
    constructor() {

        // **** Radio buttons section 1
        this.campingSettingsTab1 = document.getElementById("dv_campingSettingsTab1"); // Camping car tab
        this.campingSettingsTab2 = document.getElementById("dv_campingSettingsTab2"); // Tent tab
        this.campingSettingsTab3 = document.getElementById("dv_campingSettingsTab3"); // Hut tab

        // **** Radio buttons section 2
        this.spotType1 = document.getElementById("rb_spotType1"); // Camping button
        this.spotType2 = document.getElementById("rb_spotType2"); // Tent button
        this.spotType3 = document.getElementById("rb_spotType3"); // Hut button

        this.campingType1 = document.getElementById("rb_campingType1"); // Small button
        this.campingType2 = document.getElementById("rb_campingType2"); // Large button

        this.hutType1 = document.getElementById("rb_hutType1"); // Default button
        this.hutType2 = document.getElementById("rb_hutType2"); // Luxury button

        this.tentType1 = document.getElementById("rb_tentType1"); // Default button

        // **** Checkboxes section 2
        this.isGoodView = document.getElementById("cb_isGoodView");
        this.isPayingForCleaning = document.getElementById("cb_isPayingForCleaning");
        this.isPayingForCleaningTab = document.getElementById("dv_isPayingForCleaning"); // Hut tab

        // **** Numberboxes section 3
        this.adult = document.getElementById("nb_adult");
        this.child = document.getElementById("nb_child");
        this.dog = document.getElementById("nb_dog");

        this.adultDescription = document.getElementById("lb_adultDescription");
        this.childDescription = document.getElementById("lb_childDescription");
        this.dogDescription = document.getElementById("lb_dogDescription");

        this.showActiveSpotTab();
    }

    // Used to update enum value based on 
    // the check states of the radiobuttons
    updateSettings() {
        // **** Radio buttons section 1
        if (this.spotType1.checked) this.spotType = SpotTypeEnum.Camping;
        if (this.spotType2.checked) this.spotType = SpotTypeEnum.Tent;
        if (this.spotType3.checked) this.spotType = SpotTypeEnum.Hut;

        // **** Radio buttons section 2
        if (this.campingType1.checked) this.campingType = CampingTypeEnum.Small;
        if (this.campingType2.checked) this.campingType = CampingTypeEnum.Large;

        if (this.hutType1.checked) this.hutType = HutTypeEnum.Default;
        if (this.hutType2.checked) this.hutType = HutTypeEnum.Luxury;
    }

    showActiveSpotTab() {
        this.updateSettings();

        this.campingSettingsTab1.style.display = "none";
        this.campingSettingsTab2.style.display = "none";
        this.campingSettingsTab3.style.display = "none";
        this.isPayingForCleaningTab.style.display = "none";

        switch (this.spotType) {
            case SpotTypeEnum.Camping:
                this.campingSettingsTab1.style.display = "block";
                this.adultDescription.innerHTML = "Hver voksen koster pr. dag høj: 82,- lav: 87,-";
                this.childDescription.innerHTML = "Hver barn koster pr. dag høj: 42,- lav: 49,-";
                this.dogDescription.innerHTML = "Hver hund koster pr. dag høj: 30,- lav: 30,-";
                break;
            case SpotTypeEnum.Tent:
                this.campingSettingsTab2.style.display = "block";
                this.adultDescription.innerHTML = "Hver voksen koster pr. dag høj: 82,- lav: 87,-";
                this.childDescription.innerHTML = "Hver barn koster pr. dag høj: 42,- lav: 0,-";
                this.dogDescription.innerHTML = "Hver hund koster pr. dag høj: 0,- lav: 0,-";
                break;
            case SpotTypeEnum.Hut:
                this.campingSettingsTab3.style.display = "block";
                this.isPayingForCleaningTab.style.display = "block";
                this.adultDescription.innerHTML = "Hver voksen koster pr. dag høj: 82,- lav: 87,-";
                this.childDescription.innerHTML = "Hver barn koster pr. dag høj: 42,- lav: 49,-";
                this.dogDescription.innerHTML = "Hver hund koster pr. dag høj: 30,- lav: 30,-";
                break;
        }
    }
    getSpotTypeDescription() {
        switch (this.spotType) {
            case SpotTypeEnum.Camping:
                return "Campingvogn";
            case SpotTypeEnum.Tent:
                return "Telt";
            case SpotTypeEnum.Hut:
                return "Hytte";
        }
    }
    getSpotSettingDescription() {
        switch (this.spotType) {
            case SpotTypeEnum.Camping:
                return this.getCampingTypeDescription();
            case SpotTypeEnum.Hut:
                return this.getHutTypeDescription();
            case SpotTypeEnum.Tent:
                return "Telt plads";
        }
    }
    getCampingTypeDescription() {
        switch (this.campingType) {
            case CampingTypeEnum.Small:
                return "Lille plads";
            case CampingTypeEnum.Large:
                return "Stor plads";
        }
    }
    getHutTypeDescription() {
        switch (this.hutType) {
            case HutTypeEnum.Default:
                return "Standard hytte";
            case HutTypeEnum.Luxury:
                return "Luksus hytte";
        }
    }
    getIsGoodViewDescription() {
        if (this.isGoodView.checked){
            return "Ja";
        }
        else{
            return "Nej";
        }
    }
    getIsPayingForCleaningDescription() {
        if (this.spotType != SpotTypeEnum.Hut){
            return "-";
        }
        if (this.isPayingForCleaning.checked){
            return "Ja";
        }
        else{
            return "Nej";
        }
    }
    sessionDefault() {
        sessionStorage.setItem("spotType1", "true");
        sessionStorage.setItem("spotType2", "false");
        sessionStorage.setItem("spotType3", "false");

        sessionStorage.setItem("campingType1", "true");
        sessionStorage.setItem("campingType2", "false");
        sessionStorage.setItem("hutType1", "true");
        sessionStorage.setItem("hutType2", "false");
        sessionStorage.setItem("tentType1", "true");

        sessionStorage.setItem("cisGoodView", "false");
        sessionStorage.setItem("isPayingForCleaning", "false");

        sessionStorage.setItem("adult", "1");
        sessionStorage.setItem("child", "0");
        sessionStorage.setItem("dog", "0");

    }
    sessionSave() {
        sessionStorage.setItem("spotType1", this.spotType1.checked);
        sessionStorage.setItem("spotType2", this.spotType2.checked);
        sessionStorage.setItem("spotType3", this.spotType3.checked);

        sessionStorage.setItem("campingType1", this.campingType1.checked);
        sessionStorage.setItem("campingType2", this.campingType2.checked);
        sessionStorage.setItem("hutType1", this.hutType1.checked);
        sessionStorage.setItem("hutType2", this.hutType2.checked);
        sessionStorage.setItem("tentType1", this.tentType1.checked);

        sessionStorage.setItem("isGoodView", this.isGoodView.checked);
        sessionStorage.setItem("isPayingForCleaning", this.isPayingForCleaning.checked);

        sessionStorage.setItem("adult", this.adult.value);
        sessionStorage.setItem("child", this.child.value);
        sessionStorage.setItem("dog", this.dog.value);
    }
    sessionLoad() {
        this.spotType1.checked = sessionStorage.getItem("spotType1") == "true";
        this.spotType2.checked = sessionStorage.getItem("spotType2") == "true";
        this.spotType3.checked = sessionStorage.getItem("spotType3") == "true";

        this.campingType1.checked = sessionStorage.getItem("campingType1") == "true";
        this.campingType2.checked = sessionStorage.getItem("campingType2") == "true";
        this.hutType1.checked = sessionStorage.getItem("hutType1") == "true";
        this.hutType2.checked = sessionStorage.getItem("hutType2") == "true";
        this.tentType1.checked = sessionStorage.getItem("tentType1") == "true";

        this.isGoodView.checked = sessionStorage.getItem("isGoodView") == "true";
        this.isPayingForCleaning.checked = sessionStorage.getItem("isPayingForCleaning") == "true";

        this.adult.value = sessionStorage.getItem("adult");
        this.child.value = sessionStorage.getItem("child");
        this.dog.value = sessionStorage.getItem("dog");

        this.showActiveSpotTab();
    }
}