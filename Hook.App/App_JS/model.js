define('model',
[
    'model.user',
    'model.userInfo',
    'model.follow',
    'model.feed',
    'model.favorite',
    'model.connection',
    'model.group'
],
    function (user, userInfo, follow, feed, favorite, conection, group) {
        var model = {
            User: user,
            UserInfo: userInfo,
            Follow: follow,
            Feed: feed,
            Favorite: favorite,
            Connection: conection,
            Group: group
            };
        return model;
    });