define('dataservice.feed', ['jquery', 'config', 'amplify'],
    function ($, config, amplify) {
        var url = config.baseUrl + '/api/feed';

       var addFeed = function (feed) {
            $.ajax({
                url: url,
                headers: { "X-Token-Header": config.userData.token },
                type: 'POST',
                data: feed
            });
        };

        var getFeed = function () {
            return $.ajax({ url: url + '/Get', headers: { "X-Token-Header": config.userData.token } });
        };

        var getMyFeed = function () {
            return $.ajax({ url: url + '/GetMyFeed', headers: { "X-Token-Header": config.userData.token } });
        };

        var getFavoriteFeed = function () {
            return $.ajax({ url: url + '/GetFavoriteFeed', headers: { "X-Token-Header": config.userData.token } });
        };
        return {
            //Feed: feed,
            addFeed: addFeed,
            getFeed: getFeed,
            getMyFeed: getMyFeed,
            getFavoriteFeed: getFavoriteFeed
        };
    });