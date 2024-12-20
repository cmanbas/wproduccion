SELECT 
    0 AS UBICACION, 
    'VENTAS_PRODUCCION' AS tipo, CODIGO,
    CODIGO || '-' || DESCRIPCION AS PRODUCTO,
    -- A�o 2023
    SUM(CASE WHEN ANOMES = '202301' THEN VALOR ELSE 0 END) AS "202301",
    SUM(CASE WHEN ANOMES = '202302' THEN VALOR ELSE 0 END) AS "202302",
    SUM(CASE WHEN ANOMES = '202303' THEN VALOR ELSE 0 END) AS "202303",
    SUM(CASE WHEN ANOMES = '202304' THEN VALOR ELSE 0 END) AS "202304",
    SUM(CASE WHEN ANOMES = '202305' THEN VALOR ELSE 0 END) AS "202305",
    SUM(CASE WHEN ANOMES = '202306' THEN VALOR ELSE 0 END) AS "202306",
    SUM(CASE WHEN ANOMES = '202307' THEN VALOR ELSE 0 END) AS "202307",
    SUM(CASE WHEN ANOMES = '202308' THEN VALOR ELSE 0 END) AS "202308",
    SUM(CASE WHEN ANOMES = '202309' THEN VALOR ELSE 0 END) AS "202309",
    SUM(CASE WHEN ANOMES = '202310' THEN VALOR ELSE 0 END) AS "202310",
    SUM(CASE WHEN ANOMES = '202311' THEN VALOR ELSE 0 END) AS "202311",
    SUM(CASE WHEN ANOMES = '202312' THEN VALOR ELSE 0 END) AS "202312",
    -- A�o 2024
    SUM(CASE WHEN ANOMES = '202401' THEN VALOR ELSE 0 END) AS "202401",
    SUM(CASE WHEN ANOMES = '202402' THEN VALOR ELSE 0 END) AS "202402",
    SUM(CASE WHEN ANOMES = '202403' THEN VALOR ELSE 0 END) AS "202403",
    SUM(CASE WHEN ANOMES = '202404' THEN VALOR ELSE 0 END) AS "202404",
    SUM(CASE WHEN ANOMES = '202405' THEN VALOR ELSE 0 END) AS "202405",
    SUM(CASE WHEN ANOMES = '202406' THEN VALOR ELSE 0 END) AS "202406",
    SUM(CASE WHEN ANOMES = '202407' THEN VALOR ELSE 0 END) AS "202407",
    SUM(CASE WHEN ANOMES = '202408' THEN VALOR ELSE 0 END) AS "202408",
    SUM(CASE WHEN ANOMES = '202409' THEN VALOR ELSE 0 END) AS "202409",
    SUM(CASE WHEN ANOMES = '202410' THEN VALOR ELSE 0 END) AS "202410",
    SUM(CASE WHEN ANOMES = '202411' THEN VALOR ELSE 0 END) AS "202411",
    SUM(CASE WHEN ANOMES = '202412' THEN VALOR ELSE 0 END) AS "202412",
    -- A�o 2025
    SUM(CASE WHEN ANOMES = '202501' THEN VALOR ELSE 0 END) AS "202501",
    SUM(CASE WHEN ANOMES = '202502' THEN VALOR ELSE 0 END) AS "202502",
    SUM(CASE WHEN ANOMES = '202503' THEN VALOR ELSE 0 END) AS "202503",
    SUM(CASE WHEN ANOMES = '202504' THEN VALOR ELSE 0 END) AS "202504",
    SUM(CASE WHEN ANOMES = '202505' THEN VALOR ELSE 0 END) AS "202505",
    SUM(CASE WHEN ANOMES = '202506' THEN VALOR ELSE 0 END) AS "202506",
    SUM(CASE WHEN ANOMES = '202507' THEN VALOR ELSE 0 END) AS "202507",
    SUM(CASE WHEN ANOMES = '202508' THEN VALOR ELSE 0 END) AS "202508",
    SUM(CASE WHEN ANOMES = '202509' THEN VALOR ELSE 0 END) AS "202509",
    SUM(CASE WHEN ANOMES = '202510' THEN VALOR ELSE 0 END) AS "202510",
    SUM(CASE WHEN ANOMES = '202511' THEN VALOR ELSE 0 END) AS "202511",
    SUM(CASE WHEN ANOMES = '202512' THEN VALOR ELSE 0 END) AS "202512"
FROM 
    FACTURAS.T_VENTAS_PRODUCCION
GROUP BY 
    CODIGO, DESCRIPCION
    
