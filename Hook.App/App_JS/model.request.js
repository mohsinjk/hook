define('model.connection',['ko'],
    function (ko) {
        return function () {
            var self = this;
            self.id = ko.observable();
            self.userSenderId = ko.observable();
            self.userReceiverId = ko.observable();
            self.accepted = ko.observable();
        }
    });