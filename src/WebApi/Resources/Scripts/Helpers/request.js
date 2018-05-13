; var request = (function () {
    "use strict";

    function endLoading() {
        var loading = document.getElementsByClassName("cssload-thecube")[0];
        loading.style.display = "none";
    }

    function startLoadig() {
        var loading = document.getElementsByClassName("cssload-thecube")[0];
        loading.style.display = "block";
    }

    function sendAjax(httpMethod, url, data, options) {
        startLoadig();

        return new Promise(function (resolve, reject) {
            $.ajax({
                url: url,
                type: httpMethod,
                data: data,
                contentType: options ? options.contentType : 'application/x-www-form-urlencoded',
                processData: options ? options.processData : true,
                success: function(data) {
                    resolve(data);
                    endLoading();
                },
                error: reject
            });
        });
    };

    return {
        sendAjax: sendAjax
    }
})();