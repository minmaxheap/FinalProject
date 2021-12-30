using System;
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

		public DataTable GetSearch(INSPECT_OPERATIONProperty pr)
		{
			INSPECT_OPERATIONDAC dac = new INSPECT_OPERATIONDAC();
			DataTable dt = dac.GetSearch(pr);
			dac.Dispose();
			return dt;
		}

		public bool Op_Delete(string code)
		{
			INSPECT_OPERATIONDAC dac = new INSPECT_OPERATIONDAC();
			bool result = dac.Op_Delete(code);
			dac.Dispose();
			return result;
		}

		//할당관계 보여주기
		public DataTable GetOp_Table(string code)
		{
			INSPECT_OPERATIONDAC dac = new INSPECT_OPERATIONDAC();
			DataTable dt = dac.GetOp_Table(code);
			dac.Dispose();
			return dt;
		}
		//할당 생성 하기

		public bool Op_Insert(string op_code, string inspect_code, string createID, string updateID)
		{
			INSPECT_OPERATIONDAC dac = new INSPECT_OPERATIONDAC();
			bool b = dac.Op_Insert(op_code, inspect_code, createID, updateID);
			dac.Dispose();
			return b;
		}

		public List<string> GetAll(string Value)
		{
			INSPECT_OPERATIONDAC dac = new INSPECT_OPERATIONDAC();
			List<string> list = dac.GetAll(Value);
			dac.Dispose();
			return list;
		}
	}
}
