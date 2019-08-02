! function (e) {
    "function" != typeof e.matches && (e.matches = e.msMatchesSelector || e.mozMatchesSelector || e.webkitMatchesSelector || function (e) {
        for (var t = this, o = (t.document || t.ownerDocument).querySelectorAll(e), n = 0; o[n] && o[n] !== t;) ++n;
        return Boolean(o[n])
    }),
    "function" != typeof e.closest && (e.closest = function (e) {
    for (var t = this; t && 1 === t.nodeType;) {
        if (t.matches(e)) return t;
        t = t.parentNode
    }
    return null
})
}(window.Element.prototype);

document.addEventListener('DOMContentLoaded', function() {

var modalButtons = document.querySelectorAll('.js-open-modal'),
    overlay      = document.querySelector('.js-overlay-modal'),
    closeButtons = document.querySelectorAll('.js-modal-close');

modalButtons.forEach(function(item){

    item.addEventListener('click', function(e) {

        e.preventDefault();

        var modalId = this.getAttribute('data-signin'),
            modalElem = document.querySelector('.login_window[data-signin="' + modalId + '"]'),
            modalCont = document.querySelector('.transform');
          
        modalElem.classList.add('active');
        modalCont.style.transform = 'translateY(0)';
        overlay.classList.add('active');
    }); // end click

}); // end foreach

closeButtons.forEach(function (item) {

    item.addEventListener('click', function (e) {
        var parentModal = this.closest('.login_window'),
            modalCont = document.querySelector('.transform');

        modalCont.style.transform = 'translateY(-150%)';
        parentModal.classList.remove('active');
        overlay.classList.remove('active');
    });

}); // end foreach

document.body.addEventListener('keyup', function (e) {
    var key = e.keyCode;

    if (key == 27) {

        document.querySelector('.login_window.active').classList.remove('active');
        document.querySelector('.overlay').classList.remove('active');
    };
}, false);


overlay.addEventListener('click', function() {
    document.querySelector('.login_window.active').classList.remove('active');
    this.classList.remove('active');
});




}); // end ready

function GetLiVal(event) {
    var target = event.target || event.srcElement;
    $("#hdd").val(event.target.innerHTML);
}

//players filter
$(document).ready(function () {
    $('.btn-filter').click(function(){
        if($('.btn-checked') != true){
            $('.btn-filter').removeClass('btn-checked');
            $(this).addClass('btn-checked');
        }
    });

// Get Distance time 

    $('.MatchTime').each(function (index, value) {
        show_timer($(value).data('start-time'), $(this));
    });

    $("#reset").click(function () {
        $("#added-data").html('');
    });

    $('#clear').click(function () {
        //alert("ddd");
        $('#team-table').find("tr:gt(0)").remove();
    })
});


function show_timer(time, elem) {
    let countDownDate = new Date(time).getTime();
    let x = setInterval(function () {

        // Get today's date and time or what time you want
        let now = new Date().getTime();

        // Find the distance between now and the count down date
        let distance = countDownDate - now;

        // Time calculations for days, hours, minutes and seconds
        let days = Math.floor(distance / (1000 * 60 * 60 * 24));
        let hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
        let minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
        let seconds = Math.floor((distance % (1000 * 60)) / 1000);

        // Output the result in an element with id="MatchTime"
        $(elem).html(days + "d " + hours + "h " + minutes + "m " + seconds + "s");

        // If the count down is over, write some text 
        if (distance < 0) {
            //$.ajax({
            //    type: "POST",
            //    url: 'Home/Delete',
            //    data: { id: id },
            //    dataType: "json",
            //    success: function () {
            //        setTimeout(function () { location.reload(); }, 1000);
            //    },
            //    error: function () {
            //        alert("Error while deleting data");
            //    }
            //});
            clearInterval(x);
            $(elem).html("EXPIRED");
        }
    }, 1000);
}


