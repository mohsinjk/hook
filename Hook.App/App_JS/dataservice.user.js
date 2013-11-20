
define('dataservice.user', ['jquery', 'config', 'amplify'],
    function ($, config, amplify) {
        var url = config.baseUrl + '/api/user';

        var udata;
        var auth = function (userName, password) {
            $.ajax({
                type: "GET",
                url: url + "/Auth",
                async: false,
                data: { userName: userName, password: password }
            }).done(function (data) {
                udata=data;
            });
        };
        var getLoginUser = function () {
            return udata;
        };

        var addUser = function (data) {
            $.ajax({
                type: "Post",
                url: url,
                async: false,
                data: data
            }).done(function (data) {
                return data;
            });
        };

        return {
            addUser: addUser,
            getLoginUser: getLoginUser,
            auth: auth
        }
    });