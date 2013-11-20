define('model.group',['ko'],
    function (ko) {
      return  function () {
            var self = this;
            self.id = ko.observable();
            self.userId = ko.observable();
            self.groupName = ko.observable();
        }
    });