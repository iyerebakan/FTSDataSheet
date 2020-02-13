var basePath = "";
function UrlDuzelt(url) {
    url = window.basePath + url;
    return url;
}
if (typeof Projen == 'undefined') { Projen = {}; }
if (typeof Projen.Client == 'undefined') { Projen.Client = {}; }
if (typeof Projen.Server == 'undefined') { Projen.Server = {}; }
if (typeof Projen.Client.UI == 'undefined') { Projen.Client.UI = {}; }
var jqselected;
Projen.Client.UI.getDatatable = function (datatableId, tablet, phone, searchButton, addnewrowButton, newrecurl, showhideButton, serverside, ajax, columns, func, exportButton, exporturl) {

    if (otable != undefined) {
        otable.destroy();
    }

    var responsiveHelper = undefined;
    var breakpointDefinition = {
        tablet: tablet,
        phone: phone
    };

    var otable = $("#" + datatableId).DataTable({
        "sDom": "<'dt-toolbar'<'col-xs-12 col-sm-6 hidden-xs'f><'col-sm-6 col-xs-12 hidden-xs'<'toolbar'>" + showhideButton + ">r>" +
            "t" +
            "<'dt-toolbar-footer'<'col-sm-6 col-xs-12 hidden-xs'i><'col-xs-12 col-sm-6'p>l>",
        "serverSide": serverside,
        "proccessing": true,
        "ajax": {
            url: UrlDuzelt(ajax),
            type: "POST",
            contentType: "application/json",
            dataType: "json",
            data: function (d) {
                return JSON.stringify(d);
            }
        },
        "autoWidth": true,
        "columns": columns,
        "columnDefs": [{
            "targets": 0,
            "searchable": false
        }
        ],
        "preDrawCallback": function () {
            // Initialize the responsive datatables helper once.
            if (!responsiveHelper) {
                responsiveHelper = new ResponsiveDatatablesHelper($("#" + datatableId), breakpointDefinition);
            }
        },
        "rowCallback": func,
        "drawCallback": function (oSettings) {
            responsiveHelper.respond();
        },
        "initComplete": function (settings, json) {
            $("#" + datatableId + "_filter input").unbind();
            $("#" + datatableId + "_filter input").bind('keyup', function (e) {
                if (e.keyCode == 13) {
                    otable.search(this.value).draw();
                } else {
                    otable.search(this.value);
                }
            });
        }
    });

    if (addnewrowButton) {
        $("div.toolbar").html('<div class="col-lg-12 text-right"><button class="btn btn-success ColVis" id="btnNewRecord"><i class="fa fa-plus"></i> <span class="hidden-mobile">Yeni Kayıt Ekle</span></button></div>');
        $("#btnNewRecord").on("click", function () {
            window.open(UrlDuzelt(newrecurl));
        });
    }
    $("#" + datatableId + " thead th input").on('keydown', function (e) {
        if (e.which == 13) {
            otable
                .column($(this).parent().index() + ':visible')
                .search(this.value)
                .draw(true);
        } else {
            otable
                .column($(this).parent().index() + ':visible')
                .search(this.value)
        }
    });

    $("#" + exportButton).bind("click", function () {
        $.ajax({
            type: "POST",
            async: true,
            url: UrlDuzelt(exporturl),
            data: otable.data().ajax.params(),
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            success: func,
            error: function (xhr, errorType, exception) {
                alert(xhr.responseText);
            }
        });

    });
};


Projen.Server.PostAsync = function (model, url, func) {
    $.ajax({
        type: "POST",
        async: true,
        url: UrlDuzelt(url),
        data: JSON.stringify(model),
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        success: func,
        error: function (xhr, errorType, exception) {
            alert(xhr.responseText);
        }
    });
};

Projen.Server.GetAsync = function (model, url, func) {
    $.ajax({
        type: "GET",
        async: true,
        url: UrlDuzelt(url),
        data: JSON.stringify(model),
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        success: func,
        error: function (xhr, errorType, exception) {
            alert(xhr.responseText);
        }
    });
};

Projen.Server.UploadAsync = function (model, url, func) {
    debugger;
    if (model != undefined) {
        var formdata = new FormData();
        for (var i = 0; i < model.length; i++) {
            formdata.append("file", model[i]);
        }
        $.ajax({
            async: true,
            url: UrlDuzelt(url),
            type: "POST",
            data: formdata,
            contentType: false,
            cache: false,
            processData: false,
            success: func,
            error: function (xhr, errorType, exception) {
                alert(xhr.responseText);
            }
        });
    }
}



