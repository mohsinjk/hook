define('vm.favorite', ['ko', 'dataservice', 'hookData', 'model', 'config'],
    function (ko, dataservice, hookData, model, config) {
        
        var vm = {
            // observable array of products
            favorites: ko.observableArray([]),
            favoriteToAdd: ko.observable(""),
            // loading the observable array 
            load: function () {
                $.each(hookData.favorite, function (i, data) {
                    vm.favorites.push(new model.Favorite()
                             .id(data.id)
                             .feedId(data.feedId)
                             .userId(data.userId)
                     );
                });
            }
        };

        /////////////////////////////////////
        // Add an Favorite feed
        vm.add = function () {
            // Prevent blanks
            if (vm.favoriteToAdd() !== "") {
                var feed = new model.Feed()
                        .id(-1)
                        .feedId(vm.messageToAdd())
                        .userId(config.userData.userId)

                vm.favorites.unshift(favorite);

                //Post to Server
                dataservice.favorite.addFavorite(favorite);
            }
            vm.messageToAdd("");
        };
        /////////////////////////////////////

        vm.fnTest = function () {
            alert('test binding');
        };
        //Load ViewModel
        //vm.load();
       
        return {
            favorites: vm
        };
    });
