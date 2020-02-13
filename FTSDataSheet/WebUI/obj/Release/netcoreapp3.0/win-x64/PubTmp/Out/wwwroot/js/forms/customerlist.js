$(document).ready(function () {
    Projen.Client.UI.getDatatable(
        datatableId = "dtCustomer",
        tablet = 1024,
        phone = 480,
        searchButton = true,
        addnewrowButton = true,
        newrecurl = "/musteri/0",
        showhideButton = "",
        serverside = true,
        ajax = "/Customer/CustomerListDataTable",
        columns = [
            {
                "name": "Id",
                'render': function (data) {
                    return '<a href="/musteri/' + data + '"  role="button"><span class="glyphicon glyphicon-pencil"></span></a>';
                }
            },
            { "name": "Id" },
            { "name": "DisplayName" },
            { "name": "CommercialTitle" },
            { "name": "TelephoneNumber" },
            { "name": "EmailAddress" },
            { "name": "WebAddress" },
        ]
    );
});

