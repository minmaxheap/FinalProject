﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAC;
using System.Data;
namespace MES_Team3
{
	public class INSPECT_OPServ
	{
		public DataTable Op_GetTable()
		{
			INSPECT_OPERATIONDAC dac = new INSPECT_OPERATIONDAC();
			DataTable dt = dac.Op_GetTable();
			return dt;
		}
	}
}
