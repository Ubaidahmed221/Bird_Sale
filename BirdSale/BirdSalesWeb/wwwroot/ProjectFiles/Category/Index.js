$(document).ready(function () {
    LoadData();
});



function LoadData() {
    $.ajax({

        url: ApiUrls.Category_GetCategorys,
        type: 'Get',
       
        success: function (response) {
            var data = JSON.parse(response);
            for (var item of data.Response) {
                $('#MyTable tbody').append(`
                    <tr>
                    <td>${item.PkId}</td>
                    <td>${item.Name}</td>
                    <td>${item.Description}</td>
                    <td>
                     <input hidden value="${item.PkId}"/>
                     <button class="btn btn-danger btn-sm BtnDelete">Delete</button>
                    </td>    
             
                    </tr>

                `);
            }
          },
        Error: function () {
            alert("Error");
        }
       

    });
}



$("body").on("click", ".BtnDelete", function () {
    let id = $(this).prev().val();
    console.log(id);
    $.ajax({
        url: 'http://localhost:5154/Api/Category/DeleteCategory' + '/' + id,
        type: 'GET',
        data: id,
        Success: function () {
            console.log("seccess");
            // Reload the page after successful deletion
            location.reload(true); // true parameter forces reload from server, not cache
        },
        Error: function () {
            console.log("Error");
        }


    });
});