Projen.Client.UI.getJqGrid = function (tableId, divId, url, colNames, colModel, editurl, caption, multiselect, deleteurl) {

    jQuery("#" + tableId).jqGrid({
        url: UrlDuzelt(url),
        datatype: "json",
        height: 'auto',
        myType: 'POST',
        colNames: colNames,
        colModel: colModel,
        rowNum: 10,
        rowList: [10, 20, 30],
        pager: '#' + divId,
        sortname: 'id',
        toolbarfilter: true,
        viewrecords: true,
        loadonce: true,
        sortorder: "asc",
        gridComplete: function () {
            var ids = jQuery("#" + tableId).jqGrid('getDataIDs');
            for (var i = 0; i < ids.length; i++) {
                var cl = ids[i];
                add = "";
                upd = "<button class='btn btn-xs btn-primary' id='upd" + tableId + cl + "' style='margin-right:5px' onclick=\"Projen.Client.UI.getJqGridUpdateRow('" + tableId + "','" + cl + "');\"><i class='fa fa-pencil'></i> Güncelle</button>";
                del = "<button class='btn btn-xs btn-danger' id='del" + tableId + cl + "' style='margin-right:5px' onclick=\"Projen.Client.UI.getJqGridDeleteRow('" + tableId + "','" + cl + "','" + deleteurl + "');\"><i class='fa fa-times'></i> Sil</button>";
                save = "<button class='btn btn-xs btn-primary' id='save" + tableId + cl + "' style='margin-right:5px;display:none;' onclick=\"Projen.Client.UI.getJqGridSaveRow('" + tableId + "','" + cl + "');\"><i class='fa fa-save'></i> Kaydet</button>";
                can = "<button class='btn btn-xs btn-default' id='can" + tableId + cl + "' style='margin-right:5px;display:none;' onclick=\"Projen.Client.UI.getJqGridCancelRow('" + tableId + "','" + cl + "');\"><i class='fa fa-times'></i> İptal</button>";
                jQuery("#" + tableId).jqGrid('setRowData', ids[i], {
                    act: add + upd + del + save + can
                });
            }
        },
        editurl: UrlDuzelt(editurl),
        caption: caption,
        multiselect: multiselect,
        autowidth: true,
        postData: function (d) {
            return JSON.stringify(d);
        }
    });

    jQuery("#" + tableId).jqGrid('navGrid', "#" + divId, {
        edit: false,
        add: false,
        del: false,
    }, { hidden: true }, { hidden: true }, { hidden: true }, {
        multipleSearch: true,
    });

    jQuery("#" + tableId).jqGrid('inlineNav', "#" + divId);
    /* Add tooltips */
    $('.navtable .ui-pg-button').tooltip({
        container: 'body'
    });

    jQuery("#refresh_" + tableId).click(function () {
        jQuery('#' + tableId).setGridParam({ page: 1, datatype: "json" }).trigger('reloadGrid');
    });

    // remove classes
    $(".ui-jqgrid").removeClass("ui-widget ui-widget-content");
    $(".ui-jqgrid-view").children().removeClass("ui-widget-header ui-state-default");
    $(".ui-jqgrid-labels, .ui-search-toolbar").children().removeClass("ui-state-default ui-th-column ui-th-ltr");
    $(".ui-jqgrid-pager").removeClass("ui-state-default");
    $(".ui-jqgrid").removeClass("ui-widget-content");

    // add classes
    $(".ui-jqgrid-htable").addClass("table table-bordered table-hover");
    $(".ui-jqgrid-btable").addClass("table table-bordered table-striped");

    $(".ui-pg-div").removeClass().addClass("btn btn-sm btn-primary");
    //$(".ui-icon.ui-icon-plus").removeClass().addClass("fa fa-plus");
    $("#" + tableId + "_iladd").hide(); $("#" + tableId + "_iledit").hide();
    $("#" + tableId + "_ilsave").hide(); $("#" + tableId + "_ilcancel").hide();

    $(".ui-icon.ui-icon-search").removeClass().addClass("fa fa-search");
    $(".ui-icon.ui-icon-refresh").removeClass().addClass("fa fa-refresh");

    $(".ui-icon.ui-icon-seek-prev").wrap("<div class='btn btn-sm btn-default'></div>");
    $(".ui-icon.ui-icon-seek-prev").removeClass().addClass("fa fa-backward");

    $(".ui-icon.ui-icon-seek-first").wrap("<div class='btn btn-sm btn-default'></div>");
    $(".ui-icon.ui-icon-seek-first").removeClass().addClass("fa fa-fast-backward");

    $(".ui-icon.ui-icon-seek-next").wrap("<div class='btn btn-sm btn-default'></div>");
    $(".ui-icon.ui-icon-seek-next").removeClass().addClass("fa fa-forward");

    $(".ui-icon.ui-icon-seek-end").wrap("<div class='btn btn-sm btn-default'></div>");
    $(".ui-icon.ui-icon-seek-end").removeClass().addClass("fa fa-fast-forward");
};

