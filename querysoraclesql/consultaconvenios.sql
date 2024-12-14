SELECT 
    t_EmpleadoRenta.VersionData, 
    t_Gerencia.GERENCIA AS Gerencia, 
    t_Gerencia.EMAIL,
    t_EmpleadoRenta.agno,
    SUM(CASE WHEN t_EmpleadoRenta.mes = 1 THEN t_EmpleadoRenta.rentabruta ELSE 0 END) AS Enero,
    SUM(CASE WHEN t_EmpleadoRenta.mes = 2 THEN t_EmpleadoRenta.rentabruta ELSE 0 END) AS Febrero,
    SUM(CASE WHEN t_EmpleadoRenta.mes = 3 THEN t_EmpleadoRenta.rentabruta ELSE 0 END) AS Marzo,
    SUM(CASE WHEN t_EmpleadoRenta.mes = 4 THEN t_EmpleadoRenta.rentabruta ELSE 0 END) AS Abril,
    SUM(CASE WHEN t_EmpleadoRenta.mes = 5 THEN t_EmpleadoRenta.rentabruta ELSE 0 END) AS Mayo,
    SUM(CASE WHEN t_EmpleadoRenta.mes = 6 THEN t_EmpleadoRenta.rentabruta ELSE 0 END) AS Junio,
    SUM(CASE WHEN t_EmpleadoRenta.mes = 7 THEN t_EmpleadoRenta.rentabruta ELSE 0 END) AS Julio,
    SUM(CASE WHEN t_EmpleadoRenta.mes = 8 THEN t_EmpleadoRenta.rentabruta ELSE 0 END) AS Agosto,
    SUM(CASE WHEN t_EmpleadoRenta.mes = 9 THEN t_EmpleadoRenta.rentabruta ELSE 0 END) AS Septiembre,
    SUM(CASE WHEN t_EmpleadoRenta.mes = 10 THEN t_EmpleadoRenta.rentabruta ELSE 0 END) AS Octubre,
    SUM(CASE WHEN t_EmpleadoRenta.mes = 11 THEN t_EmpleadoRenta.rentabruta ELSE 0 END) AS Noviembre,
    SUM(CASE WHEN t_EmpleadoRenta.mes = 12 THEN t_EmpleadoRenta.rentabruta ELSE 0 END) AS Diciembre,
    COUNt(distinct t_Empleado.RUT) AS cantidad  
FROM 
    t_EmpleadoRenta 
    INNER JOIN t_Empleado ON t_EmpleadoRenta.RUT = t_Empleado.RUT 
    INNER JOIN t_Gerencia ON t_Empleado.codinternogerencia = t_Gerencia.CODINTERNO
WHERE    
     t_EmpleadoRenta.RENTABRUTA >0 and t_EmpleadoRenta.versiondata = 1 and t_EmpleadoRenta.agno=  2024
GROUP BY 
    t_EmpleadoRenta.VersionData,  
    t_Gerencia.GERENCIA, 
    t_Gerencia.EMAIL,
    t_EmpleadoRenta.agno
    
union all

SELECT 
    t_EmpleadoRenta.VersionData, 
    t_Gerencia.GERENCIA AS Gerencia, 
    t_Gerencia.EMAIL,
    t_EmpleadoRenta.agno,
    
    SUM(CASE WHEN t_EmpleadoRenta.mes = 1 THEN t_EmpleadoRenta.rentabruta ELSE 0 END) AS Enero,
    SUM(CASE WHEN t_EmpleadoRenta.mes = 2 THEN t_EmpleadoRenta.rentabruta ELSE 0 END) AS Febrero,
    SUM(CASE WHEN t_EmpleadoRenta.mes = 3 THEN t_EmpleadoRenta.rentabruta ELSE 0 END) AS Marzo,
    SUM(CASE WHEN t_EmpleadoRenta.mes = 4 THEN t_EmpleadoRenta.rentabruta ELSE 0 END) AS Abril,
    SUM(CASE WHEN t_EmpleadoRenta.mes = 5 THEN t_EmpleadoRenta.rentabruta ELSE 0 END) AS Mayo,
    SUM(CASE WHEN t_EmpleadoRenta.mes = 6 THEN t_EmpleadoRenta.rentabruta ELSE 0 END) AS Junio,
    SUM(CASE WHEN t_EmpleadoRenta.mes = 7 THEN t_EmpleadoRenta.rentabruta ELSE 0 END) AS Julio,
    SUM(CASE WHEN t_EmpleadoRenta.mes = 8 THEN t_EmpleadoRenta.rentabruta ELSE 0 END) AS Agosto,
    SUM(CASE WHEN t_EmpleadoRenta.mes = 9 THEN t_EmpleadoRenta.rentabruta ELSE 0 END) AS Septiembre,
    SUM(CASE WHEN t_EmpleadoRenta.mes = 10 THEN t_EmpleadoRenta.rentabruta ELSE 0 END) AS Octubre,
    SUM(CASE WHEN t_EmpleadoRenta.mes = 11 THEN t_EmpleadoRenta.rentabruta ELSE 0 END) AS Noviembre,
    SUM(CASE WHEN t_EmpleadoRenta.mes = 12 THEN t_EmpleadoRenta.rentabruta ELSE 0 END) AS Diciembre,
    
    COUNt(distinct t_Empleado.RUT) AS cantidad  
FROM 
    t_EmpleadoRenta 
    INNER JOIN t_Empleado ON t_EmpleadoRenta.RUT = t_Empleado.RUT 
    INNER JOIN t_Gerencia ON t_Empleado.codinternogerencia = t_Gerencia.CODINTERNO
WHERE    
     t_EmpleadoRenta.RENTABRUTA >0 and t_EmpleadoRenta.versiondata = 1 and t_EmpleadoRenta.agno=  2025
GROUP BY 
    t_EmpleadoRenta.VersionData,  
    t_Gerencia.GERENCIA, 
    t_Gerencia.EMAIL,
    t_EmpleadoRenta.agno
ORDER BY 
    VersionData, 
    GERENCIA  , 
    EMAIL,
    agno 

