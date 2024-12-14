 
   
INSERT INTO FACTURAS.T_VENTASUNIPPTO_RAS
(AGNOMES, CODIGO,CODIGOSAP, DESCRIPCION, VALOR, CAMPO1, CAMPO2, AGNO, MES, PAIS)
SELECT 
    TO_CHAR(detocexp.DETFECSOL, 'YYYYMM') AS ANOMES,
    SUBSTR(detocexp.DETPROD, 1, INSTR(detocexp.DETPROD, '-') - 1) AS CODIGO,
    NVL((SELECT NVL(a.codterm,' ') FROM tablas.foprtesap a 
         WHERE substr(a.codterm,3,6) = substr(foprte.codterm,1,6)), ' ') AS CODIGOSAP,
    foprte.NOMTERM AS DESCRIPCION,
    detocexp.DETCANT AS VALOR,
    0 AS CAMPO1,
    0 AS CAMPO2,
    EXTRACT(YEAR FROM detocexp.DETFECSOL) AS AGNO,
    EXTRACT(MONTH FROM detocexp.DETFECSOL) AS MES,
    ocexp.OCPAIS AS PAIS
FROM 
    ocexp ocexp
JOIN 
    detocexp detocexp ON ocexp.OCNUM = detocexp.DETOCNUM
JOIN 
    foprte ON detocexp.DETPROD = foprte.codterm
WHERE 
    EXTRACT(YEAR FROM detocexp.DETFECSOL) IN (2023, 2024, 2025)
ORDER BY 
    ocexp.OCPAIS, detocexp.DETFECSOL DESC, foprte.nomterm;
 