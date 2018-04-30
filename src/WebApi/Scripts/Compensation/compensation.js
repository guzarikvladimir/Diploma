"use strict";

var co = (function() {
    var model = {
        compensations: ko.observableArray()
    }

    $(document).ready(function () {
        ko.applyBindings(model);
        getAll();
    });

    function getAll() {
        request.sendAjax('GET', "/api/compensations")
            .then(addAll, (error) => alert.show(error));
    }

    function addAll(data) {
        model.compensations.removeAll();
        for (var i = 0; i < data.length; i++) {
            model.compensations.push(data[i]);
        }
    }

    return {
        compensations: model.compensations
    }
})();
