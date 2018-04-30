"use strict";

var coNew = (function () {
    var model = {
        value: ko.observable(),
        currency: ko.observable(),
        promotionType: ko.observable(),
        applyDate: ko.observable(new Date().toISOString().split('T')[0]),
        comment: ko.observable(),
        submitHandler: function() {
            var data = {
                value: model.value(),
                currency: model.currency(),
                employee: coSide.employeeCompensations().Employee,
                promotionType: model.promotionType(),
                applyDate: model.applyDate(),
                comment: model.comment()
            }

            request.sendAjax('POST', '/api/CompensationWorkflow/Create', ko.toJS(data))
                .then(() => {
                    co.getCompensations();
                    coSide.show();
                }, (error) => alert.show(error));
        }
    }

    return {
        value: model.value,
        currency: model.currency,
        promotionType: model.promotionType,
        applyDate: model.applyDate,
        comment: model.comment,
        submitHandler: model.submitHandler
    }
})();