"use strict";

var cotable = (function () {
    var model = {
        compensations: ko.observableArray(),
        total: ko.observable()
    }

    $(document).ready(function () {
        ko.applyBindings(model);
        getCompensations();
    });

    function getCompensations() {
        request.sendAjax('GET', "/api/Compensations/Table")
            .then((data) => {
                co.fillWithData(data.CompensationsByEmployees, model.compensations);
                model.total(data.Total);
            }, (error) => alert.error(error));
    }

    function buildRow(item) {
        var result = `<td class="column100">${item.Employee.Name}</td>`;
        result = appendWithJobFunction(result, item.Employee.JobFunction);
        result = appendWithCompensations(result, item);
        result += `<td class="column100">${co.parseValueWithCurrency(item.Total)}</td>`;

        return result;
    }

    function appendWithJobFunction(result, jf) {
        result += '<td class="column100">';
        if (jf.JobFunctionTitle !== undefined) {
            result += `${jf.JobFunctionTitle.Name} `;
        }

        result += `${jf.JobFunctionPosition.Name}</td>`;

        return result;
    }

    function appendWithCompensations (result, item) {
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

    return {
        compensations: model.compensations,
        total: model.total,
        getCompensations: getCompensations,
        buildRow: buildRow
    }
})();
