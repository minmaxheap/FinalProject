﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAC;
using System.Data;

namespace POPprogram.Services
{
	public class StarWorkServ
	{
		public List<StarWorkProperty> GetData(string Code)
		{
			StartWorkDAC dac = new StartWorkDAC();
			List<StarWorkProperty> List = dac.GetData(Code);
			dac.Dispose();
			return List;
		}
		public DataTable GetCode()
		{
			StartWorkDAC dac = new StartWorkDAC();
			DataTable dt = dac.GetCode();
			dac.Dispose();
			return dt;
		}


	}
}
