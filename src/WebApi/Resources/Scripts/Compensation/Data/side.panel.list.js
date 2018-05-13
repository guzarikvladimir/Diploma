; var cosidelist = (function () {
    "use strict";

    var model = {
        employeeCompensations: ko.observableArray(),
        isMore: ko.observable(false),
        overflow: ko.observable(false)
    }

    function toggleMore() {
        if (model.isMore() === false) {
            co.fillWithData(coside.employeeCompensations().CompensationPromotions, model.employeeCompensations);
            model.isMore(true);
        } else {
            co.fillWithData(coside.employeeCompensations().CompensationPromotions.slice(0, 5), model.employeeCompensations);
            model.isMore(false);
        }
    }

    function getListItemPreview(item) {
        var promotionType = co.promotionTypes()[item.PromotionType];
        var value = item.Value;
        var currency = item.Currency.Name;
        var result = `${promotionType}: ${value} ${currency}`;
        if (item.SalaryType !== undefined) {
            if (item.SalaryType === 0) {
                result += ' Monthly';
            } else {
                result += ' Annual';
            }
        }

        if (promotionType === 'Salary') {
            result += ` ${item.LegalEntity.Name}`;
        }

        return result;
    }

    function rejectCompensation(item) {
        let action = co.promotionTypes()[item.PromotionType];

        request.sendAjax('POST', `/api/Compensations/${action}/Reject`, getData(item))
            .then(() => {
                alert.show(action + ' successfully rejected.');
                cotable.getCompensations();
                coside.show();
            }, (error) => alert.error(error));
    }

    function getData(item) {
        item.CurrencyId = item.Currency.Id;
        item.CreatedById = item.CreatedBy.Id;
        item.EmployeeId = item.Employee.Id;
        item.LegalEntityId = item.LegalEntity.Id;

        return item;
    }

    function isApproved(item) {
        return item.PromotionStatus === 0;
    }

    return {
        isMore: model.isMore,
        employeeCompensations: model.employeeCompensations,
        overflow: model.overflow,
        getListItemPreview: getListItemPreview,
        rejectCompensation: rejectCompensation,
        isApproved: isApproved,
        toggleMore: toggleMore
    }
})();