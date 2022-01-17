<<<<<<< HEAD
(function (global, factory) {
    typeof exports === 'object' && typeof module !== 'undefined' ? module.exports = factory() :
    typeof define === 'function' && define.amd ? define(factory) :
    (global = global || self, (global.FullCalendarLocales = global.FullCalendarLocales || {}, global.FullCalendarLocales.da = factory()));
}(this, function () { 'use strict';

    var da = {
        code: "da",
        week: {
            dow: 1,
            doy: 4 // The week that contains Jan 4th is the first week of the year.
        },
        buttonText: {
            prev: "Forrige",
            next: "Næste",
            today: "I dag",
            month: "Måned",
            week: "Uge",
            day: "Dag",
            list: "Agenda"
        },
        weekLabel: "Uge",
        allDayText: "Hele dagen",
        eventLimitText: "flere",
        noEventsMessage: "Ingen arrangementer at vise"
    };

    return da;

}));
=======
FullCalendar.globalLocales.push(function () {
  'use strict';

  var da = {
    code: 'da',
    week: {
      dow: 1, // Monday is the first day of the week.
      doy: 4, // The week that contains Jan 4th is the first week of the year.
    },
    buttonText: {
      prev: 'Forrige',
      next: 'Næste',
      today: 'I dag',
      month: 'Måned',
      week: 'Uge',
      day: 'Dag',
      list: 'Agenda',
    },
    weekText: 'Uge',
    allDayText: 'Hele dagen',
    moreLinkText: 'flere',
    noEventsText: 'Ingen arrangementer at vise',
  };

  return da;

}());
>>>>>>> 4cbc01b69c36dfba861ad4c0abb1f969485d3f67
