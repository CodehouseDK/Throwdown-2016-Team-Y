import test = require("../Loader/AjaxLoader");

export interface ILunchDto
{
	Id: String;
	Date: Date;
	Menu: String;
	ImageSrc: String;
}


export class LunchService {
	
	getLunch() {
		var xhr = new test.AjaxLoader();
		xhr.getJson("/api/lunch", this.success, this.error);
	}

	success(jsonResult: ILunchDto) {
		console.log(jsonResult);
	}

	error(error: String, statusCode: Number) {
		alert("error");
	}

}