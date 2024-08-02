$(document).ready(function () {
    LoadData();
});




function LoadData() {
    $.ajax({
        url: ApiUrls.Bird_GetBird,
        type: "Get",
        success: function (response) {
            console.log(response);
            var data = JSON.parse(response);
            console.log(data);
            for (var item of data.Response) {
                $('#MyTable tbody').append(`
                <tr>
                <td>${item.PkId}</td>
                <td>${item.Name}</td>
                <td>${item.Species}</td>
                <td>${item.Age}</td>
                <td>${item.Price}</td>
                <td>${item.Description}</td>
                <td>${item.ImageURL}</td>
                <td>${item.FKCategoryId}</td>
             
                </tr>
                `);
            }

        },


        Error: function () {
            alert("Errpr");
        }

    });
}