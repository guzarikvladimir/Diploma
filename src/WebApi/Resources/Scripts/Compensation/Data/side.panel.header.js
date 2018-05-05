"use strict";

var cosidehead = (function() {
    var model = {
        employeeName: function() {
            return coside.employeeCompensations().Employee.Name;
        },
        employeeLocation: function () {
            var location = coside.employeeCompensations().Employee.Location;

            return `${location.Country.Name}, ${location.Name}`;
        },
        employeeJobFunction: function() {
            var jf = coside.employeeCompensations().Employee.JobFunction;

            return `${jf.JobFunctionTitle.Name} ${jf.JobFunctionPosition.Name}`;
        }
    }

    return {
        employeeName: model.employeeName,
        employeeLocation: model.employeeLocation,
        employeeJobFunction: model.employeeJobFunction
    }
})();