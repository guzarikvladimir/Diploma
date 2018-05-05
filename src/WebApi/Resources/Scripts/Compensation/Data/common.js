"use strict";

var co = (function () {
    var model = {
        currencies: ko.observableArray(),
        promotionTypes: ko.observableArray(["Salary", "Bonus"])
    }

    $(document).ready(function () {
        getCurrencies();
    });

    function getCurrencies() {
        request.sendAjax('GET', "/api/Currency")
            .then((data) => fillWithData(data, model.currencies),
                (error) => alert.error(error));
    }

    function fillWithData(data, array) {
        array.removeAll();
        for (var i = 0; i < data.length; i++) {
            array.push(data[i]);
        }
    }

    function parseValueWithCurrency(obj) {
        return `${obj.Value.toFixed(2)} ${obj.Currency.Name}`;
    }

    return {
        currencies: model.currencies,
        promotionTypes: model.promotionTypes,
        parseValueWithCurrency: parseValueWithCurrency,
        fillWithData: fillWithData
    }
})();