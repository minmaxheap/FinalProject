															
CREATE TABLE SALES_ORDER_MST (										
SALES_ORDER_ID                 VARCHAR (50)    ,					
ORDER_DATE                     DATETIME      ,						
CUSTOMER_CODE                  VARCHAR (50)    ,					
PRODUCT_CODE                   VARCHAR (50)    ,						
ORDER_QTY                      NUMERIC (10,3)    ,					
CONFIRM_FLAG                   CHAR (1)    ,										
SHIP_FLAG                      CHAR (1)    ,									
CREATE_TIME                    DATETIME      ,						
CREATE_USER_ID                 VARCHAR (50)    ,						
UPDATE_TIME                    DATETIME      ,						
UPDATE_USER_ID                 VARCHAR (50)    						
);
						
		EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�� �ֹ��� �ڵ�', 'USER', DBO, 'TABLE', SALES_ORDER_MST,'COLUMN',SALES_ORDER_ID									
	EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�ֹ� ����', 'USER', DBO, 'TABLE', SALES_ORDER_MST,'COLUMN',ORDER_DATE									
		EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�� �ڵ�', 'USER', DBO, 'TABLE', SALES_ORDER_MST,'COLUMN',CUSTOMER_CODE									
		EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�ֹ� ��ǰ �ڵ�, ǰ��', 'USER', DBO, 'TABLE', SALES_ORDER_MST,'COLUMN',PRODUCT_CODE								
		EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�ֹ� ����', 'USER', DBO, 'TABLE', SALES_ORDER_MST,'COLUMN',ORDER_QTY									
	EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'Ȯ�� ����. ��Ȯ�� : null, Ȯ�� : Y', 'USER', DBO, 'TABLE', SALES_ORDER_MST,'COLUMN',CONFIRM_FLAG					
	EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� ����. ������ : null, ���� : Y', 'USER', DBO, 'TABLE', SALES_ORDER_MST,'COLUMN',SHIP_FLAG						
	EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�ֹ��� ���� �ð�', 'USER', DBO, 'TABLE', SALES_ORDER_MST,'COLUMN',CREATE_TIME									
		EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�ֹ��� ���� �����', 'USER', DBO, 'TABLE', SALES_ORDER_MST,'COLUMN',CREATE_USER_ID								
	EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�ֹ��� ���� �ð�', 'USER', DBO, 'TABLE', SALES_ORDER_MST,'COLUMN',UPDATE_TIME									
	EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�ֹ��� ���� �����', 'USER', DBO, 'TABLE', SALES_ORDER_MST,'COLUMN',UPDATE_USER_ID									

	CREATE TABLE SHIP_LOT_HIS (				
SALES_ORDER_ID                 VARCHAR (50)    ,				
LOT_ID                         VARCHAR (50)    ,				
SHIP_TIME                      DATETIME      ,				
PRODUCT_CODE                   VARCHAR (50)    ,				
SHIP_QTY                       NUMERIC (10,3)    ,				
SHIP_USER_ID                   VARCHAR (50)    				
);

EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�� �ֹ��� �ڵ�', 'USER', DBO, 'TABLE', SHIP_LOT_HIS,'COLUMN',SALES_ORDER_ID									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� LOT ID', 'USER', DBO, 'TABLE', SHIP_LOT_HIS,'COLUMN',LOT_ID									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �ð�', 'USER', DBO, 'TABLE', SHIP_LOT_HIS,'COLUMN',SHIP_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� ��ǰ �ڵ�, ǰ��', 'USER', DBO, 'TABLE', SHIP_LOT_HIS,'COLUMN',PRODUCT_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� ����', 'USER', DBO, 'TABLE', SHIP_LOT_HIS,'COLUMN',SHIP_QTY									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �����', 'USER', DBO, 'TABLE', SHIP_LOT_HIS,'COLUMN',SHIP_USER_ID									

CREATE TABLE PURCHASE_ORDER_MST (				
PURCHASE_ORDER_ID              VARCHAR (50)    ,				
SALES_ORDER_ID                 VARCHAR (50)    ,				
ORDER_DATE                     DATETIME      ,				
VENDOR_CODE                    VARCHAR (50)    ,				
MATERIAL_CODE                  VARCHAR (50)    ,				
ORDER_QTY                      NUMERIC (10,3)    ,				
STOCK_IN_FLAG                  CHAR (1)    ,				
STOCK_IN_STORE_CODE            VARCHAR (50)    ,				
STOCK_IN_LOT_ID                VARCHAR (50)    				
);

EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� ��ǰ�� �ڵ�', 'USER', DBO, 'TABLE', PURCHASE_ORDER_MST,'COLUMN',PURCHASE_ORDER_ID									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�� �ֹ��� �ڵ�', 'USER', DBO, 'TABLE', PURCHASE_ORDER_MST,'COLUMN',SALES_ORDER_ID									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���Ź��� ����', 'USER', DBO, 'TABLE', PURCHASE_ORDER_MST,'COLUMN',ORDER_DATE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '��ǰó �ڵ�', 'USER', DBO, 'TABLE', PURCHASE_ORDER_MST,'COLUMN',VENDOR_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� ǰ��', 'USER', DBO, 'TABLE', PURCHASE_ORDER_MST,'COLUMN',MATERIAL_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� ����', 'USER', DBO, 'TABLE', PURCHASE_ORDER_MST,'COLUMN',ORDER_QTY									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� ����. ������ : null, ���� : Y', 'USER', DBO, 'TABLE', PURCHASE_ORDER_MST,'COLUMN',STOCK_IN_FLAG									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� â�� �ڵ�', 'USER', DBO, 'TABLE', PURCHASE_ORDER_MST,'COLUMN',STOCK_IN_STORE_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� ���� LOT ID', 'USER', DBO, 'TABLE', PURCHASE_ORDER_MST,'COLUMN',STOCK_IN_LOT_ID									

CREATE TABLE WORK_ORDER_MST (				
WORK_ORDER_ID                  VARCHAR (50)    ,				
ORDER_DATE                     DATETIME      ,				
PRODUCT_CODE                   VARCHAR (50)    ,				
CUSTOMER_CODE                  VARCHAR (50)    ,				
ORDER_QTY                      NUMERIC (10,3)    ,				
ORDER_STATUS                   VARCHAR (10)    ,				
PRODUCT_QTY                    NUMERIC (10,3)    ,				
DEFECT_QTY                     NUMERIC (10,3)    ,				
WORK_START_TIME                DATETIME      ,				
WORK_CLOSE_TIME                DATETIME      ,				
WORK_CLOSE_USER_ID             VARCHAR (50)    ,				
CREATE_TIME                    DATETIME      ,				
CREATE_USER_ID                 VARCHAR (50)    ,				
UPDATE_TIME                    DATETIME      ,				
UPDATE_USER_ID                 VARCHAR (50)    				
);

EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �۾����� �ڵ�', 'USER', DBO, 'TABLE', WORK_ORDER_MST,'COLUMN',WORK_ORDER_ID									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�۾� ����', 'USER', DBO, 'TABLE', WORK_ORDER_MST,'COLUMN',ORDER_DATE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� ��ǰ�ڵ�, ǰ��', 'USER', DBO, 'TABLE', WORK_ORDER_MST,'COLUMN',PRODUCT_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �ڵ�', 'USER', DBO, 'TABLE', WORK_ORDER_MST,'COLUMN',CUSTOMER_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '��ȹ ����', 'USER', DBO, 'TABLE', WORK_ORDER_MST,'COLUMN',ORDER_QTY									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� ����. ���� : OPEN, ���� �� : PROC, ���� : CLOSE', 'USER', DBO, 'TABLE', WORK_ORDER_MST,'COLUMN',ORDER_STATUS									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� ����', 'USER', DBO, 'TABLE', WORK_ORDER_MST,'COLUMN',PRODUCT_QTY									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�ҷ� ����', 'USER', DBO, 'TABLE', WORK_ORDER_MST,'COLUMN',DEFECT_QTY									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�۾� ���� �ð�', 'USER', DBO, 'TABLE', WORK_ORDER_MST,'COLUMN',WORK_START_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� ���� �ð�', 'USER', DBO, 'TABLE', WORK_ORDER_MST,'COLUMN',WORK_CLOSE_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� ������', 'USER', DBO, 'TABLE', WORK_ORDER_MST,'COLUMN',WORK_CLOSE_USER_ID									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�۾����� ���� �ð�', 'USER', DBO, 'TABLE', WORK_ORDER_MST,'COLUMN',CREATE_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�۾����� ���� �����', 'USER', DBO, 'TABLE', WORK_ORDER_MST,'COLUMN',CREATE_USER_ID									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�۾����� ���� �ð�', 'USER', DBO, 'TABLE', WORK_ORDER_MST,'COLUMN',UPDATE_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�۾����� ���� �����', 'USER', DBO, 'TABLE', WORK_ORDER_MST,'COLUMN',UPDATE_USER_ID									

 CREATE TABLE OPERATION_MST (				
OPERATION_CODE                 VARCHAR (50)    ,				
OPERATION_NAME                 VARCHAR (1000)    ,				
CHECK_DEFECT_FLAG              CHAR (1)    ,				
CHECK_INSPECT_FLAG             CHAR (1)    ,				
CHECK_MATERIAL_FLAG            CHAR (1)    ,				
CREATE_TIME                    DATETIME      ,				
CREATE_USER_ID                 VARCHAR (50)    ,				
UPDATE_TIME                    DATETIME      ,				
UPDATE_USER_ID                 VARCHAR (50)    				
);

EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �ڵ�', 'USER', DBO, 'TABLE', OPERATION_MST,'COLUMN',OPERATION_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '������', 'USER', DBO, 'TABLE', OPERATION_MST,'COLUMN',OPERATION_NAME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�ҷ� �Է� üũ ����. ��üũ : null, üũ : Y', 'USER', DBO, 'TABLE', OPERATION_MST,'COLUMN',CHECK_DEFECT_FLAG									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�˻� ������ �Է� üũ ����. ��üũ : null, üũ : Y', 'USER', DBO, 'TABLE', OPERATION_MST,'COLUMN',CHECK_INSPECT_FLAG									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� ��� üũ ����. ��üũ : null, üũ : Y', 'USER', DBO, 'TABLE', OPERATION_MST,'COLUMN',CHECK_MATERIAL_FLAG									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �ð�', 'USER', DBO, 'TABLE', OPERATION_MST,'COLUMN',CREATE_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �����', 'USER', DBO, 'TABLE', OPERATION_MST,'COLUMN',CREATE_USER_ID									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �ð�', 'USER', DBO, 'TABLE', OPERATION_MST,'COLUMN',UPDATE_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �����', 'USER', DBO, 'TABLE', OPERATION_MST,'COLUMN',UPDATE_USER_ID									

CREATE TABLE PRODUCT_MST (				
PRODUCT_CODE                   VARCHAR (50)    ,				
PRODUCT_NAME                   VARCHAR (1000)    ,				
PRODUCT_TYPE                   VARCHAR (10)    ,				
CUSTOMER_CODE                  VARCHAR (50)    ,				
VENDOR_CODE                    VARCHAR (50)    ,				
CREATE_TIME                    DATETIME      ,				
CREATE_USER_ID                 VARCHAR (50)    ,				
UPDATE_TIME                    DATETIME      ,				
UPDATE_USER_ID                 VARCHAR (50)    				
);

EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '��ǰ �ڵ�, ǰ��', 'USER', DBO, 'TABLE', PRODUCT_MST,'COLUMN',PRODUCT_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '��ǰ��, ǰ��', 'USER', DBO, 'TABLE', PRODUCT_MST,'COLUMN',PRODUCT_NAME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'ǰ�� ����, ����ǰ : FERT, ����ǰ : HALB, ������ : ROH', 'USER', DBO, 'TABLE', PRODUCT_MST,'COLUMN',PRODUCT_TYPE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '����ǰ�� ��� ���ڵ�', 'USER', DBO, 'TABLE', PRODUCT_MST,'COLUMN',CUSTOMER_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�������� ��� ��ǰ��ü �ڵ�', 'USER', DBO, 'TABLE', PRODUCT_MST,'COLUMN',VENDOR_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �ð�', 'USER', DBO, 'TABLE', PRODUCT_MST,'COLUMN',CREATE_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �����', 'USER', DBO, 'TABLE', PRODUCT_MST,'COLUMN',CREATE_USER_ID									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �ð�', 'USER', DBO, 'TABLE', PRODUCT_MST,'COLUMN',UPDATE_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �����', 'USER', DBO, 'TABLE', PRODUCT_MST,'COLUMN',UPDATE_USER_ID									

CREATE TABLE PRODUCT_OPERATION_REL (					
PRODUCT_CODE                   VARCHAR (50)    ,					
OPERATION_CODE                 VARCHAR (1000)    ,					
FLOW_SEQ                       NUMERIC (5)    ,					
CREATE_TIME                    DATETIME      ,					
CREATE_USER_ID                 VARCHAR (50)    ,					
UPDATE_TIME                    DATETIME      	,				
UPDATE_USER_ID                 VARCHAR (50)    					
);
									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '��ǰ �ڵ�, ǰ��', 'USER', DBO, 'TABLE', PRODUCT_OPERATION_REL,'COLUMN',PRODUCT_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� ����', 'USER', DBO, 'TABLE', PRODUCT_OPERATION_REL,'COLUMN',OPERATION_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�����帧 ����', 'USER', DBO, 'TABLE', PRODUCT_OPERATION_REL,'COLUMN',FLOW_SEQ									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �ð�', 'USER', DBO, 'TABLE', PRODUCT_OPERATION_REL,'COLUMN',CREATE_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �����', 'USER', DBO, 'TABLE', PRODUCT_OPERATION_REL,'COLUMN',CREATE_USER_ID									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �ð�', 'USER', DBO, 'TABLE', PRODUCT_OPERATION_REL,'COLUMN',UPDATE_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �����', 'USER', DBO, 'TABLE', PRODUCT_OPERATION_REL,'COLUMN',UPDATE_USER_ID									

CREATE TABLE BOM_MST (				
PRODUCT_CODE                   VARCHAR (50)    ,				
CHILD_PRODUCT_CODE             VARCHAR (50)    ,				
REQUIRE_QTY                    NUMERIC (10,3)    ,				
ALTER_PRODUCT_CODE             VARCHAR (50)    ,				
CREATE_TIME                    DATETIME      ,				
CREATE_USER_ID                 VARCHAR (50)    ,				
UPDATE_TIME                    DATETIME      	,			
UPDATE_USER_ID                 VARCHAR (50)    				
);
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '��ǰ �ڵ�, ǰ��', 'USER', DBO, 'TABLE', BOM_MST,'COLUMN',PRODUCT_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '��ǰ��', 'USER', DBO, 'TABLE', BOM_MST,'COLUMN',CHILD_PRODUCT_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� ����', 'USER', DBO, 'TABLE', BOM_MST,'COLUMN',REQUIRE_QTY									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '��ü ǰ��', 'USER', DBO, 'TABLE', BOM_MST,'COLUMN',ALTER_PRODUCT_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �ð�', 'USER', DBO, 'TABLE', BOM_MST,'COLUMN',CREATE_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �����', 'USER', DBO, 'TABLE', BOM_MST,'COLUMN',CREATE_USER_ID									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �ð�', 'USER', DBO, 'TABLE', BOM_MST,'COLUMN',UPDATE_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �����', 'USER', DBO, 'TABLE', BOM_MST,'COLUMN',UPDATE_USER_ID									

CREATE TABLE STORE_MST (				
STORE_CODE                     VARCHAR (50)    ,				
STORE_NAME                     VARCHAR (50)    ,				
STORE_TYPE                     VARCHAR (50)    ,				
FIFO_FLAG                      CHAR (1)    ,				
CREATE_TIME                    DATETIME      ,				
CREATE_USER_ID                 VARCHAR (50)    ,				
UPDATE_TIME                    DATETIME      	,			
UPDATE_USER_ID                 VARCHAR (50)    				
);

EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'â�� �ڵ�', 'USER', DBO, 'TABLE', STORE_MST,'COLUMN',STORE_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'â���', 'USER', DBO, 'TABLE', STORE_MST,'COLUMN',STORE_NAME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'â�� Ÿ��. ������â�� : RS, ����ǰâ�� : HS, ����ǰâ�� : FS', 'USER', DBO, 'TABLE', STORE_MST,'COLUMN',STORE_TYPE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���Լ��⿩��. �̼��Լ��� : null, ���Լ��� : Y', 'USER', DBO, 'TABLE', STORE_MST,'COLUMN',FIFO_FLAG									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �ð�', 'USER', DBO, 'TABLE', STORE_MST,'COLUMN',CREATE_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �����', 'USER', DBO, 'TABLE', STORE_MST,'COLUMN',CREATE_USER_ID									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �ð�', 'USER', DBO, 'TABLE', STORE_MST,'COLUMN',UPDATE_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �����', 'USER', DBO, 'TABLE', STORE_MST,'COLUMN',UPDATE_USER_ID									

