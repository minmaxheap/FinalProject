<<<<<<< HEAD
(function (global, factory) {
    typeof exports === 'object' && typeof module !== 'undefined' ? module.exports = factory() :
    typeof define === 'function' && define.amd ? define(factory) :
    (global = global || self, (global.FullCalendarLocales = global.FullCalendarLocales || {}, global.FullCalendarLocales.uz = factory()));
}(this, function () { 'use strict';

    var uz = {
        code: "uz",
        buttonText: {
            month: "Oy",
            week: "Xafta",
            day: "Kun",
            list: "Kun tartibi"
        },
        allDayText: "Kun bo'yi",
        eventLimitText: function (n) {
            return "+ yana " + n;
        },
        noEventsMessage: "Ko'rsatish uchun voqealar yo'q"
    };

    return uz;

}));
=======
FullCalendar.globalLocales.push(function () {
  'use strict';

  var uz = {
    code: 'uz',
    buttonText: {
      month: 'Oy',
      week: 'Xafta',
      day: 'Kun',
      list: 'Kun tartibi',
    },
    allDayText: "Kun bo'yi",
    moreLinkText: function(n) {
      return '+ yana ' + n
    },
    noEventsText: "Ko'rsatish uchun voqealar yo'q",
  };

  return uz;

}());
>>>>>>> 4cbc01b69c36dfba861ad4c0abb1f969485d3f67
