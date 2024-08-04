$("#SubmitCategory").on('click', function () {
    var obj = JSON.stringify({
        Name: $('#categoryName').val(),
        Description: $('#categoryDescription').val(),
    });
    console.log(obj);
    $.ajax({
        url: 'http://localhost:5154/api/Bird/AddBird',
        type: 'POST',
        data: obj,
        contentType: 'application/json',
        success: function () {
            console.log("Successfully Inserted");
            // Reload the page after successful insertion
            location.reload(true); // true parameter forces reload from server, not cache
        },
        error: function () {
            console.log("Error occurred");
            // Handle error if needed
        }
    });
});
