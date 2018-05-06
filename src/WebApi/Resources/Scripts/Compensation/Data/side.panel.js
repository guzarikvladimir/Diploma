; var coside = (function () {
    "use strict";

    var model = {
        employeeCompensations: ko.observable(),
        employeeLegalEntities: ko.observableArray(),
        isOpened: ko.observable(false),
        show: show,
        hide: hide
    }

    function show(obj) {
        if (obj === undefined) {
            obj = model.employeeCompensations();
        }

        request.sendAjax('GET', '/api/LegalEntity/' + obj.Employee.Id)
            .then((data) => {
                co.fillWithData(data, model.employeeLegalEntities);

                return request.sendAjax('GET', '/api/Compensations/SidePanel/' + obj.Employee.Id);
            })
            .then((data) => model.employeeCompensations(data))
            .then(() => {
                model.isOpened(true);
                document.getElementById("sidenav").style.display = "block";
            })
            .catch((error) => alert.error(error));
    }

    function hide() {
        model.isOpened(false);
        document.getElementById("sidenav").style.display = "none";
    }

    return {
        employeeCompensations: model.employeeCompensations,
        employeeLegalEntities: model.employeeLegalEntities,
        isOpened: model.isOpened,
        show: model.show,
        hide: model.hide
    }
})();