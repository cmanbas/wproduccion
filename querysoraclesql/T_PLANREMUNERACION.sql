--------------------------------------------------------
--  DDL for Table T_PLANREMUNERACION
--------------------------------------------------------

  CREATE TABLE "REMUNE"."T_PLANREMUNERACION" 
   (	"VERSION" NUMBER(10,0), 
	"CODINTERNOGERENCIA" NUMBER(10,0), 
	"CODITEM" NUMBER(10,0), 
	"ENERO" NUMBER(16,2), 
	"FEBRERO" NUMBER(16,2), 
	"MARZO" NUMBER(16,2), 
	"ABRIL" NUMBER(16,2), 
	"MAYO" NUMBER(16,2), 
	"JUNIO" NUMBER(16,2), 
	"JULIO" NUMBER(16,2), 
	"AGOSTO" NUMBER(16,2), 
	"SEPTIEMBRE" NUMBER(16,2), 
	"OCTUBRE" NUMBER(16,2), 
	"NOVIEMBRE" NUMBER(16,2), 
	"DICIEMBRE" NUMBER(16,2)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "REMUNETS" ;