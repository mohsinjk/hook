/// <reference path="../lib/jquery-1.8.2.js" />

define('dataservice.connection', ['jquery', 'config'],
    function ($, config) {
        var url = config.baseUrl + '/api/connection';

        var addConnection = function (data) {
            return $.ajax({ url: url + '/Get?token=' + config.userData.token, data: data, dataType: 'json'});
        };

        var getConnection = function () {
            return $.ajax({ url: url + '/Get?token=' + config.userData.token });
        };
        return {
            addConnection: addConnection,
            getConnection: getConnection
        }
    });