"use strict";

var alert = (function () {
    var model = {
        message: ko.observable()
    };

    function show(mes) {
        model.message(mes);
        trigger('tn-box-color-success');
    }

    function error(error)
    {
        var mes;
        if (error.responseText.indexOf('<') >= 0) {
            mes = error.statusText;
        } else {
            mes = `${error.statusText}. ${error.responseText}`;
        }
        model.message(mes);
        trigger('tn-box-color-error');
    }

    function trigger(name) {
        $('.tn-box').removeClass('tn-box-active');
        $('.tn-box').removeClass('tn-box-color-success');
        $('.tn-box').removeClass('tn-box-color-error');
        setTimeout(() => {
            $('.tn-box').addClass(name);
            $('.tn-box').addClass('tn-box-active');
        }, 10);
    }

    return {
        message: model.message,
        show: show,
        error: error
    }
})();