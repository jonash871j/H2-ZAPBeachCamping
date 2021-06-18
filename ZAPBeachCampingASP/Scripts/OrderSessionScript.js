class SessionSaver {
    constructor() {
        this.save();
    }

    clear() {
        sessionStorage.setItem("prb_orderProgrss", "0%");

        sessionStorage.setItem("endDate", "");
        sessionStorage.setItem("startDate", "");

        sessionStorage.setItem("rb_spotType1", "true");
        sessionStorage.setItem("rb_spotType2", "false");
        sessionStorage.setItem("rb_spotType3", "false");
        sessionStorage.setItem("rb_campingType1", "true");
        sessionStorage.setItem("rb_campingType2", "false");
        sessionStorage.setItem("rb_hutType1", "true");
        sessionStorage.setItem("rb_hutType2", "false");
        sessionStorage.setItem("rb_tentType1", "true");

        sessionStorage.setItem("nb_adult", "1");
        sessionStorage.setItem("nb_child", "0");
        sessionStorage.setItem("nb_dog", "0");

        sessionStorage.setItem("firstName", "");
        sessionStorage.setItem("lastName", "");
        sessionStorage.setItem("email", "");
        sessionStorage.setItem("address", "");
        sessionStorage.setItem("phoneNumber", "");
        sessionStorage.setItem("city", "");
    }
    save() {
        sessionStorage.setItem("prb_orderProgrss", document.getElementById("prb_orderProgrss").style.width);

        sessionStorage.setItem("dat_end", document.getElementById("dat_end").value);
        sessionStorage.setItem("dat_start", document.getElementById("dat_start").value);

        sessionStorage.setItem("rb_spotType1", document.getElementById("rb_spotType1").checked);
        sessionStorage.setItem("rb_spotType2", document.getElementById("rb_spotType2").checked);
        sessionStorage.setItem("rb_spotType3", document.getElementById("rb_spotType3").checked);
        sessionStorage.setItem("rb_campingType1", document.getElementById("rb_campingType1").checked);
        sessionStorage.setItem("rb_campingType2", document.getElementById("rb_campingType2").checked);
        sessionStorage.setItem("rb_hutType1", document.getElementById("rb_hutType1").checked);
        sessionStorage.setItem("rb_hutType2", document.getElementById("rb_hutType2").checked);
        sessionStorage.setItem("rb_tentType1", document.getElementById("rb_tentType1").checked);

        sessionStorage.setItem("nb_adult", document.getElementById("nb_adult").value);
        sessionStorage.setItem("nb_child", document.getElementById("nb_child").value);
        sessionStorage.setItem("nb_dog", document.getElementById("nb_dog").value);

        sessionStorage.setItem("tb_firstName", document.getElementById("tb_firstName").value);
        sessionStorage.setItem("tb_lastName", document.getElementById("tb_lastName").value);
        sessionStorage.setItem("tb_email", document.getElementById("tb_email").value);
        sessionStorage.setItem("tb_address", document.getElementById("tb_address").value);
        sessionStorage.setItem("tb_phoneNumber", document.getElementById("tb_phoneNumber").value);
        sessionStorage.setItem("tb_city", document.getElementById("tb_city").value);
    }
}
class SessionLoader {
    constructor() {
        console.log(!!sessionStorage.getItem("rb_tentType1"));
        console.log(document.getElementById("rb_tentType1").checked);

        var orderProgrss = sessionStorage.getItem("prb_orderProgrss");
        if (orderProgrss != null) {
            document.getElementById("prb_orderProgrss").style.width = orderProgrss;
            progressHandler.update();
        }

        document.getElementById("dat_end").value = sessionStorage.getItem("dat_end");
        document.getElementById("dat_start").value = sessionStorage.getItem("dat_start");

        document.getElementById("rb_spotType1").checked = !!sessionStorage.getItem("rb_spotType1");
        document.getElementById("rb_spotType2").checked = !!sessionStorage.getItem("rb_spotType2");
        document.getElementById("rb_spotType3").checked = !!sessionStorage.getItem("rb_spotType3");
        document.getElementById("rb_campingType1").checked = !!sessionStorage.getItem("rb_campingType1");
        document.getElementById("rb_campingType2").checked = !!sessionStorage.getItem("rb_campingType2");
        document.getElementById("rb_hutType1").checked = !!sessionStorage.getItem("rb_hutType1");
        document.getElementById("rb_hutType2").checked = !!sessionStorage.getItem("rb_hutType2");
        document.getElementById("rb_tentType1").checked = !!sessionStorage.getItem("rb_tentType1");

        document.getElementById("nb_adult").value = parseInt(sessionStorage.getItem("nb_adult"));
        document.getElementById("nb_child").value = parseInt(sessionStorage.getItem("nb_child"));
        document.getElementById("nb_dog").value = parseInt(sessionStorage.getItem("nb_dog"));

        document.getElementById("tb_firstName").value = sessionStorage.getItem("tb_firstName");
        document.getElementById("tb_lastName").value = sessionStorage.getItem("tb_lastName");
        document.getElementById("tb_email").value = sessionStorage.getItem("tb_email");
        document.getElementById("tb_address").value = sessionStorage.getItem("tb_address");
        document.getElementById("tb_phoneNumber").value = sessionStorage.getItem("tb_phoneNumber");
        document.getElementById("tb_city").value = sessionStorage.getItem("tb_city");
    }
}
