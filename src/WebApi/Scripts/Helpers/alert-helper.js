"use strict";

var alert = (function () {
    var model = {
        message: ko.observable(),
        show: function(mes) {
            model.message(mes);
            $('.tn-box-color-success').addClass('tn-box-active');
        },
        error: function(error) {
            model.message(error.responseText);
            $('.tn-box-color-error').addClass('tn-box-active');
        }
    };

    return {
        message: model.message,
        show: model.show,
        error: model.error
    }
})();