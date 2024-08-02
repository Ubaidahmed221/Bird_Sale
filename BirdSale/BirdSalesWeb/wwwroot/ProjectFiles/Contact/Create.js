
$("#SubmitContact").on('click', function () {
    var obj = JSON.stringify({
        Name: $('#ContactName').val(),
        Email: $('#ContactEmail').val(),
        phone: $('#Contactnumber').val(),
        City: $('#city').val(),
    })
    console.log(obj);
    $.ajax({
        url: ApiUrls.Contact_AddContact,
        type: 'POST',
        data: obj,
        contentType: 'application/json;',
        success: function () {
            console.log("Successfully Inserted");
          
            // Reload the page after successful insert
            window.location.reload(); // true parameter forces reload from server, not cache
        },
        Error: function (err) {
            //window.location.reload();
            console.log(err);
            console.log("error");
        }
    });



});
