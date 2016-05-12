import test = require("../Loader/AjaxLoader");

export class FrokostService {
	
	dagensFrokostText: string;

	getFrokost() {
		var xhr = new test.AjaxLoader();
		xhr.getJson("/api/lunch/get", this.success,this.error);
		return this.dagensFrokostText;
	}

	success() {
		this.dagensFrokostText = "Helt sikkert noget kylling";
	}

	error(error: String, statusCode: Number) {
		alert(statusCode);
	}

}