UNION ALL
 SELECT 
    3 AS UBICACION, 
    'STOCK REAL' AS tipo, 
    CODIGO || '-' || DESCRIPCION AS PRODUCTO,
    -- A�o 2023
    SUM(CASE WHEN ANOMES = '202301' THEN VALOR ELSE 0 END) AS "202301",
    SUM(CASE WHEN ANOMES = '202302' THEN VALOR ELSE 0 END) AS "202302",
    SUM(CASE WHEN ANOMES = '202303' THEN VALOR ELSE 0 END) AS "202303",
    SUM(CASE WHEN ANOMES = '202304' THEN VALOR ELSE 0 END) AS "202304",
    SUM(CASE WHEN ANOMES = '202305' THEN VALOR ELSE 0 END) AS "202305",
    SUM(CASE WHEN ANOMES = '202306' THEN VALOR ELSE 0 END) AS "202306",
    SUM(CASE WHEN ANOMES = '202307' THEN VALOR ELSE 0 END) AS "202307",
    SUM(CASE WHEN ANOMES = '202308' THEN VALOR ELSE 0 END) AS "202308",
    SUM(CASE WHEN ANOMES = '202309' THEN VALOR ELSE 0 END) AS "202309",
    SUM(CASE WHEN ANOMES = '202310' THEN VALOR ELSE 0 END) AS "202310",
    SUM(CASE WHEN ANOMES = '202311' THEN VALOR ELSE 0 END) AS "202311",
    SUM(CASE WHEN ANOMES = '202312' THEN VALOR ELSE 0 END) AS "202312",
    -- A�o 2024
    SUM(CASE WHEN ANOMES = '202401' THEN VALOR ELSE 0 END) AS "202401",
    SUM(CASE WHEN ANOMES = '202402' THEN VALOR ELSE 0 END) AS "202402",
    SUM(CASE WHEN ANOMES = '202403' THEN VALOR ELSE 0 END) AS "202403",
    SUM(CASE WHEN ANOMES = '202404' THEN VALOR ELSE 0 END) AS "202404",
    SUM(CASE WHEN ANOMES = '202405' THEN VALOR ELSE 0 END) AS "202405",
    SUM(CASE WHEN ANOMES = '202406' THEN VALOR ELSE 0 END) AS "202406",
    SUM(CASE WHEN ANOMES = '202407' THEN VALOR ELSE 0 END) AS "202407",
    SUM(CASE WHEN ANOMES = '202408' THEN VALOR ELSE 0 END) AS "202408",
    SUM(CASE WHEN ANOMES = '202409' THEN VALOR ELSE 0 END) AS "202409",
    SUM(CASE WHEN ANOMES = '202410' THEN VALOR ELSE 0 END) AS "202410",
    SUM(CASE WHEN ANOMES = '202411' THEN VALOR ELSE 0 END) AS "202411",
    SUM(CASE WHEN ANOMES = '202412' THEN VALOR ELSE 0 END) AS "202412",
    -- A�o 2025
    SUM(CASE WHEN ANOMES = '202501' THEN VALOR ELSE 0 END) AS "202501",
    SUM(CASE WHEN ANOMES = '202502' THEN VALOR ELSE 0 END) AS "202502",
    SUM(CASE WHEN ANOMES = '202503' THEN VALOR ELSE 0 END) AS "202503",
    SUM(CASE WHEN ANOMES = '202504' THEN VALOR ELSE 0 END) AS "202504",
    SUM(CASE WHEN ANOMES = '202505' THEN VALOR ELSE 0 END) AS "202505",
    SUM(CASE WHEN ANOMES = '202506' THEN VALOR ELSE 0 END) AS "202506",
    SUM(CASE WHEN ANOMES = '202507' THEN VALOR ELSE 0 END) AS "202507",
    SUM(CASE WHEN ANOMES = '202508' THEN VALOR ELSE 0 END) AS "202508",
    SUM(CASE WHEN ANOMES = '202509' THEN VALOR ELSE 0 END) AS "202509",
    SUM(CASE WHEN ANOMES = '202510' THEN VALOR ELSE 0 END) AS "202510",
    SUM(CASE WHEN ANOMES = '202511' THEN VALOR ELSE 0 END) AS "202511",
    SUM(CASE WHEN ANOMES = '202512' THEN VALOR ELSE 0 END) AS "202512"
FROM 
    FACTURAS.T_STOCKREAL_PRODUCCION
GROUP BY 
    CODIGO, DESCRIPCION
