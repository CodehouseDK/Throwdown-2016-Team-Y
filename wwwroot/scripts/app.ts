import LunchService = require("../scripts/ServiceLayer/LunchService");
declare var require: any;
require("../style/style.scss");

var lunchService = new LunchService.LunchService();

var test = lunchService.getLunch();

