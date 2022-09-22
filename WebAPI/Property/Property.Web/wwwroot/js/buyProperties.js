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
                            <a class="btn btn-success mx-2" href="/Properties/Buy?id=${data}">
                                Buy
                            </a>                           
                        </div>
                    `
                }
            }
        ]
    })
}

