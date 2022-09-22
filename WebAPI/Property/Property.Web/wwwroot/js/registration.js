var dataTbl;
$(document).ready(function () {
    debugger;
    loadDataTable()
})

function loadDataTable() {

    dataTbl = $('#tblRegistrationData').DataTable({
        "ajax": {
            "url": "/Registration/GetAll"
        },
        "columns": [
            { "data": "name", "width": "15%" },
            { "data": "address", "width": "15%" },
            { "data": "city", "width": "15%" },
            { "data": "mobileNumber", "width": "15%" },
            { "data": "email", "width": "15%" },
            { "data": "type", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                         <div class="w-75 btn-group" role="group">
                            <a class="btn btn-dark mx-2" href="/Registration/Edit?id=${data}">
                                <i class="bi bi-pencil-square"></i>
                            </a>
                            <a class="btn btn-danger mx-2" onclick=deleteProduct('/Registration/DeleteRecord/${data}')>
                                <i class="bi bi-trash-fill"></i>
                            </a>
                        </div>
                    `
                }
            }
        ]
    })
}
function deleteProduct(url) {
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