$("body").on("click", "#btnAdd", function () {
    //Reference the Name and Country TextBoxes.
    var txtName = $("#txtName");
    var txtCountry = $("#txtCountry");
    var baba = $("#dtOf");

    //Get the reference of the Table's TBODY element.
    var tBody = $("#tblCustomers > TBODY")[0];

    //Add Row.
    var row = tBody.insertRow(-1);

    //first team.
    var cell = $(row.insertCell(-1));
    cell.html(txtName.val());

    //date
    cell = $(row.insertCell(-1));
    cell.html(baba.val());

    //second Team.
    cell = $(row.insertCell(-1));
    cell.html(txtCountry.val());


    //Add Button cell.
    cell = $(row.insertCell(-1));
    var btnRemove = $("<input />");
    btnRemove.attr("Class", "btn custum_btn");
    btnRemove.attr("type", "button");
    btnRemove.attr("onclick", "Remove(this);");
    btnRemove.val("Remove");
    cell.append(btnRemove);

    //Clear the TextBoxes.
    txtName.val("");
    txtCountry.val("");
});

function Remove(button) {
    //Determine the reference of the Row using the Button.
    var row = $(button).closest("TR");
    var name = $("TD", row).eq(0).html();
    if (confirm("Do you want to delete: " + name)) {
        //Get the reference of the Table.
        var table = $("#tblCustomers")[0];

        //Delete the Table row using it's Index.
        table.deleteRow(row[0].rowIndex);
    }
};


$("body").on("click", "#btnSave", function () {
    //Loop through the Table rows and build a JSON array.
    var turNavModel = {};
    var tourModel = new Array();
    $("#tblCustomers TBODY TR").each(function () {
        var row = $(this);
        var Team = {};
        Team.Team_1 = row.find("TD").eq(0).html();
        Team.StartDate = row.find("TD").eq(1).html();
        Team.Team_2 = row.find("TD").eq(2).html();
        tourModel.push(Team);
    });

    var objtur = {};
    objtur.Title = $("#title").val();
    objtur.Price = $("#balance").val(); 
    objtur.Balance = $("#price").val();
    turNavModel = {
        TourModel: tourModel,
        TourHeader: objtur


    }
    //Send the JSON array to Controller using AJAX.
    alert(JSON.stringify(turNavModel));
    $.ajax({
        type: "POST",
        url: "/api/AddTournament/AddTour",
        data: JSON.stringify(turNavModel),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (r) {
            alert(" inserted!!!!");
        }
    });
});

$(".add_player").click(function () {
    var icon = $(this).next(".icon");
    $(this).toggleClass("add_player_active");
    $(this).children(icon).toggleClass("fa-plus");
    $(this).children(icon).toggleClass("fa-check");

    let member = $(this).closest('.one').find('.player_name p').html();
    let position = $(this).closest('.one').find('.shirt span').html();

    if ($(this).hasClass('add_player_active')) {
        let html = '<tr class="pl-teams2" data-id="' + member + '"><td>' + member + '</td><td>' + position + '</td></tr >';
        $('#team-table').append(html);
    } else {
        $('*[data-id="' + member + '"]').remove();
    }

});

$(document).ready(function () {
    $(".autocomplate-data").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/Home/Autocomplete",
                type: "POST",
                dataType: "json",
                data: { Prefix: request.term },
                success: function (data) {
                    response($.map(data, function (item) {
                        return { label: item.teamName, value: item.teamName };
                    }))
                }
            })
        },
        messages: {
            noResults: "", results: ""
        }
    });
});

$(document).ready(function () {
    $("#add_team_db").click(function () {
        var player = new Array();
        $("#team-table TBODY tr").each(function () {
            var row = $(this);
            var Team = {};
            Team.FootballPlayer = row.find("td").eq(0).html();
            player.push(Team);
        });
        alert(JSON.stringify(player));
        $.ajax({
            type: "POST",
            url: "/Home/AddPlayers",
            data: JSON.stringify(player),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (r) {
                alert(r);
            }
        });
    });   
});