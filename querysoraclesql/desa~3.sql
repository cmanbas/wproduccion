
  CREATE OR REPLACE FORCE VIEW "FACTURAS"."V_KAM_CLIENTE" ("USR_CORRELATIVO", "USR_COD", "CLRAZON", "CLRUT", "CLDIGRUT", "CLCODIGO", "CODSAP", "USR_OBSERVACION", "USR_FECHACREACION", "RUTCOMPLETO") AS 
  SELECT TUSERCLI.USR_CORRELATIVO,  TUSERCLI.USR_COD,      CLI.CLRAZON, CLI.CLRUT,CLI.CLDIGRUT,  CLI.CLCODIGO,  
 CODSAP , TUSERCLI.USR_OBSERVACION, TUSERCLI.USR_FECHACREACION, CLI.CLRUT ||'-'||CLI.CLDIGRUT RUTCOMPLETO
FROM  
ccclie.clientes CLI , 
T_USER_CLIENTE TUSERCLI, 
CL_EQUIVALENCIA CLE
WHERE CLI.clcodigo = TUSERCLI.CLCODIGO and  substr(CLI.codinteli,4,1) = 1
AND CLE.codclbago  = TUSERCLI.CLCODIGO;
 