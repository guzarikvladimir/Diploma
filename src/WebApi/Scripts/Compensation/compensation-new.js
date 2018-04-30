"use strict";

var coNew = (function () {
    var model = {
        value: ko.observable(),
        currency: ko.observable(),
        promotionType: ko.observable(),
        applyDate: ko.observable(new Date().toISOString().split('T')[0]),
        comment: ko.observable(),
        salaryType: ko.observable(),
        submitHandler: function() {
            var data = getData();
            var action = model.isSalary() ? "Salary" : "Bonus";

            request.sendAjax('POST', '/api/Compensations/' + action + '/Create', data)
                .then(() => {
                    alert.show(action + ' successfully created.');
                    co.getCompensations();
                    coSide.show();
                    clearData();
                }, (error) => alert.error(error));
        },
        isSalary: ko.observable(true),
        triggerIsSalary: function() {
            if (model.promotionType() === 0) {
                model.isSalary(true);
            } else {
                model.isSalary(false);
            }
        }
    }

    function clearData() {
        model.value('');
        model.comment('');
    }

    function getData() {
        var data = {
            value: model.value(),
            currency: model.currency(),
            employee: coSide.employeeCompensations().Employee,
            promotionType: model.promotionType(),
            applyDate: model.applyDate(),
            comment: model.comment()
        }

        if (model.isSalary()) {
            data.salaryType = model.salaryType();
        }

        return ko.toJS(data);
    }

    return {
        value: model.value,
        currency: model.currency,
        promotionType: model.promotionType,
        applyDate: model.applyDate,
        comment: model.comment,
        salaryType: model.salaryType,
        submitHandler: model.submitHandler,
        isSalary: model.isSalary,
        triggerIsSalary: model.triggerIsSalary
    }
})();