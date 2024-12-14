                    SELECT
                        TABLA.Agno, TABLA.codinternogerencia, TABLA.Gerencia,  
                        sum(CASE WHEN TIPOCONVENIO = '0001' THEN TABLA.cantidadrut  ELSE null END) AS  Convenio_0001 ,
                        sum(CASE WHEN TIPOCONVENIO = '0002' THEN TABLA.cantidadrut  ELSE null END) AS Convenio_0002,
                        SUM(distinct TABLA.cantidadrut)   AS empleados ,
                        (
                        SELECT   
                  
                         COUNT(DISTINCT t_Empleado.RUT) AS cantidadrut 
                        FROM t_Empleado
                        INNER JOIN t_EmpleadoRenta ON t_Empleado.RUT = t_EmpleadoRenta.RUT
                        INNER JOIN t_Gerencia ON t_Empleado.codinternogerencia = t_Gerencia.CODINTERNO
                        WHERE  t_EmpleadoRenta.rentabruta > 0  and t_EmpleadoRenta.versiondata=1
                        and  t_Empleado.codinternogerencia =  1  AND TABLA.Agno= t_EmpleadoRenta.AGNO  
                        GROUP BY t_EmpleadoRenta.agno,t_Empleado.codinternogerencia, t_Gerencia.GERENCIA ) TOTAL,
                        
                      (   SUM(distinct TABLA.cantidadrut)   /(
                        SELECT   
                  
                         COUNT(DISTINCT t_Empleado.RUT) AS cantidadrut 
                        FROM t_Empleado
                        INNER JOIN t_EmpleadoRenta ON t_Empleado.RUT = t_EmpleadoRenta.RUT
                        INNER JOIN t_Gerencia ON t_Empleado.codinternogerencia = t_Gerencia.CODINTERNO
                        WHERE  t_EmpleadoRenta.rentabruta > 0  and t_EmpleadoRenta.versiondata=1
                        and  t_Empleado.codinternogerencia =  1  AND TABLA.Agno= t_EmpleadoRenta.AGNO  
                        GROUP BY t_EmpleadoRenta.agno,t_Empleado.codinternogerencia, t_Gerencia.GERENCIA ))*100 pTOTAL
                         
                        
   
                  FROM
                        (
                         SELECT t_Empleado.codinternogerencia,
                         t_Gerencia.GERENCIA, t_EmpleadoRenta.agno AS Agno,
                         t_Empleado.TIPOCONVENIO ,
                         t_Empleado.sindicato, 
                         COUNT(DISTINCT t_Empleado.RUT) AS cantidadrut 
                        FROM t_Empleado
                        INNER JOIN t_EmpleadoRenta ON t_Empleado.RUT = t_EmpleadoRenta.RUT
                        INNER JOIN t_Gerencia ON t_Empleado.codinternogerencia = t_Gerencia.CODINTERNO
                        WHERE t_Empleado.TipoConvenio IN ('0001','0002') and t_EmpleadoRenta.rentabruta > 0  and t_EmpleadoRenta.versiondata=1
                        and  t_Gerencia.codinterno  =  1  
                        GROUP BY t_EmpleadoRenta.agno,
                          t_Empleado.codinternogerencia, t_Gerencia.GERENCIA,t_Empleado.TIPOCONVENIO  ,t_Empleado.sindicato
                          )   TABLA 
                        GROUP BY   TABLA.Agno, TABLA.codinternogerencia, TABLA.Gerencia  
                        
                        
                   
                      
 
 