Projen.Client.UI.getJqGridNewRow = function (tableId) {
    jqselected = null;
    if ($("#" + tableId + " tr[id ^= 'jqg']").length == 0) {
        if ($("#" + tableId + " tr td button[id^='save" + tableId + "']").not("[style*=none]").length > 0) {
            var t = $("#" + tableId + " tr td button[id^='save" + tableId + "']").not("[style*=none]").button()[0].id.replace("save" + tableId, "");
            Projen.Client.UI.getJqGridCancelRow(tableId, t);
        }
        jQuery('#' + tableId).addRow('new');
        var Id = $("#" + tableId + " tr[id^='jqg']")[0].id;
        $('#' + tableId + ' tr td button[id^="upd' + tableId + '"]').hide();
        $('#' + tableId + ' tr td button[id^="del' + tableId + '"]').hide();
        $('#save' + tableId + Id).show(); $('#can' + tableId + Id).show();
    }
};

Projen.Client.UI.getJqGridUpdateRow = function (tableId, Id) {
    jqselected = $("#" + tableId).getRowData(Id);
    if ($("#" + tableId + " tr td button[id^='save" + tableId + "']").not("[style*=none]").length > 0) {
        var t = $("#j" + tableId + " tr td button[id^='save" + tableId + "']").not("[style*=none]").button()[0].id.replace("save" + tableId, "");
        if ($.isNumeric(t))
            CancelRow(tableId, t);
        else
            DeleteRow(tableId, t);
    }
    jQuery('#' + tableId).editRow(Id);
    $('#' + tableId + ' tr td button[id^="upd' + tableId + '"]').hide();
    $('#' + tableId + ' tr td button[id^="del' + tableId + '"]').hide();
    $('#save' + tableId + Id).show(); $('#can' + tableId + Id).show();
};

Projen.Client.UI.getJqGridDeleteRow = function (tableId, Id, url) {
    var ans = window.confirm(Id + " numaralı kayıt silinecektir. İşleme devam etmek istiyor musunuz?");
    if (ans) {
        $.ajax({
            type: "POST",
            async: true,
            url: url + "?Id=" + Id,
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            success: function () {
                jQuery('#' + tableId).delRowData(Id);
            },
            error: function (exception) {
                alert(exception);
            }
        });
    }
};

Projen.Client.UI.getJqGridCancelRow = function (tableId, Id) {
    jqselected = null;
    jQuery('#' + tableId).restoreRow(Id);
    $('#' + tableId + ' tr td button[id^="upd' + tableId + '"]').show();
    $('#' + tableId + ' tr td button[id^="del' + tableId + '"]').show();
    $('#save' + tableId + Id).hide(); $('#can' + tableId + Id).hide();
};

Projen.Client.UI.getJqGridSaveRow = function (tableId, Id) {
    //var result = Projen.Client.UI.funcJqGridSaveRow(Id);
    //if (result) {
    //    jQuery('#' + tableId).saveRow(Id);
    //    jQuery('#' + tableId).setGridParam({ page: 1, datatype: "json" }).trigger('reloadGrid');
    //}
    jQuery('#' + tableId).saveRow(Id);
    jQuery('#' + tableId).setGridParam({ page: 1, datatype: "json" }).trigger('reloadGrid');
};


Projen.Client.UI.getSelect2Combobox = function (comboId, url) {
    $("#" + comboId).select2({
        placeholder: 'Seçiniz..',
        minimumInputLength: 0,
        allowClear: true,
        ajax: {
            url: UrlDuzelt(url),
            dataType: 'json',
            delay: 500,
            type: "GET",
            async: true,
            data: function (params) {
                return {
                    pageSize: 100,
                    pageNum: params.page || 1,
                    searchTerm: params.term,
                };
            },
            processResults: function (data, params) {
                debugger;
                params.page = params.page || 1;
                return {
                    results: $.map(data.results, function (obj) {
                        return { id: obj.id, text: obj.name };
                    }),
                    pagination: {
                        more: (params.page * 100) <= data.total
                    }
                };
            }
        },
    });
};



