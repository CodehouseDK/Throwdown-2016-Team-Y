"use strict";
var AjaxLoader = (function () {
    function AjaxLoader() {
    }
    AjaxLoader.prototype.getJson = function (url, success, error, owner) {
        var xhr = new XMLHttpRequest();
        xhr.onreadystatechange = function () {
            if (xhr.readyState === 4) {
                if (xhr.status === 200) {
                    success(JSON.parse(xhr.responseText), owner);
                }
                else {
                    error(xhr.responseText, xhr.status, owner);
                }
            }
        };
        xhr.open("GET", url);
        xhr.send();
    };
    AjaxLoader.prototype.postJson = function (url, data, success, error) {
        var xhr = new XMLHttpRequest();
        xhr.onreadystatechange = function () {
            if (xhr.readyState === 4) {
                if (xhr.status === 200) {
                    if (xhr.responseText === '') {
                        success('');
                    }
                    else {
                        success(JSON.parse(xhr.responseText));
                    }
                }
                else {
                    error(xhr.responseText, xhr.status);
                }
            }
        };
        xhr.open("POST", url);
        xhr.setRequestHeader('Content-Type', 'application/json');
        xhr.send(JSON.stringify(data));
    };
    return AjaxLoader;
}());
exports.AjaxLoader = AjaxLoader;
//# sourceMappingURL=AjaxLoader.js.map