"use strict";
var LunchService = require("../scripts/ServiceLayer/LunchService");
var mood = require("../scripts/ServiceLayer/MoodService");
var state = require("../scripts/ServiceLayer/StateService");
require("../style/style.scss");
var lunchService = new LunchService.LunchService();
var moodService = new mood.MoodService();
moodService.init();
lunchService.getLunch();
var stateListService = new state.StateListService();
stateListService.init();
var stateAggregateService = new state.StateAggregateService();
stateAggregateService.init();
//# sourceMappingURL=app.js.map