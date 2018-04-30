"use strict"

var dblclickHelper = (function () {
    ko.bindingHandlers.click = {
        init: function (element, valueAccessor, allBindingsAccessor, viewModel, context) {
            var accessor = valueAccessor();
            var clicks = 0;
            var timeout = 200;

            $(element).click(function (event) {
                if (typeof (accessor) === 'object') {
                    var single = accessor.single;
                    var double = accessor.double;
                    clicks++;
                    if (clicks === 1) {
                        setTimeout(function () {
                            if (clicks === 1) {
                                if (single != undefined) {
                                    single.call(viewModel, context.$data, event);
                                }
                            } else {
                                if (double != undefined) {
                                    double.call(viewModel, context.$data, event);
                                }
                            }
                            clicks = 0;
                        },
                            timeout);
                    }
                } else {
                    accessor.call(viewModel, context.$data, event);
                }
            });
        }
    }
})();