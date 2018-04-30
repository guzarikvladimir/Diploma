"use strict";

var coSide = (function () {
    var model = {
        employeeCompensations: ko.observable(),
        compensation: ko.observable(
            {
                value: 0
            }),
        isOpened: ko.observable(false),
        show: function (obj) {
            if (obj === undefined) {
                obj = model.employeeCompensations();
            }

            request.sendAjax('GET', "/api/Compensations/SidePanel/" + obj.Employee.Id)
                .then((data) => {
                    model.employeeCompensations(data);
                }, (error) => alert.error(error))
                .then(() => {
                    model.isOpened(true);
                    document.getElementById("sidenav").style.display = "block";
                });
        },
        hide: function () {
            model.isOpened(false);
            document.getElementById("sidenav").style.display = "none";
        }
    }

    return {
        employeeCompensations: model.employeeCompensations,
        isOpened: model.isOpened,
        show: model.show,
        hide: model.hide
    }
})();