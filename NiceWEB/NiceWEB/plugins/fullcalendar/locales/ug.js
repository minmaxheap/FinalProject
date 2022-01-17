<<<<<<< HEAD
(function (global, factory) {
    typeof exports === 'object' && typeof module !== 'undefined' ? module.exports = factory() :
    typeof define === 'function' && define.amd ? define(factory) :
    (global = global || self, (global.FullCalendarLocales = global.FullCalendarLocales || {}, global.FullCalendarLocales.ug = factory()));
}(this, function () { 'use strict';

    var ug = {
        code: "ug",
        buttonText: {
            month: "ئاي",
            week: "ھەپتە",
            day: "كۈن",
            list: "كۈنتەرتىپ"
        },
        allDayText: "پۈتۈن كۈن"
    };

    return ug;

}));
=======
FullCalendar.globalLocales.push(function () {
  'use strict';

  var ug = {
    code: 'ug',
    buttonText: {
      month: 'ئاي',
      week: 'ھەپتە',
      day: 'كۈن',
      list: 'كۈنتەرتىپ',
    },
    allDayText: 'پۈتۈن كۈن',
  };

  return ug;

}());
>>>>>>> 4cbc01b69c36dfba861ad4c0abb1f969485d3f67