CREATE TABLE SAFE_STOCK_MST (				
CHILD_PRODUCT_CODE             VARCHAR (50)    ,				
STORE_CODE                     VARCHAR (50)    ,				
SAFE_QTY                       NUMERIC (10,3)    ,				
CREATE_TIME                    DATETIME      ,				
CREATE_USER_ID                 VARCHAR (50)    ,				
UPDATE_TIME                    DATETIME      	,			
UPDATE_USER_ID                 VARCHAR (50)    				
);

EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '��ǰ��', 'USER', DBO, 'TABLE', SAFE_STOCK_MST,'COLUMN',CHILD_PRODUCT_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'â�� �ڵ�', 'USER', DBO, 'TABLE', SAFE_STOCK_MST,'COLUMN',STORE_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '������� ����', 'USER', DBO, 'TABLE', SAFE_STOCK_MST,'COLUMN',SAFE_QTY									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �ð�', 'USER', DBO, 'TABLE', SAFE_STOCK_MST,'COLUMN',CREATE_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �����', 'USER', DBO, 'TABLE', SAFE_STOCK_MST,'COLUMN',CREATE_USER_ID									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �ð�', 'USER', DBO, 'TABLE', SAFE_STOCK_MST,'COLUMN',UPDATE_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �����', 'USER', DBO, 'TABLE', SAFE_STOCK_MST,'COLUMN',UPDATE_USER_ID									

CREATE TABLE EQUIPMENT_MST (				
EQUIPMENT_CODE                 VARCHAR (50)    ,				
EQUIPMENT_NAME                 VARCHAR (1000)    ,				
EQUIPMENT_TYPE                 VARCHAR (50)    ,				
EQUIPMENT_STATUS               VARCHAR (10)    ,				
LAST_DOWN_TIME                 DATETIME      ,				
CREATE_TIME                    DATETIME      ,				
CREATE_USER_ID                 VARCHAR (50)    ,				
UPDATE_TIME                    DATETIME      ,				
UPDATE_USER_ID                 VARCHAR (50)    				
);
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�����ڵ�', 'USER', DBO, 'TABLE', EQUIPMENT_MST,'COLUMN',EQUIPMENT_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�����', 'USER', DBO, 'TABLE', EQUIPMENT_MST,'COLUMN',EQUIPMENT_NAME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� ����. ��� : EQUIP, ���� : TOOL, ������ : INSP', 'USER', DBO, 'TABLE', EQUIPMENT_MST,'COLUMN',EQUIPMENT_TYPE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� ����. ���� : PROC, ����񰡵� : DOWN, �Ϲݺ񰡵� : WAIT', 'USER', DBO, 'TABLE', EQUIPMENT_MST,'COLUMN',EQUIPMENT_STATUS									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�ֱ� ����񰡵� �ð�', 'USER', DBO, 'TABLE', EQUIPMENT_MST,'COLUMN',LAST_DOWN_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �ð�', 'USER', DBO, 'TABLE', EQUIPMENT_MST,'COLUMN',CREATE_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �����', 'USER', DBO, 'TABLE', EQUIPMENT_MST,'COLUMN',CREATE_USER_ID									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �ð�', 'USER', DBO, 'TABLE', EQUIPMENT_MST,'COLUMN',UPDATE_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �����', 'USER', DBO, 'TABLE', EQUIPMENT_MST,'COLUMN',UPDATE_USER_ID									

CREATE TABLE EQUIPMENT_OPERATION_REL (				
OPERATION_CODE                 VARCHAR (50)    ,				
EQUIPMENT_CODE                 VARCHAR (50)    ,				
CREATE_TIME                    DATETIME      ,				
CREATE_USER_ID                 VARCHAR (50)    ,				
UPDATE_TIME                    DATETIME      ,				
UPDATE_USER_ID                 VARCHAR (50)    				
);

EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�����ڵ�', 'USER', DBO, 'TABLE', EQUIPMENT_OPERATION_REL,'COLUMN',OPERATION_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�����ڵ�', 'USER', DBO, 'TABLE', EQUIPMENT_OPERATION_REL,'COLUMN',EQUIPMENT_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �ð�', 'USER', DBO, 'TABLE', EQUIPMENT_OPERATION_REL,'COLUMN',CREATE_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �����', 'USER', DBO, 'TABLE', EQUIPMENT_OPERATION_REL,'COLUMN',CREATE_USER_ID									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �ð�', 'USER', DBO, 'TABLE', EQUIPMENT_OPERATION_REL,'COLUMN',UPDATE_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �����', 'USER', DBO, 'TABLE', EQUIPMENT_OPERATION_REL,'COLUMN',UPDATE_USER_ID									

CREATE TABLE INSPECT_ITEM_MST (				
INSPECT_ITEM_CODE              VARCHAR (50)    ,				
INSPECT_ITEM_NAME              VARCHAR (1000)    ,				
VALUE_TYPE                     CHAR (1)    ,				
SPEC_LSL                       VARCHAR (50)    ,				
SPEC_TARGET                    VARCHAR (50)    ,				
SPEC_USL                       VARCHAR (50)    ,				
CREATE_TIME                    DATETIME      ,				
CREATE_USER_ID                 VARCHAR (50)    ,				
UPDATE_TIME                    DATETIME      ,				
UPDATE_USER_ID                 VARCHAR (50)    				
);			
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�˻��׸� �ڵ�', 'USER', DBO, 'TABLE', INSPECT_ITEM_MST,'COLUMN',INSPECT_ITEM_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�˻��׸��', 'USER', DBO, 'TABLE', INSPECT_ITEM_MST,'COLUMN',INSPECT_ITEM_NAME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�˻� ������ ����. ���� : C, ���� : N', 'USER', DBO, 'TABLE', INSPECT_ITEM_MST,'COLUMN',VALUE_TYPE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� ���Ѱ�', 'USER', DBO, 'TABLE', INSPECT_ITEM_MST,'COLUMN',SPEC_LSL									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� Ÿ�ٰ�', 'USER', DBO, 'TABLE', INSPECT_ITEM_MST,'COLUMN',SPEC_TARGET									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� ���Ѱ�', 'USER', DBO, 'TABLE', INSPECT_ITEM_MST,'COLUMN',SPEC_USL									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �ð�', 'USER', DBO, 'TABLE', INSPECT_ITEM_MST,'COLUMN',CREATE_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �����', 'USER', DBO, 'TABLE', INSPECT_ITEM_MST,'COLUMN',CREATE_USER_ID									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �ð�', 'USER', DBO, 'TABLE', INSPECT_ITEM_MST,'COLUMN',UPDATE_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �����', 'USER', DBO, 'TABLE', INSPECT_ITEM_MST,'COLUMN',UPDATE_USER_ID									

CREATE TABLE INSPECT_ITEM_OPERATION_REL (				
OPERATION_CODE                 VARCHAR (50)    ,				
INSPECT_ITEM_CODE              VARCHAR (50)    ,				
CREATE_TIME                    DATETIME      ,				
CREATE_USER_ID                 VARCHAR (50)    ,				
UPDATE_TIME                    DATETIME      ,				
UPDATE_USER_ID                 VARCHAR (50)    				
);			

EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�����ڵ�', 'USER', DBO, 'TABLE', INSPECT_ITEM_OPERATION_REL,'COLUMN',OPERATION_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�˻��׸� �ڵ�', 'USER', DBO, 'TABLE', INSPECT_ITEM_OPERATION_REL,'COLUMN',INSPECT_ITEM_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �ð�', 'USER', DBO, 'TABLE', INSPECT_ITEM_OPERATION_REL,'COLUMN',CREATE_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �����', 'USER', DBO, 'TABLE', INSPECT_ITEM_OPERATION_REL,'COLUMN',CREATE_USER_ID									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �ð�', 'USER', DBO, 'TABLE', INSPECT_ITEM_OPERATION_REL,'COLUMN',UPDATE_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �����', 'USER', DBO, 'TABLE', INSPECT_ITEM_OPERATION_REL,'COLUMN',UPDATE_USER_ID									

CREATE TABLE USER_GROUP_MST (				
USER_GROUP_CODE                VARCHAR (50)    ,				
USER_GROUP_NAME                VARCHAR (50)    ,				
USER_GROUP_TYPE                VARCHAR (50)    ,				
CREATE_TIME                    DATETIME      ,				
CREATE_USER_ID                 VARCHAR (50)    ,				
UPDATE_TIME                    DATETIME      ,				
UPDATE_USER_ID                 VARCHAR (50)    				
);

EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '����� �׷��ڵ�', 'USER', DBO, 'TABLE', USER_GROUP_MST,'COLUMN',USER_GROUP_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '����� �׷��', 'USER', DBO, 'TABLE', USER_GROUP_MST,'COLUMN',USER_GROUP_NAME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '����� �׷� ����', 'USER', DBO, 'TABLE', USER_GROUP_MST,'COLUMN',USER_GROUP_TYPE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �ð�', 'USER', DBO, 'TABLE', USER_GROUP_MST,'COLUMN',CREATE_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �����', 'USER', DBO, 'TABLE', USER_GROUP_MST,'COLUMN',CREATE_USER_ID									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �ð�', 'USER', DBO, 'TABLE', USER_GROUP_MST,'COLUMN',UPDATE_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �����', 'USER', DBO, 'TABLE', USER_GROUP_MST,'COLUMN',UPDATE_USER_ID									

CREATE TABLE USER_MST (				
USER_ID                        VARCHAR (50)    ,				
USER_NAME                      VARCHAR (50)    ,				
USER_GROUP_CODE                VARCHAR (50)    ,				
USER_PASSWORD                  VARCHAR (50)    ,				
USER_DEPARTMENT                VARCHAR (50)    ,				
CREATE_TIME                    DATETIME      ,				
CREATE_USER_ID                 VARCHAR (50)    ,				
UPDATE_TIME                    DATETIME      ,				
UPDATE_USER_ID                 VARCHAR (50)    				
);

EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�α��� ����� ID', 'USER', DBO, 'TABLE', USER_MST,'COLUMN',USER_ID									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '����ڸ�', 'USER', DBO, 'TABLE', USER_MST,'COLUMN',USER_NAME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '����� �׷� �ڵ�', 'USER', DBO, 'TABLE', USER_MST,'COLUMN',USER_GROUP_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '����� ��ȣ', 'USER', DBO, 'TABLE', USER_MST,'COLUMN',USER_PASSWORD									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '����� �μ�', 'USER', DBO, 'TABLE', USER_MST,'COLUMN',USER_DEPARTMENT									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �ð�', 'USER', DBO, 'TABLE', USER_MST,'COLUMN',CREATE_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �����', 'USER', DBO, 'TABLE', USER_MST,'COLUMN',CREATE_USER_ID									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �ð�', 'USER', DBO, 'TABLE', USER_MST,'COLUMN',UPDATE_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �����', 'USER', DBO, 'TABLE', USER_MST,'COLUMN',UPDATE_USER_ID									


CREATE TABLE FUNCTION_MST (				
FUNCTION_CODE                  VARCHAR (50)    ,				
FUNCTION_NAME                  VARCHAR (50)    ,				
SHORT_CUT_KEY                  VARCHAR (50)    ,				
ICON_INDEX                     NUMERIC (5)    ,				
CREATE_TIME                    DATETIME      ,				
CREATE_USER_ID                 VARCHAR (50)    ,				
UPDATE_TIME                    DATETIME      	,			
UPDATE_USER_ID                 VARCHAR (50)    				
);

EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'ȭ�� ��� �ڵ�', 'USER', DBO, 'TABLE', FUNCTION_MST,'COLUMN',FUNCTION_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'ȭ�� ��ɸ�', 'USER', DBO, 'TABLE', FUNCTION_MST,'COLUMN',FUNCTION_NAME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '����Ű', 'USER', DBO, 'TABLE', FUNCTION_MST,'COLUMN',SHORT_CUT_KEY									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '������ �ε���', 'USER', DBO, 'TABLE', FUNCTION_MST,'COLUMN',ICON_INDEX									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �ð�', 'USER', DBO, 'TABLE', FUNCTION_MST,'COLUMN',CREATE_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �����', 'USER', DBO, 'TABLE', FUNCTION_MST,'COLUMN',CREATE_USER_ID									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �ð�', 'USER', DBO, 'TABLE', FUNCTION_MST,'COLUMN',UPDATE_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �����', 'USER', DBO, 'TABLE', FUNCTION_MST,'COLUMN',UPDATE_USER_ID									

CREATE TABLE FUNCTION_USER_GROUP_REL (				
USER_GROUP_CODE                VARCHAR (50)    ,				
FUNCTION_CODE                  VARCHAR (50)    ,				
CREATE_TIME                    DATETIME      ,				
CREATE_USER_ID                 VARCHAR (50)    ,				
UPDATE_TIME                    DATETIME      ,				
UPDATE_USER_ID                 VARCHAR (50)    				
);
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '����� �׷� �ڵ�', 'USER', DBO, 'TABLE', FUNCTION_USER_GROUP_REL,'COLUMN',USER_GROUP_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'ȭ�� ��� �ڵ�', 'USER', DBO, 'TABLE', FUNCTION_USER_GROUP_REL,'COLUMN',FUNCTION_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �ð�', 'USER', DBO, 'TABLE', FUNCTION_USER_GROUP_REL,'COLUMN',CREATE_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �����', 'USER', DBO, 'TABLE', FUNCTION_USER_GROUP_REL,'COLUMN',CREATE_USER_ID									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �ð�', 'USER', DBO, 'TABLE', FUNCTION_USER_GROUP_REL,'COLUMN',UPDATE_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �����', 'USER', DBO, 'TABLE', FUNCTION_USER_GROUP_REL,'COLUMN',UPDATE_USER_ID									

CREATE TABLE CODE_TABLE_MST (				
CODE_TABLE_NAME                VARCHAR (50)    ,				
CODE_TABLE_DESC                VARCHAR (1000)    ,				
KEY_1_NAME                     VARCHAR (100)    ,				
KEY_2_NAME                     VARCHAR (100)    ,				
KEY_3_NAME                     VARCHAR (100)    ,				
DATA_1_NAME                    VARCHAR (100)    ,				
DATA_2_NAME                    VARCHAR (100)    ,				
DATA_3_NAME                    VARCHAR (100)    ,				
DATA_4_NAME                    VARCHAR (100)    ,				
DATA_5_NAME                    VARCHAR (100)    ,				
CREATE_TIME                    DATETIME      ,				
CREATE_USER_ID                 VARCHAR (50)    ,				
UPDATE_TIME                    DATETIME      ,				
UPDATE_USER_ID                 VARCHAR (50)    				
);

EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�ڵ� ���̺��', 'USER', DBO, 'TABLE', CODE_TABLE_MST,'COLUMN',CODE_TABLE_NAME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���̺� ����', 'USER', DBO, 'TABLE', CODE_TABLE_MST,'COLUMN',CODE_TABLE_DESC									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'Ű 1 �̸�', 'USER', DBO, 'TABLE', CODE_TABLE_MST,'COLUMN',KEY_1_NAME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'Ű 2 �̸�', 'USER', DBO, 'TABLE', CODE_TABLE_MST,'COLUMN',KEY_2_NAME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'Ű 3 �̸�', 'USER', DBO, 'TABLE', CODE_TABLE_MST,'COLUMN',KEY_3_NAME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '������ 1 �̸�', 'USER', DBO, 'TABLE', CODE_TABLE_MST,'COLUMN',DATA_1_NAME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '������ 2 �̸�', 'USER', DBO, 'TABLE', CODE_TABLE_MST,'COLUMN',DATA_2_NAME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '������ 3 �̸�', 'USER', DBO, 'TABLE', CODE_TABLE_MST,'COLUMN',DATA_3_NAME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '������ 4 �̸�', 'USER', DBO, 'TABLE', CODE_TABLE_MST,'COLUMN',DATA_4_NAME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '������ 5 �̸�', 'USER', DBO, 'TABLE', CODE_TABLE_MST,'COLUMN',DATA_5_NAME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �ð�', 'USER', DBO, 'TABLE', CODE_TABLE_MST,'COLUMN',CREATE_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �����', 'USER', DBO, 'TABLE', CODE_TABLE_MST,'COLUMN',CREATE_USER_ID									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �ð�', 'USER', DBO, 'TABLE', CODE_TABLE_MST,'COLUMN',UPDATE_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �����', 'USER', DBO, 'TABLE', CODE_TABLE_MST,'COLUMN',UPDATE_USER_ID									

