<<<<<<< HEAD
(function (global, factory) {
    typeof exports === 'object' && typeof module !== 'undefined' ? module.exports = factory() :
    typeof define === 'function' && define.amd ? define(factory) :
    (global = global || self, (global.FullCalendarLocales = global.FullCalendarLocales || {}, global.FullCalendarLocales.he = factory()));
}(this, function () { 'use strict';

    var he = {
        code: "he",
        dir: 'rtl',
        buttonText: {
            prev: "הקודם",
            next: "הבא",
            today: "היום",
            month: "חודש",
            week: "שבוע",
            day: "יום",
            list: "סדר יום"
        },
        allDayText: "כל היום",
        eventLimitText: "אחר",
        noEventsMessage: "אין אירועים להצגה",
        weekLabel: "שבוע"
    };

    return he;

}));
=======
FullCalendar.globalLocales.push(function () {
  'use strict';

  var he = {
    code: 'he',
    direction: 'rtl',
    buttonText: {
      prev: 'הקודם',
      next: 'הבא',
      today: 'היום',
      month: 'חודש',
      week: 'שבוע',
      day: 'יום',
      list: 'סדר יום',
    },
    allDayText: 'כל היום',
    moreLinkText: 'אחר',
    noEventsText: 'אין אירועים להצגה',
    weekText: 'שבוע',
  };

  return he;

}());
>>>>>>> 4cbc01b69c36dfba861ad4c0abb1f969485d3f67
