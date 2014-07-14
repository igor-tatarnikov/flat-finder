define('model.flatAd',
    ['ko'],
    function (ko) {
        var FlatAd = function () {
            var self = this;
            self.id = ko.observable();
            self.description = ko.observable();
            self.detailedDescription = ko.observable();
            self.price = ko.observable();
            self.floor = ko.observable();
            self.roomsCount = ko.observable();
            self.city = ko.observable();
            self.street = ko.observable();
            self.house = ko.observable();
            self.flat = ko.observable();
            self.district = ko.observable();
            
            
            self.isNullo = false;
            return self;
        };

        FlatAd.Nullo = new FlatAd().id(0).description('Not an ad');
        FlatAd.Nullo.isNullo = true;

        return FlatAd;
    });
