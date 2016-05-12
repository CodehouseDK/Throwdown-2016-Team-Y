"use strict";
var LunchService = require("../scripts/ServiceLayer/LunchService");
var mood = require("../scripts/ServiceLayer/MoodService");
require("../style/style.scss");
var lunchService = new LunchService.LunchService();
var moodService = new mood.MoodService();
moodService.init();
lunchService.getLunch();
//# sourceMappingURL=app.js.map