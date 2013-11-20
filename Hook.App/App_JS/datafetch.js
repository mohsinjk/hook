define('datafetch',
    ['jquery','dataservice','hookData', 'config', 'binder'],
    function ($,dataservice, hookData, config, binder) {
        var fetch = function (callback) {
            $.mobile.loading("show");
            //Get userData from localstorage
            config.userData = amplify.store("userData");
            //Return if user is not login
            var feed = dataservice.feed.getFeed(),
                myFeed = dataservice.feed.getMyFeed(),
                favorite = dataservice.feed.getFavoriteFeed(),
                following = dataservice.follow.getFollowing(),
                followers = dataservice.follow.getFollowers();
                groups = dataservice.group.getGroup();

            $.when(feed, favorite, following, followers, myFeed, groups)
              .then(function (feed, favorite, following, followers, myFeed, groups) {
                  hookData.feeds = feed[0];
                  hookData.favorite = favorite[0];
                  hookData.following = following[0];
                  hookData.followers = followers[0];
                  hookData.myFeed = myFeed[0];
                  hookData.groups = groups[0];
              })
              .done(function () {
                  binder.bind();
                  $.mobile.loading("hide");
                  if (callback && typeof (callback) === "function") {
                      callback();
                  }
              });
        }
        return {
            fetch: fetch
        };
    });