UNION ALL
SELECT 
    2 AS UBICACION, 
    'SALIDAS PRODUCCION' AS tipo, 
    CODIGO || '-' || DESCRIPCION AS PRODUCTO,
    -- A�o 2023
    SUM(CASE WHEN ANOMES = '202301' THEN MOVIMIENTO ELSE 0 END) AS "202301",
    SUM(CASE WHEN ANOMES = '202302' THEN MOVIMIENTO ELSE 0 END) AS "202302",
    SUM(CASE WHEN ANOMES = '202303' THEN MOVIMIENTO ELSE 0 END) AS "202303",
    SUM(CASE WHEN ANOMES = '202304' THEN MOVIMIENTO ELSE 0 END) AS "202304",
    SUM(CASE WHEN ANOMES = '202305' THEN MOVIMIENTO ELSE 0 END) AS "202305",
    SUM(CASE WHEN ANOMES = '202306' THEN MOVIMIENTO ELSE 0 END) AS "202306",
    SUM(CASE WHEN ANOMES = '202307' THEN MOVIMIENTO ELSE 0 END) AS "202307",
    SUM(CASE WHEN ANOMES = '202308' THEN MOVIMIENTO ELSE 0 END) AS "202308",
    SUM(CASE WHEN ANOMES = '202309' THEN MOVIMIENTO ELSE 0 END) AS "202309",
    SUM(CASE WHEN ANOMES = '202310' THEN MOVIMIENTO ELSE 0 END) AS "202310",
    SUM(CASE WHEN ANOMES = '202311' THEN MOVIMIENTO ELSE 0 END) AS "202311",
    SUM(CASE WHEN ANOMES = '202312' THEN MOVIMIENTO ELSE 0 END) AS "202312",
    -- A�o 2024
    SUM(CASE WHEN ANOMES = '202401' THEN MOVIMIENTO ELSE 0 END) AS "202401",
    SUM(CASE WHEN ANOMES = '202402' THEN MOVIMIENTO ELSE 0 END) AS "202402",
    SUM(CASE WHEN ANOMES = '202403' THEN MOVIMIENTO ELSE 0 END) AS "202403",
    SUM(CASE WHEN ANOMES = '202404' THEN MOVIMIENTO ELSE 0 END) AS "202404",
    SUM(CASE WHEN ANOMES = '202405' THEN MOVIMIENTO ELSE 0 END) AS "202405",
    SUM(CASE WHEN ANOMES = '202406' THEN MOVIMIENTO ELSE 0 END) AS "202406",
    SUM(CASE WHEN ANOMES = '202407' THEN MOVIMIENTO ELSE 0 END) AS "202407",
    SUM(CASE WHEN ANOMES = '202408' THEN MOVIMIENTO ELSE 0 END) AS "202408",
    SUM(CASE WHEN ANOMES = '202409' THEN MOVIMIENTO ELSE 0 END) AS "202409",
    SUM(CASE WHEN ANOMES = '202410' THEN MOVIMIENTO ELSE 0 END) AS "202410",
    SUM(CASE WHEN ANOMES = '202411' THEN MOVIMIENTO ELSE 0 END) AS "202411",
    SUM(CASE WHEN ANOMES = '202412' THEN MOVIMIENTO ELSE 0 END) AS "202412",
    -- A�o 2025
    SUM(CASE WHEN ANOMES = '202501' THEN MOVIMIENTO ELSE 0 END) AS "202501",
    SUM(CASE WHEN ANOMES = '202502' THEN MOVIMIENTO ELSE 0 END) AS "202502",
    SUM(CASE WHEN ANOMES = '202503' THEN MOVIMIENTO ELSE 0 END) AS "202503",
    SUM(CASE WHEN ANOMES = '202504' THEN MOVIMIENTO ELSE 0 END) AS "202504",
    SUM(CASE WHEN ANOMES = '202505' THEN MOVIMIENTO ELSE 0 END) AS "202505",
    SUM(CASE WHEN ANOMES = '202506' THEN MOVIMIENTO ELSE 0 END) AS "202506",
    SUM(CASE WHEN ANOMES = '202507' THEN MOVIMIENTO ELSE 0 END) AS "202507",
    SUM(CASE WHEN ANOMES = '202508' THEN MOVIMIENTO ELSE 0 END) AS "202508",
    SUM(CASE WHEN ANOMES = '202509' THEN MOVIMIENTO ELSE 0 END) AS "202509",
    SUM(CASE WHEN ANOMES = '202510' THEN MOVIMIENTO ELSE 0 END) AS "202510",
    SUM(CASE WHEN ANOMES = '202511' THEN MOVIMIENTO ELSE 0 END) AS "202511",
    SUM(CASE WHEN ANOMES = '202512' THEN MOVIMIENTO ELSE 0 END) AS "202512"
