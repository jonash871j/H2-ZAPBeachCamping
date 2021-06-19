// Used to converts date to yyyy-mm-dd with leadning zeros
function getDateString(date) {
    var dateString = date.getFullYear() + "-" +
        ("0" + (date.getMonth() + 1)).slice(-2) + "-" +
        ("0" + date.getDate()).slice(-2);

    return dateString;
}

$(function () {
    // Gets date of today
    var minStartDate = new Date();

    // Sets min date for start calender
    $('#dat_start').attr('min', getDateString(minStartDate));

    // When there is no selected start date
    if ($('#dat_start').value == null) {
        document.getElementById("dat_start").valueAsDate = minStartDate;
    }

    updateEndDate();
});



$(function () {
    document.getElementById("dat_start").addEventListener("change", function () {
        // Convert start date value to date object
        var minEndDate = new Date(this.value);

        // Adds one day from the start day
        minEndDate.setDate(minEndDate.getDate() + 1);

        // Sets min date for end calender
        $('#dat_end').attr('min', getDateString(minEndDate));
    });
});


function updateEndDate() {
    // Convert start date value to date object
    var minEndDate = new Date(document.getElementById("dat_start").valueAsDate);

    // Adds one day from the start day
    minEndDate.setDate(minEndDate.getDate() + 1);

    
    document.getElementById("dat_end").valueAsDate = minEndDate;
}

$(function () {
    document.getElementById("dat_start").addEventListener("change", function () {
        updateEndDate();
    });
});