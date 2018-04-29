"use strict";

var ah = (function() {
    var model = {
        compensations: ko.observableArray()
    }

    $(document).ready(function () {
        ko.applyBindings(model);
        getAll();
    });

    function getAll() {
        sendAjax('GET')
            .then(addAll, (error) => alert(error.message));
    }

    function sendAjax(httpMethod, url, data, options) {
        return new Promise(function (resolve, reject) {
            $.ajax({
                url: "/api/compensations" + (url ? "/" + url : ""),
                type: httpMethod,
                data: data,
                contentType: options ? options.contentType : 'application/x-www-form-urlencoded; charset=UTF-8',
                processData: options ? options.processData : true,
                success: resolve,
                error: reject
            });
        });
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
