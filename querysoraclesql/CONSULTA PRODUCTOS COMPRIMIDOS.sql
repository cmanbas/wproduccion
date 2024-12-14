SELECT  SAP_BOM.MATNR,  
               
                       SUBSTR(SAP_BOM.MATNR, 1, 2) AS CODPAIS,
                     SUBSTR(SAP_BOM.MATNR, -6) AS CODBAGO,
                   SAP_M2.MAKTX DESCPRODUCTO,
 				   SAP_BOM.IDNRK  AS GRANEL,
                   SAP_BOM.MAKTX  AS DESCGRANEL, 
				   SAP_BOM.POSNR,
				   SAP_BOM.MEINS, 
				   FLOOR(SAP_BOM.MENGE) COMPRIMIDOS, 
				   SAP_BOM.AUSCH, 
				   SAP_MATERIALES.PAIS_EXPORTACION, 
				   SAP_MATERIALES.BSTFE * 1000 UNIDXLOTE, 
    CASE 
        WHEN SAP_BOM.MENGE <> 0 THEN FLOOR((SAP_MATERIALES.BSTFE * 1000) / SAP_BOM.MENGE)
        ELSE 0 
    END AS CANTBLISTER, 
                   SAP_MATERIALES.IPRKZ,
				   SAP_MATERIALES.MHDHB, 
				   SAP_MATERIALES.BSTMA,
				  
                   SAP_M2.BWART
FROM     SAP_BOM INNER JOIN 
                  SAP_MATERIALES ON SAP_BOM.IDNRK = SAP_MATERIALES.MATNR
		INNER JOIN  SAP_MATERIALES SAP_M2  ON  SAP_BOM.MATNR  = SAP_M2.MATNR
        
        AND SUBSTR(SAP_BOM.MATNR, -6) IN ( SELECT SUBSTR(CODPROD, 1, 6)  FROM tablas.foprte WHERE  tiprod = 'CP' )
        ORDER BY 1
        
     --   AND  SUBSTR(SAP_BOM.MATNR, 1, 2) = 10
        
        
 select  SUBSTR(CODPROD, 1, 6) , foprte.* from tablas.foprte where tiprod = 'CP'