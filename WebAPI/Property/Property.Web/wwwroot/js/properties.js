var dataTbl;
$(document).ready(function () {
    debugger;
    loadDataTable()
})

function loadDataTable() {

    dataTbl = $('#tblProperties').DataTable({
        "ajax": {
            "url": "/Properties/GetAll"
        },
        "columns": [
            { "data": "propertyNumber", "width": "20%" },
            { "data": "address", "width": "15%" },
            { "data": "city", "width": "15%" },
            { "data": "costPerSqft", "width": "18%" },
            { "data": "numberOfSqft", "width": "18%" },
            { "data": "totalCost", "width": "15%" },
            { "data": "type", "width": "15%" },
            { "data": "owner", "width": "15%" },
            { "data": "status", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                         <div class="w-75 btn-group" role="group">
                            <a class="btn btn-dark mx-2" href="/Properties/Edit?id=${data}">
                                <i class="bi bi-pencil-square"></i>
                            </a>
                            <a class="btn btn-danger mx-2" onclick=deleteProperty('/Properties/Delete/${data}')>
                                <i class="bi bi-trash-fill"></i>
                            </a>
                        </div>
                    `
                }
            }
        ]
    })
}
function deleteProperty(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then(
        (result) => {
            if (result.isConfirmed) {
                $.ajax({
                    url: url,
                    type: 'DELETE',
                    success: function (resp) {
                        if (resp.success) {
                            dataTbl.ajax.reload();
                            toastr.success(resp.message)
                        } else {
                            toastr.error(resp.message)
                        }
                    }
                })
            }
        }
    )
}
