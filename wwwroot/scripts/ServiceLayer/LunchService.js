"use strict";
var ajax = require("../Loader/AjaxLoader");
var LunchService = (function () {
    function LunchService() {
    }
    LunchService.prototype.getLunch = function () {
        var xhr = new ajax.AjaxLoader();
        xhr.getJson("/api/lunch", this.success, this.error, this);
    };
    LunchService.prototype.success = function (jsonResult) {
        document.getElementById("lunch-content").innerHTML = jsonResult.Menu;
    };
    LunchService.prototype.error = function (error, statusCode) {
        console.error(error);
    };
    return LunchService;
}());
exports.LunchService = LunchService;
//# sourceMappingURL=LunchService.js.map