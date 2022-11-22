// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var dataTable;
$(document).ready(function ()){

    loadDataTable();
});
function loaddatatable() {
    datatable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/Product/GetAll"
        },

        "columns": [

            { "data": "Name", "width": "15%" },
            { "data": "Description", "width": "15%" },
            { "data": "Price", "width": "15%" },
            { "data": "Created Date", "width": "15%" },
            { "data": "Created By", "width": "15%" },
            { "data": "Updated date", "width": "15%" },
            { "data": "Updated By", "width": "15%" },
            { "data": "Title": "Category", "15%" },
            { "data": "Title", "SubCategory.Name": "15%" },

            {
                "data": "Id",
                "render": function (data) {
                    return

                    <div class=" w-75 btn-group" role="group">
                        <a href="/Admin/Product/upsert?id=${data}"
                            class="btn btn-primary mx-2">
                            <i class="bi bi-pencil-square"></i>&nbsp;Edit</a>
                        <a onClick=Delete('/Admin/Product/Delete'+${data}) class="btn btn-danger mx-2">
                            <i class="bi-trash-fill"></i>Delete</a>
                    </div>

                },


                "width": "15%"
            },
        ]
    });

}

function Delete(url) {

    wal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type='Delete',
                success: function (data) {
                    if (data.success)
                    {
                        dataTable.ajax.reload();
                        toaster.sucess(data.message);

                    }
                    else {
                        toaster.error(data.message);
                    }
                    )
                }

            })
        }
    })

}
                    