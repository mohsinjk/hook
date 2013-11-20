define('hookData',
    function () {
       
        var hookData = {
            authUser: ko.observableArray(),
            feeds: ko.observableArray(),
            favorite: ko.observableArray(),
            following: ko.observableArray(),
            followers: ko.observableArray(),
            myFeed: ko.observableArray(),
            groups: ko.observableArray()
        };
        return {
            hookData: hookData
        };
    });