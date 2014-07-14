(function () {
    var self = this;

    defineModules();
    loadPluginsAndBoot();

    function defineModules() {
        define('jquery', [], function () { return self.jQuery; });
        define('ko', [], function () { return self.ko; });
        define('amplify', [], function () { return self.amplify; });
        define('moment', [], function () { return self.moment; });
        define('sammy', [], function () { return self.Sammy; });
        define('toastr', [], function () { return self.toastr; });
    }

    function loadPluginsAndBoot() {
        requirejs([
        ], boot);
    }

    function boot() {
        require(['bootstrapper'], function (bs) { bs.run(); });
    }
})();