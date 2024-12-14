mandText = @"
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
                        d.AGNO,
                        d.MES,
                        NVL(d.STOCKINIMES, 0) AS STOCK_INI_MES,
                        NVL(pm.VALOR, 0) AS PRODUCCION,
                        tp.NOMBRE AS TIPO_PRODUCCION,
                        NVL(d.ENTREGAS, 0) AS ENTREGAS,
                        NVL(d.OTRASSALIDAS, 0) AS OTRAS_SALIDAS,
                        NVL(d.CUARENTENA, 0) AS CUARENTENA,
                        NVL(d.PPTOVENTAS, 0) AS PPTO_VENTAS,
                        NVL(d.VTASREALES, 0) AS VTAS_REALES,
                        NVL(d.DIASSTOCK, 0) AS DIAS_STOCK
                    FROM 
                        TP_PRODUCTOS p
                    LEFT JOIN 
                        TP_DATOSMENSUALES d ON p.PRODUCTOID = d.PRODUCTOID AND d.AGNO BETWEEN :AgnoInicio AND :AgnoFin
                    LEFT JOIN
                        TP_PRODUCCIONMENSUAL pm ON p.PRODUCTOID = pm.PRODUCTOID AND pm.AGNO = d.AGNO AND pm.MES = d.MES
                    LEFT JOIN
                        TP_TIPOSPRODUCCION tp ON pm.TIPOPRODUCCIONID = tp.TIPOPRODUCCIONID
                    ORDER BY 
                        p.PRODUCTOID, d.AGNO, d.MES