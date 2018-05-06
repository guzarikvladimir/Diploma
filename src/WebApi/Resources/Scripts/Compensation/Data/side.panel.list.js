; var cosidelist = (function () {
    "use strict";

    var model = {
        getListItemPreview: getListItemPreview,
        rejectCompensation: rejectCompensation,
        isApproved: function(item) {
            return item.PromotionStatus === 0;
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

    return {
        getListItemPreview: model.getListItemPreview,
        rejectCompensation: rejectCompensation,
        isApproved: model.isApproved
    }
})();