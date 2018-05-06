; var request = (function () {
    "use strict";

    function sendAjax(httpMethod, url, data, options) {
        return new Promise(function (resolve, reject) {
            $.ajax({
                url: url,
                type: httpMethod,
                data: data,
                contentType: options ? options.contentType : 'application/x-www-form-urlencoded',
                success: resolve,
                error: reject
            });
        });
    };

    return {
        sendAjax: sendAjax
    }
})();