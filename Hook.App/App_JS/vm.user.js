define('vm.user', ['jquery', 'ko', 'datafetch', 'dataservice', 'config', 'amplify', 'model'],
    function ($, ko, datafetch, dataservice, config, amplify, model) {

        //Check: Do we are usrData(userName/Password) is browser storage or not.
        var userData = amplify.store("userData");
        if (typeof userData == 'undefined') {
            $.mobile.changePage($("#login"), { transition: "slideup" });
        }
        else {
            datafetch.fetch();
            $.mobile.changePage($("#home"), { transition: "slideup" });
        }
        //------------------------------------------------------------
        var doLogin = function (userName, password) {
            dataservice.user.auth(userName, password);
            var userData = dataservice.user.getLoginUser();

            if (userData != null) {
                // Store userName and Password in local storage for later use.
                amplify.store("userData", userData);
                datafetch.fetch();
                $.mobile.changePage($("#home"), { transition: "slideup" });
            }
            else {
                // Try again.
                vm.alert(config.wrongUserNameOrPassword);
            }
        };

        var vm = {
            enterUserName: ko.observable("mohsinjk"),
            enterPassword: ko.observable("mohsinjk"),
            alert: ko.observable(""),

            userName: ko.observable(),
            password: ko.observable(),
            email: ko.observable(),
            invitationCode: ko.observable("comaround")
        };

        vm.login = function () {
            doLogin(vm.enterUserName(), vm.enterPassword());
        };

        //Logoff user
        $('#btnLogoff').on('click', function () {
            amplify.store("userData", null);
            config.refreshPage();
        });
        // Form Validation
        $("#formRegister").validate({
            rules: {
                confirmPassword: {
                    equalTo: "#password"
                },
            }
        });

        //Register new user
        vm.registerUser = function () {
            if ($("#formRegister").valid()) {
                var userInfo = new model.UserInfo()
                        .id(0)
                        .email(vm.email())
                        .fullName(vm.userName())
                        .companyName(vm.invitationCode())
                        .phoneNumber("")
                        .information("");

                var user = new model.User()
                        .id(0)
                        .userName(vm.userName())
                        .password(vm.password())
                        .userInfoId(0);
                        
                user.userInfo = userInfo;
                //Post to Server
                dataservice.user.addUser(user);
                // Login new user
                doLogin(vm.userName(), vm.password());
                config.refreshPage();
            }
            else {
                alert('form is not valid');
            }
        }

        //Refresh all data
        $('#btnRefresh').on('click', function () {
            config.refreshPage();
        });
        return {
            ViewModel: vm
        };
    });