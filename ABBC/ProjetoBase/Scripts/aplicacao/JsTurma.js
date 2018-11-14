$(document).ready(function () {

    //Add class no menu
    $('#mturma').addClass("active");
    //Remove class no menu
    $('#mdash').removeClass("active");
    $('#mrelat').removeClass("active");
    $('#mgraf').removeClass("active");
    $('#matend').removeClass("active");
    $('#mailb').removeClass("active");
    $('#maluno').removeClass("active");
    $('#mcurso').removeClass("active");
    $('#mplanoPag').removeClass("active");
    $('#mfuncionario').removeClass("active");

});

function chamaAjax(id) {
    /*POST*/
    $.ajax({
        url: '/Turma/DeleteTurma',
        dataType: "json",
        type: "POST",
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify({ ID: id }),
        async: true,
        processData: false,
        cache: false,
        success: function (data) {
            window.location.reload();
        },
        error: function (xhr) {
            //alert('error');
        }
    });
}

