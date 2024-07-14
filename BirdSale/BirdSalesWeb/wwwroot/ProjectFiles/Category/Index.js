$(document).ready(function () {
    LoadData();
});



function LoadData() {
    $.ajax({

        url: ApiUrls.Category_GetCategorys,
        type: 'Get',
        data = null,
        success: function (response) {
            console.log(response);
            var data = json.parse(response);
            console.log(response);
            for (var item of data.Response) {
                $('#MyTable tbody').append(`
                
                    <tr>
                    <td>${item.Name}</td>
                    <td>${item.Description}</td>
                    <td>
                    </tr>

                `);
            }
              $("#MyTable").DataTable({
                dom: "lBfrtip",
                buttons: [
                    'print',
                    'pdf',
                    'excel',
                    'copy'
                ]
            });

        },
        Error: function () {
            alert("Errpr");
        }
       

    });
}