define('model.userInfo',['ko'],
    function (ko) {
        return function () {
            var self = this;
            self.id = ko.observable();
            self.fullName = ko.observable();
            self.email = ko.observable();
            self.companyName = ko.observable();
            self.phoneNumber = ko.observable();
            self.information = ko.observable();
        }
    });