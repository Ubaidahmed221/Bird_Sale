$(document).ready(function () {
    LoadData();
});



function LoadData() {
    $.ajax({

        url: ApiUrls.Category_GetCategorys,
        type: 'Get',
       
        success: function (response) {
            console.log(response);
            var data = JSON.parse(response);
            console.log(data);
            for (var item of data.Response) {
                $('#MyTable tbody').append(`
                
                    <tr>
                    <td>${item.PkId}</td>
                    <td>${item.Name}</td>
                    <td>${item.Description}</td>
                    <td>
                    </tr>

                `);
            }
             

        },
        Error: function () {
            alert("Errpr");
        }
       

    });
}