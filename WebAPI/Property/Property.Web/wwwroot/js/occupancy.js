var dataTbl;
$(document).ready(function () {
    debugger;
    loadDataTable()
})

function loadDataTable() {
    debugger;
    dataTbl = $('#tblOccupancy').DataTable({
        "ajax": {
            "url": "/Occupancy/GetAll"
        },
        "columns": [
            { "data": "customerName", "width": "20%" },
            { "data": "ownerName", "width": "15%" },           
            { "data": "propertyNumber", "width": "15%" },
            { "data": "occupiedOn", "width": "15%" }            
        ]
    })
}

