import frokost = require("../scripts/ServiceLayer/FrokostService");
declare var require: any;
require("../style/style.scss");

var frokostService = new frokost.FrokostService();

alert(frokostService.getFrokost());

