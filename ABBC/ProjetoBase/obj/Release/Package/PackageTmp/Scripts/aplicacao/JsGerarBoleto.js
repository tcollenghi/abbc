$(document).ready(function () {

    //Add class no menu
    $('#mcurso').addClass("active");
    //Remove class no menu
    $('#mdash').removeClass("active");
    $('#mrelat').removeClass("active");
    $('#mgraf').removeClass("active");
    $('#matend').removeClass("active");
    $('#mailb').removeClass("active");
    $('#maluno').removeClass("active");
    $('#mplanoPag').removeClass("active");
    $('#mfuncionario').removeClass("active");
    
});

function gera34()
{
    var datas = {
        "email": "cleytoncorrea86@gmail.com",
        "due_date": "2018-11-20",
        "items": [
            {
                "description": "Curso",
                "quantity": 1,
                "price_cents": 19300
            }
        ],
        "payer": {
            "cpf_cnpj": "11296118762",
            "name": "cleyton c",
            "address": {
                "zip_code": "29043060",
                "number": "190"
            }
        }
    };

    var username = "6443ac0510d1f4aa8c6ca1326aec3a8d";
    var password = "";

    $.ajax({
        method: 'POST',
        //url: 'https://api.iugu.com/v1/invoices/',
        url: 'https://api.iugu.com/v1/invoices?api_token=6443ac0510d1f4aa8c6ca1326aec3a8d',
        headers: {
            "content-type": "application/json",
            "cache-control": "no-cache",
            "Accept": "application/json",
            "Access-Control-Allow-Origin": "*",
            "Access-Control-Allow-Methods": "POST",
            "User-Agent": "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/70.0.3538.77 Safari/537.36",
            "Authorization": "Basic " + btoa(username + ":" + password)
        },
        dataType: 'json',
        crossDomain: true,
        crossOrigin: false,
        async: true,
        data: datas,
        success: function (data) {
            console.log('succes: ' + data);
        }
    });

}

