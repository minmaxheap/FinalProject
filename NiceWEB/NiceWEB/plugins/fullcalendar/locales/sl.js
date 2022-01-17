<<<<<<< HEAD
(function (global, factory) {
    typeof exports === 'object' && typeof module !== 'undefined' ? module.exports = factory() :
    typeof define === 'function' && define.amd ? define(factory) :
    (global = global || self, (global.FullCalendarLocales = global.FullCalendarLocales || {}, global.FullCalendarLocales.sl = factory()));
}(this, function () { 'use strict';

    var sl = {
        code: "sl",
        week: {
            dow: 1,
            doy: 7 // The week that contains Jan 1st is the first week of the year.
        },
        buttonText: {
            prev: "Prejšnji",
            next: "Naslednji",
            today: "Trenutni",
            month: "Mesec",
            week: "Teden",
            day: "Dan",
            list: "Dnevni red"
        },
        weekLabel: "Teden",
        allDayText: "Ves dan",
        eventLimitText: "več",
        noEventsMessage: "Ni dogodkov za prikaz"
    };

    return sl;

}));
=======
FullCalendar.globalLocales.push(function () {
  'use strict';

  var sl = {
    code: 'sl',
    week: {
      dow: 1, // Monday is the first day of the week.
      doy: 7, // The week that contains Jan 1st is the first week of the year.
    },
    buttonText: {
      prev: 'Prejšnji',
      next: 'Naslednji',
      today: 'Trenutni',
      month: 'Mesec',
      week: 'Teden',
      day: 'Dan',
      list: 'Dnevni red',
    },
    weekText: 'Teden',
    allDayText: 'Ves dan',
    moreLinkText: 'več',
    noEventsText: 'Ni dogodkov za prikaz',
  };

  return sl;

}());
>>>>>>> 4cbc01b69c36dfba861ad4c0abb1f969485d3f67
