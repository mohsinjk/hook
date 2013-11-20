define('model.feed',['ko'],
    function (ko) {
      return  function () {
            var self = this;
            self.id = ko.observable();
            self.message = ko.observable();
            self.messageDateTime = ko.observable();
            self.userId = ko.observable();
            self.groupId = ko.observable();
        }
    });