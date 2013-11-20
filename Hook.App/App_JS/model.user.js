define('model.user',['ko'],
    function (ko) {
        return function () {
            var self = this;
            self.id = ko.observable();
            self.userName = ko.observable();
            self.password = ko.observable();
            self.userInfoId = ko.observable();
        }
    });