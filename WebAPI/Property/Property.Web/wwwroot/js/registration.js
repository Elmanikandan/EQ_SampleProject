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
            { "data": "Name", "width": "15%" },
            { "data": "Address", "width": "15%" },
            { "data": "City", "width": "15%" },
            { "data": "MobileNumber", "width": "15%" },
            { "data": "Email", "width": "15%" },
            { "data": "Type", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                         <div class="w-75 btn-group" role="group">
                            <a class="btn btn-primary mx-2" href="/Registration/Edit/id=${data}">
                                <i class="bi bi-pencil-square"></i>&nbsp;&nbsp;Edit
                            </a>
                            <a class="btn btn-danger mx-2">
                                <i class="bi bi-trash-fill"></i>&nbsp;&nbsp;Delete
                            </a>
                        </div>
                    `
                }
            }
        ]
    })
}
