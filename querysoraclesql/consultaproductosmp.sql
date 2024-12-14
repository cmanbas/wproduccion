SELECT   SAP_BOM.MATNR,  
       SUBSTR(SAP_BOM.MATNR, 1, 2) AS CODPAIS,
        SUBSTR(SAP_BOM.MATNR, 3) AS CODBAGOBOM,
                    ( SELECT   MAKTX FROM  SAP_MATERIALES  SP WHERE SP.MATNR  = SAP_BOM.MATNR ) DESCPRODUCTO,
                    NVL( ( select  tiprod from tablas.foprte where SUBSTR(CODTERM, 1, INSTR(CODTERM, '-') - 1)   =  SUBSTR(SAP_BOM.MATNR, 3) )   ,'S/I')  TIPOPRODUCTO,
 
				   SAP_BOM.IDNRK  AS GRANEL,
                   SAP_BOM.MAKTX  AS DESCGRANEL, 

				   SAP_BOM.POSNR,
				   SAP_BOM.MEINS, 
				   SAP_BOM.MENGE, 
				   SAP_BOM.AUSCH, 
				   SAP_MATERIALES.PAIS_EXPORTACION, 
				   SAP_MATERIALES.BSTFE, 
                   SAP_MATERIALES.IPRKZ,
				   SAP_MATERIALES.MHDHB, 
				   SAP_MATERIALES.BSTMA,
				   SAP_MATERIALES.BWART  

FROM     SAP_BOM   SAP_BOM  INNER JOIN 
                  SAP_MATERIALES ON SAP_BOM.IDNRK = SAP_MATERIALES.MATNR
                  where SAP_BOM.MAKTX like '%GLICENEX%' 
                  ; 
                  
                  
                  
   select  * from tablas.foprte where  nomterm like '%GLICENEX 850%'  
   SELECT SUBSTR('808040-2', 1, INSTR('808040-2', '-') - 1) AS parte_antes_del_guion,
       SUBSTR('22808040', 1, 2) AS pais,
    SUBSTR('22808040', 3) AS codigo_producto
FROM dual;
   
   codterm ='2823222' tiprod = 'CP'          
  select * from cl_equivalencia  where codclbago = 108037     