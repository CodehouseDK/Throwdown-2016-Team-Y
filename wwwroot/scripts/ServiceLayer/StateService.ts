import ajax = require("../Loader/AjaxLoader");

export interface IStateDto {
    Id: string;
    Name: string;
}

export interface IStateAggregateDto {
    Id: string;
    Name: string;
    Count: number;
}

class Option {
    element: HTMLOptionElement;

    constructor(dto: IStateDto) {
        this.element = document.createElement("option");
        this.element.nodeValue = dto.Id.toString();
        this.element.innerText = dto.Name;
    }
}

export class StateListService {

    init() {
        this.getList();
        //var selector = document.getElementById("updateStatus");
        //selector.onchange = () => {
        //    //this.getList((<HTMLInputElement>(updateMoodElement)).value);
        //};
    }

    getList() {
        var xhr = new ajax.AjaxLoader();
        xhr.getJson("/api/state/getlist", this.success, this.error);
    }

    success(jsonResult: Array<IStateDto>) {
        var selector = document.getElementById("updateStatus");
        while (selector.firstChild) {
            selector.removeChild(selector.firstChild);
        }
        var length = jsonResult.length;
        
        for (var i = 0; i < length; i += 1) {
            var item = jsonResult[i];
            var option = new Option(item);
            selector.appendChild(option.element);
        }
    }

    error(error: String, statusCode: Number) {
        alert("error");
    }
}

export class StateOverviewService {
    getOverview() {
        var xhr = new ajax.AjaxLoader();
        xhr.getJson("/api/state/getoverview", this.success, this.error);
    }

    success(jsonResult: IStateAggregateDto) {
        //document.getElementById("lunch-content").innerHTML = jsonResult.Menu;
    }

    error(error: String, statusCode: Number) {
        alert("error");
    }
}