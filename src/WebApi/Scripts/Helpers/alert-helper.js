"use strict";

var alert = (function () {
    var model = {
        message: ko.observable(),
        show: function(error) {
            model.message(error.responseText);
            $('.tn-box').addClass('tn-box-active');
        }
    };

    return {
        message: model.message,
        show: model.show
    }
})();