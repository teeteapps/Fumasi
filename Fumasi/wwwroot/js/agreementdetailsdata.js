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
            { "data": "accountCode", "name": "accountCode", "autoWidth": true },
            {
                "render": function (data, row) {
                    return "<a href='/Agreements/Getagreementaccounts?Code='" + accountCode + "''>Account</a>"; }
            },
            { "data": "identifierSno", "name": "Account Mask", "autoWidth": true }
        ]
    });
});