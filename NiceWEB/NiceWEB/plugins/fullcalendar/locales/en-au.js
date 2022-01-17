<<<<<<< HEAD
(function (global, factory) {
    typeof exports === 'object' && typeof module !== 'undefined' ? module.exports = factory() :
    typeof define === 'function' && define.amd ? define(factory) :
    (global = global || self, (global.FullCalendarLocales = global.FullCalendarLocales || {}, global.FullCalendarLocales['en-au'] = factory()));
}(this, function () { 'use strict';

    var enAu = {
        code: "en-au",
        week: {
            dow: 1,
            doy: 4 // The week that contains Jan 4th is the first week of the year.
        }
    };

    return enAu;

}));
=======
FullCalendar.globalLocales.push(function () {
  'use strict';

  var enAu = {
    code: 'en-au',
    week: {
      dow: 1, // Monday is the first day of the week.
      doy: 4, // The week that contains Jan 4th is the first week of the year.
    },
  };

  return enAu;

}());
>>>>>>> 4cbc01b69c36dfba861ad4c0abb1f969485d3f67
