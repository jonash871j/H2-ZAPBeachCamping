$(function () {
    var dtToday = new Date();



    var month = dtToday.getMonth() + 1;
    var day = dtToday.getDate();
    var year = dtToday.getFullYear();
    if (month < 10)
        month = '0' + month.toString();
    if (day < 10)
        day = '0' + day.toString();



    var maxDate = year + '-' + month + '-' + day;
    $('#start').attr('min', maxDate);
});



$(function () {
    let newSelectedDate; // undefined



    document.getElementById("start").addEventListener("change", function () {
        newSelectedDate = this.value;



        $('#end').attr('min', newSelectedDate);
    });
});



$(function () {
    let newSelectedDate; // undefined



    document.getElementById("start").addEventListener("change", function () {
        document.getElementById("end").valueAsDate = null;
    });
});