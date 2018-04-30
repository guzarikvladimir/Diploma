"use strict";

var co = (function() {
    var model = {
        compensations: ko.observableArray(),
        currencies: ko.observableArray(),
        promotionTypes: ko.observableArray([
            { id: 0, name: "Salary" },
            { id: 1, name: "Bonus" }])
    }

    $(document).ready(function () {
        ko.applyBindings(model);
        getCompensations();
        getCurrencies();
    });

    function getCompensations() {
        request.sendAjax('GET', "/api/compensations")
            .then((data) => addAll(data, model.compensations),
                (error) => alert.show(error));
    }

    function getCurrencies() {
        request.sendAjax('GET', "/api/currency")
            .then((data) => addAll(data, model.currencies), 
                (error) => alert.show(error));
    }

    function addAll(data, array) {
        array.removeAll();
        for (var i = 0; i < data.length; i++) {
            array.push(data[i]);
        }
    }

    return {
        compensations: model.compensations,
        getCompensations: getCompensations,
        currencies: model.currencies,
        promotionTypes: model.promotionTypes
    }
})();
