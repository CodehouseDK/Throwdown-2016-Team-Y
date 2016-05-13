import ajax = require("../Loader/AjaxLoader");

export interface IStateDto {
    Id: string;
    Name: string;
}

export interface IStateAggregateDto {
    Id: string;
    Name: string;
    Count: number;
    IconClass: string;
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

class AggregateElement {
    listElement: HTMLLIElement;
    iconElement: HTMLElement;
    countElement: HTMLSpanElement;
    titleElement: HTMLSpanElement;

    constructor(dto: IStateAggregateDto) {
        this.listElement = document.createElement("li");

        this.iconElement = document.createElement("i");
        this.iconElement.className = dto.IconClass;
        
        this.countElement = document.createElement("span");
        this.countElement.innerText = dto.Count.toString();

        this.titleElement = document.createElement("span");
        this.titleElement.innerText = dto.Name;

        this.listElement.appendChild(this.iconElement);
        this.listElement.appendChild(this.titleElement);
        this.listElement.appendChild(this.countElement);
    }
}

export class StateListService {

    init() {
        this.populateStateCombo();
        var selector = <HTMLSelectElement>document.getElementById("updateStatus");
        selector.onchange = () => {
            this.changeState(selector.value);
        };
    }

    populateStateCombo() {
        var xhr = new ajax.AjaxLoader();
        xhr.getJson("/api/state/getlist", this.multiStateSuccess, this.error, this);
    }

    multiStateSuccess(jsonResult: Array<IStateDto>, callback: any) {
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
        xhr.getJson("/api/state/getforuser", this.singleStateSuccess, this.error, this);
    }

    singleStateSuccess(jsonResult: IStateDto) {
        var selector = <HTMLSelectElement>document.getElementById("updateStatus");
        if (jsonResult.Name === undefined || jsonResult.Name === null) {
            return;
        }
        selector.value = jsonResult.Id;
    }

    changeState(value: string) {
        var data = new UserStateDto(value);
        var xhr = new ajax.AjaxLoader();
        xhr.postJson("/api/state/set", data, this.changeSuccess, this.error);
    }

    changeSuccess() {
        new StateAggregateService().init();
        return true;
    }

    error(error: String, statusCode: Number) {
        console.error(error);
    }
}

export class StateOverviewService {

    //init() {
    //    this.populateOverview();
    //}

    //populateOverview() {
    //    var xhr = new ajax.AjaxLoader();
    //    xhr.getJson("/api/state/getoverview", this.overViewSuccess, this.error);
    //}

    //overViewSuccess(jsonResult: any:data) {
    //    var length = jsonResult.length;
    //    for (var i = 0; i < length; i += 1) {
    //        var item = jsonResult[i];
    //        console.log(item.Name + ": " + item.Count.toString());
    //    } 
    //}

    error(error: String, statusCode: Number) {
        console.error(error);
    }
}

export class StateAggregateService {

    init() {
        this.populateAggregatedStates();
    }

    populateAggregatedStates() {
        var xhr = new ajax.AjaxLoader();
        xhr.getJson("/api/state/getaggregate", this.success, this.error, this);
    }
    
    success(jsonResult: Array<IStateAggregateDto>) {
        var unorderedList = document.getElementById("location-list");
        //empty
        while (unorderedList.firstChild) {
            unorderedList.removeChild(unorderedList.firstChild);
        }
        //populate
        var length = jsonResult.length;
        for (var i = 0; i < length; i += 1) {
            var item = jsonResult[i];
            var listElementObject = new AggregateElement(item);
            unorderedList.appendChild(listElementObject.listElement);
        }
    }

    error(error: String, statusCode: Number) {
        console.error(error);
    }
}