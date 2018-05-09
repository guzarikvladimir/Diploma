; var imp = function () {
    "use strict";

    var model = {
        options: ko.observableArray([
            { name: 'Employees', value: 0 },
            { name: 'Roles', value: 1 },
            { name: 'Employees Roles', value: 2 },
            { name: 'Currencies', value: 3 },
            { name: 'Currency Rates', value: 4 },
            { name: 'Legal Entities', value: 5 },
            { name: 'Employees Legal Entities', value: 6 },
            { name: 'Locations', value: 7 },
            { name: 'Job Functions', value: 8 },
            { name: 'Employee Statuses', value: 9 }
        ]),
        selectedOption: ko.observable(),
        file: ko.observable(),
        upload: upload
    }

    $(document).ready(function () {
        ko.applyBindings(model);
    });

    function upload() {
        if (model.file == undefined || model.file == null) {
            alert.error('No files selected.');

            return;
        }

        var fileData = new FormData();
        fileData.append(model.file.name, model.file);
        var requestStr = 'Upload?importOption=' + model.selectedOption();
        request.sendAjax('POST', requestStr, fileData, { contentType: false, processData: false })
            .then(() => {
                model.file = null;
                alert.show('File successfully iploaded.');
                $('#import-file').prop('value', null);
            })
            .catch((error) => alert.error(error));
    }

    return {
        options: model.options,
        selectedOption: model.selectedOption,
        file: model.file,
        upload: model.upload
    }
}();