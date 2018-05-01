"use strict";

var cotable = (function() {
    var model = {
        compensations: ko.observableArray()
    }

    $(document).ready(function () {
        ko.applyBindings(model);
        getCompensations();
    });

    function getCompensations() {
        request.sendAjax('GET', "/api/Compensations/Table")
            .then((data) => co.fillWithData(data, model.compensations),
                (error) => alert.error(error));
    }

    return {
        compensations: model.compensations,
        getCompensations: getCompensations
    }
})();