FROM 
    FACTURAS.T_SALIDAS_PRODUCCION
GROUP BY 
    CODIGO, DESCRIPCION
 UNION ALL
  SELECT 
    4 AS UBICACION, 
    'CUARENTENA_PRODUCCION' AS tipo, 
    CODIGO || '-' || DESCRIPCION AS PRODUCTO,
    -- A�o 2023
    SUM(CASE WHEN ANOMES = '202301' THEN VALOR ELSE 0 END) AS "202301",
    SUM(CASE WHEN ANOMES = '202302' THEN VALOR ELSE 0 END) AS "202302",
    SUM(CASE WHEN ANOMES = '202303' THEN VALOR ELSE 0 END) AS "202303",
    SUM(CASE WHEN ANOMES = '202304' THEN VALOR ELSE 0 END) AS "202304",
    SUM(CASE WHEN ANOMES = '202305' THEN VALOR ELSE 0 END) AS "202305",
    SUM(CASE WHEN ANOMES = '202306' THEN VALOR ELSE 0 END) AS "202306",
    SUM(CASE WHEN ANOMES = '202307' THEN VALOR ELSE 0 END) AS "202307",
    SUM(CASE WHEN ANOMES = '202308' THEN VALOR ELSE 0 END) AS "202308",
    SUM(CASE WHEN ANOMES = '202309' THEN VALOR ELSE 0 END) AS "202309",
    SUM(CASE WHEN ANOMES = '202310' THEN VALOR ELSE 0 END) AS "202310",
    SUM(CASE WHEN ANOMES = '202311' THEN VALOR ELSE 0 END) AS "202311",
    SUM(CASE WHEN ANOMES = '202312' THEN VALOR ELSE 0 END) AS "202312",
    -- A�o 2024
    SUM(CASE WHEN ANOMES = '202401' THEN VALOR ELSE 0 END) AS "202401",
    SUM(CASE WHEN ANOMES = '202402' THEN VALOR ELSE 0 END) AS "202402",
    SUM(CASE WHEN ANOMES = '202403' THEN VALOR ELSE 0 END) AS "202403",
    SUM(CASE WHEN ANOMES = '202404' THEN VALOR ELSE 0 END) AS "202404",
    SUM(CASE WHEN ANOMES = '202405' THEN VALOR ELSE 0 END) AS "202405",
    SUM(CASE WHEN ANOMES = '202406' THEN VALOR ELSE 0 END) AS "202406",
    SUM(CASE WHEN ANOMES = '202407' THEN VALOR ELSE 0 END) AS "202407",
    SUM(CASE WHEN ANOMES = '202408' THEN VALOR ELSE 0 END) AS "202408",
    SUM(CASE WHEN ANOMES = '202409' THEN VALOR ELSE 0 END) AS "202409",
    SUM(CASE WHEN ANOMES = '202410' THEN VALOR ELSE 0 END) AS "202410",
    SUM(CASE WHEN ANOMES = '202411' THEN VALOR ELSE 0 END) AS "202411",
    SUM(CASE WHEN ANOMES = '202412' THEN VALOR ELSE 0 END) AS "202412",
    -- A�o 2025
    SUM(CASE WHEN ANOMES = '202501' THEN VALOR ELSE 0 END) AS "202501",
    SUM(CASE WHEN ANOMES = '202502' THEN VALOR ELSE 0 END) AS "202502",
    SUM(CASE WHEN ANOMES = '202503' THEN VALOR ELSE 0 END) AS "202503",
    SUM(CASE WHEN ANOMES = '202504' THEN VALOR ELSE 0 END) AS "202504",
    SUM(CASE WHEN ANOMES = '202505' THEN VALOR ELSE 0 END) AS "202505",
    SUM(CASE WHEN ANOMES = '202506' THEN VALOR ELSE 0 END) AS "202506",
    SUM(CASE WHEN ANOMES = '202507' THEN VALOR ELSE 0 END) AS "202507",
    SUM(CASE WHEN ANOMES = '202508' THEN VALOR ELSE 0 END) AS "202508",
    SUM(CASE WHEN ANOMES = '202509' THEN VALOR ELSE 0 END) AS "202509",
    SUM(CASE WHEN ANOMES = '202510' THEN VALOR ELSE 0 END) AS "202510",
    SUM(CASE WHEN ANOMES = '202511' THEN VALOR ELSE 0 END) AS "202511",
    SUM(CASE WHEN ANOMES = '202512' THEN VALOR ELSE 0 END) AS "202512"
FROM 
    FACTURAS.T_CUARENTENA_PRODUCCION
