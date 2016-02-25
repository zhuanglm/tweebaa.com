$(document).ready(
   function () {
       loadCurrentUser();

       $("#save-personal").click(savePersonal);
   }
);

function loadCurrentUser() {
    var _data = "{ action:'query'}";
    $.ajax({
        type: "POST",
        url: '../AjaxPages/homePersonalData.aspx',
        dataType: "json",
        data: _data,
        success: function (resu) {
            if (resu == "-1") {
                alert("You are not logged in!");
                return;
            }

            $("#user-name").text(resu.username);
            $("#radiolist label").removeClass("hRadio_Checked");
            if (resu.gender == 1) {
                $("#gender-man").addClass("hRadio_Checked");
            } else if (resu.gender == 2) {
                $("#gender-woman").addClass("hRadio_Checked");
            } else {
                $("#gender-secret").addClass("hRadio_Checked");
            }
            if (resu.birthday) {
                var birthday = new Date(parseInt(resu.birthday.replace("/Date(", "").replace(")/", "")));
                var month = (birthday.getMonth() + 1).toString();
                var date = birthday.getDate().toString();
                var fullYear = birthday.getFullYear().toString();
                $("#birthday-month").val(month)
                $("#birthday-month").next("div").text(month);
                $("#birthday-date").val(date);
                $("#birthday-date").next("div").text(date);
                $("#birthday-year").val(fullYear);
                $("#birthday-year").next("div").text(fullYear);
            }
            if (resu.jobid) {
                $("#job").val(resu.jobid.toString());
                $("#job").next("div").text($("#job option:selected").text());
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("status:" + XMLHttpRequest.status);
            alert("readyState:" + XMLHttpRequest.readyState);
            alert("textStatus:" + textStatus);

            alert("Failed to load data!");
        }
    });
};

function savePersonal() {
    var gender = 1;
    if ($("#gender-woman").hasClass("hRadio_Checked")) {
        gender = 2;
    } else if ($("#gender-secret").hasClass("hRadio_Checked")) {
        gender = 3;
    }
    var month = $("#birthday-month").val();
    var date = $("#birthday-date").val();
    var year = $("#birthday-year").val();
    var jobid = $("#job").val();

    var _data = "{ action:'save', gender:" + gender + ", month:"
        + month + ",date:" + date + ",year:" + year + ",jobid:"
        + jobid + "}";
    $.ajax({
        type: "POST",
        url: '../AjaxPages/homePersonalData.aspx',
        dataType: "json",
        data: _data,
        success: function (resu) {
            if (resu == "-1") {
                alert("please login first！");
                window.top.location.href = "../User/login.aspx";
                return;
            }
            if (resu == "1") {
                alert("Saved successfully!");
            } else {
                alert("save fail！");
            }

        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("save fail！");
        }
    });
}