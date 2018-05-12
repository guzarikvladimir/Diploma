; var cotable = (function () {
    "use strict";

    var model = {
        compensations: ko.observableArray(),
        total: ko.observable()
    }

    $(document).ready(function () {
        ko.applyBindings(model);
    });

    function getCompensations() {
        var requestStr = "/api/Compensations/Table";
        var params = filters.get();
        if (params !== undefined) {
            requestStr += `?${params}`;
        }

        request.sendAjax('GET', requestStr)
            .then((data) => {
                co.fillWithData(data.CompensationsByEmployees, model.compensations);
                model.total(data.Total);
            }, (error) => alert.error(error));
    }

    function buildRow(item) {
        var result = `<td class="column100">${item.Employee.Name}</td>`;
        result = appendWithJobFunction(result, item.Employee);
        result = appendWithCompensations(result, item);
        result = appendWithTotal(result, item);

        return result;
    }

    function appendWithJobFunction(result, employee) {
        result += `<td class="column100">${co.employeeJobFunction(employee)}</td>`;

        return result;
    }

    function appendWithCompensations(result, item) {
        var periods = new Array(12);
        item.CompensationsByPeriods.forEach(function (item) {
            var date = new Date(item.Period);
            periods[date.getMonth()] = item;
        });
        for (let i = 0; i < 12; i++) {
            result += '<td class="column100">';
            if (periods[i] !== undefined) {
                result += co.parseValueWithCurrency(periods[i].Total);
            } else {
                result += '--';
            }

            result += '</td>';
        }

        return result;
    }

    function appendWithTotal(result, item) {
        result += '<td class="column100">';
        if (item.Total !== null) {
            result += co.parseValueWithCurrency(item.Total);
        } else {
            result += '--';
        }

        result += '</td>';

        return result;
    }

    return {
        compensations: model.compensations,
        total: model.total,
        getCompensations: getCompensations,
        buildRow: buildRow
    }
})();
