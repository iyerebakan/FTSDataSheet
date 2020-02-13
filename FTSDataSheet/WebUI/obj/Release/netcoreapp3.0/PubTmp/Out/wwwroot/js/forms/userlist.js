$(document).ready(function () {
    Projen.Client.UI.getDatatable(
        datatableId = "datatable_fixed_column",
        tablet = 1024,
        phone = 480,
        searchButton = true,
        addnewrowButton = true,
        newrecurl = "/kullanici/0",
        showhideButton = "",
        serverside = true,
        ajax = "/User/UserListDataTable",
        columns = [
            {
                "name": "Id",
                'render': function (data) {
                    return '<a href="/kullanici/' + data + '"  role="button"><span class="glyphicon glyphicon-pencil"></span></a>';
                }
            },
            { "name": "Id" },
            { "name": "FirstName" },
            { "name": "LastName" },
            { "name": "Email" },
            { "name": "Status" }
        ]
    );
});