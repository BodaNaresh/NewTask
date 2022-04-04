
function Register() {
    let UserName = $("#txtName").val();
    let Email = $("#txtEmail").val();
    let Gender = "";
    if ($("#RadioMale").prop("checked") == true) {
        Gender = "Male";
    }
    else {
        Gender = "Female";
    }
    let Mobile = $("#txtMobile").val();

    let Location = $("#txtLocation").val();

    let Password = $("#txtPassword").val();
    

    var url = "/Admin/Register";
    var data = JSON.stringify({
        "UserName": UserName,
        "Email": Email,
        "Gender": Gender,
        "Mobile": Mobile,
        "Location": Location,
        "Password": Password
        
    });
    $.ajax({
        type: "POST",
        data: data,
        url: url,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            clear();
            alert(result);
        },
        error: function (error) {
            alert(error);
        },
    });

    function clear() {
        $("#txtName").val('');
        $("#txtEmail").val('');
        ($("#RadioMale").prop("checked", false));
        ($("#RadioFeMale").prop("checked", false));
        $("#txtMobile").val('');
        $("#txtpassword").val('');
    }
}