define('model.favorite',['ko'],
    function (ko) {
      return  function () {
            var self = this;
            self.id = ko.observable();
            self.feedId = ko.observable();
            self.userId = ko.observable();
        }
    });