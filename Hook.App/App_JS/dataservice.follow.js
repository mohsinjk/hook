define('dataservice.follow', ['jquery', 'config'],
    function ($, config) {
        var url = config.baseUrl + '/api/follow';

        var addFollow = function (follow) {
            
            $.ajax({
                url: url,
                headers: { "X-Token-Header": config.userData.token },
                type: 'POST',
                data: follow,
                async:false,
                success: function (data) {
                    return data;
            }
            });
        };

        var getFollowing = function () {
            return $.ajax({ url: url + '/following', headers: { "X-Token-Header": config.userData.token } });
        };

        var getFollowers = function () {
            return $.ajax({ url: url + '/followers', headers: { "X-Token-Header": config.userData.token } });
        };
        return {
            getFollowing: getFollowing,
            getFollowers: getFollowers,
            addFollow: addFollow
        }
    });