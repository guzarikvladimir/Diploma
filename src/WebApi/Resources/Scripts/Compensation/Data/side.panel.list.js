"use strict";

var cosidelist = (function() {
    var model = {
        getListItemPreview: getListItemPreview,
        rejectCompensation: rejectCompensation,
        isApproved: function (item) {
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

        return result;
    }

    function rejectCompensation(item) {
        let action = co.promotionTypes()[item.PromotionType];

        request.sendAjax('GET', `/api/Compensations/${action}/Reject/${item.Id}`)
            .then(() => {
                alert.show(action + ' successfully rejected.');
                cotable.getCompensations();
                coside.show();
            }, (error) => alert.error(error));
    }

    return {
        getListItemPreview: model.getListItemPreview,
        rejectCompensation: rejectCompensation,
        isApproved: model.isApproved
    }
})();