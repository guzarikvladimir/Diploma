"use strict";

var alert = (function () {
    var model = {
        message: ko.observable(),
        show: function (mes) {
            model.message(mes);
            trigger('.tn-box-color-success');
        },
        error: function (error) {
            model.message(error.responseText);
            trigger('.tn-box-color-error');
        }
    };

    function trigger(name) {
        $(name).removeClass('tn-box-active');
        setTimeout(() => $(name).addClass('tn-box-active'), 10);
    }

    return {
        message: model.message,
        show: model.show,
        error: model.error
    }
})();