CREATE TABLE CODE_DATA_MST (				
CODE_TABLE_NAME                VARCHAR (50)    ,				
KEY_1                          VARCHAR (50)    ,				
KEY_2                          VARCHAR (100)    ,				
KEY_3                          VARCHAR (100)    ,				
DATA_1                         VARCHAR (1000)    ,				
DATA_2                         VARCHAR (1000)    ,				
DATA_3                         VARCHAR (1000)    ,				
DATA_4                         VARCHAR (1000)    ,				
DATA_5                         VARCHAR (1000)    ,				
DISPLAY_SEQ                    NUMERIC (5)    ,				
CREATE_TIME                    DATETIME      ,				
CREATE_USER_ID                 VARCHAR (50)    ,				
UPDATE_TIME                    DATETIME      ,				
UPDATE_USER_ID                 VARCHAR (50)    				
);			

EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�ڵ� ���̺��', 'USER', DBO, 'TABLE', CODE_DATA_MST,'COLUMN',CODE_TABLE_NAME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'Ű 1 ��', 'USER', DBO, 'TABLE', CODE_DATA_MST,'COLUMN',KEY_1									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'Ű 2 ��', 'USER', DBO, 'TABLE', CODE_DATA_MST,'COLUMN',KEY_2									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'Ű 3 ��', 'USER', DBO, 'TABLE', CODE_DATA_MST,'COLUMN',KEY_3									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '������ 1 ��', 'USER', DBO, 'TABLE', CODE_DATA_MST,'COLUMN',DATA_1									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '������ 2 ��', 'USER', DBO, 'TABLE', CODE_DATA_MST,'COLUMN',DATA_2									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '������ 3 ��', 'USER', DBO, 'TABLE', CODE_DATA_MST,'COLUMN',DATA_3									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '������ 4 ��', 'USER', DBO, 'TABLE', CODE_DATA_MST,'COLUMN',DATA_4									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '������ 5 ��', 'USER', DBO, 'TABLE', CODE_DATA_MST,'COLUMN',DATA_5									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�� ǥ�� ����', 'USER', DBO, 'TABLE', CODE_DATA_MST,'COLUMN',DISPLAY_SEQ									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �ð�', 'USER', DBO, 'TABLE', CODE_DATA_MST,'COLUMN',CREATE_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �����', 'USER', DBO, 'TABLE', CODE_DATA_MST,'COLUMN',CREATE_USER_ID									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �ð�', 'USER', DBO, 'TABLE', CODE_DATA_MST,'COLUMN',UPDATE_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �����', 'USER', DBO, 'TABLE', CODE_DATA_MST,'COLUMN',UPDATE_USER_ID									

CREATE TABLE MESSAGE_MST (				
MESSAGE_CODE                   VARCHAR (50)    ,				
MESSAGE_TYPE                   VARCHAR (10)    ,				
MESSAGE_KOR                    NVARCHAR (1000)    ,				
MESSAGE_ENG                    NVARCHAR (1000)    ,				
CREATE_TIME                    DATETIME      ,				
CREATE_USER_ID                 VARCHAR (50)    ,				
UPDATE_TIME                    DATETIME      ,				
UPDATE_USER_ID                 VARCHAR (50)    				
);

EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�޽��� �ڵ�', 'USER', DBO, 'TABLE', MESSAGE_MST,'COLUMN',MESSAGE_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�޽��� ����. Error : E, Information : I, Warning : W', 'USER', DBO, 'TABLE', MESSAGE_MST,'COLUMN',MESSAGE_TYPE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�ѱ� �޽���', 'USER', DBO, 'TABLE', MESSAGE_MST,'COLUMN',MESSAGE_KOR									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �޽���', 'USER', DBO, 'TABLE', MESSAGE_MST,'COLUMN',MESSAGE_ENG									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �ð�', 'USER', DBO, 'TABLE', MESSAGE_MST,'COLUMN',CREATE_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �����', 'USER', DBO, 'TABLE', MESSAGE_MST,'COLUMN',CREATE_USER_ID									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �ð�', 'USER', DBO, 'TABLE', MESSAGE_MST,'COLUMN',UPDATE_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �����', 'USER', DBO, 'TABLE', MESSAGE_MST,'COLUMN',UPDATE_USER_ID									

CREATE TABLE DICTIONARY_MST (				
DICTIONARY_CODE                VARCHAR (50)    ,				
DICTIONARY_KOR                 NVARCHAR (100)    ,				
DICTIONARY_ENG                 NVARCHAR (100)    ,				
CREATE_TIME                    DATETIME      ,				
CREATE_USER_ID                 VARCHAR (50)    ,				
UPDATE_TIME                    DATETIME      	,			
UPDATE_USER_ID                 VARCHAR (50)    				
);
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�ٱ��� �ڵ�', 'USER', DBO, 'TABLE', DICTIONARY_MST,'COLUMN',DICTIONARY_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�ѱ� �ٱ���', 'USER', DBO, 'TABLE', DICTIONARY_MST,'COLUMN',DICTIONARY_KOR									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �ٱ���', 'USER', DBO, 'TABLE', DICTIONARY_MST,'COLUMN',DICTIONARY_ENG									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �ð�', 'USER', DBO, 'TABLE', DICTIONARY_MST,'COLUMN',CREATE_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �����', 'USER', DBO, 'TABLE', DICTIONARY_MST,'COLUMN',CREATE_USER_ID									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �ð�', 'USER', DBO, 'TABLE', DICTIONARY_MST,'COLUMN',UPDATE_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �����', 'USER', DBO, 'TABLE', DICTIONARY_MST,'COLUMN',UPDATE_USER_ID									

