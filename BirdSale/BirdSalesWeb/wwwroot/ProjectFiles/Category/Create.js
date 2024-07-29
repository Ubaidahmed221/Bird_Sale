$(document).ready(function () {
    // Load data initially
    LoadData();

    // Form submission handling
    $('#categoryForm').submit(function (event) {
        event.preventDefault();

        var categoryName = $('#categoryName').val();
        var categoryDescription = $('#categoryDescription').val();

        // Perform AJAX POST to add category
        $.ajax({
            url: ApiUrls.Category_AddCategory,
            type: 'POST',
            contentType: 'application/json', // Specify the content type
            data: JSON.stringify({ // Convert data to JSON string
                Name: categoryName,
                Description: categoryDescription
            }),
            success: function (response) {
                console.log(response);
                $('#categoryName').val('');
                $('#categoryDescription').val('');
                LoadData();
            },
            error: function (xhr, status, error) {
                console.error("Error adding category:", xhr.responseText);
                alert("Error adding category.");
            }
        });
    });
});
