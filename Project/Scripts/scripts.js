function validation(form) {
    if (form == "login") {
        //login get var
        var logemail = document.getElementById("Email").value;
        var logpassword = document.getElementById("Password").value;
        //login
        if (logemail && logpassword) {
            if ($("#loginform .Error").text() != "") {
                $("#loginform .Error").remove();
            }
            return true;
            /*
            $.ajax({
                type: "Post",
                url: '/Default',
                data: { email: logemail.text },
                datatype: "json",
                success: function (e) {
                    alert(e);
                },
                error: function () {
                    if ($("#loginform .CError").val() == null) {
                        $("#loginform").append("<div class='CError'>Error from ajax C#</div>");
                        return false;
                    }
                }
            })*/
        } else if ($("#loginform .Error").text() == "") {
            $("#loginform").append("<div class='Error'>Empty Fields!</div>");
        }
        return false;
    }
    if (form == "reg") {
        //register get var
        var email = document.getElementById("regEmail").value;
        var username = document.getElementById("regUsername").value;
        var fullname = document.getElementById("regFullname").value;
        var password = document.getElementById("regPassword").value;
        //register

        if ($("#regform .Error").val() == null) {
            $("#regform").append("<div class='Error'>Empty Fields for reg!</div>");
            return false;
        }
    }
    return false;
}
