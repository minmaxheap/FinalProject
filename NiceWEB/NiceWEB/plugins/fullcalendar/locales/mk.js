<<<<<<< HEAD
(function (global, factory) {
    typeof exports === 'object' && typeof module !== 'undefined' ? module.exports = factory() :
    typeof define === 'function' && define.amd ? define(factory) :
    (global = global || self, (global.FullCalendarLocales = global.FullCalendarLocales || {}, global.FullCalendarLocales.mk = factory()));
}(this, function () { 'use strict';

    var mk = {
        code: "mk",
        buttonText: {
            prev: "претходно",
            next: "следно",
            today: "Денес",
            month: "Месец",
            week: "Недела",
            day: "Ден",
            list: "График"
        },
        weekLabel: "Сед",
        allDayText: "Цел ден",
        eventLimitText: function (n) {
            return "+повеќе " + n;
        },
        noEventsMessage: "Нема настани за прикажување"
    };

    return mk;

}));
=======
FullCalendar.globalLocales.push(function () {
  'use strict';

  var mk = {
    code: 'mk',
    buttonText: {
      prev: 'претходно',
      next: 'следно',
      today: 'Денес',
      month: 'Месец',
      week: 'Недела',
      day: 'Ден',
      list: 'График',
    },
    weekText: 'Сед',
    allDayText: 'Цел ден',
    moreLinkText: function(n) {
      return '+повеќе ' + n
    },
    noEventsText: 'Нема настани за прикажување',
  };

  return mk;

}());
>>>>>>> 4cbc01b69c36dfba861ad4c0abb1f969485d3f67