GROUP BY 
    CODIGO, DESCRIPCION
 UNION ALL 
  SELECT 
    5 AS UBICACION, 
    'CUARENTENA_PRODUCCION' AS tipo, 
    CODIGO || '-' || DESCRIPCION AS PRODUCTO,
    -- A�o 2023
    SUM(CASE WHEN ANOMES = '202301' THEN VALOR ELSE 0 END) AS "202301",
    SUM(CASE WHEN ANOMES = '202302' THEN VALOR ELSE 0 END) AS "202302",
    SUM(CASE WHEN ANOMES = '202303' THEN VALOR ELSE 0 END) AS "202303",
    SUM(CASE WHEN ANOMES = '202304' THEN VALOR ELSE 0 END) AS "202304",
    SUM(CASE WHEN ANOMES = '202305' THEN VALOR ELSE 0 END) AS "202305",
    SUM(CASE WHEN ANOMES = '202306' THEN VALOR ELSE 0 END) AS "202306",
    SUM(CASE WHEN ANOMES = '202307' THEN VALOR ELSE 0 END) AS "202307",
    SUM(CASE WHEN ANOMES = '202308' THEN VALOR ELSE 0 END) AS "202308",
    SUM(CASE WHEN ANOMES = '202309' THEN VALOR ELSE 0 END) AS "202309",
    SUM(CASE WHEN ANOMES = '202310' THEN VALOR ELSE 0 END) AS "202310",
    SUM(CASE WHEN ANOMES = '202311' THEN VALOR ELSE 0 END) AS "202311",
    SUM(CASE WHEN ANOMES = '202312' THEN VALOR ELSE 0 END) AS "202312",
    -- A�o 2024
    SUM(CASE WHEN ANOMES = '202401' THEN VALOR ELSE 0 END) AS "202401",
    SUM(CASE WHEN ANOMES = '202402' THEN VALOR ELSE 0 END) AS "202402",
    SUM(CASE WHEN ANOMES = '202403' THEN VALOR ELSE 0 END) AS "202403",
    SUM(CASE WHEN ANOMES = '202404' THEN VALOR ELSE 0 END) AS "202404",
    SUM(CASE WHEN ANOMES = '202405' THEN VALOR ELSE 0 END) AS "202405",
    SUM(CASE WHEN ANOMES = '202406' THEN VALOR ELSE 0 END) AS "202406",
    SUM(CASE WHEN ANOMES = '202407' THEN VALOR ELSE 0 END) AS "202407",
    SUM(CASE WHEN ANOMES = '202408' THEN VALOR ELSE 0 END) AS "202408",
    SUM(CASE WHEN ANOMES = '202409' THEN VALOR ELSE 0 END) AS "202409",
    SUM(CASE WHEN ANOMES = '202410' THEN VALOR ELSE 0 END) AS "202410",
    SUM(CASE WHEN ANOMES = '202411' THEN VALOR ELSE 0 END) AS "202411",
    SUM(CASE WHEN ANOMES = '202412' THEN VALOR ELSE 0 END) AS "202412",
    -- A�o 2025
    SUM(CASE WHEN ANOMES = '202501' THEN VALOR ELSE 0 END) AS "202501",
    SUM(CASE WHEN ANOMES = '202502' THEN VALOR ELSE 0 END) AS "202502",
    SUM(CASE WHEN ANOMES = '202503' THEN VALOR ELSE 0 END) AS "202503",
    SUM(CASE WHEN ANOMES = '202504' THEN VALOR ELSE 0 END) AS "202504",
    SUM(CASE WHEN ANOMES = '202505' THEN VALOR ELSE 0 END) AS "202505",
    SUM(CASE WHEN ANOMES = '202506' THEN VALOR ELSE 0 END) AS "202506",
    SUM(CASE WHEN ANOMES = '202507' THEN VALOR ELSE 0 END) AS "202507",
    SUM(CASE WHEN ANOMES = '202508' THEN VALOR ELSE 0 END) AS "202508",
    SUM(CASE WHEN ANOMES = '202509' THEN VALOR ELSE 0 END) AS "202509",
    SUM(CASE WHEN ANOMES = '202510' THEN VALOR ELSE 0 END) AS "202510",
    SUM(CASE WHEN ANOMES = '202511' THEN VALOR ELSE 0 END) AS "202511",
    SUM(CASE WHEN ANOMES = '202512' THEN VALOR ELSE 0 END) AS "202512"
FROM 
    FACTURAS.T_ENTREGAS_PRODUCCION
GROUP BY 
    CODIGO, DESCRIPCION
    ORDER BY   PRODUCTO 
 