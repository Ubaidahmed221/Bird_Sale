
$("#SubmitBird").on('click', function () {
    var obj = JSON.stringify({
        Name: $('#Name').val(),
        Species: $('#Species').val(),
        Age: $('#Age').val(),
        Price: $('#Price').val(),
        Description: $('#Description').val(),
        Image: $('#Image').val(),
       
    })
    console.log(obj);
    $.ajax({
        url: ApiUrls.Bird_AddBird,
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
