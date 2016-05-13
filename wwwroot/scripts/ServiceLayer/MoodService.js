"use strict";
var ajax = require("../Loader/AjaxLoader");
var MoodService = (function () {
    function MoodService() {
    }
    MoodService.prototype.init = function () {
        var _this = this;
        var updateMoodElement = document.getElementById("updateMood");
        updateMoodElement.onchange = function () {
            _this.updateMood((updateMoodElement).value);
        };
    };
    MoodService.prototype.updateMood = function (data) {
        var xhr = new ajax.AjaxLoader();
        xhr.postJson("/api/mood/" + data, '', this.success, this.error);
    };
    MoodService.prototype.success = function () {
        console.log('success');
    };
    MoodService.prototype.error = function (error, statusCode) {
        console.error(error);
    };
    return MoodService;
}());
exports.MoodService = MoodService;
//# sourceMappingURL=MoodService.js.map