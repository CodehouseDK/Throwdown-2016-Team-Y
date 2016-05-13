import ajax = require("../Loader/AjaxLoader");

export interface ILunchDto
{
	Id: string;
	Date: Date;
	Menu: string;
	ImageSrc: string;
}


export class LunchService {
	
	getLunch() {
		var xhr = new ajax.AjaxLoader();
		xhr.getJson("/api/lunch", this.success, this.error);
	}

	success(jsonResult: ILunchDto) {
		document.getElementById("lunch-content").innerHTML = jsonResult.Menu;
	}

	error(error: String, statusCode: Number) {
        console.error(error);
	}
}