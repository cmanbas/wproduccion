
CREATE TABLE "FACTURAS"."T_VENTASUNIPPTO_RAS" 
   (	"AGNOMES" VARCHAR2(6 BYTE), 
	"CODIGO" VARCHAR2(50 BYTE), 
	"CODIGOSAP" VARCHAR2(50 BYTE), 
	"DESCRIPCION" VARCHAR2(255 BYTE), 
	"VALOR" NUMBER(10,2), 
	"CAMPO1" NUMBER(10,0), 
	"CAMPO2" NUMBER(10,0), 
	"AGNO" NUMBER(4,0), 
	"MES" NUMBER(2,0), 
	"PAIS" NUMBER(2,0)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "FACTURASTS" ;
 
