<<<<<<< HEAD
(function (global, factory) {
    typeof exports === 'object' && typeof module !== 'undefined' ? module.exports = factory() :
    typeof define === 'function' && define.amd ? define(factory) :
    (global = global || self, (global.FullCalendarLocales = global.FullCalendarLocales || {}, global.FullCalendarLocales['en-gb'] = factory()));
}(this, function () { 'use strict';

    var enGb = {
        code: "en-gb",
        week: {
            dow: 1,
            doy: 4 // The week that contains Jan 4th is the first week of the year.
        }
    };

    return enGb;

}));
=======
FullCalendar.globalLocales.push(function () {
  'use strict';

  var enGb = {
    code: 'en-gb',
    week: {
      dow: 1, // Monday is the first day of the week.
      doy: 4, // The week that contains Jan 4th is the first week of the year.
    },
  };

  return enGb;

}());
>>>>>>> 4cbc01b69c36dfba861ad4c0abb1f969485d3f67
