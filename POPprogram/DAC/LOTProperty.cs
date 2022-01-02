using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAC
{
    public class LOTProperty
    {

        private string lot_id;
        private string lot_desc;
        private string product_code;
        private string operation_code;
        private string store_code;
        private decimal lot_qty;
        private decimal create_qty;
        private decimal oper_in_qty;
        private string start_flag;
        private decimal start_qty;
        private DateTime start_time;
        private string start_equipment_code;
        private string end_flag;
        private DateTime end_time;
        private string end_equipment_code;
        private string ship_flag;
        private string ship_code;
        private DateTime ship_time;
        private DateTime production_time;
        private DateTime create_time;
        private DateTime oper_in_time;
        private string work_order_id;
        private string lot_delete_flag;
        private string lot_delete_code;
        private DateTime lot_delete_time;
        private string last_tran_code;
        private DateTime last_tran_time;
        private string last_tran_user_id;
        private string last_tran_comment;
        private int last_hist_seq;

        [DisplayName("LOT ID")]
        public string LOT_ID { get { return lot_id; } set { lot_id = value; } }
        [DisplayName("LOT 설명")]
        public string LOT_DESC { get { return lot_desc; } set { lot_desc = value; } }
        [DisplayName("품번")]
        public string PRODUCT_CODE { get { return product_code; } set { product_code = value; } }

        [DisplayName("공정")]
        public string OPERATION_CODE { get { return operation_code; } set { operation_code = value; } }
        [DisplayName("창고")]
        public string STORE_CODE { get { return store_code; } set { store_code = value; } }
        [DisplayName("수량")]
        public decimal LOT_QTY { get { return lot_qty; } set { lot_qty = value; } }
        [DisplayName("생성 수량")]
        public decimal CREATE_QTY { get { return create_qty; } set { create_qty = value; } }
        [DisplayName("공정 투입 수량")]
        public decimal OPER_IN_QTY { get { return oper_in_qty; } set { oper_in_qty = value; } }
        [DisplayName("작업 시작 여부")]
        public string START_FLAG { get { return start_flag; } set { start_flag = value; } }
        [DisplayName("작업 시작 수량")]
        public decimal START_QTY { get { return start_qty; } set { start_qty = value; } }

        [DisplayName("작업 시작 시간")]
        public DateTime START_TIME { get { return start_time; } set { start_time = value; } }
        [DisplayName("작업 시작 설비")]
        public string START_EQUIPMENT_CODE { get { return start_equipment_code; } set { start_equipment_code = value; } }
        [DisplayName("작업 완료 여부")]
        public string END_FLAG { get { return end_flag; } set { end_flag = value; } }
        [DisplayName("작업 완료 시간")]
        public DateTime END_TIME { get { return end_time; } set { end_time = value; } }
        [DisplayName("작업 완료 설비")]
        public string END_EQUIPMENT_CODE { get { return end_equipment_code; } set { end_equipment_code = value; } }
        [DisplayName("출하 여부")]
        public string SHIP_FLAG { get { return ship_flag; } set { ship_flag = value; } }
        [DisplayName("출하 코드")]
        public string SHIP_CODE { get { return ship_code; } set { ship_code = value; } }
        [DisplayName("출하 시간")]
        public DateTime SHIP_TIME { get { return ship_time; } set { ship_time = value; } }
        [DisplayName("생산 시간")]
        public DateTime PRODUCTION_TIME { get { return production_time; } set { production_time = value; } }
        [DisplayName("LOT 생성 시간")]
        public DateTime CREATE_TIME { get { return create_time; } set { create_time = value; } }
        [DisplayName("공정 투입 시간")]
        public DateTime OPER_IN_TIME { get { return oper_in_time; } set { oper_in_time = value; } }
        [DisplayName("작업지시")]
        public string WORK_ORDER_ID { get { return work_order_id; } set { work_order_id = value; } }
        [DisplayName("LOT 삭제 여부")]
        public string LOT_DELETE_FLAG { get { return lot_delete_flag; } set { lot_delete_flag = value; } }
        [DisplayName("LOT 삭제 코드")]
        public string LOT_DELETE_CODE { get { return lot_delete_code; } set { lot_delete_code = value; } }
        [DisplayName("LOT 삭제 시간")]
        public DateTime LOT_DELETE_TIME { get { return lot_delete_time; } set { lot_delete_time = value; } }
        [DisplayName("마지막 처리 코드")]
        public string LAST_TRAN_CODE { get { return last_tran_code; } set { last_tran_code = value; } }
        [DisplayName("마지막 처리 시간")]
        public DateTime LAST_TRAN_TIME { get { return last_tran_time; } set { last_tran_time = value; } }
        [DisplayName("마지막 처리 사용자")]
        public string LAST_TRAN_USER_ID { get { return last_tran_user_id; } set { last_tran_user_id = value; } }
        [DisplayName("마지막 처리 주석")]
        public string LAST_TRAN_COMMENT { get { return last_tran_comment; } set { last_tran_comment = value; } }
        [DisplayName("마지막 이력 순서")]
        public int LAST_HIST_SEQ { get { return last_hist_seq; } set { last_hist_seq = value; } }


    }

    public class LOTSearchProperty
    {
        private string operation_code;
        private string store_code;
        private string product_code;
        private string lot_id;


        [DisplayName("공정")]
        [TypeConverter(typeof(OperationCodeConverter))]
        public string OPERATION_CODE { get { return operation_code; } set { operation_code = value; } }

        [DisplayName("창고")]
        [TypeConverter(typeof(StoreCodeConverter))]
        public string STORE_CODE { get { return store_code; } set { store_code = value; } }

        [DisplayName("품번")]
        [TypeConverter(typeof(ProductCodeConverter))]
        public string PRODUCT_CODE { get { return product_code; } set { product_code = value; } }

        [DisplayName("LOT ID")]
        public string LOT_ID { get { return lot_id; } set { lot_id = value; } }
    }

    public class OperationCode
    {
        public List<string> GetOperationCode()
        {
            //dac에서 list 받아오기 //앗 근데 DAC을 참조할 수가 없구나(순환 종속성 때문에) => 그래서 여기로 vo를 옮겼다.

            LOTDAC dac = new LOTDAC();
            List<string> operCode = dac.GetOperationCode();
            return operCode; //한번에 다 가져올까 말까 
        }
    }
    public class OperationCodeConverter : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            //ProductVO refMyObject = context.Instance as ProductVO;
            return new StandardValuesCollection(new OperationCode().GetOperationCode());
        }
    }

    public class StoreCode
    {
        public List<string> GetStoreCode()
        {
            //dac에서 list 받아오기 //앗 근데 DAC을 참조할 수가 없구나(순환 종속성 때문에) => 그래서 여기로 vo를 옮겼다.

            LOTDAC dac = new LOTDAC();
            List<string> storeCode = dac.GetStoreCode();
            return storeCode; //한번에 다 가져올까 말까 
        }
    }
    public class StoreCodeConverter : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            //ProductVO refMyObject = context.Instance as ProductVO;
            return new StandardValuesCollection(new StoreCode().GetStoreCode());
        }
    }
    public class ProductCode
    {
        public List<string> GetProductCode()
        {
            //dac에서 list 받아오기 //앗 근데 DAC을 참조할 수가 없구나(순환 종속성 때문에) => 그래서 여기로 vo를 옮겼다.

            LOTDAC dac = new LOTDAC();
            List<string> productCode = dac.GetProductCode();
            return productCode; //한번에 다 가져올까 말까 
        }
    }
    public class ProductCodeConverter : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            //ProductVO refMyObject = context.Instance as ProductVO;
            return new StandardValuesCollection(new ProductCode().GetProductCode());
        }
    }
    

}
