import ajax = require("../Loader/AjaxLoader");

export class MoodService {

    init() {
        var updateMoodElement = document.getElementById("updateMood");
        updateMoodElement.onchange = () => {
            this.updateMood((<HTMLInputElement>(updateMoodElement)).value);
        };
    }

    updateMood(data: string) {
        var xhr = new ajax.AjaxLoader();
        xhr.postJson("/api/mood/" + data, '', this.success, this.error);
    }

    success() {
        console.log('success');
    }

    error(error: String, statusCode: Number) {
        console.error(error);
    }
}