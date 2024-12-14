
                        SELECT 
                            CDC.CORRELATIVO,
                            CDC.RUT_CLIENTE,
                            CDC.COD_CLIENTE,  
                            CLI.CLRAZON, 
                            CLE.CODSAP, 
                            CDC.FECHA_EMISION , 
                            CDC.TIPO_DOCUMENTO,  
                            CDC.NUMERO_DOCUMENTO, 
                            CDC.MONTO_NETO, 
                            CDC.CORRINTERNONFS,
                            CDC.TIPODOCUMENTONVS,
                            CDC.FACTURANFS,
                            CDC.FECHAASIGNACIONNFS,TO_CHAR(CDC.FECHA_EMISION, 'YYYY-MM')
                        FROM T_CARGA_DOCUMENTO_CLIENTE CDC
                        JOIN Clientes CLI ON CDC.COD_CLIENTE = CLI.CLCODIGO
                        JOIN CL_EQUIVALENCIA CLE ON CLI.CLCODIGO = CLE.CODCLBAGO
                        WHERE  ASIGNADA = 'SI' AND  --TO_CHAR(CDC.FECHA_EMISION, 'YYYY-MM')  BETWEEN :periodoDesde AND :periodoHasta   AND 
                       (CDC.CORRINTERNONFS IS NULL OR CDC.CORRINTERNONFS = 0)
                        order by  CDC.NUMERO_DOCUMENTO 