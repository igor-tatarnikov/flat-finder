define('dataLoader',
    ['ko', 'dataContext', 'config'],
    function (ko, dataContext, config) {

        var logger = config.logger,

            fetch = function () {

                return $.Deferred(function (def) {

                    var data = {
                        flatAds: ko.observableArray()
                    };

                    $.when(
                        dataContext.flatAds.getData({ results: data.flatAds })
                    )

                    .pipe(function () {
                        logger.success('Fetched data for: '
                            + '<div>' + data.flatAds().length + ' ads </div>'
                        );
                    })

                    .fail(function () { def.reject(); })

                    .done(function () { def.resolve(); });

                }).promise();
            };

        return {
            fetch: fetch
        };
    });