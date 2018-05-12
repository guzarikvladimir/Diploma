; var co = (function () {
    "use strict";

    var model = {
        currencies: ko.observableArray(),
        promotionTypes: ko.observableArray(["Salary", "Bonus"])
    }

    $(document).ready(function () {
        getCurrencies();
        cotable.getCompensations();
    });

    function getCurrencies() {
        request.sendAjax('GET', "/api/Currency")
            .then((data) => {
                fillWithData(data, model.currencies);
                filters.currencies.push({
                    Id: guid.empty(),
                    Name: 'Default'
                });
                fillWithData(data, filters.currencies, true);
            }, (error) => alert.error(error));
    }

    function fillWithData(data, array, donotClear) {
        if (donotClear !== true) {
            array.removeAll();
        }

        for (var i = 0; i < data.length; i++) {
            array.push(data[i]);
        }
    }

    function parseValueWithCurrency(obj) {
        return `${(+obj.Value.toFixed(2)).toLocaleString()} ${obj.Currency.Name}`;
    }

    function employeeJobFunction(employee) {
        var jf;
        if (employee !== undefined && employee !== null) {
            jf = employee.JobFunction;
        } else {
            jf = coside.employeeCompensations().Employee.JobFunction;
        }

        return `${jf.Title.Name} ${jf.Position.Name}`;
    }

    return {
        currencies: model.currencies,
        promotionTypes: model.promotionTypes,
        parseValueWithCurrency: parseValueWithCurrency,
        fillWithData: fillWithData,
        employeeJobFunction: employeeJobFunction
    }
})();