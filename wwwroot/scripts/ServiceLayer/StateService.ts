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

class UserStateDto {
    UserId: string;
    StateId: string;

    constructor(stateId: string) {
        this.StateId = stateId;
        this.UserId = null;
    }
}

class Option {
    element: HTMLOptionElement;

    constructor(dto: IStateDto) {
        this.element = document.createElement("option");
        this.element.value = dto.Id.toString();
        this.element.innerText = dto.Name;
    }
}

export class StateListService {

    private me = this;
    init() {
        alert("stateinit");
        this.populateStateCombo();
        var selector = <HTMLSelectElement>document.getElementById("updateStatus");
        selector.onchange = () => {
            this.changeState(selector.value);
        };
    }

    populateStateCombo() {
        var xhr = new ajax.AjaxLoader();
        xhr.getJson("/api/state/getlist", this.multiStateSuccess, this.error);
    }
    
    multiStateSuccess(jsonResult: Array<IStateDto>, callback:any) {
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

        new StateListService().setState();
    }
    
    setState() {
        var xhr = new ajax.AjaxLoader();
        xhr.getJson("/api/state/getforuser", this.singleStateSuccess, this.error);
    }

    singleStateSuccess(jsonResult: IStateDto) {
        var selector = <HTMLSelectElement>document.getElementById("updateStatus");
        selector.value = jsonResult.Id;
    }

    changeState(value: string) {
        var data = new UserStateDto(value);
        var xhr = new ajax.AjaxLoader();
        xhr.postJson("/api/state/set", data, this.changeSuccess, this.error);
    }

    changeSuccess() {
        return true;
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