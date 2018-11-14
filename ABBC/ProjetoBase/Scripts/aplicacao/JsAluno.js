$(document).ready(function () {

    //Add class no menu
    $('#maluno').addClass("active");
    //Remove class no menu
    $('#mdash').removeClass("active");
    $('#mrelat').removeClass("active");
    $('#mgraf').removeClass("active");
    $('#matend').removeClass("active");
    $('#mailb').removeClass("active");
    $('#mplanoPag').removeClass("active");
    $('#mfuncionario').removeClass("active");
    

    //$('.summernote').summernote();

    //$('#myModal').on('shown.bs.modal', function () {
    //    $('#myInput').focus()
    //});

    $(document).on("click", ".open-AddBookDialog", function () {
        //Pega o valor passado por paramtro
        var myBookId = $(this).data('id');
        //var myBookNome = $(this).data('nome');
        //var myBookEmail = $(this).data('email');
        //var myBookTelefone = $(this).data('telefone');
        //var myBookNomeContratante = $(this).data('nomecontratante');
        //var myBookTelefoneContrante = $(this).data('telefonecontrante');
        //var myBookVencimento = $(this).data('vencimento');

        //var myBookCpf = $(this).data('cpf');
        //var myBookHorarioAula = $(this).data('horarioaula');
        //var myBookDiasDaSemana = $(this).data('diasdasemana');
        //var myBookInicioAulas = $(this).data('inicioaulas');
        //var myBookLocalDoCurso = $(this).data('localdocurso');



        GetFoodDetails(myBookId);


        //var tbody = "";
        //tbody += "  <div href='#' class='list-group'>";
        //tbody += "   <a  class='list-group-item'>";
        //tbody += "       <h4 class='list-group-item-heading'>Dados do Contrato</h4>";
        //tbody += "       <p class='list-group-item-text'>";
        //tbody += "           <strong>Nome:</strong> " + myBookNome;
        //tbody += "       </p>";
        //tbody += "       <p class='list-group-item-text'>";
        //tbody += "           <strong>E-mail:</strong> " + myBookEmail;
        //tbody += "       </p>";
        //tbody += "       <p class='list-group-item-text'>";
        //tbody += "           <strong>Telefone:</strong> " + myBookTelefone;
        //tbody += "       </p>";
        //tbody += "       <p class='list-group-item-text'>";
        //tbody += "           <strong>Contratante:</strong> " + myBookNomeContratante;
        //tbody += "       </p>";
        //tbody += "       <p class='list-group-item-text'>";
        //tbody += "           <strong>Telefone Contratante:</strong> " + myBookTelefoneContrante;
        //tbody += "       </p>";
        //tbody += "       <p class='list-group-item-text'>";
        //tbody += "           <strong>Cpf:</strong> " + myBookCpf;
        //tbody += "       </p>";
        //tbody += "       <p class='list-group-item-text'>";
        //tbody += "           <strong>Vencimento:</strong> " + myBookVencimento;
        //tbody += "       </p>";
        //tbody += "   </a>";
        //tbody += "   <a href='/Aluno/AlunoLinqCursoTurma?aluno=" + myBookId + "' class='list-group-item'>";
        //tbody += "       <h4 class='list-group-item-heading'>Dados do Curso</h4>";
        //tbody += "       <p class='list-group-item-text'>";
        //tbody += "           <strong>Início das aulas:</strong> " + myBookInicioAulas;
        //tbody += "       </p>";
        //tbody += "       <p class='list-group-item-text'>";
        //tbody += "           <strong>Horário aula:</strong> " + myBookHorarioAula;
        //tbody += "       </p>";
        //tbody += "       <p class='list-group-item-text'>";
        //tbody += "           <strong>Dias da semana:</strong> " + myBookDiasDaSemana;
        //tbody += "       </p>";
        //tbody += "       <p class='list-group-item-text'>";
        //tbody += "           <strong>Local do curso:</strong> " + myBookLocalDoCurso;
        //tbody += "       </p>";
        //tbody += "   </a> ";
        //tbody += " </div>";

        ////Chama o Modal
        //$('#myModalContent').html(tbody);
        //$('#myModal').modal('show');
    });

});

function GetFoodDetails(x) {
    var Id = x;
    debugger;
    $.ajax({
        type: "GET",
        url: "Aluno/getAlunoDetails",
        data: { userId: Id },
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            $.each(result, function (index, item) {
                var tbody = "";
                tbody += "  <div href='#' class='list-group'>";
                tbody += "   <a  class='list-group-item'>";
                tbody += "       <h4 class='list-group-item-heading'>Dados do Contrato</h4>";
                tbody += "       <p class='list-group-item-text'>";
                tbody += "           <strong>Nome:</strong> " + item[0].Nome;
                tbody += "       </p>";
                tbody += "       <p class='list-group-item-text'>";
                tbody += "           <strong>E-mail:</strong> " + item[0].Email;
                tbody += "       </p>";
                tbody += "       <p class='list-group-item-text'>";
                tbody += "           <strong>Telefone:</strong> " + item[0].Telefone;
                tbody += "       </p>";
                tbody += "       <p class='list-group-item-text'>";
                tbody += "           <strong>Contratante:</strong> " + item[0].Contratante;
                tbody += "       </p>";
                tbody += "       <p class='list-group-item-text'>";
                tbody += "           <strong>Telefone Contratante:</strong> " + item[0].TelefoneContratante;
                tbody += "       </p>";
                tbody += "       <p class='list-group-item-text'>";
                tbody += "           <strong>Cpf:</strong> " + item[0].Cpf;
                tbody += "       </p>";
                tbody += "       <p class='list-group-item-text'>";
                tbody += "           <strong>Vencimento:</strong> " + item[0].VencimentoParcela;
                tbody += "       </p>";
                tbody += "   </a>";
                tbody += "   <a href='/Aluno/AlunoLinqCursoTurma?aluno=" + item[0].ID + "' class='list-group-item'>";
                tbody += "       <h4 class='list-group-item-heading'>Dados do Curso</h4>";
                tbody += "       <p class='list-group-item-text'>";
                tbody += "           <h4 class='text-danger'>Clique para ver os dados...</h4> "
                tbody += "       </p>";
                //tbody += "       <p class='list-group-item-text'>";
                //tbody += "           <strong>Turma:</strong> " + item[0].Turma;
                //tbody += "       </p>";
                //tbody += "       <p class='list-group-item-text'>";
                //tbody += "           <strong>Plano de Pagamento:</strong> " + item[0].PlanoPagamento;
                //tbody += "       </p>";
                //tbody += "       <p class='list-group-item-text'>";
                //tbody += "           <strong>Local do curso:</strong> " + item[0].LocalCurso;
                //tbody += "       </p>";
                tbody += "   </a> ";
                tbody += " </div>";

                //Chama o Modal
                $('#myModalContent').html(tbody);
                $('#myModal').modal('show');
            });
        },
        error: function (response) {
            debugger;
            alert('eror');
        }
    });

}

function chamaAjax(id) {
    /*POST*/
    $.ajax({
        url: '/Aluno/DeleteAluno',
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