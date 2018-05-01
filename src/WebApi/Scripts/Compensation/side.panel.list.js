"use strict";

var cosidelist = (function() {
    var model = {
        getListItemPreview: getListItemPreview,
        isApproved: function (item) {
            return item.PromotionStatus === 0;
        }
    }

    function getListItemPreview(item) {
        var promotionType = co.promotionTypes()[item.PromotionType];
        var value = item.Value;
        var currency = item.Currency.Name;

        return `${promotionType}: ${value} ${currency}`;
    }

    return {
        getListItemPreview: model.getListItemPreview,
        isApproved: model.isApproved
    }
})();