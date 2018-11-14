$(document).ready(function () {

    //Add class no menu
    $('#maluno').addClass("active");
    //Remove class no menu
    $('#mdash').removeClass("active");
    $('#mrelat').removeClass("active");
    $('#mgraf').removeClass("active");
    $('#unid').removeClass("active");
    $('#mplanoPag').removeClass("active");
    $('#mfuncionario').removeClass("active");

    demo.initMaterialWizard();
    demo.initFormExtendedDatetimepickers();
    
    $("#email").emailautocomplete({
        domains: [
            "itsolutionstuff.com",
            "gmail.com",
            "yahoo.com",
            "hotmail.com",
            "live.com",
            "facebook.com",
            "outlook.com",
            "gmx.com",
            "me.com",
            "laravel.com",
            "aol.com"]
    });


    //Quando o campo cep perde o foco.
    $("#cep").blur(function () {


        //Nova variável "cep" somente com dígitos.
        var cep = $(this).val().replace(/\D/g, '');

        //Verifica se campo cep possui valor informado.
        if (cep != "") {

            //Expressão regular para validar o CEP.
            var validacep = /^[0-9]{8}$/;

            //Valida o formato do CEP.
            if (validacep.test(cep)) {

                //Preenche os campos com "..." enquanto consulta webservice.
                $("#rua").val("...");
                $("#bairro").val("...");
                $("#cidade").val("...");
                $("#uf").val("...");
                $("#ibge").val("...");

                //Consulta o webservice viacep.com.br/
                $.getJSON("https://viacep.com.br/ws/" + cep + "/json/?callback=?", function (dados) {

                    if (!("erro" in dados)) {
                        //Atualiza os campos com os valores da consulta.
                        $("#rua").val(dados.logradouro);
                        $("#bairro").val(dados.bairro);
                        $("#cidade").val(dados.localidade);
                        $("#uf").val(dados.uf);
                        $("#ibge").val(dados.ibge);
                    } //end if.
                    else {
                        //CEP pesquisado não foi encontrado.
                        limpa_formulário_cep();
                        alert("CEP não encontrado.");
                    }
                });
            } //end if.
            else {
                //cep é inválido.
                limpa_formulário_cep();
                alert("Formato de CEP inválido.");
            }
        } //end if.
        else {
            //cep sem valor, limpa formulário.
            limpa_formulário_cep();
        }
    });
});

