define('config', ['jquery', 'moment'],
    function ($, moment) {

        var pullToRefresh = function () {
            $('#feed-view').pull_to_refresh({
                refresh: function (stoploading) {
                    alert('refresh');
                    stoploading();
                }
            });
        }
        //pullToRefresh();
        var lazyLoading = function () {
            $(window).scroll(function () {
                var scrollPercentage = $(window).scrollTop() / ($(document).height() - $(window).height()) * 100;

                if (scrollPercentage >= 90) {
                    $.mobile.loading("show");
                }
                else {
                    $.mobile.loading("hide");
                }
            });
        }
        lazyLoading();

        var baseUrl = ""; //"http://jkhookdev.azurewebsites.net";
        var userData;
        var wrongUserNameOrPassword = "Try again! Given information is not correct.";
        viewIds = {
            login: '#login-view',
            feed: '#feed-view',
            favorite: '#favorite-view',
            following: '#following-view',
            followers: '#followers-view',
            myFeed: '#myFeed-view',
            write: '#write-view',
            register: '#register-view',
            connection: '#connection-view'
        };

        var currentDataTime = function () {
            var now = new Date();
            now = now.toLocaleString();
            //now = moment("9/23/2013 10:47:40 PM", "YYYY-MM-DD HH:mm");
            return now;
        };
        var refreshPage = function () {
            location.reload();
        };

        return {
            userData: userData,
            baseUrl: baseUrl,
            viewIds: viewIds,
            currentDataTime: currentDataTime,
            refreshPage: refreshPage
        };
    });