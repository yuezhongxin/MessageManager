function getPassportHost() {
    var hostname = location.hostname;
    var suffix = hostname.substring(hostname.lastIndexOf("."));
    return 'http://passport.cnblogs' + suffix;
}

function login() {
    location.href = getPassportHost() + "/login.aspx?ReturnUrl=" + location.href;
    return false;
}

function login2(anchor) {
    var url = encodeURIComponent(location.href + "#" + anchor);
    location.href = getPassportHost() + "/login.aspx?ReturnUrl=" + url;
    return false;
}

function register() {
    location.href = getPassportHost() + "/register.aspx?ReturnUrl=" + location.href;
    return false;
}

function logout() {
    if (confirm('确定要退出吗?')) {
        location.href = getPassportHost() + "/logout.aspx?ReturnUrl=" + location.href;
    }
    return false;
}

var ajaxRequest = {};
ajaxRequest.type = 'post';
ajaxRequest.dataType = 'json';
ajaxRequest.contentType = 'application/json; charset=utf8';

function getHostPostfix() {
    var hostname = location.hostname;
    hostname = hostname.substring(hostname.lastIndexOf("."), hostname.length);
    return hostname;
}

function GetUserInfo() {
    var prefixUrl = 'http://passport.cnblogs' + getHostPostfix();
    $.ajax({
        url: prefixUrl + '/user/LoginInfo',
        dataType: 'jsonp',
        success: function (data) {
            $("#login_area").html(data);
            var spacerUserId = parseInt($("#current_spaceId").html());
            if (spacerUserId > 0) {
                $.ajax({
                    url: prefixUrl + '/user/NewMsgCount',
                    data: 'spaceUserId=' + spacerUserId,
                    dataType: 'jsonp',
                    success: function (data) {
                        if (data) {
                            $("#msg_count").html('(' + data + ')').show();
                        }
                    }
                });
            }
        }
    });

}

function GetNewMsgCount() {    
}

if (typeof (jQuery) != 'undefined') {
    $(function () {
        GetNewMsgCount();
    });
}