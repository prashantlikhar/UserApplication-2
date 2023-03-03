var uiUserId = "#txtUserId";
var errorMessageid = "#errorMessage";
var otpExistId = "#otpExist";
var txtOtpId = "#txtOtp";
var timeId = "#time";
var counter = 30;
var baseUrl = "http://localhost:9266";
$(document).ready(function () {
    $(uiUserId).keypress(function (e) {
        var charCode = (e.which) ? e.which : event.keyCode
        if (String.fromCharCode(charCode).match(/[^0-9]/g))
            return false;
    });
});


function GetOtp() {
    $(errorMessageid).text("");
    $(errorMessageid).attr("style", "display:none");
    $(otpExistId).text("")
    var userIdEle = $(uiUserId);
    if (userIdEle != undefined) {
        var userId = userIdEle.val();
        if (userId === "") {
            $(errorMessageid).attr("style", "display:inline ; color:red");
            $(errorMessageid).text("User Id shouuld not be blank");
        }
        else if (userId >= 999999999) {
            $(errorMessageid).attr("style", "display:inline ; color:red");
            $(errorMessageid).text("User Id shouuld not be greater than 9 digit");
        }        
        else {
            CheckOtpExist(userId);
        }
    }
}

function CheckOtpExist(userId) {
    $.ajax({
        type: "GET",
        cache: false,
        url: baseUrl + "/user/IsOtpAlreadyGenrated",
        data: { userId: userId },        
        dataType: "json",
        async :false,
        success: function (result) {
            if (result.isErrorMessage === false && result.isExist === false) {
                counter = 0;                
                GetOtpFromService(userId)
            }
            else if (result.isErrorMessage === false && result.isExist === true)
            {
                $(otpExistId).text("OTP already exists for the user");
            }
            else {
                SetError(result.errorMessage);
            }
        },
        error: function (result) {
            redirectToErrorPageWithJSONCheck(result, "CheckOtpExist");
        }
    });
}
function SetError(message) {
    $(txtOtpId).val("");
    $(errorMessageid).attr("style", "display:inline ; color:red");
    $(errorMessageid).text(message);
}
function GetOtpFromService(userId) {
    $.ajax({
        type: "GET",
        cache: false,
        url: baseUrl + "/user/GetOtp",
        data: { userId: userId },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (!result.isErrorMessage) {
                SetTimer();
                $(txtOtpId).val(result.otp);
            }
            else {
                SetError(result.errorMessage);
            }
        },
        error: function (result) {
            redirectToErrorPageWithJSONCheck(result, "GetOtp");
        }
    });
}
function SetTimer() {
    counter = 30;
    $(timeId).text(counter + " seconds");
    var interval = setInterval(function () {
        counter--;
        if (counter <= 0) {
            clearInterval(interval);
            $(timeId).text("");
            $(txtOtpId).val("");
            $(uiUserId).val("");
            $(otpExistId).text("");
            //Can call api which set OTP as null
        }
        else {
            $(timeId).text(counter + " seconds");
        }
    },1000);
}
