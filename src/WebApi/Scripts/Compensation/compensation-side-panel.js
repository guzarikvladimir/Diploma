"use strict";

var cosp = (function () {
    var model = {
        employeeCompensations: ko.observable(),
        isOpened: ko.observable(false),
        show: show,
        hide: hide
    }

    function show(obj) {
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
    }

    function hide() {
        model.isOpened(false);
        document.getElementById("sidenav").style.display = "none";
    }

    return {
        employeeCompensations: model.employeeCompensations,
        isOpened: model.isOpened,
        show: model.show,
        hide: model.hide
    }
})();