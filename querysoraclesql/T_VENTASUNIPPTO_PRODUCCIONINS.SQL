INSERT INTO 
 t_ventasunippto_produccion (
    agnomes,
    codigo,
    descripcion,
    valor,
    campo1,
    campo2,
    agno,
    mes,
    ubicacion
)  
SELECT 
    TO_CHAR(pu_ano) || LPAD(mes, 2, '0') AS AGNOMES, -- Año y mes concatenados
    pu_codigo AS CODIGO,                             -- Código del producto
    nom AS DESCRIPCION,                              -- Nombre del producto
    NVL(valor,0) VALOR,                                           -- Valor del mes específico
    NULL AS CAMPO1,                                  -- Placeholder para CAMPO1
    NULL AS CAMPO2,                                  -- Placeholder para CAMPO2
    pu_ano AS AGNO,                                  -- Año
    mes,                                             -- Mes
    NULL AS UBICACION                                -- Placeholder para UBICACION
FROM (
    -- Año 2023, 2024 y 2025 con pu_tipo IN ('1', '2')
    SELECT 
        pu_codigo, 
        UPPER(pu_producto) AS nom,
        pu_ano,
        1 AS mes, SUM(pu_ene) AS valor
    FROM presupuesto.presupuesto_unidpt
    WHERE pu_clase = 1 AND pu_ano IN (2023, 2024, 2025) AND pu_tipo IN ('1', '2')
    GROUP BY pu_codigo, UPPER(pu_producto), pu_ano
    UNION ALL
    SELECT 
        pu_codigo, 
        UPPER(pu_producto) AS nom,
        pu_ano,
        2 AS mes, SUM(pu_feb) AS valor
    FROM presupuesto.presupuesto_unidpt
    WHERE pu_clase = 1 AND pu_ano IN (2023, 2024, 2025) AND pu_tipo IN ('1', '2')
    GROUP BY pu_codigo, UPPER(pu_producto), pu_ano
    UNION ALL
    SELECT 
        pu_codigo, 
        UPPER(pu_producto) AS nom,
        pu_ano,
        3 AS mes, SUM(pu_mar) AS valor
    FROM presupuesto.presupuesto_unidpt
    WHERE pu_clase = 1 AND pu_ano IN (2023, 2024, 2025) AND pu_tipo IN ('1', '2')
    GROUP BY pu_codigo, UPPER(pu_producto), pu_ano
    UNION ALL
    SELECT 
        pu_codigo, 
        UPPER(pu_producto) AS nom,
        pu_ano,
        4 AS mes, SUM(pu_abr) AS valor
    FROM presupuesto.presupuesto_unidpt
    WHERE pu_clase = 1 AND pu_ano IN (2023, 2024, 2025) AND pu_tipo IN ('1', '2')
    GROUP BY pu_codigo, UPPER(pu_producto), pu_ano
    UNION ALL
    SELECT 
        pu_codigo, 
        UPPER(pu_producto) AS nom,
        pu_ano,
        5 AS mes, SUM(pu_may) AS valor
    FROM presupuesto.presupuesto_unidpt
    WHERE pu_clase = 1 AND pu_ano IN (2023, 2024, 2025) AND pu_tipo IN ('1', '2')
    GROUP BY pu_codigo, UPPER(pu_producto), pu_ano
    UNION ALL
    SELECT 
        pu_codigo, 
        UPPER(pu_producto) AS nom,
        pu_ano,
        6 AS mes, SUM(pu_jun) AS valor
    FROM presupuesto.presupuesto_unidpt
    WHERE pu_clase = 1 AND pu_ano IN (2023, 2024, 2025) AND pu_tipo IN ('1', '2')
    GROUP BY pu_codigo, UPPER(pu_producto), pu_ano
    UNION ALL
    SELECT 
        pu_codigo, 
        UPPER(pu_producto) AS nom,
        pu_ano,
        7 AS mes, SUM(pu_jul) AS valor
    FROM presupuesto.presupuesto_unidpt
    WHERE pu_clase = 1 AND pu_ano IN (2023, 2024, 2025) AND pu_tipo IN ('1', '2')
    GROUP BY pu_codigo, UPPER(pu_producto), pu_ano
    UNION ALL
    SELECT 
        pu_codigo, 
        UPPER(pu_producto) AS nom,
        pu_ano,
        8 AS mes, SUM(pu_ago) AS valor
    FROM presupuesto.presupuesto_unidpt
    WHERE pu_clase = 1 AND pu_ano IN (2023, 2024, 2025) AND pu_tipo IN ('1', '2')
    GROUP BY pu_codigo, UPPER(pu_producto), pu_ano
    UNION ALL
    SELECT 
        pu_codigo, 
        UPPER(pu_producto) AS nom,
        pu_ano,
        9 AS mes, SUM(pu_sep) AS valor
    FROM presupuesto.presupuesto_unidpt
    WHERE pu_clase = 1 AND pu_ano IN (2023, 2024, 2025) AND pu_tipo IN ('1', '2')
    GROUP BY pu_codigo, UPPER(pu_producto), pu_ano
    UNION ALL
    SELECT 
        pu_codigo, 
        UPPER(pu_producto) AS nom,
        pu_ano,
        10 AS mes, SUM(pu_oct) AS valor
    FROM presupuesto.presupuesto_unidpt
    WHERE pu_clase = 1 AND pu_ano IN (2023, 2024, 2025) AND pu_tipo IN ('1', '2')
    GROUP BY pu_codigo, UPPER(pu_producto), pu_ano
    UNION ALL
    SELECT 
        pu_codigo, 
        UPPER(pu_producto) AS nom,
        pu_ano,
        11 AS mes, SUM(pu_nov) AS valor
    FROM presupuesto.presupuesto_unidpt
    WHERE pu_clase = 1 AND pu_ano IN (2023, 2024, 2025) AND pu_tipo IN ('1', '2')
    GROUP BY pu_codigo, UPPER(pu_producto), pu_ano
    UNION ALL
    SELECT 
        pu_codigo, 
        UPPER(pu_producto) AS nom,
        pu_ano,
        12 AS mes, SUM(pu_dic) AS valor
    FROM presupuesto.presupuesto_unidpt
    WHERE pu_clase = 1 AND pu_ano IN (2023, 2024, 2025) AND pu_tipo IN ('1', '2')
    GROUP BY pu_codigo, UPPER(pu_producto), pu_ano
    UNION ALL
    -- Año 2023, 2024 y 2025 con pu_tipo = 'M'
    SELECT 
        pu_codigo, 
        pu_producto AS nom,
        pu_ano,
        1 AS mes, pu_ene AS valor
    FROM presupuesto.presupuesto_unidpt
    WHERE pu_clase = 1 AND pu_ano IN (2023, 2024, 2025) AND pu_tipo = 'M'
    UNION ALL
    SELECT 
        pu_codigo, 
        pu_producto AS nom,
        pu_ano,
        2 AS mes, pu_feb AS valor
    FROM presupuesto.presupuesto_unidpt
    WHERE pu_clase = 1 AND pu_ano IN (2023, 2024, 2025) AND pu_tipo = 'M'
    UNION ALL
    SELECT 
        pu_codigo, 
        pu_producto AS nom,
        pu_ano,
        3 AS mes, pu_mar AS valor
    FROM presupuesto.presupuesto_unidpt
    WHERE pu_clase = 1 AND pu_ano IN (2023, 2024, 2025) AND pu_tipo = 'M'
    UNION ALL
    -- Repetir la lógica para los meses 4 a 12...
    SELECT 
        pu_codigo, 
        pu_producto AS nom,
        pu_ano,
        12 AS mes, pu_dic AS valor
    FROM presupuesto.presupuesto_unidpt
    WHERE pu_clase = 1 AND pu_ano IN (2023, 2024, 2025) AND pu_tipo = 'M'
) datos
   ORDER BY 3; -- Filtrar resultados sin valores