CREATE TABLE LOT_STS (				
LOT_ID                         VARCHAR (50)    ,				
LOT_DESC                       VARCHAR (1000)    ,				
PRODUCT_CODE                   VARCHAR (50)    ,				
OPERATION_CODE                 VARCHAR (50)    ,				
STORE_CODE                     VARCHAR (50)    ,				
LOT_QTY                        NUMERIC (10,3)    ,				
CREATE_QTY                     NUMERIC (10,3)    ,				
OPER_IN_QTY                    NUMERIC (10,3)    ,				
START_FLAG                     CHAR (1)    ,				
START_QTY                      NUMERIC (10,3)    ,				
START_TIME                     DATETIME      ,				
START_EQUIPMENT_CODE           VARCHAR (50)    ,				
END_FLAG                       CHAR (1)    ,				
END_TIME                       DATETIME      ,				
END_EQUIPMENT_CODE             VARCHAR (50)    ,				
SHIP_FLAG                      CHAR (1)    ,				
SHIP_CODE                      VARCHAR (50)    ,				
SHIP_TIME                      DATETIME      ,				
PRODUCTION_TIME                DATETIME      ,				
CREATE_TIME                    DATETIME      ,				
OPER_IN_TIME                   DATETIME      ,				
WORK_ORDER_ID                  VARCHAR (50)    ,				
LOT_DELETE_FLAG                CHAR (1)    ,				
LOT_DELETE_CODE                VARCHAR (50)    ,				
LOT_DELETE_TIME                DATETIME      ,				
LAST_TRAN_CODE                 VARCHAR (50)    ,				
LAST_TRAN_TIME                 DATETIME      ,				
LAST_TRAN_USER_ID              VARCHAR (50)    ,				
LAST_TRAN_COMMENT              VARCHAR (1000)    ,				
LAST_HIST_SEQ                  NUMERIC (5)    				
);
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'LOT ID. ������, ����ǰ, ����ǰ�� ��� LOT ID', 'USER', DBO, 'TABLE', LOT_STS,'COLUMN',LOT_ID									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'LOT ����', 'USER', DBO, 'TABLE', LOT_STS,'COLUMN',LOT_DESC									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'ǰ��. �������� ��� ������ ǰ��, ����ǰ�� ����ǰ ǰ��, ����ǰ�� ����ǰ ǰ���� ����', 'USER', DBO, 'TABLE', LOT_STS,'COLUMN',PRODUCT_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �ڵ�. ���� ���� ��� ���� �ڵ带 ����', 'USER', DBO, 'TABLE', LOT_STS,'COLUMN',OPERATION_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'â�� �ڵ�. â�� �� ��� â�� �ڵ带 ����', 'USER', DBO, 'TABLE', LOT_STS,'COLUMN',STORE_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'LOT ����', 'USER', DBO, 'TABLE', LOT_STS,'COLUMN',LOT_QTY									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'LOT ���� �� ����', 'USER', DBO, 'TABLE', LOT_STS,'COLUMN',CREATE_QTY									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'LOT �� ���� ���Եɶ��� ����', 'USER', DBO, 'TABLE', LOT_STS,'COLUMN',OPER_IN_QTY									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'LOT ���� �۾� ���� ����', 'USER', DBO, 'TABLE', LOT_STS,'COLUMN',START_FLAG									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�۾� ���� �� ����', 'USER', DBO, 'TABLE', LOT_STS,'COLUMN',START_QTY									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�۾� ���� �ð�', 'USER', DBO, 'TABLE', LOT_STS,'COLUMN',START_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�۾� ���� ����', 'USER', DBO, 'TABLE', LOT_STS,'COLUMN',START_EQUIPMENT_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'LOT ���� �۾� �Ϸ� ����', 'USER', DBO, 'TABLE', LOT_STS,'COLUMN',END_FLAG									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�۾� �Ϸ� �ð�', 'USER', DBO, 'TABLE', LOT_STS,'COLUMN',END_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�۾� �Ϸ� ����', 'USER', DBO, 'TABLE', LOT_STS,'COLUMN',END_EQUIPMENT_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� ����', 'USER', DBO, 'TABLE', LOT_STS,'COLUMN',SHIP_FLAG									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �ڵ�', 'USER', DBO, 'TABLE', LOT_STS,'COLUMN',SHIP_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �ð�', 'USER', DBO, 'TABLE', LOT_STS,'COLUMN',SHIP_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'LOT ���� ����. �������� ��� ��ǰ��ü������ ���� �ð�, ����ǰ�� ��� ����ǰ �۾� �Ϸ� �ð�', 'USER', DBO, 'TABLE', LOT_STS,'COLUMN',PRODUCTION_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'LOT ���� �ð�', 'USER', DBO, 'TABLE', LOT_STS,'COLUMN',CREATE_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'LOT �� ���� ���Եɶ��� �ð�', 'USER', DBO, 'TABLE', LOT_STS,'COLUMN',OPER_IN_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�۾�����', 'USER', DBO, 'TABLE', LOT_STS,'COLUMN',WORK_ORDER_ID									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'LOT ���� ����', 'USER', DBO, 'TABLE', LOT_STS,'COLUMN',LOT_DELETE_FLAG									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'LOT ���� �ڵ�', 'USER', DBO, 'TABLE', LOT_STS,'COLUMN',LOT_DELETE_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'LOT ���� �ð�', 'USER', DBO, 'TABLE', LOT_STS,'COLUMN',LOT_DELETE_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '������ ó�� �ڵ�', 'USER', DBO, 'TABLE', LOT_STS,'COLUMN',LAST_TRAN_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '������ ó�� �ð�', 'USER', DBO, 'TABLE', LOT_STS,'COLUMN',LAST_TRAN_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '������ ó�� �����', 'USER', DBO, 'TABLE', LOT_STS,'COLUMN',LAST_TRAN_USER_ID									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '������ ó�� �ּ�', 'USER', DBO, 'TABLE', LOT_STS,'COLUMN',LAST_TRAN_COMMENT									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '������ �̷� ����', 'USER', DBO, 'TABLE', LOT_STS,'COLUMN',LAST_HIST_SEQ									
CREATE TABLE LOT_HIS (				
LOT_ID                         VARCHAR (50)    ,				
HIST_SEQ                       NUMERIC (10)    ,				
TRAN_TIME                      DATETIME      ,				
TRAN_CODE                      VARCHAR (50)    ,				
LOT_DESC                       VARCHAR (1000)    ,				
PRODUCT_CODE                   VARCHAR (50)    ,				
OPERATION_CODE                 VARCHAR (50)    ,				
STORE_CODE                     VARCHAR (50)    ,				
LOT_QTY                        NUMERIC (10,3)    ,				
CREATE_QTY                     NUMERIC (10,3)    ,				
OPER_IN_QTY                    NUMERIC (10,3)    ,				
START_FLAG                     CHAR (1)    ,				
START_QTY                      NUMERIC (10,3)    ,				
START_TIME                     DATETIME      ,				
START_EQUIPMENT_CODE           VARCHAR (50)    ,				
END_FLAG                       CHAR (1)    ,				
END_TIME                       DATETIME      ,				
END_EQUIPMENT_CODE             VARCHAR (50)    ,				
SHIP_FLAG                      CHAR (1)    ,				
SHIP_CODE                      VARCHAR (50)    ,				
SHIP_TIME                      DATETIME      ,				
PRODUCTION_TIME                DATETIME      ,				
CREATE_TIME                    DATETIME      ,				
OPER_IN_TIME                   DATETIME      ,				
WORK_ORDER_ID                  VARCHAR (50)    ,				
LOT_DELETE_FLAG                CHAR (1)    ,				
LOT_DELETE_CODE                VARCHAR (50)    ,				
LOT_DELETE_TIME                DATETIME      ,				
TRAN_USER_ID                   VARCHAR (50)    ,				
TRAN_COMMENT                   VARCHAR (1000)    ,				
OLD_PRODUCT_CODE               NUMERIC (5)    ,				
OLD_OPERATION_CODE             VARCHAR (50)    ,				
OLD_STORE_CODE                 VARCHAR (50)    ,				
OLD_LOT_QTY                    NUMERIC (10,3)    				
);

EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'LOT ID. ������, ����ǰ, ����ǰ�� ��� LOT ID', 'USER', DBO, 'TABLE', LOT_HIS,'COLUMN',LOT_ID									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�̷� ����', 'USER', DBO, 'TABLE', LOT_HIS,'COLUMN',HIST_SEQ									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'ó�� �ð�', 'USER', DBO, 'TABLE', LOT_HIS,'COLUMN',TRAN_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'ó�� �ڵ�', 'USER', DBO, 'TABLE', LOT_HIS,'COLUMN',TRAN_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'LOT ����', 'USER', DBO, 'TABLE', LOT_HIS,'COLUMN',LOT_DESC									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'ǰ��. �������� ��� ������ ǰ��, ����ǰ�� ����ǰ ǰ��, ����ǰ�� ����ǰ ǰ���� ����', 'USER', DBO, 'TABLE', LOT_HIS,'COLUMN',PRODUCT_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �ڵ�. ���� ���� ��� ���� �ڵ带 ����', 'USER', DBO, 'TABLE', LOT_HIS,'COLUMN',OPERATION_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'â�� �ڵ�. â�� �� ��� â�� �ڵ带 ����', 'USER', DBO, 'TABLE', LOT_HIS,'COLUMN',STORE_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'LOT ����', 'USER', DBO, 'TABLE', LOT_HIS,'COLUMN',LOT_QTY									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'LOT ���� �� ����', 'USER', DBO, 'TABLE', LOT_HIS,'COLUMN',CREATE_QTY									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'LOT �� ���� ���Եɶ��� ����', 'USER', DBO, 'TABLE', LOT_HIS,'COLUMN',OPER_IN_QTY									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'LOT ���� �۾� ���� ����', 'USER', DBO, 'TABLE', LOT_HIS,'COLUMN',START_FLAG									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�۾� ���� �� ����', 'USER', DBO, 'TABLE', LOT_HIS,'COLUMN',START_QTY									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�۾� ���� �ð�', 'USER', DBO, 'TABLE', LOT_HIS,'COLUMN',START_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�۾� ���� ����', 'USER', DBO, 'TABLE', LOT_HIS,'COLUMN',START_EQUIPMENT_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'LOT ���� �۾� �Ϸ� ����', 'USER', DBO, 'TABLE', LOT_HIS,'COLUMN',END_FLAG									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�۾� �Ϸ� �ð�', 'USER', DBO, 'TABLE', LOT_HIS,'COLUMN',END_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�۾� �Ϸ� ����', 'USER', DBO, 'TABLE', LOT_HIS,'COLUMN',END_EQUIPMENT_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� ����', 'USER', DBO, 'TABLE', LOT_HIS,'COLUMN',SHIP_FLAG									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �ڵ�', 'USER', DBO, 'TABLE', LOT_HIS,'COLUMN',SHIP_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �ð�', 'USER', DBO, 'TABLE', LOT_HIS,'COLUMN',SHIP_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'LOT ���� ����. �������� ��� ��ǰ��ü������ ���� �ð�, ����ǰ�� ��� ����ǰ �۾� �Ϸ� �ð�', 'USER', DBO, 'TABLE', LOT_HIS,'COLUMN',PRODUCTION_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'LOT ���� �ð�', 'USER', DBO, 'TABLE', LOT_HIS,'COLUMN',CREATE_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'LOT �� ���� ���Եɶ��� �ð�', 'USER', DBO, 'TABLE', LOT_HIS,'COLUMN',OPER_IN_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�۾�����', 'USER', DBO, 'TABLE', LOT_HIS,'COLUMN',WORK_ORDER_ID									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'LOT ���� ����', 'USER', DBO, 'TABLE', LOT_HIS,'COLUMN',LOT_DELETE_FLAG									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'LOT ���� �ڵ�', 'USER', DBO, 'TABLE', LOT_HIS,'COLUMN',LOT_DELETE_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'LOT ���� �ð�', 'USER', DBO, 'TABLE', LOT_HIS,'COLUMN',LOT_DELETE_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'ó�� �����', 'USER', DBO, 'TABLE', LOT_HIS,'COLUMN',TRAN_USER_ID									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'ó�� �ּ�', 'USER', DBO, 'TABLE', LOT_HIS,'COLUMN',TRAN_COMMENT									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �̷��� ǰ��', 'USER', DBO, 'TABLE', LOT_HIS,'COLUMN',OLD_PRODUCT_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �̷��� ����', 'USER', DBO, 'TABLE', LOT_HIS,'COLUMN',OLD_OPERATION_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �̷��� â��', 'USER', DBO, 'TABLE', LOT_HIS,'COLUMN',OLD_STORE_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �̷��� LOT ����', 'USER', DBO, 'TABLE', LOT_HIS,'COLUMN',OLD_LOT_QTY									

