INSERT INTO FACTURAS.T_VENTASUNI_PRODUCCION 
(ANOMES, CODIGO, DESCRIPCION, MOVIMIENTO, CAMPO1, CAMPO2, AGNO, MES)
WITH datos_base AS (
    SELECT 
        pu_codigo,
        UPPER(pu_producto) AS producto,
        pu_ano AS agno,
        pu_ene, pu_feb, pu_mar, pu_abr, pu_may, pu_jun,
        pu_jul, pu_ago, pu_sep, pu_oct, pu_nov, pu_dic
    FROM presupuesto.presupuesto_unidpt
    WHERE pu_clase = 1 
      AND pu_ano IN (2023, 2024)
      AND pu_tipo IN ('1', '2')
)
SELECT 
    TO_CHAR(TO_DATE(agno || LPAD(mes, 2, '0'), 'YYYYMM'), 'YYYYMM') AS ANOMES,
    pu_codigo AS CODIGO,
    producto AS DESCRIPCION,
    cantidad AS MOVIMIENTO,
    NULL AS CAMPO1,
    NULL AS CAMPO2,
    agno AS AGNO,
    mes AS MES
FROM (
    SELECT 
        pu_codigo,
        producto,
        agno,
        1 AS mes,
        SUM(pu_ene) AS cantidad
    FROM datos_base
    GROUP BY pu_codigo, producto, agno

    UNION ALL

    SELECT 
        pu_codigo,
        producto,
        agno,
        2 AS mes,
        SUM(pu_feb) AS cantidad
    FROM datos_base
    GROUP BY pu_codigo, producto, agno

    UNION ALL

    SELECT 
        pu_codigo,
        producto,
        agno,
        3 AS mes,
        SUM(pu_mar) AS cantidad
    FROM datos_base
    GROUP BY pu_codigo, producto, agno

    UNION ALL

    SELECT 
        pu_codigo,
        producto,
        agno,
        4 AS mes,
        SUM(pu_abr) AS cantidad
    FROM datos_base
    GROUP BY pu_codigo, producto, agno

    UNION ALL

    SELECT 
        pu_codigo,
        producto,
        agno,
        5 AS mes,
        SUM(pu_may) AS cantidad
    FROM datos_base
    GROUP BY pu_codigo, producto, agno

    UNION ALL

    SELECT 
        pu_codigo,
        producto,
        agno,
        6 AS mes,
        SUM(pu_jun) AS cantidad
    FROM datos_base
    GROUP BY pu_codigo, producto, agno

    UNION ALL

    SELECT 
        pu_codigo,
        producto,
        agno,
        7 AS mes,
        SUM(pu_jul) AS cantidad
    FROM datos_base
    GROUP BY pu_codigo, producto, agno

    UNION ALL

    SELECT 
        pu_codigo,
        producto,
        agno,
        8 AS mes,
        SUM(pu_ago) AS cantidad
    FROM datos_base
    GROUP BY pu_codigo, producto, agno

    UNION ALL

    SELECT 
        pu_codigo,
        producto,
        agno,
        9 AS mes,
        SUM(pu_sep) AS cantidad
    FROM datos_base
    GROUP BY pu_codigo, producto, agno

    UNION ALL

    SELECT 
        pu_codigo,
        producto,
        agno,
        10 AS mes,
        SUM(pu_oct) AS cantidad
    FROM datos_base
    GROUP BY pu_codigo, producto, agno

    UNION ALL

    SELECT 
        pu_codigo,
        producto,
        agno,
        11 AS mes,
        SUM(pu_nov) AS cantidad
    FROM datos_base
    GROUP BY pu_codigo, producto, agno

    UNION ALL

    SELECT 
        pu_codigo,
        producto,
        agno,
        12 AS mes,
        SUM(pu_dic) AS cantidad
    FROM datos_base
    GROUP BY pu_codigo, producto, agno
)
ORDER BY CODIGO, DESCRIPCION, AGNO, MES;

 