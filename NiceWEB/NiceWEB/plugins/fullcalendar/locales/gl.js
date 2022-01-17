<<<<<<< HEAD
(function (global, factory) {
    typeof exports === 'object' && typeof module !== 'undefined' ? module.exports = factory() :
    typeof define === 'function' && define.amd ? define(factory) :
    (global = global || self, (global.FullCalendarLocales = global.FullCalendarLocales || {}, global.FullCalendarLocales.gl = factory()));
}(this, function () { 'use strict';

    var gl = {
        code: "gl",
        week: {
            dow: 1,
            doy: 4 // The week that contains Jan 4th is the first week of the year.
        },
        buttonText: {
            prev: "Ant",
            next: "Seg",
            today: "Hoxe",
            month: "Mes",
            week: "Semana",
            day: "Día",
            list: "Axenda"
        },
        weekLabel: "Sm",
        allDayHtml: "Todo<br/>o día",
        eventLimitText: "máis",
        noEventsMessage: "Non hai eventos para amosar"
    };

    return gl;

}));
=======
FullCalendar.globalLocales.push(function () {
  'use strict';

  var gl = {
    code: 'gl',
    week: {
      dow: 1, // Monday is the first day of the week.
      doy: 4, // The week that contains Jan 4th is the first week of the year.
    },
    buttonText: {
      prev: 'Ant',
      next: 'Seg',
      today: 'Hoxe',
      month: 'Mes',
      week: 'Semana',
      day: 'Día',
      list: 'Axenda',
    },
    weekText: 'Sm',
    allDayText: 'Todo o día',
    moreLinkText: 'máis',
    noEventsText: 'Non hai eventos para amosar',
  };

  return gl;

}());
>>>>>>> 4cbc01b69c36dfba861ad4c0abb1f969485d3f67
