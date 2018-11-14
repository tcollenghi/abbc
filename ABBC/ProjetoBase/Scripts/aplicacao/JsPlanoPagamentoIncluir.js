$(document).ready(function () {

    //Add class no menu
    $('#mplanoPag').addClass("active");
    //Remove class no menu
    $('#mdash').removeClass("active");
    $('#mrelat').removeClass("active");
    $('#mgraf').removeClass("active");
    $('#matend').removeClass("active");
    $('#mailb').removeClass("active");
    $('#maluno').removeClass("active");
    $('#mcurso').removeClass("active");
    $('#mfuncionario').removeClass("active");

    demo.initMaterialWizard();
    demo.initFormExtendedDatetimepickers();

});
