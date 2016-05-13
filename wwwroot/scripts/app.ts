import LunchService = require("../scripts/ServiceLayer/LunchService");
import mood = require("../scripts/ServiceLayer/MoodService");
import state = require("../scripts/ServiceLayer/StateService");
declare var require: any;
require("../style/style.scss");

var lunchService = new LunchService.LunchService();
var moodService = new mood.MoodService();
moodService.init();
lunchService.getLunch();

var stateService = new state.StateListService();
stateService.init();
