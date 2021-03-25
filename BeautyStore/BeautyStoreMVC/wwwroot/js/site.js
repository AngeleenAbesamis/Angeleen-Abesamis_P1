
function INitializeTable(Table) {
    var UsersTable = $("#" + Table).dataTable({
        pageLength: 10,
        filter: true,
        deferRender: true,
        "aaSorting": []
        // scrollY: 200,
        //scrollCollapse: true,
        //scroller: true

    });

    $('#' + Table + ' tbody').on('mouseenter', 'td', function () {
        if ($(this).find(".fa-trash-o").length <= 0) {
            this.setAttribute('title', $(this).text());
        }
    });
}