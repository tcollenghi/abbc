$(document).ready(function () {
    //Add class no menu
    $('#matend').addClass("active");
    //Remove class no menu
    $('#mdash').removeClass("active");
    $('#mrelat').removeClass("active");
    $('#mgraf').removeClass("active");
    $('#unid').removeClass("active");
    $('#mailb').removeClass("active");
    
    demo.initMaterialWizard();
    demo.initFullCalendar();

    var events = [];
    var selectedEvent = null;
    FetchEventAndRenderCalendar();

});

function FetchEventAndRenderCalendar() {
            events = [];
            $.ajax({
                type: "GET",
                url: "/Reservas/GetEvents",
                success: function (data) {
                    $.each(data, function (i, v) {
                        var ast = "";
                        if (v.tipo == "chale") {
                            ast = "event-green";
                        } else {
                            ast = "event-azure";
                        }
                        events.push({
                            eventID: v.id,
                            title: v.nome,
                            description: v.responsavel,
                            start: moment(v.entrada),
                            end: v.saida != null ? moment(v.saida) : null,
                            className: ast,
                            allDay: false
                        });
                    })

                    GenerateCalender(events);
                },
                error: function (error) {
                    alert('Erro ao carregar o Calendario!');
                }
            })
}

function GenerateCalender(events) {

    $('#fullCalendar').fullCalendar('destroy');

    $calendar = $('#fullCalendar');

    today = new Date();
    y = today.getFullYear();
    m = today.getMonth();
    d = today.getDate();

    $calendar.fullCalendar({
        viewRender: function (view, element) {
            // We make sure that we activate the perfect scrollbar when the view isn't on Month
            if (view.name != 'month') {
                $(element).find('.fc-scroller').perfectScrollbar();
            }
        },
        locale: 'pt-br',
        header: {
            left: 'title',
            center: 'month,agendaWeek,agendaDay',
            right: 'prev,next,today'
        },
        defaultDate: today,
        selectable: true,
        selectHelper: true,
        views: {
            month: { // name of view
                titleFormat: 'MMMM YYYY'
                // other view-specific options here
            },
            week: {
                titleFormat: " MMMM D YYYY"
            },
            day: {
                titleFormat: 'D MMM, YYYY'
            }
        },

                eventClick: function (calEvent, jsEvent, view) {
                    selectedEvent = calEvent;
                    var $description = $('<div/>');
                    $description.append($('<p/>').html('<b>Unidade: </b>' + calEvent.title));
                    $description.append($('<p/>').html('<b>Entrada: </b>' + calEvent.start.format("DD/MM/YYYY")));
                    if (calEvent.end != null) {
                        $description.append($('<p/>').html('<b>Saída: </b>' + calEvent.end.format("DD/MM/YYYY")));
                    }
                    $description.append($('<p/>').html('<b>Responsável: </b>' + calEvent.description));
                    
                    //swal({
                    //    title: 'Detalhes',
                    //    html: $description,
                    //    confirmButtonClass: 'btn btn-info',
                    //    buttonsStyling: false
                    //});

                    var tb = '';
                    tb += '<div class="form-group">';
                    tb += '<div class="form-group">';
                    tb += '<h5 class="col-lg-2">Unidade:</h5>';
                    tb += '         <div class="col-lg-4">';
                    tb += '<input name="unidade" id="unidade" value="' + calEvent.title + '" class="form-control border-input">';
                    tb += '         </div>';
                    tb += '     </div>';
                    tb += '<div class="form-group">';
                    tb += '<h5 class="col-lg-2">Entrada:</h5>';
                    tb += '         <div class="col-lg-4">';
                    tb += '<input name="entrada" id="entrada" value="' + calEvent.start.format("DD/MM/YYYY") + '" class="form-control border-input">';
                    tb += '         </div>';
                    tb += '<h5 class="col-lg-2">Saída:</h5>';
                    tb += '         <div class="col-lg-4">';
                    tb += '<input name="saida" id="saida" value="' + calEvent.end.format("DD/MM/YYYY") + '" class="form-control border-input">';
                    tb += '         </div>';
                    tb += '     </div>';
                    tb += '<div class="form-group">';
                    tb += '<h5 class="col-lg-3">Responsável:</h5>';
                    tb += '         <div class="col-lg-8">';
                    tb += '<input name="responsavel" id="responsavel" value="' + calEvent.description + '" class="form-control border-input">';
                    tb += '         </div>';
                    tb += '         </div>';
                    tb += '<div class="checkbox-radios">';
                    tb += '<div class="radio">';
                    tb += '<label><input type="radio" value="CheckIn" name="optionsRadios"> Check-In</label>';
                    tb += '</div>';
                    tb += '<div class="radio">';
                    tb += '<label><input type="radio" value="ChekOut" name="optionsRadios"> Chek-Out</label>';
                    tb += '</div>';
                    tb += '</div>';
                    tb += '<div class="form-group">';
                    tb += '         <label class="col-lg-2 control-label">Existe valor a pagar ?</label>';
                    tb += '         <div class="col-lg-4">';
                    tb += '             <input type="number" name="apagar" id="apagar" class="form-control border-input" placeholder="A Pagar">';
                    tb += '         </div>';
                    tb += '         <div class="col-lg-6">';
                    tb += '            <input name="observacao" id="observacao" class="form-control border-input" placeholder="Observação">';
                    tb += '         </div>';
                    tb += '     </div>';
                    tb += '</div>';

                    $('#tb').html(tb);
                    $("#myModal").modal("show");

                },

        //select: function (start, end) {

        //    // on select we show the Sweet Alert modal with an input
        //    swal({
        //        title: 'Create an Event',
        //        html: '<div class="form-group">' +
        //            '<input class="form-control" placeholder="Event Title" id="input-field">' +
        //            '</div>',
        //        showCancelButton: true,
        //        confirmButtonClass: 'btn btn-success',
        //        cancelButtonClass: 'btn btn-danger',
        //        buttonsStyling: false
        //    }).then(function (result) {

        //        var eventData;
        //        event_title = $('#input-field').val();

        //        if (event_title) {
        //            eventData = {
        //                title: event_title,
        //                start: start,
        //                end: end
        //            };
        //            $calendar.fullCalendar('renderEvent', eventData, true); // stick? = true
        //        }

        //        $calendar.fullCalendar('unselect');

        //    });
        //},

        // color classes: [ event-blue | event-azure | event-green | event-orange | event-red ]
        events: events,
        editable: true,
        eventLimit: true, // allow "more" link when too many events
    });
}