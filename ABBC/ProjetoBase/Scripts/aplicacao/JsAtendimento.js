$(document).ready(function () {

    //Add class no menu
    $('#matend').addClass("active");
    //Remove class no menu
    $('#mdash').removeClass("active");
    $('#mrelat').removeClass("active");
    $('#mgraf').removeClass("active");

    demo.initMaterialWizard();
    demo.initFormExtendedDatetimepickers();

    var $table = $('#fresh-table'),
          $alertBtn = $('#alertBtn'),
          full_screen = false;

    $().ready(function () {
        $table.bootstrapTable({
            toolbar: ".toolbar",
            locale:'pt-BR',
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

function onValidadeTipoAtendimento()
{
    //Tipo de Atendimento
    var str = $("#selectAtendimento").val();

    //2 - manifestação
    if (str == 2) {

        //Produto
        var selectProdutoCliente = $("#selectProdutoCliente").val();
        if (selectProdutoCliente == null || selectProdutoCliente == undefined) {
            $("#selectProdutoCliente").addClass("required");
        } else {
            $("#selectProdutoCliente").removeClass("required");
        }
        //Em tratamento pela área
        var selecSetorUnico = $("#selecSetorUnico").val();
        if (selecSetorUnico == null || selecSetorUnico == undefined) {
            $("#selecSetorUnico").addClass("required");
        } else {
            $("#selecSetorUnico").removeClass("required");
        }
        //Tratado por
        var selectTratadoPor = $("#selectTratadoPor").val();
        if (selectTratadoPor == null || selectTratadoPor == undefined) {
            $("#selectTratadoPor").addClass("required");
        } else {
            $("#selectTratadoPor").removeClass("required");
        }
        //Causa Origem
        var selectCausaOrigem = $("#selectCausaOrigem").val();
        if (selectCausaOrigem == null || selectCausaOrigem == undefined) {
            $("#selectCausaOrigem").addClass("required");
        } else {
            $("#selectCausaOrigem").removeClass("required");
        }
        //Categoria
        var selectCategorias = $("#selectCategorias").val();
        if (selectCategorias == null || selectCategorias == undefined) {
            $("#selectCategorias").addClass("required");
        } else {
            $("#selectCategorias").removeClass("required");
        }
        //Classificação
        var selectClassificacao = $("#selectClassificacao").val();
        if (selectClassificacao == null || selectClassificacao == undefined) {
            $("#selectClassificacao").addClass("required");
        } else {
            $("#selectClassificacao").removeClass("required");
        }
        //O atendimento gerou N2?
        var selectGerouN2 = $("#selectGerouN2").val();
        if (selectGerouN2 == null || selectGerouN2 == undefined) {
            $("#selectGerouN2").addClass("required");
        } else {
            $("#selectGerouN2").removeClass("required");
        }
        //Resumo da Manifestação do Contratante
        var txaResumoManifestacao = $("#txaResumoManifestacao").val();
        if (txaResumoManifestacao == null || txaResumoManifestacao == undefined || txaResumoManifestacao == "") {
            $("#txaResumoManifestacao").addClass("required");
        } else {
            $("#txaResumoManifestacao").removeClass("required");
        }
        //Resumo da Análise SOLLO
        var txaResumoAnaliseSollo = $("#txaResumoAnaliseSollo").val();
        if (txaResumoAnaliseSollo == null || txaResumoAnaliseSollo == undefined || txaResumoAnaliseSollo == "") {
            $("#txaResumoAnaliseSollo").addClass("required");
        } else {
            $("#txaResumoAnaliseSollo").removeClass("required");
        }
        //Ações Realizadas
        var txaAcoesRealizadas = $("#txaAcoesRealizadas").val();
        if (txaAcoesRealizadas == null || txaAcoesRealizadas == undefined || txaAcoesRealizadas == "") {
            $("#txaAcoesRealizadas").addClass("required");
        } else {
            $("#txaAcoesRealizadas").removeClass("required");
        }
        
       //Demanda-Preventiva 
    } else {

        //Produto
        var selectProdutoCliente = $("#selectProdutoCliente").val();
        if (selectProdutoCliente == null || selectProdutoCliente == undefined) {
            $("#selectProdutoCliente").addClass("required");
        } else {
            $("#selectProdutoCliente").removeClass("required");
        }
        //Em tratamento pela área
        var selecSetorUnico = $("#selecSetorUnico").val();
        if (selecSetorUnico == null || selecSetorUnico == undefined) {
            $("#selecSetorUnico").addClass("required");
        } else {
            $("#selecSetorUnico").removeClass("required");
        }
        //Tratado por
        var selectTratadoPor = $("#selectTratadoPor").val();
        if (selectTratadoPor == null || selectTratadoPor == undefined) {
            $("#selectTratadoPor").addClass("required");
        } else {
            $("#selectTratadoPor").removeClass("required");
        }
        //Categoria
        var selectCategorias = $("#selectCategorias").val();
        if (selectCategorias == null || selectCategorias == undefined) {
            $("#selectCategorias").addClass("required");
        } else {
            $("#selectCategorias").removeClass("required");
        }
        //O atendimento gerou N2?
        var selectGerouN2 = $("#selectGerouN2").val();
        if (selectGerouN2 == null || selectGerouN2 == undefined) {
            $("#selectGerouN2").addClass("required");
        } else {
            $("#selectGerouN2").removeClass("required");
        }
        //Ações Realizadas
        var txaAcoesRealizadas = $("#txaAcoesRealizadas").val();
        if (txaAcoesRealizadas == null || txaAcoesRealizadas == undefined || txaAcoesRealizadas == "") {
            $("#txaAcoesRealizadas").addClass("required");
        } else {
            $("#txaAcoesRealizadas").removeClass("required");
        }

        //campos obrigatórios apenas para Manifestação
        $("#selectCausaOrigem").removeClass("required");
        $("#txaResumoManifestacao").removeClass("required");
        $("#txaResumoAnaliseSollo").removeClass("required");

       escondeLabels();
   }
}

function escondeLabels()
{
    var theControlVA = document.getElementById("valorAproximado");
    theControlVA.style.display = "none";
    var BLVA = document.getElementById("lbVA");
    BLVA.style.display = "none";

    var theControlNi = document.getElementById("NumeroIdentificacao");
    theControlNi.style.display = "none";
    var BLNi = document.getElementById("lbNI");
    BLNi.style.display = "none";

    var theControlJus = document.getElementById("Justificativa");
    theControlJus.style.display = "none";
    var BLJus = document.getElementById("lbJu");
    BLJus.style.display = "none";

    var theControlJus = document.getElementById("GerouPPP");
    theControlJus.style.display = "none";
    var BLJus = document.getElementById("lbgPPP");
    BLJus.style.display = "none";

    function validaNumeroIdentificacao() {
        var theControlNi = document.getElementById("NumeroIdentificacao");
        theControlNi.style.display = "block";

        var BLNi = document.getElementById("lbNI");
        BLNi.style.display = "block";
    }

    function validaValorAproximado() {
        var theControlVA = document.getElementById("valorAproximado");
        theControlVA.style.display = "block";
        var BLVA = document.getElementById("lbVA");
        BLVA.style.display = "block";
    }

    function validaJustificativa() {
        var theControlJus = document.getElementById("Justificativa");
        theControlJus.style.display = "block";
        var BLJus = document.getElementById("lbJu");
        BLJus.style.display = "block";
    }

    function validaGerouPPP() {
        var theControlJus = document.getElementById("GerouPPP");
        theControlJus.style.display = "block";
        var BLJus = document.getElementById("lbgPPP");
        BLJus.style.display = "block";
    }
}

//function onValidade() {
//    $("#selectAtendimento").change(function () {
//        var str = "";
//        $("select option:selected").each(function () {
//            str += $(this).text() + " ";
//        });
//        alert(str);
//    })
//}