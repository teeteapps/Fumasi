$(document).ready(function () {
    $("#Agreementaccountsdetail").DataTable({
        "processing": true,
        "serverSide": true,
        "filter": true,
        "ajax": {
            "url": "/Agreements/Getagreementaccounts?Code="+$("#Agreementcodeid").val(),
            "type": "POST",
            "datatype": "json"
        },
        "columnDefs": [{
            "targets": [0],
            "visible": false,
            "searchable": false
        }],
        "columns": [
            { "data": "accountCode", "name": "account Action", "autoWidth": true },
            { "data": "accountAction", "name": "account Action", "autoWidth": true },
            { "data": "identifierSno", "name": "Account Mask", "autoWidth": true },
            { "data": "identifierUid", "name": "Card Uid", "autoWidth": true }
        ]
    });
});