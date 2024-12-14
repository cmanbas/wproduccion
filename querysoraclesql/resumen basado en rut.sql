  SELECT 
	 VersionData,
     Ngerente, AGerente, codinterno codinternogerencia, Gerencia ,agno ,  
    NVL(sum(CASE WHEN mes = 1 THEN rentabruta END), 0) AS Enero,
    NVL(sum(CASE WHEN mes = 2 THEN rentabruta END), 0) AS Febrero,
    NVL(sum(CASE WHEN mes = 3 THEN rentabruta END), 0) AS Marzo,
    NVL(sum(CASE WHEN mes = 4 THEN rentabruta END), 0) AS Abril,
    NVL(sum(CASE WHEN mes = 5 THEN rentabruta END), 0) AS Mayo,
    NVL(sum(CASE WHEN mes = 6 THEN rentabruta END), 0) AS Junio,
    NVL(sum(CASE WHEN mes = 7 THEN rentabruta END), 0) AS Julio,
    NVL(sum(CASE WHEN mes = 8 THEN rentabruta END), 0) AS Agosto,
    NVL(sum(CASE WHEN mes = 9 THEN rentabruta END), 0) AS Septiembre,
    NVL(sum(CASE WHEN mes = 10 THEN rentabruta END), 0) AS Octubre,
    NVL(sum(CASE WHEN mes = 11 THEN rentabruta END), 0) AS Noviembre,
    NVL(sum(CASE WHEN mes = 12 THEN rentabruta END), 0) AS Diciembre,
    NVL(SUM(rentabruta), 0) AS Total,
    NVL(sum(CASE WHEN mes = 1 THEN xxxx END), 0) AS CEnero,
    NVL(sum(CASE WHEN mes = 2 THEN xxxx END), 0) AS CFebrero,
    NVL(sum(CASE WHEN mes = 3 THEN xxxx END), 0) AS CMarzo,
    NVL(sum(CASE WHEN mes = 4 THEN xxxx END), 0) AS CAbril,
    NVL(sum(CASE WHEN mes = 5 THEN xxxx END), 0) AS CMayo,
    NVL(sum(CASE WHEN mes = 6 THEN xxxx END), 0) AS CJunio,
    NVL(sum(CASE WHEN mes = 7 THEN xxxx END), 0) AS CJulio,
    NVL(sum(CASE WHEN mes = 8 THEN xxxx END), 0) AS CAgosto,
    NVL(sum(CASE WHEN mes = 9 THEN xxxx END), 0) AS CSeptiembre,
    NVL(sum(CASE WHEN mes = 10 THEN xxxx END), 0) AS COctubre,
    NVL(sum(CASE WHEN mes = 11 THEN xxxx END), 0) AS CNoviembre,
    NVL(sum(CASE WHEN mes = 12 THEN xxxx END), 0) AS CDiciembre,
    NVL(sum(CASE WHEN mes = 12 THEN xxxx END), 0) AS CTotal
 
FROM (
SELECT EmpleadoRenta.VersionData,
           EmpleadoRenta.periodo, EmpleadoRenta.agno, EmpleadoRenta.mes, sum( EmpleadoRenta.rentabruta) rentabruta ,  
                  
				  Gerencia.codinterno, Gerencia.Gerencia , 
				  EmpGerente.Nombre AS Ngerente, EmpGerente.ApellidoPaterno AS AGerente  ,count(  EmpleadoRenta.RUT) xxxx
				        
FROM    T_EMPLEADORENTA EmpleadoRenta INNER JOIN
                 T_EMPLEADO Empleado  ON EmpleadoRenta.RUT = Empleado.RUT INNER JOIN
                 T_GERENCIA Gerencia ON Empleado.codinternogerencia = Gerencia.codinterno LEFT OUTER JOIN
                  T_EMPLEADO   EmpGerente ON Gerencia.RUT = EmpGerente.RUT
                  WHERE EmpleadoRenta.rentabruta <>0 AND VERSIONDATA = 1
                group by EmpleadoRenta.VersionData,
                  EmpleadoRenta.periodo, EmpleadoRenta.agno, EmpleadoRenta.mes, EmpleadoRenta.rentabruta,  
			       	  Gerencia.codinterno, Gerencia.Gerencia  
 , 
				  EmpGerente.Nombre  , EmpGerente.ApellidoPaterno  
   
)    d
 
GROUP BY VersionData,   Gerencia ,   codinterno, Ngerente, AGerente  ,agno 
ORDER BY GERENCIA, AGNO;