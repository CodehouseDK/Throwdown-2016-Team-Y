import LunchService = require("../scripts/ServiceLayer/LunchService");
import mood = require("../scripts/ServiceLayer/MoodService");
declare var require: any;
require("../style/style.scss");

var lunchService = new LunchService.LunchService();
var moodService = new mood.MoodService();
moodService.init();
lunchService.getLunch();