"use strict";

var coSide = (function () {
    var model = {
        employeeCompensations: ko.observable({}),
        isOpened: ko.observable(false),
        show: function (obj) {
            request.sendAjax('GET', "/api/compensations/" + obj.Employee.Id)
                .then((data) => {
                    model.employeeCompensations(data[0]);
                    model.isOpened(true);
                    document.getElementById("sidenav").style.display = "block";
                }, (error) => alert.show(error));
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