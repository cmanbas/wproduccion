INSERT INTO FACTURAS.T_VENTASUNIPPTO_PRODUCCION 
(ANOMES, CODIGO, DESCRIPCION, MOVIMIENTO, CAMPO1, CAMPO2, AGNO, MES)
WITH datos_mensuales AS (
    SELECT pu_codigo, pu_producto, pu_ano,
           'ENE' AS mes_nombre, pu_ene AS valor, 1 AS mes_num FROM PRESUPUESTO.presupuesto_unidpt WHERE pu_clase = 1 AND pu_ano IN (2022,2023, 2024) AND pu_tipo = 'M'
    UNION ALL
    SELECT pu_codigo, pu_producto, pu_ano,
           'FEB' AS mes_nombre, pu_feb AS valor, 2 AS mes_num FROM PRESUPUESTO.presupuesto_unidpt WHERE pu_clase = 1 AND pu_ano IN (2022,2023, 2024) AND pu_tipo = 'M'
    UNION ALL
    SELECT pu_codigo, pu_producto, pu_ano,
           'MAR' AS mes_nombre, pu_mar AS valor, 3 AS mes_num FROM PRESUPUESTO.presupuesto_unidpt WHERE pu_clase = 1 AND pu_ano IN (2022,2023, 2024) AND pu_tipo = 'M'
    UNION ALL
    SELECT pu_codigo, pu_producto, pu_ano,
           'ABR' AS mes_nombre, pu_abr AS valor, 4 AS mes_num FROM PRESUPUESTO.presupuesto_unidpt WHERE pu_clase = 1 AND pu_ano IN (2022,2023, 2024) AND pu_tipo = 'M'
    UNION ALL
    SELECT pu_codigo, pu_producto, pu_ano,
           'MAY' AS mes_nombre, pu_may AS valor, 5 AS mes_num FROM PRESUPUESTO.presupuesto_unidpt WHERE pu_clase = 1 AND pu_ano IN (2022,2023, 2024) AND pu_tipo = 'M'
    UNION ALL
    SELECT pu_codigo, pu_producto, pu_ano,
           'JUN' AS mes_nombre, pu_jun AS valor, 6 AS mes_num FROM PRESUPUESTO.presupuesto_unidpt WHERE pu_clase = 1 AND pu_ano IN (2022,2023, 2024) AND pu_tipo = 'M'
    UNION ALL
    SELECT pu_codigo, pu_producto, pu_ano,
           'JUL' AS mes_nombre, pu_jul AS valor, 7 AS mes_num FROM PRESUPUESTO.presupuesto_unidpt WHERE pu_clase = 1 AND pu_ano IN (2022,2023, 2024) AND pu_tipo = 'M'
    UNION ALL
    SELECT pu_codigo, pu_producto, pu_ano,
           'AGO' AS mes_nombre, pu_ago AS valor, 8 AS mes_num FROM PRESUPUESTO.presupuesto_unidpt WHERE pu_clase = 1 AND pu_ano IN (2022,2023, 2024) AND pu_tipo = 'M'
    UNION ALL
    SELECT pu_codigo, pu_producto, pu_ano,
           'SEP' AS mes_nombre, pu_sep AS valor, 9 AS mes_num FROM PRESUPUESTO.presupuesto_unidpt WHERE pu_clase = 1 AND pu_ano IN (2022,2023, 2024) AND pu_tipo = 'M'
    UNION ALL
    SELECT pu_codigo, pu_producto, pu_ano,
           'OCT' AS mes_nombre, pu_oct AS valor, 10 AS mes_num FROM PRESUPUESTO.presupuesto_unidpt WHERE pu_clase = 1 AND pu_ano IN (2022,2023, 2024) AND pu_tipo = 'M'
    UNION ALL
    SELECT pu_codigo, pu_producto, pu_ano,
           'NOV' AS mes_nombre, pu_nov AS valor, 11 AS mes_num FROM PRESUPUESTO.presupuesto_unidpt WHERE pu_clase = 1 AND pu_ano IN (2022,2023, 2024) AND pu_tipo = 'M'
    UNION ALL
    SELECT pu_codigo, pu_producto, pu_ano,
           'DIC' AS mes_nombre, pu_dic AS valor, 12 AS mes_num FROM PRESUPUESTO.presupuesto_unidpt WHERE pu_clase = 1 AND pu_ano IN (2022,2023, 2024) AND pu_tipo = 'M'
)
SELECT 
    TO_CHAR(TO_DATE(pu_ano || LPAD(mes_num, 2, '0'), 'YYYYMM'), 'YYYYMM') AS ANOMES,
    pu_codigo AS CODIGO,
    pu_producto AS DESCRIPCION,
    valor AS MOVIMIENTO,
    0 AS CAMPO1,
    0 AS CAMPO2,
    pu_ano AS AGNO,
    mes_num AS MES
FROM 
    datos_mensuales
ORDER BY 
    pu_ano, mes_num, pu_codigo;