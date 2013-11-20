/// <reference path="../lib/jquery-1.8.2.js" />

define('dataservice.group', ['jquery', 'config'],
    function ($, config) {
        var url = config.baseUrl + '/api/group';

        var addGroup = function (data) {
            return $.ajax({
                url: url + '/Get',
                headers: { "X-Token-Header": config.userData.token },
                data: data
            });
        };

        var getGroup = function () {
            return $.ajax({ url: url + '/Get', headers: { "X-Token-Header": config.userData.token } });
        };
        return {
            addGroup: addGroup,
            getGroup: getGroup
        }
    });