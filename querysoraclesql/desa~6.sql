  WITH TODOSLOSMESES AS (
                    SELECT LEVEL + :AgnoInicio - 1 AS AGNO, 
                           MOD(LEVEL - 1, 12) + 1 AS MES
                    FROM DUAL
                    CONNECT BY LEVEL <= (:AgnoFin - :AgnoInicio + 1) * 12
                )
                SELECT 
                    p.PRODUCTOID,
                    p.NOMBRE,
                    p.CODIGOPRODUCTO,
                    p.CODIGOPEDIDO,
                    p.PERIODOEFICACIA,
                    p.TAMANOLOTE,
                    p.UNIDADLOTE,
                    p.PESOLOTE,
                    p.TIPOEMPAQUE,
                    p.UNIDADESPOREMPAQUE,
                    tm.AGNO,
                    tm.MES,
                    NVL(d.STOCKINIMES, 0) AS STOCK_INI_MES,
                    NVL(pm.VALOR, 0) AS PRODUCCION,
                    NVL(tp.NOMBRE, 's/i') AS TIPO_PRODUCCION,
                    NVL(d.ENTREGAS, 0) AS ENTREGAS,
                    NVL(d.OTRASSALIDAS, 0) AS OTRAS_SALIDAS,
                    NVL(d.CUARENTENA, 0) AS CUARENTENA,
                    NVL(d.PPTOVENTAS, 0) AS PPTO_VENTAS,
                    NVL(d.VTASREALES, 0) AS VTAS_REALES,
                    NVL(d.DIASSTOCK, 0) AS DIAS_STOCK
                FROM 
                    TP_PRODUCTOS p
                CROSS JOIN
                    TODOSLOSMESES tm
                LEFT JOIN 
                    TP_DATOSMENSUALES d ON p.PRODUCTOID = d.PRODUCTOID AND tm.AGNO = d.AGNO AND tm.MES = d.MES
                LEFT JOIN
                    TP_PRODUCCIONMENSUAL pm ON p.PRODUCTOID = pm.PRODUCTOID AND tm.AGNO = pm.AGNO AND tm.MES = pm.MES
                LEFT JOIN
                    TP_TIPOSPRODUCCION tp ON pm.TIPOPRODUCCIONID = tp.TIPOPRODUCCIONID
                      where p.PRODUCTOID='408049' 
                ORDER BY 
                    p.PRODUCTOID, tm.AGNO, tm.MES
