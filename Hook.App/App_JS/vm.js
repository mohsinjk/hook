define('vm',
[
    //'vm.user',
    'vm.follow',
    'vm.feed',
    'vm.favorite',
    'vm.group',
],
    function (follow, feed, favorite, group) {
        
        return {
            //user: user,
            follow: follow,
            feed: feed,
            favorite: favorite,
            group:group
        };
    });