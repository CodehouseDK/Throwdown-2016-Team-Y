"use strict";
var AjaxLoader = (function () {
    function AjaxLoader() {
    }
    AjaxLoader.prototype.getJson = function (url, success, error) {
        var xhr = new XMLHttpRequest();
        xhr.onreadystatechange = function () {
            if (xhr.readyState === 4) {
                if (xhr.status === 200) {
                    success(JSON.parse(xhr.responseText));
                }
                else {
                    error(xhr.responseText, xhr.status);
                }
            }
        };
        xhr.open("GET", url);
        xhr.send();
    };
    return AjaxLoader;
}());
exports.AjaxLoader = AjaxLoader;
//# sourceMappingURL=AjaxLoader.js.map