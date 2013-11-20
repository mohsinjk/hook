/// <reference path="../lib/jquery-1.8.2.js" />

define('dataservice.favorite', ['jquery', 'config', 'amplify'],
    function ($, config, amplify) {
        var url = config.baseUrl + '/api/favorite';

        //var favorite;
        //$.ajax({
        //    type: "GET",
        //    url: url,
        //    async: false
        //}).done(function (data) {
        //    favorite = data;
        //});

        var
            init = function () {

                amplify.request.define('getFavorite', 'ajax', {
                    url: url,
                    dataType: 'json',
                    type: 'GET',
                    contentType: 'application/json; charset=utf-8'
                });

                amplify.request.define('addFavorite', 'ajax', {
                    url: url,
                    dataType: 'json',
                    type: 'POST'
                });
            },

            getFavorite = function (id) {
                 return amplify.request({
                     resourceId: 'getFavorite'
                 });
             },

            addFavorite = function (data) {
                return amplify.request({
                    resourceId: 'addFavorite',
                    data: data
                });
            };

        init();


        return {
            //favorite: favorite,
            addFavorite: addFavorite,
            getFavorite: ""
        }
    });