CREATE TABLE LOT_DEFECT_HIS (				
LOT_ID                         VARCHAR (50)    ,				
HIST_SEQ                       NUMERIC (10)    ,				
DEFECT_CODE                    VARCHAR (50)    ,				
DEFECT_QTY                     NUMERIC (10,3)    ,				
TRAN_TIME                      DATETIME      ,				
TRAN_CODE                      VARCHAR (50)    ,				
PRODUCT_CODE                   VARCHAR (50)    ,				
OPERATION_CODE                 VARCHAR (50)    ,				
STORE_CODE                     VARCHAR (50)    ,				
EQUIPMENT_CODE                 VARCHAR (50)    ,				
TRAN_USER_ID                   VARCHAR (50)    ,				
TRAN_COMMENT                   VARCHAR (1000)    				
);
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'LOT ID. ������, ����ǰ, ����ǰ�� ��� LOT ID', 'USER', DBO, 'TABLE', LOT_DEFECT_HIS,'COLUMN',LOT_ID									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�̷� ����', 'USER', DBO, 'TABLE', LOT_DEFECT_HIS,'COLUMN',HIST_SEQ									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�ҷ� �ڵ�', 'USER', DBO, 'TABLE', LOT_DEFECT_HIS,'COLUMN',DEFECT_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�ҷ� ����', 'USER', DBO, 'TABLE', LOT_DEFECT_HIS,'COLUMN',DEFECT_QTY									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'ó�� �ð�', 'USER', DBO, 'TABLE', LOT_DEFECT_HIS,'COLUMN',TRAN_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'ó�� �ڵ�', 'USER', DBO, 'TABLE', LOT_DEFECT_HIS,'COLUMN',TRAN_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'ǰ��. �������� ��� ������ ǰ��, ����ǰ�� ����ǰ ǰ��, ����ǰ�� ����ǰ ǰ���� ����', 'USER', DBO, 'TABLE', LOT_DEFECT_HIS,'COLUMN',PRODUCT_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �ڵ�. ���� ���� ��� ���� �ڵ带 ����', 'USER', DBO, 'TABLE', LOT_DEFECT_HIS,'COLUMN',OPERATION_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'â�� �ڵ�. â�� �� ��� â�� �ڵ带 ����', 'USER', DBO, 'TABLE', LOT_DEFECT_HIS,'COLUMN',STORE_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �ڵ�', 'USER', DBO, 'TABLE', LOT_DEFECT_HIS,'COLUMN',EQUIPMENT_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'ó�� �����', 'USER', DBO, 'TABLE', LOT_DEFECT_HIS,'COLUMN',TRAN_USER_ID									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'ó�� �ּ�', 'USER', DBO, 'TABLE', LOT_DEFECT_HIS,'COLUMN',TRAN_COMMENT									

CREATE TABLE LOT_INSPECT_HIS (				
LOT_ID                         VARCHAR (50)    ,				
HIST_SEQ                       NUMERIC (10)    ,				
INSPECT_ITEM_CODE              VARCHAR (50)    ,				
INSPECT_ITEM_NAME              VARCHAR (1000)    ,				
VALUE_TYPE                     CHAR (1)    ,				
SPEC_LSL                       VARCHAR (50)    ,				
SPEC_TARGET                    VARCHAR (50)    ,				
SPEC_USL                       VARCHAR (50)    ,				
INSPECT_VALUE                  VARCHAR (100)    ,				
INSPECT_RESULT                 VARCHAR (50)    ,				
TRAN_TIME                      DATETIME      ,				
TRAN_CODE                      VARCHAR (50)    ,				
PRODUCT_CODE                   VARCHAR (50)    ,				
OPERATION_CODE                 VARCHAR (50)    ,				
STORE_CODE                     VARCHAR (50)    ,				
EQUIPMENT_CODE                 VARCHAR (50)    ,				
TRAN_USER_ID                   VARCHAR (50)    ,				
TRAN_COMMENT                   VARCHAR (1000)    				
);

EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'LOT ID. ������, ����ǰ, ����ǰ�� ��� LOT ID', 'USER', DBO, 'TABLE', LOT_INSPECT_HIS,'COLUMN',LOT_ID									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�̷� ����', 'USER', DBO, 'TABLE', LOT_INSPECT_HIS,'COLUMN',HIST_SEQ									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�˻� �׸� �ڵ�', 'USER', DBO, 'TABLE', LOT_INSPECT_HIS,'COLUMN',INSPECT_ITEM_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�˻� �׸��', 'USER', DBO, 'TABLE', LOT_INSPECT_HIS,'COLUMN',INSPECT_ITEM_NAME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�˻� ������ ����. ���� : C, ���� : N', 'USER', DBO, 'TABLE', LOT_INSPECT_HIS,'COLUMN',VALUE_TYPE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� ���Ѱ�', 'USER', DBO, 'TABLE', LOT_INSPECT_HIS,'COLUMN',SPEC_LSL									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� Ÿ�ٰ�', 'USER', DBO, 'TABLE', LOT_INSPECT_HIS,'COLUMN',SPEC_TARGET									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� ���Ѱ�', 'USER', DBO, 'TABLE', LOT_INSPECT_HIS,'COLUMN',SPEC_USL									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�˻� ������ ��', 'USER', DBO, 'TABLE', LOT_INSPECT_HIS,'COLUMN',INSPECT_VALUE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�˻� ���. OK/NG', 'USER', DBO, 'TABLE', LOT_INSPECT_HIS,'COLUMN',INSPECT_RESULT									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'ó�� �ð�', 'USER', DBO, 'TABLE', LOT_INSPECT_HIS,'COLUMN',TRAN_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'ó�� �ڵ�', 'USER', DBO, 'TABLE', LOT_INSPECT_HIS,'COLUMN',TRAN_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'ǰ��. �������� ��� ������ ǰ��, ����ǰ�� ����ǰ ǰ��, ����ǰ�� ����ǰ ǰ���� ����', 'USER', DBO, 'TABLE', LOT_INSPECT_HIS,'COLUMN',PRODUCT_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �ڵ�. ���� ���� ��� ���� �ڵ带 ����', 'USER', DBO, 'TABLE', LOT_INSPECT_HIS,'COLUMN',OPERATION_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'â�� �ڵ�. â�� �� ��� â�� �ڵ带 ����', 'USER', DBO, 'TABLE', LOT_INSPECT_HIS,'COLUMN',STORE_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �ڵ�', 'USER', DBO, 'TABLE', LOT_INSPECT_HIS,'COLUMN',EQUIPMENT_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'ó�� �����', 'USER', DBO, 'TABLE', LOT_INSPECT_HIS,'COLUMN',TRAN_USER_ID									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'ó�� �ּ�', 'USER', DBO, 'TABLE', LOT_INSPECT_HIS,'COLUMN',TRAN_COMMENT									

