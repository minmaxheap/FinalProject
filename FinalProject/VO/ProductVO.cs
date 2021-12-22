using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class ProductVO
    {
        public enum CustomEnum { TEST1, TEST2, TEST3 }

//private string  PRODUCT_CODE   ;
//private string  PRODUCT_NAME   ;
//private string  PRODUCT_TYPE   ;
//private string  CUSTOMER_CODE  ;
//private string  VENDOR_CODE    ;
//private string  CREATE_TIME    ;
//private string  CREATE_USER_ID ;
//private string  UPDATE_TIME    ;
//private string UPDATE_USER_ID;

        [DisplayName("품번")]
        public string PRODUCT_CODE   {get;set;}
        
        [DisplayName("품명")]
        public string PRODUCT_NAME   {get;set;}
        [DisplayName("품번 유형")]
        public string PRODUCT_TYPE   {get;set;}
        [DisplayName("고객 코드")]
        public string CUSTOMER_CODE  {get;set;}
        [DisplayName("업체 코드")]
        public string VENDOR_CODE    {get;set;}
        [DisplayName("생성 시간")]
        public DateTime CREATE_TIME    {get;set;}
        [DisplayName("생성 사용자")]
        public string CREATE_USER_ID {get;set;}
        [DisplayName("변경 시간")]
        public DateTime UPDATE_TIME    {get;set;}
        [DisplayName("변경 사용자")]
        public string UPDATE_USER_ID { get; set; }

    }
}
