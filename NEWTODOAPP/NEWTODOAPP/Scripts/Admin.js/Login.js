function Login() {
    let Email = $("#txtEmail").val();
    let Password = $("#txtpassword").val();

    var url = "/Admin/Login";
    var data = JSON.stringify({
        "Email": Email,
        "Password": Password
    });
    $.ajax({
        type: "POST",
        data: data,
        url: url,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result != "Login Failed")
                window.location.href = "/Home";
        },
        error: function (error) {
            alert(error);
        },
    });

}
       