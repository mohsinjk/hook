define('bootstrapper', ['jquery', 'ko', 'datafetch','vm.user'],
    function ($, ko, datafetch,vmUser) {
        var
            run = function () {
                ko.applyBindings(vmUser.ViewModel, $('#login-view').get(0));
                ko.applyBindings(vmUser.ViewModel, $('#register-view').get(0));
                //ko.applyBindings(vmUser.ViewModel, $('#me').get(0));
                //datafetch.fetch();
            };

        return {
            run: run
        };
    });
