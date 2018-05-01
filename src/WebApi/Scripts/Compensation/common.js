"use strict";

var co = (function() {
    var model = {
        currencies: ko.observableArray(),
        promotionTypes: ko.observableArray(["Salary", "Bonus"]),
        salaryTypes: ko.observableArray(["Monthly", "Annual"])
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

    return {
        currencies: model.currencies,
        promotionTypes: model.promotionTypes,
        salaryTypes: model.salaryTypes,
        fillWithData: fillWithData
    }
})();