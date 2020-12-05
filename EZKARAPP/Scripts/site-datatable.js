$(document).ready(function () {

    $.extend(true, $.fn.dataTable.defaults, {
        //"searching": false,
        "stateSave": true,
        dom: '<"row bg-info pt-3 pr-3 m-0 small view-filter"<"col-sm-12" f<"clearfix">>>t<"bg-info p-4 small"<"row view-pager"<"col-6 col-sm-6" l><"col-6 col-sm-6" p>><"row"<"col-12 text-right" i>>>'
    });

});

