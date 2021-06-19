class CustomerHandler {
    constructor() {
        this.firstName = document.getElementById("tb_firstName");
        this.lastName = document.getElementById("tb_lastName");
        this.email = document.getElementById("tb_email");
        this.address = document.getElementById("tb_address");
        this.phoneNumber = document.getElementById("tb_phoneNumber");
        this.city = document.getElementById("tb_city");
    }

    sessionDefault() {
        sessionStorage.setItem("firstName", "");
        sessionStorage.setItem("lastName", "");
        sessionStorage.setItem("email", "");
        sessionStorage.setItem("address", "");
        sessionStorage.setItem("phoneNumber", "");
        sessionStorage.setItem("city", "");
    }
    sessionSave() {
        sessionStorage.setItem("firstName", this.firstName.value);
        sessionStorage.setItem("lastName", this.lastName.value);
        sessionStorage.setItem("email", this.email.value);
        sessionStorage.setItem("address", this.address.value);
        sessionStorage.setItem("phoneNumber", this.phoneNumber.value);
        sessionStorage.setItem("city", this.city.value);
    }
    sessionLoad() {
        this.firstName.value = sessionStorage.getItem("firstName");
        this.lastName.value = sessionStorage.getItem("lastName");
        this.email.value = sessionStorage.getItem("email");
        this.address.value = sessionStorage.getItem("address");
        this.phoneNumber.value = sessionStorage.getItem("phoneNumber");
        this.city.value = sessionStorage.getItem("city");

    }
}