CREATE TABLE LOT_MATERIAL_HIS (				
LOT_ID                         VARCHAR (50)    ,				
HIST_SEQ                       NUMERIC (10)    ,				
MATERIAL_LOT_ID                VARCHAR (50)    ,				
MATERIAL_LOT_HIST_SEQ          NUMERIC (10)    ,				
INPUT_QTY                      VARCHAR (1000)    ,				
CHILD_PRODUCT_CODE             VARCHAR (50)    ,				
MATERIAL_STORE_CODE            VARCHAR (50)    ,				
TRAN_TIME                      DATETIME      ,				
TRAN_CODE                      VARCHAR (50)    ,				
PRODUCT_CODE                   VARCHAR (50)    ,				
OPERATION_CODE                 VARCHAR (50)    ,				
EQUIPMENT_CODE                 VARCHAR (50)    ,				
TRAN_USER_ID                   VARCHAR (50)    ,				
TRAN_COMMENT                   VARCHAR (1000)    				
);
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'LOT ID. ������, ����ǰ, ����ǰ�� ��� LOT ID', 'USER', DBO, 'TABLE', LOT_MATERIAL_HIS,'COLUMN',LOT_ID									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�̷� ����', 'USER', DBO, 'TABLE', LOT_MATERIAL_HIS,'COLUMN',HIST_SEQ									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� LOT ID', 'USER', DBO, 'TABLE', LOT_MATERIAL_HIS,'COLUMN',MATERIAL_LOT_ID									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� LOT �̷� ����', 'USER', DBO, 'TABLE', LOT_MATERIAL_HIS,'COLUMN',MATERIAL_LOT_HIST_SEQ									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� ��� ����', 'USER', DBO, 'TABLE', LOT_MATERIAL_HIS,'COLUMN',INPUT_QTY									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� ǰ��', 'USER', DBO, 'TABLE', LOT_MATERIAL_HIS,'COLUMN',CHILD_PRODUCT_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� LOT �� ��ġ�� â�� �ڵ�', 'USER', DBO, 'TABLE', LOT_MATERIAL_HIS,'COLUMN',MATERIAL_STORE_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'ó�� �ð�', 'USER', DBO, 'TABLE', LOT_MATERIAL_HIS,'COLUMN',TRAN_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'ó�� �ڵ�', 'USER', DBO, 'TABLE', LOT_MATERIAL_HIS,'COLUMN',TRAN_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'ǰ��. �������� ��� ������ ǰ��, ����ǰ�� ����ǰ ǰ��, ����ǰ�� ����ǰ ǰ���� ����', 'USER', DBO, 'TABLE', LOT_MATERIAL_HIS,'COLUMN',PRODUCT_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �ڵ�. ���� ���� ��� ���� �ڵ带 ����', 'USER', DBO, 'TABLE', LOT_MATERIAL_HIS,'COLUMN',OPERATION_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �ڵ�', 'USER', DBO, 'TABLE', LOT_MATERIAL_HIS,'COLUMN',EQUIPMENT_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'ó�� �����', 'USER', DBO, 'TABLE', LOT_MATERIAL_HIS,'COLUMN',TRAN_USER_ID									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'ó�� �ּ�', 'USER', DBO, 'TABLE', LOT_MATERIAL_HIS,'COLUMN',TRAN_COMMENT									

CREATE TABLE LOT_END_HIS (				
LOT_ID                         VARCHAR (50)    ,				
HIST_SEQ                       NUMERIC (10)    ,				
TRAN_TIME                      DATETIME      ,				
TRAN_CODE                      VARCHAR (50)    ,				
PRODUCT_CODE                   VARCHAR (50)    ,				
OPERATION_CODE                 VARCHAR (50)    ,				
EQUIPMENT_CODE                 VARCHAR (50)    ,				
TRAN_USER_ID                   VARCHAR (50)    ,				
TRAN_COMMENT                   VARCHAR (1000)    ,				
TO_OPERATION_CODE              VARCHAR (50)    ,				
OPER_IN_QTY                    NUMERIC (10,3)    ,				
START_QTY                      NUMERIC (10,3)    ,				
END_QTY                        NUMERIC (10,3)    ,				
OPER_IN_TIME                   DATETIME      ,				
START_TIME                     DATETIME      ,				
PROC_TIME                      NUMERIC (5)    ,				
WORK_ORDER_ID                  VARCHAR (50)    				
);
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'LOT ID. ������, ����ǰ, ����ǰ�� ��� LOT ID', 'USER', DBO, 'TABLE', LOT_END_HIS,'COLUMN',LOT_ID									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�̷� ����', 'USER', DBO, 'TABLE', LOT_END_HIS,'COLUMN',HIST_SEQ									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'ó�� �ð�', 'USER', DBO, 'TABLE', LOT_END_HIS,'COLUMN',TRAN_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'ó�� �ڵ�', 'USER', DBO, 'TABLE', LOT_END_HIS,'COLUMN',TRAN_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'ǰ��. �������� ��� ������ ǰ��, ����ǰ�� ����ǰ ǰ��, ����ǰ�� ����ǰ ǰ���� ����', 'USER', DBO, 'TABLE', LOT_END_HIS,'COLUMN',PRODUCT_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'LOT �۾� �Ϸ� ����', 'USER', DBO, 'TABLE', LOT_END_HIS,'COLUMN',OPERATION_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�۾� �Ϸ� ���� �ڵ�', 'USER', DBO, 'TABLE', LOT_END_HIS,'COLUMN',EQUIPMENT_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'ó�� �����', 'USER', DBO, 'TABLE', LOT_END_HIS,'COLUMN',TRAN_USER_ID									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'ó�� �ּ�', 'USER', DBO, 'TABLE', LOT_END_HIS,'COLUMN',TRAN_COMMENT									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�۾� �Ϸ�Ǿ� �̵��� ���� �ڵ�', 'USER', DBO, 'TABLE', LOT_END_HIS,'COLUMN',TO_OPERATION_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'LOT �� ���� ���Եɶ��� ����', 'USER', DBO, 'TABLE', LOT_END_HIS,'COLUMN',OPER_IN_QTY									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�۾� ���� �� ����', 'USER', DBO, 'TABLE', LOT_END_HIS,'COLUMN',START_QTY									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�۾� �Ϸ� �� ����', 'USER', DBO, 'TABLE', LOT_END_HIS,'COLUMN',END_QTY									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'LOT �� ���� ���Եɶ��� �ð�', 'USER', DBO, 'TABLE', LOT_END_HIS,'COLUMN',OPER_IN_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�۾� ���� �ð�', 'USER', DBO, 'TABLE', LOT_END_HIS,'COLUMN',START_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�۾� �Ϸ� ���������� �� �۾� �ð�(��)', 'USER', DBO, 'TABLE', LOT_END_HIS,'COLUMN',PROC_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�۾�����', 'USER', DBO, 'TABLE', LOT_END_HIS,'COLUMN',WORK_ORDER_ID									

CREATE TABLE EQUIP_DOWN_HIS (				
EQUIPMENT_CODE                 VARCHAR (50)    ,				
DT_DATE                        VARCHAR (8)    ,				
DT_START_TIME                  DATETIME      ,				
DT_END_TIME                    DATETIME      ,				
DT_TIME                        NUMERIC (5)    ,				
DT_CODE                        VARCHAR (50)    ,				
DT_COMMENT                     VARCHAR (1000)    ,				
DT_USER_ID                     VARCHAR (50)    ,				
ACTION_COMMENT                 VARCHAR (1000)    ,				
CONFIRM_TIME                   DATETIME      ,				
CONFIRM_USER_ID                VARCHAR (50)    				
);

EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '���� �ڵ�', 'USER', DBO, 'TABLE', EQUIP_DOWN_HIS,'COLUMN',EQUIPMENT_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�񰡵� ����', 'USER', DBO, 'TABLE', EQUIP_DOWN_HIS,'COLUMN',DT_DATE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�񰡵� ���� �ð�', 'USER', DBO, 'TABLE', EQUIP_DOWN_HIS,'COLUMN',DT_START_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�񰡵� ���� �ð�', 'USER', DBO, 'TABLE', EQUIP_DOWN_HIS,'COLUMN',DT_END_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�񰡵� �ð�(��)', 'USER', DBO, 'TABLE', EQUIP_DOWN_HIS,'COLUMN',DT_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�񰡵� �ڵ�', 'USER', DBO, 'TABLE', EQUIP_DOWN_HIS,'COLUMN',DT_CODE									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�񰡵� �ּ�', 'USER', DBO, 'TABLE', EQUIP_DOWN_HIS,'COLUMN',DT_COMMENT									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '�񰡵� �����', 'USER', DBO, 'TABLE', EQUIP_DOWN_HIS,'COLUMN',DT_USER_ID									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', '��ġ ����', 'USER', DBO, 'TABLE', EQUIP_DOWN_HIS,'COLUMN',ACTION_COMMENT									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'Ȯ�� �ð�', 'USER', DBO, 'TABLE', EQUIP_DOWN_HIS,'COLUMN',CONFIRM_TIME									
EXEC SP_ADDEXTENDEDPROPERTY 'MS_Description', 'Ȯ����', 'USER', DBO, 'TABLE', EQUIP_DOWN_HIS,'COLUMN',CONFIRM_USER_ID									
