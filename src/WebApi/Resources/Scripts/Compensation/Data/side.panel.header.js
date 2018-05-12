; var cosidehead = (function () {
    "use strict";

    function employeeName() {
        return coside.employeeCompensations().Employee.Name;
    }

    function employeeLocation() {
        var location = coside.employeeCompensations().Employee.Location;

        return `${location.Country.Name}, ${location.Name}`;
    }

    return {
        employeeName: employeeName,
        employeeLocation: employeeLocation
    }
})();