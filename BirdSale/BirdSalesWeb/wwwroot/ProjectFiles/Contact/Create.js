
$("#SubmitContact").on('click', function () {
    var obj = JSON.stringify({
        Name: $('#ContactName').val(),
        Email: $('#ContactEmail').val(),
        Number: $('#Contactnumber').val(),
        City: $('#city').val(),
    })
    console.log(obj);
    $.ajax({
        url: 'http://localhost:5154/Api/Contact/AddCategory',
        type: 'POST',
        data: obj,
        contentType: 'application/json;',
        success: function () {
            console.log("Successfully Inserted");
        },
        Error: function () {
            window.location.reload();
            console.log("error");
        }
    });



});
