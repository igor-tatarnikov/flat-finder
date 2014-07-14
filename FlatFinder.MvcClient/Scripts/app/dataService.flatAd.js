define('dataService.flatAd',
    ['amplify', 'config'],
    function (amplify, config) {
        var
            init = function () {
                amplify.request.define('ads', 'ajax', {
                    url: config.endPointUrl + '/api/flatad',
                    dataType: 'json',
                    type: 'GET'
                });

                amplify.request.define('adAdd', 'ajax', {
                    url: config.endPointUrl + '/api/detailedflatad',
                    dataType: 'json',
                    type: 'POST',
                    contentType: 'application/json; charset=utf-8'
                });
            },

            getAds = function (callbacks) {
                var
                    resourceId = 'ads';

                return amplify.request({
                    resourceId: resourceId,
                    success: callbacks.success,
                    error: callbacks.error
                });
            },
            
            addAd = function(callbacks, data) {
                return amplify.request({
                    resourceId: 'adAdd',
                    data: data,
                    success: callbacks.success,
                    error: callbacks.error
                });
            };

        init();

        return {
            getAds: getAds,
            addAd: addAd
        };
    });