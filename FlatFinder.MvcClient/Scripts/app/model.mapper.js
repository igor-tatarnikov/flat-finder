define('model.mapper',
['model'],
    function (model) {
        var
            flatAd = {
                getDtoId: function (dto) {
                    return dto.id;
                },
                fromDto: function (dto, item) {
                    item = item || new model.FlatAd();
                    return item;
                }
            };

        return {
            flatAd: flatAd
        };
    });