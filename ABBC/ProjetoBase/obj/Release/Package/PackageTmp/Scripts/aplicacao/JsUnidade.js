$(document).ready(function () {

    //Add class no menu
    $('#unid').addClass("active");
    //Remove class no menu
    $('#mdash').removeClass("active");
    $('#mrelat').removeClass("active");
    $('#mgraf').removeClass("active");
    $('#matend').removeClass("active");

    demo.initMaterialWizard();
    demo.initFormExtendedDatetimepickers();

    var $table = $('#fresh-table'),
          $alertBtn = $('#alertBtn'),
          full_screen = false;

    $().ready(function () {
        $table.bootstrapTable({
            toolbar: ".toolbar",
            locale: 'pt-BR',
            showRefresh: true,
            search: true,
            showToggle: true,
            showColumns: true,
            pagination: true,
            striped: true,
            pageSize: 8,
            pageList: [8, 10, 25, 50, 100],

            formatShowingRows: function (pageFrom, pageTo, totalRows) {
                //do nothing here, we don't want to show the text "showing x of y from..."
            },
            formatRecordsPerPage: function (pageNumber) {
                return pageNumber;
            },
            icons: {
                refresh: 'fa fa-refresh',
                toggle: 'fa fa-th-list',
                columns: 'fa fa-columns',
                detailOpen: 'fa fa-plus-circle',
                detailClose: 'fa fa-minus-circle'
            }
        });

        $(window).resize(function () {
            $table.bootstrapTable('resetView');
        });

        $alertBtn.click(function () {
            alert("You pressed on Alert");
        });
    });
});
