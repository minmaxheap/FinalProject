using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAC
{
    public class DownProperty
    {
		public string DT_DATE { get; set; } //비가동 일자
		public DateTime DT_START_TIME { get; set; }

		public DateTime DT_END_TIME { get; set; }

		public string DT_TIME { get; set; } // 비가동 시간(분)

		public string DT_CODE { get; set; } // 비가동 코드

		public string DT_COMMENT { get; set; } //비가동 주석

		public string DT_USER_ID { get; set; } // 비가동 등록자

		public string ACTION_COMMENT { get; set; } // 조치 내역

		public DateTime CONFIRM_TIME { get; set; } // 확인 시간

		public string CONFIRM_USER_ID { get; set; } // 확인자

	}
}
