define('vm.feed', ['jquery', 'ko', 'dataservice', 'hookData', 'model', 'config'],
    function ($, ko, dataservice, hookData, model, config) {

        var vm = {
            // observable array of feeds
            feeds: "",
            favorites: "",
            myFeeds: "",
            groups: "",
            selectedGroups: ko.observable(false),
            messageToAdd: ko.observable(""),
            // loading the observable array 
            load: function () {
                vm.feeds = ko.mapping.fromJS(hookData.feeds);
                vm.myFeeds = ko.mapping.fromJS(hookData.myFeed);
                vm.favorites = ko.mapping.fromJS(hookData.favorite);
                vm.groups = ko.mapping.fromJS(hookData.groups);
            }
        };
        /////////////////////////////////////
        vm.selectedGroup = function () {
            //alert('group');
        };
        vm.btnAddFeed = function () {
            // Prevent blanks
            if (vm.messageToAdd() !== "") {
                var user = new model.UserInfo()
                        .id(config.userData.id)
                        .fullName(config.userData.fullName)
                        .companyName(config.userData.companyName);

                var feed = new model.Feed()
                        .id(0)
                        .groupId(0)
                        .message(vm.messageToAdd())
                        .messageDateTime(config.currentDataTime())
                        .userId(config.userData.id);
                //Post to Server
                //var viewModel = ko.mapping.toJSON(feed);
                dataservice.feed.addFeed(feed);
                //Attach entity for KO
                feed.user = user;
                vm.myFeeds.unshift(feed);
                vm.feeds.unshift(feed);
            }
            vm.messageToAdd("");

            //refreshList();
        };

        vm.btnForward = function () {
            var self = this;

            var user = new model.User()
                        .id(config.userData.id)
                        .userName(config.userData.userName)
                        .fullName(config.userData.fullName);

            var feed = new model.Feed()
                        .id(0)
                        .groupId(0)
                        .message(self.message())
                        .messageDateTime(config.currentDataTime())
                        .userId(config.userData.id);


            //Post to Server
            dataservice.feed.addFeed(feed);

            //Attach entity for KO
            feed.user = user;
            vm.myFeeds.unshift(feed);
            vm.feeds.unshift(feed);

            //refreshList();
        };

        vm.btnFavorite = function () {
            var self = this;

            var user = new model.User()
                            .id(config.userData.id)
                            .userName(config.userData.userName)
                            .fullName(config.userData.fullName);

            var feed = new model.Feed()
                      .id(-1)
                      .message(self.message())
                      .messageDateTime(config.currentDataTime())
                      .userId(self.userId);

            var favorite = new model.Favorite()
                        .id(-1)
                        .feedId(self.id())
                        .userId(config.userData.id);

            //Post to Server
            dataservice.favorite.addFavorite(favorite);

            //Attach entity for KO
            feed.user = user;
            vm.favorites.unshift(feed);
            //debugger;
            refreshList();
        };

        var refreshList = function () {
            $("#listFavorite").listview("refresh");
            $("#listMyFeed").listview("refresh");
            $("#listFeed").listview("refresh");
            //$("#listFavorite").listview("refresh").trigger("create");
        }
        return {
            ViewModel: vm
        };
    });
