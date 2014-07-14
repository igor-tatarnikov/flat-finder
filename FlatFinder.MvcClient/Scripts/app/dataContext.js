define('dataContext',
    ['jquery', 'ko', 'model', 'model.mapper', 'dataService', 'config'],
    function ($, ko, model, modelmapper, dataservice, config) {
        var logger = config.logger,
            EntitySet = function(getFunction, mapper, nullo, updateFunction) {
                var items = {},
                    // returns the model item produced by merging dto into context
                    mapDtoToContext = function(dto) {
                        var id = mapper.getDtoId(dto);
                        var existingItem = items[id];
                        items[id] = mapper.fromDto(dto, existingItem);
                        return items[id];
                    },
                    add = function(newObj) {
                        items[newObj.id()] = newObj;
                    },
                    removeById = function(id) {
                        delete items[id];
                    },
                    getLocalById = function(id) {
                        // This is the only place we set to NULLO
                        return !!id && !!items[id] ? items[id] : nullo;
                    },
                    getAllLocal = function() {
                        //return utils.mapMemoToArray(items);
                    },
                    getData = function(options) {
                        return $.Deferred(function(def) {
                            var results = options && options.results,
                                sortFunction = options && options.sortFunction,
                                filter = options && options.filter,
                                forceRefresh = options && options.forceRefresh,
                                param = options && options.param,
                                getFunctionOverride = options && options.getFunctionOverride;

                            getFunction = getFunctionOverride || getFunction;

                            //if (forceRefresh || !items || !utils.hasProperties(items)) {
                            if (forceRefresh || !items) {
                                getFunction({
                                    success: function(dtoList) {
                                        items = mapToContext(dtoList, items, results, mapper, filter, sortFunction);
                                        def.resolve(results);
                                    },
                                    error: function(response) {
                                        logger.error(config.toasts.errorGettingData);
                                        def.reject();
                                    }
                                }, param);
                            } else {
                                itemsToArray(items, results, filter, sortFunction);
                                def.resolve(results);
                            }
                        }).promise();
                    },
                    updateData = function(entity, callbacks) {

                        var entityJson = ko.toJSON(entity);

                        return $.Deferred(function(def) {
                            if (!updateFunction) {
                                //logger.error('updateData method not implemented');
                                if (callbacks && callbacks.error) {
                                    callbacks.error();
                                }
                                def.reject();
                                return;
                            }

                            updateFunction({
                                success: function(response) {
                                    //logger.success(config.toasts.savedData);
                                    entity.dirtyFlag().reset();
                                    if (callbacks && callbacks.success) {
                                        callbacks.success();
                                    }
                                    def.resolve(response);
                                },
                                error: function(response) {
                                    //logger.error(config.toasts.errorSavingData);
                                    if (callbacks && callbacks.error) {
                                        callbacks.error();
                                    }
                                    def.reject(response);
                                    return;
                                }
                            }, entityJson);
                        }).promise();
                    };

                return {
                    mapDtoToContext: mapDtoToContext,
                    add: add,
                    getAllLocal: getAllLocal,
                    getLocalById: getLocalById,
                    getData: getData,
                    removeById: removeById,
                    updateData: updateData
                };
            },
            //----------------------------------
            // Repositories
            //----------------------------------
            flatAds = new EntitySet(dataservice.flatAd.getAds, modelmapper.flatAd, model.FlatAd.Nullo);

        // FlatAd extensions
        flatAds.addData = function (sessionModel, callbacks) {
            var adModel = new model.FlatAd()
                    .sessionId(sessionModel.id()),
                    adModelJson = ko.toJSON(adModel);

            return $.Deferred(function (def) {
                dataservice.flatAd.addAd({
                    success: function (dto) {
                        if (!dto) {
                            //logger.error(config.toasts.errorSavingData);
                            if (callbacks && callbacks.error) { callbacks.error(); }
                            def.reject();
                            return;
                        }
                        var newAd = modelmapper.attendance.fromDto(dto);
                        flatAds.add(newAd); // Add to the datacontext
                        //logger.success(config.toasts.savedData);
                        if (callbacks && callbacks.success) { callbacks.success(newAd); }
                        def.resolve(dto);
                    },
                    error: function (response) {
                        //logger.error(config.toasts.errorSavingData);
                        if (callbacks && callbacks.error) { callbacks.error(); }
                        def.reject(response);
                        return;
                    }
                }, adModelJson);
            }).promise();
        };

        flatAds.updateData = function (sessionModel, callbacks) {
        };

        flatAds.deleteData = function (sessionModel, callbacks) {
        };

        var datacontext = {
            flatAds: flatAds
        };

        model.setDataContext(datacontext);

        return datacontext;
    });