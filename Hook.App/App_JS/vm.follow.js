define('vm.follow', ['ko', 'hookData', 'model', 'dataservice','config'],
    function (ko, hookData, model, dataservice, config) {

        var vmFollowing = {
            following: ko.observableArray([]),
            userName: ko.observable(""),
            load: function () {
                vmFollowing.following = ko.mapping.fromJS(hookData.following);
            }
        };
        vmFollowing.btnAddConnection = function () {
            var follow = new model.Follow()
                        .id(0)
                        .userId(config.userData.id)
                        .followUserId(vmFollowing.userName())
                        .groupId(0);
                        
            //Post to Server
            //var viewModel = ko.mapping.toJSON(follow);
            var i = dataservice.follow.addFollow(follow);
            var viewModel = ko.mapping.fromJSON(i);
            vmFollowing.following.unshift(viewModel);
        };

        var vmFollowers = {
            load: function () {
                vmFollowers.followers = ko.mapping.fromJS(hookData.followers);
            }
        };

      
        return {
            following: vmFollowing,
            followers: vmFollowers
        };
    });
