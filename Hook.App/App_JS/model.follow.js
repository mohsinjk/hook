define('model.follow',['ko'],
    function (ko) {
        return function () {
            var self = this;
            self.id = ko.observable();
            self.userId = ko.observable();
            self.followUserId = ko.observable();
            self.groupId = ko.observable();
        }
    });