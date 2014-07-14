define('model',
    [
        'model.flatAd'
    ],
    function (flatAd) {
        var
            model = {
                FlatAd: flatAd
            };

        model.setDataContext = function (dc) {
        };

        return model;
    });