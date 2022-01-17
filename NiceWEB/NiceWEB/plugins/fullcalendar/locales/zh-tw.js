<<<<<<< HEAD
(function (global, factory) {
    typeof exports === 'object' && typeof module !== 'undefined' ? module.exports = factory() :
    typeof define === 'function' && define.amd ? define(factory) :
    (global = global || self, (global.FullCalendarLocales = global.FullCalendarLocales || {}, global.FullCalendarLocales['zh-tw'] = factory()));
}(this, function () { 'use strict';

    var zhTw = {
        code: "zh-tw",
        buttonText: {
            prev: "上月",
            next: "下月",
            today: "今天",
            month: "月",
            week: "週",
            day: "天",
            list: "活動列表"
        },
        weekLabel: "周",
        allDayText: "整天",
        eventLimitText: '顯示更多',
        noEventsMessage: "没有任何活動"
    };

    return zhTw;

}));
=======
FullCalendar.globalLocales.push(function () {
  'use strict';

  var zhTw = {
    code: 'zh-tw',
    buttonText: {
      prev: '上月',
      next: '下月',
      today: '今天',
      month: '月',
      week: '週',
      day: '天',
      list: '活動列表',
    },
    weekText: '周',
    allDayText: '整天',
    moreLinkText: '顯示更多',
    noEventsText: '没有任何活動',
  };

  return zhTw;

}());
>>>>>>> 4cbc01b69c36dfba861ad4c0abb1f969485d3f67
