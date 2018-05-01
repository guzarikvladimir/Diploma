"use strict";

var alert = (function () {
    var model = {
        message: ko.observable(),
        show: function (mes) {
            model.message(mes);
            trigger('tn-box-color-success');
        },
        error: function (error) {
            model.message(`An error has occured: ${error.statusText}`);
            trigger('tn-box-color-error');
        }
    };

    function trigger(name) {
        $('.tn-box').removeClass('tn-box-active');
        $('.tn-box').removeClass(name);
        setTimeout(() => {
            $('.tn-box').addClass(name);
            $('.tn-box').addClass('tn-box-active');
        }, 10);
    }

    return {
        message: model.message,
        show: model.show,
        error: model.error
    }
})();