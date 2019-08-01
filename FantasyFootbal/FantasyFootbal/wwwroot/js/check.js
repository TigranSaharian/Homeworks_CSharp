 var check = function () {
     var p = document.getElementById("reg_password").value;
     var cp = document.getElementById("confirm_password").value;
     var msg = document.getElementById("message");
         if (p == cp && p != '' && cp != ''){  // && = и
             msg.style.color = '#F7FF00';
             msg.innerHTML = '* Nice! text is matching';
         }

         else if (p != cp && cp != '') {
             msg.style.color = 'red';
             msg.innerHTML = '* Your text does not match';
         }

         else{
             msg.innerHTML = '';
         }

    var lenght_msg = document.getElementById('lenght_msg');

    if(p.length >= 10){
        lenght_msg.innerHTML = '';
        lenght_msg.style.color = '#F7FF00';
        lenght_msg.innerHTML = '* The length of password is correct!';
     }
     else{
         lenght_msg.style.color = 'darkgray';
         lenght_msg.innerHTML = '* Your password must be at least 8 characters long';
     }
 }

$(function () {
    $('#bolola').click(function (e) {
        var table = $("#team-table");
        $.ajax({
            //url: "/api/TeamTest/GetData",
            url: "/Home/FillAutocomplete",
            type: "GET",
            data: JSON.stringify(table),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            error: function (response) {
                alert(response.responseText);
            },
            success: function (data1) {
                $("#team-table > TBODY ").html('');
                for (var i = 0; i < data1.length; i++) {
                    $("#team-table").append("<tr><td>" + data1[i].name + "</td><td>" + data1[i].position + "</td></tr>");              
                }    
            }               
        });

    });
});