; var filters = (function () {
    "use strict";

    var model = {
        currencies: ko.observableArray(),
        currency: ko.observable(),
        year: ko.observable(new Date().getYear() + 1900),
        page: ko.observable(1),
        pageCount: ko.observable(20)
    }

    function get() {
        var params = '';
        if (model.currency() !== undefined) {
            if (model.currency().Id !== guid.empty()) {
                params = appendWithValue(params, model.currency().Id, 'currencyId');
            }
        }

        params = appendWithValue(params, model.year(), 'year');
        params = appendWithValue(params, model.page(), 'page');
        params = appendWithValue(params, model.pageCount(), 'pageCount');

        return params;
    }

    function appendWithValue(params, value, valueName) {
        if (value !== undefined) {
            params = appendWithAnd(params);
            params += `${valueName}=${value}`;
        }

        return params;
    }

    function appendWithAnd(params) {
        if (params === '') {
            return params;
        }

        return params + '&';
    }

    return {
        year: model.year,
        currency: model.currency,
        page: model.page,
        pageCount: model.pageCount,
        get: get,
        currencies: model.currencies
    }
})();