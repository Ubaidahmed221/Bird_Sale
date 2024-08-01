$(document).ready(function () {
    LoadData();
});



function LoadData() {
    $.ajax({

        url: ApiUrls.Contact_GetContact,
        type: 'Get',

        success: function (response) {
            var data = JSON.parse(response);
            console.log(data);
            for (var item of data.Response) {
                $('#MyTable tbody').append(`
                    <tr>
                    <td>${item.id}</td>
                    <td>${item.name}</td>
                    <td>${item.email}</td>
                    <td>${item.phone}</td>
                    <td>${item.city}</td>
                    <td>
                     <input hidden value="${item.pkId}"/>
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
        url: 'http://localhost:5154/Api/Contact/DeleteContact' + '/' + id,
        type: 'GET',
        data: id,
        Success: function () {
            console.log("seccess");
        },
        Error: function () {
            console.log("Error");
        }


    });
});



