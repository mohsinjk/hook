define('binder',
    ['jquery', 'ko', 'config', 'vm'],
    function ($, ko, config, vm) {

        var fn = function () {
            alert('bind');
        }

        var
            ids = config.viewIds,
            //Bind all views after Login
            bind = function () {

                //Map View model
                vm.feed.ViewModel.load();
                vm.follow.following.load();
                vm.follow.followers.load();
                //Load View model
                ko.applyBindings(vm.feed.ViewModel, getView(viewIds.write));
                ko.applyBindings(vm.feed.ViewModel, getView(viewIds.feed));
                ko.applyBindings(vm.feed.ViewModel, getView(viewIds.myFeed));
                ko.applyBindings(vm.feed.ViewModel, getView(viewIds.favorite));
                ko.applyBindings(vm.follow.following, getView(viewIds.following));
                ko.applyBindings(vm.follow.followers, getView(viewIds.followers));
                ko.applyBindings(vm.follow.following, getView(viewIds.connection));
            },

            getView = function (viewName) {
                return $(viewName).get(0);
            };

        return {
            bind: bind,
            fn:fn
        };
    });