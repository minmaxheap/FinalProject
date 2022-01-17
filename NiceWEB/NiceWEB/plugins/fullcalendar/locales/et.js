<<<<<<< HEAD
(function (global, factory) {
    typeof exports === 'object' && typeof module !== 'undefined' ? module.exports = factory() :
    typeof define === 'function' && define.amd ? define(factory) :
    (global = global || self, (global.FullCalendarLocales = global.FullCalendarLocales || {}, global.FullCalendarLocales.et = factory()));
}(this, function () { 'use strict';

    var et = {
        code: "et",
        week: {
            dow: 1,
            doy: 4 // The week that contains Jan 4th is the first week of the year.
        },
        buttonText: {
            prev: "Eelnev",
            next: "Järgnev",
            today: "Täna",
            month: "Kuu",
            week: "Nädal",
            day: "Päev",
            list: "Päevakord"
        },
        weekLabel: "näd",
        allDayText: "Kogu päev",
        eventLimitText: function (n) {
            return "+ veel " + n;
        },
        noEventsMessage: "Kuvamiseks puuduvad sündmused"
    };

    return et;

}));
=======
FullCalendar.globalLocales.push(function () {
  'use strict';

  var et = {
    code: 'et',
    week: {
      dow: 1, // Monday is the first day of the week.
      doy: 4, // The week that contains Jan 4th is the first week of the year.
    },
    buttonText: {
      prev: 'Eelnev',
      next: 'Järgnev',
      today: 'Täna',
      month: 'Kuu',
      week: 'Nädal',
      day: 'Päev',
      list: 'Päevakord',
    },
    weekText: 'näd',
    allDayText: 'Kogu päev',
    moreLinkText: function(n) {
      return '+ veel ' + n
    },
    noEventsText: 'Kuvamiseks puuduvad sündmused',
  };

  return et;

}());
>>>>>>> 4cbc01b69c36dfba861ad4c0abb1f969485d3f67
