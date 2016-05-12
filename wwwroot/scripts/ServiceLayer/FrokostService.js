var test = require("../Loader/AjaxLoader");
var FrokostService = (function () {
    function FrokostService() {
    }
    FrokostService.prototype.getFrokost = function () {
        var xhr = new test.AjaxLoader();
        this.dagensFrokostText = "Helt sikkert noget kylling";
        xhr.getJson("https://www.google.dk", this.success, this.error);
        return this.dagensFrokostText;
    };
    FrokostService.prototype.success = function () {
        this.dagensFrokostText = "Helt sikkert noget kylling";
    };
    FrokostService.prototype.error = function (error, statusCode) {
        alert(statusCode);
    };
    return FrokostService;
})();
exports.FrokostService = FrokostService;
//# sourceMappingURL=FrokostService.js.map