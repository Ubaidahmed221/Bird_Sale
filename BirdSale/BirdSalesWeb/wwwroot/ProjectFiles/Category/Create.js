﻿
$("#SubmitCategory").on('click', function () {
    var obj = JSON.stringify({
        Name:$('#categoryName').val(),
        Description:$('#categoryDescription').val(),
    })
    console.log(obj);
    $.ajax({
        url: 'http://localhost:5154/Api/Category/AddCategory',
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
