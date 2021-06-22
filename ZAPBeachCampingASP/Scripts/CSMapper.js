class Customer
{
    constructor() {
        this.FirstName = document.getElementById("tb_firstName").value;
        this.LastName = document.getElementById("tb_lastName").value;
        this.Email = document.getElementById("tb_email").value;
        this.Address = document.getElementById("tb_address").value;
        this.PhoneNumber = document.getElementById("tb_phoneNumber").value;
        this.City = document.getElementById("tb_city").value;
    }
}

class BookingOptions {
    constructor() {
        this.StartDate = document.getElementById("dat_start").valueAsDate;
        this.EndDate = document.getElementById("dat_end").valueAsDate;

        this.SpotType = campingSettingsHandler.spotType;
        this.CampingType = campingSettingsHandler.campingType;
        this.HutType = campingSettingsHandler.hutType;
        this.Adult = parseInt(campingSettingsHandler.adult.value);
        this.Child = parseInt(campingSettingsHandler.child.value);
        this.Dog = parseInt(campingSettingsHandler.dog.value);
        this.IsGoodView = campingSettingsHandler.isGoodView.checked;
        this.IsPayingForCleaning = campingSettingsHandler.isPayingForCleaning.checked;
        this.Additions = additionsHandler.getAdditions();
        this.SeasonType = travelperiodHandler.seasonType;
    }
}

function updateCSMapperHiddenElements() {
    document.getElementById('HF_Customer').value = JSON.stringify(new Customer());
    document.getElementById('HF_BookingOptions').value = JSON.stringify(new BookingOptions());
    return true;
}