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

        request.sendAjax('GET', '/api/LegalEntity?employeeId=' + obj.Employee.Id)
            .then((data) => {
                co.fillWithData(data, model.employeeLegalEntities);

                return request.sendAjax('GET', '/api/Compensations/SidePanel/' + obj.Employee.Id);
            })
            .then((data) => {
                model.employeeCompensations(data);
                co.fillWithData(data.CompensationPromotions.slice(0, 5), cosidelist.employeeCompensations);
                if (data.CompensationPromotions.length >= 5) {
                    cosidelist.overflow(true);
                }
            })
            .then(() => {
                model.isOpened(true);
                document.getElementById("sidenav").style.display = "block";
            })
            .catch((error) => alert.error(error));
    }

    function hide() {
        model.isOpened(false);
        cosidelist.overflow(false);
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