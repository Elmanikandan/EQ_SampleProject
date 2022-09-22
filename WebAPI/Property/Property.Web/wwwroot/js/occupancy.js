var dataTbl;
$(document).ready(function () {
    debugger;
    loadDataTable()
})

function loadDataTable() {
    debugger;
    dataTbl = $('#tblOcupancy').DataTable({
        "ajax": {
            "url": "/Occupancy/GetAll"
        },
        "columns": [
            { "data": "customerId", "width": "20%" },
            { "data": "ownerId", "width": "15%" },           
            { "data": "occupiedBy", "width": "15%" },
            { "data": "occupiedOn", "width": "15%" }            
        ]
    })
}

