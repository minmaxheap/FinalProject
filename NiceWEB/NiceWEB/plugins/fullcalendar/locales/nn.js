<<<<<<< HEAD
(function (global, factory) {
    typeof exports === 'object' && typeof module !== 'undefined' ? module.exports = factory() :
    typeof define === 'function' && define.amd ? define(factory) :
    (global = global || self, (global.FullCalendarLocales = global.FullCalendarLocales || {}, global.FullCalendarLocales.nn = factory()));
}(this, function () { 'use strict';

    var nn = {
        code: "nn",
        week: {
            dow: 1,
            doy: 4 // The week that contains Jan 4th is the first week of the year.
        },
        buttonText: {
            prev: "Førre",
            next: "Neste",
            today: "I dag",
            month: "Månad",
            week: "Veke",
            day: "Dag",
            list: "Agenda"
        },
        weekLabel: "Veke",
        allDayText: "Heile dagen",
        eventLimitText: "til",
        noEventsMessage: "Ingen hendelser å vise"
    };

    return nn;

}));
=======
FullCalendar.globalLocales.push(function () {
  'use strict';

  var nn = {
    code: 'nn',
    week: {
      dow: 1, // Monday is the first day of the week.
      doy: 4, // The week that contains Jan 4th is the first week of the year.
    },
    buttonText: {
      prev: 'Førre',
      next: 'Neste',
      today: 'I dag',
      month: 'Månad',
      week: 'Veke',
      day: 'Dag',
      list: 'Agenda',
    },
    weekText: 'Veke',
    allDayText: 'Heile dagen',
    moreLinkText: 'til',
    noEventsText: 'Ingen hendelser å vise',
  };

  return nn;

}());
>>>>>>> 4cbc01b69c36dfba861ad4c0abb1f969485d3f67
