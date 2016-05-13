"use strict";
var ajax = require("../Loader/AjaxLoader");
var MoodOption = (function () {
    function MoodOption(dto) {
        this.element = document.createElement("option");
        this.element.value = dto.ImageSrc;
        this.element.innerText = dto.Name;
    }
    return MoodOption;
}());
var MoodService = (function () {
    function MoodService() {
    }
    MoodService.prototype.init = function () {
        var _this = this;
        this.selectedMoodIcon = document.getElementById("selected-mood-icon");
        this.moodsDropdown = document.getElementById("updateMood");
        // fill the dropdown
        this.getMoods();
        this.moodsDropdown.onchange = function () {
            _this.updateMood((_this.moodsDropdown).value);
            var selectedOption = (_this.moodsDropdown).options[(_this.moodsDropdown).selectedIndex];
            _this.updateMoodIcon(selectedOption.value);
        };
    };
    MoodService.prototype.updateMoodIcon = function (moodCssClass) {
        this.selectedMoodIcon.className = moodCssClass;
    };
    MoodService.prototype.updateMood = function (data) {
        var xhr = new ajax.AjaxLoader();
        xhr.postJson("/api/mood/" + data, '', this.success, this.error);
    };
    MoodService.prototype.getMoods = function () {
        var xhr = new ajax.AjaxLoader();
        xhr.getJson("/api/mood/getmoods", this.getMoodsSuccess, this.getMoodsError, this);
    };
    MoodService.prototype.success = function () {
        console.log('success');
    };
    MoodService.prototype.error = function (error, statusCode) {
        console.error(error);
    };
    MoodService.prototype.getMoodsError = function () {
        console.log("Cannot load list of moods");
    };
    MoodService.prototype.getMoodsSuccess = function (moods, owner) {
        while (owner.moodsDropdown.firstChild) {
            owner.moodsDropdown.removeChild(owner.moodsDropdown.firstChild);
        }
        for (var i = 0; i < moods.length; i += 1) {
            var item = moods[i];
            var option = new MoodOption(item);
            owner.moodsDropdown.appendChild(option.element);
        }
    };
    return MoodService;
}());
exports.MoodService = MoodService;
//# sourceMappingURL=MoodService.js.map