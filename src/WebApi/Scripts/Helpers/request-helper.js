"use strict";

var request = (function() {
    function sendAjax(httpMethod, url, data, options) {
        return new Promise(function (resolve, reject) {
            $.ajax({
                url: url,
                type: httpMethod,
                data: data,
                contentType: options ? options.contentType : 'application/x-www-form-urlencoded',
                //processData: options ? options.processData : true,
                success: resolve,
                error: reject
            });
        });
    };

    return {
        sendAjax : sendAjax
    }
})();