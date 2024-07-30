//$(document).ready(function () {
//    // Load data initially
//    LoadData();

//    // Form submission handling
//    $('#categoryForm').submit(function (event) {
//        event.preventDefault();

//        var categoryName = $('#categoryName').val();
//        var categoryDescription = $('#categoryDescription').val();

//        // Perform AJAX POST to add category
//        $.ajax({
//            url: ApiUrls.Category_AddCategory,
//            type: 'POST',
//            contentType: 'application/json', // Specify the content type
//            data: JSON.stringify({ // Convert data to JSON string
//                Name: categoryName,
//                Description: categoryDescription
//            }),
//            success: function (response) {
//                console.log(response);
//                $('#categoryName').val('');
//                $('#categoryDescription').val('');
//                LoadData();
//            },
//            error: function (xhr, status, error) {
//                console.error("Error adding category:", xhr.responseText);
//                alert("Error adding category.");
//            }
//        });
//    });
//});

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
