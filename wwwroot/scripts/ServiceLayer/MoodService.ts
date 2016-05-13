import ajax = require("../Loader/AjaxLoader");

export interface Mood {
    Id: string;
    Name: string;
    Value: string;
    ImageSrc: string;
}

class MoodOption {
    element: HTMLOptionElement;

    constructor(dto: Mood) {
        this.element = document.createElement("option");
        this.element.value = dto.ImageSrc;
        this.element.innerText = dto.Name;
    }
}

export class MoodService {

    private moodsDropdown: HTMLElement;
    private selectedMoodIcon: HTMLElement;

    init() {
        this.selectedMoodIcon = document.getElementById("selected-mood-icon");
        this.moodsDropdown = document.getElementById("updateMood");

        // fill the dropdown
        this.getMoods();

        this.moodsDropdown.onchange = () => {
            this.updateMood((<HTMLInputElement>(this.moodsDropdown)).value);

            var selectedOption: any = (<HTMLSelectElement>(this.moodsDropdown)).options[(<HTMLSelectElement>(this.moodsDropdown)).selectedIndex];
            this.updateMoodIcon((<HTMLOptionElement>selectedOption).value);
        };

    }

    updateMoodIcon(moodCssClass: string) {
        this.selectedMoodIcon.className = moodCssClass;
    }

    updateMood(data: string) {
        var xhr = new ajax.AjaxLoader();
        xhr.postJson("/api/mood/" + data, '', this.success, this.error);
    }

    getMoods() {
        var xhr = new ajax.AjaxLoader();
        xhr.getJson("/api/mood/getmoods", this.getMoodsSuccess, this.getMoodsError, this);
    }

    success() {
        console.log('success');
    }

    error(error: String, statusCode: Number) {
        console.error(error);
    }

    getMoodsError() {
        console.log("Cannot load list of moods");
    }

    getMoodsSuccess(moods: Array<Mood>, owner: MoodService) {
        while (owner.moodsDropdown.firstChild) {
            owner.moodsDropdown.removeChild(owner.moodsDropdown.firstChild);
        }

        for (var i = 0; i < moods.length; i += 1) {
            var item = moods[i];
            var option = new MoodOption(item);
            owner.moodsDropdown.appendChild(option.element);
        }

    }
}