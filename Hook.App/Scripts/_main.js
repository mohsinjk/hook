(function () {
    var root = this;
    define3rdPartyModules();
    boot();
    function define3rdPartyModules() {
        // These are already loaded via bundles. 
        // We define them and put them in the root object.
        define('jquery', [], function () { return root.jQuery; });
        define('jquerymobile', [], function () { return root.jQuerymobile; });
        define('ko', [], function () { return root.ko; });
        define('amplify', [], function () { return root.amplify; });
        define('moment', [], function () { return root.moment; });
        define('sammy', [], function () { return root.Sammy; });
        define('toastr', [], function () { return root.toastr; });
    }

    function boot() {

        require.config({
            paths: {
                'bootstrapper': 'app/bootstrapper'
            }
        });

        require(['bootstrapper'], function (bs) { bs.run(); });
    }
})();