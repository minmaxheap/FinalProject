using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace DAC
{
    public class OperationProperty
    {
        private string operation_code;
        private string operation_name;
        private string check_defect_flag;
        private string check_inspect_flag;
        private string check_material_flag;

        private DateTime create_time;
        private string create_user_id;
        private DateTime update_time;
        private string update_user_id;

        [System.ComponentModel.RefreshProperties(RefreshProperties.All)]
        [DisplayName("공정")]
        public string OPERATION_CODE { get { return operation_code; } set { operation_code = value; } }

        [ReadOnly(false)]
        [DisplayName("공정명")]
        public string OPERATION_NAME { get { return operation_name; } set { operation_name = value; } }

        [DisplayName("불량 입력")]
        [TypeConverter(typeof(Check_Value_Converter))]
        public string CHECK_DEFECT_FLAG {get { return check_defect_flag; }set { check_defect_flag = value; }}

        [DisplayName("검사 데이터 입력")]
        [TypeConverter(typeof(Check_Value_Converter))]
        public string CHECK_INSPECT_FLAG { get { return check_inspect_flag; } set { check_inspect_flag = value; } }

        [DisplayName("자재 사용")]
        [TypeConverter(typeof(Check_Value_Converter))]
        public string CHECK_MATERIAL_FLAG { get { return check_material_flag; } set { check_material_flag = value; } }

        [ReadOnly(true)]
        [DisplayName("생성 시간")]
        public DateTime CREATE_TIME { get { return create_time; } set { create_time = value; } }

        [ReadOnly(true)]
        [DisplayName("생성 사용자")]
        public string CREATE_USER_ID { get { return create_user_id; } set { create_user_id = value; } }

        [ReadOnly(true)]
        [DisplayName("변경 시간")]
        public DateTime UPDATE_TIME { get { return update_time; } set { update_time = value; } }

        [ReadOnly(true)]
        [DisplayName("변경 사용자")]
        public string UPDATE_USER_ID 
        { get { return update_user_id; } set  {update_user_id = value;} }

        public OperationProperty()
        {

         }

    }
}
