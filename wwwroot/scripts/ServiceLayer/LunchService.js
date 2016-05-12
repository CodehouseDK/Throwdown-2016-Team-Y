var test = require("../Loader/AjaxLoader");
var LunchService = (function () {
    function LunchService() {
    }
    LunchService.prototype.getLunch = function () {
        var xhr = new test.AjaxLoader();
        xhr.getJson("/api/lunch", this.success, this.error);
    };
    LunchService.prototype.success = function (jsonResult) {
        console.log(jsonResult);
    };
    LunchService.prototype.error = function (error, statusCode) {
        alert("error");
    };
    return LunchService;
})();
exports.LunchService = LunchService;
//# sourceMappingURL=LunchService.js.map