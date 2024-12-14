--------------------------------------------------------
-- Archivo creado  - miércoles-julio-10-2024   
--------------------------------------------------------
--------------------------------------------------------
--  DDL for View V_PLANREMUNERACION
--------------------------------------------------------

  CREATE OR REPLACE FORCE VIEW "REMUNE"."V_PLANREMUNERACION" ("VERSION", "GERENCIA", "ORDENGRUPO", "CODGRUPO", "DESGRUPO", "CODINTERNOGERENCIA", "CODITEM", "DESITEM", "ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SEPTIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE") AS 
  SELECT T_PLANREMUNERACION.VERSION, 
GERENCIA,
T_GRUPO.ORDENGRUPO, 
T_GRUPOITEM.CODGRUPO,
T_GRUPO.DESGRUPO,
T_PLANREMUNERACION.CODINTERNOGERENCIA,
T_PLANREMUNERACION.CODITEM,DESITEM,
ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,JULIO,AGOSTO,SEPTIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE 
FROM T_PLANREMUNERACION , T_GERENCIA , T_GRUPOITEM,T_GRUPO
WHERE T_PLANREMUNERACION.CODINTERNOGERENCIA = T_GERENCIA.CODINTERNO
   AND T_PLANREMUNERACION.CODITEM = T_GRUPOITEM.CODITEM
   AND T_GRUPO.CODGRUPO = T_GRUPOITEM.CODGRUPO 
   ORDER BY  T_PLANREMUNERACION.VERSION, 
GERENCIA, T_PLANREMUNERACION.CODITEM,
T_GRUPO.ORDENGRUPO;
--------------------------------------------------------
--  DDL for View V_GERENCIA_EMPLEADO_RENTA
--------------------------------------------------------

  CREATE OR REPLACE FORCE VIEW "REMUNE"."V_GERENCIA_EMPLEADO_RENTA" ("VERSIONDATA", "RUT", "NOMBRE", "APELLIDOPATERNO", "APELLIDOMATERNO", "CARGO", "CODINTERNOGERENCIA", "GERENCIA", "AGNO", "CENTROCOSTO", "DESCENTROCOSTO", "TIPOCONVENIO", "SINDICATO", "ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SEPTIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE", "TOTAL") AS 
  SELECT 
	 VersionData,
    RUT,  Nombre, ApellidoPaterno, ApellidoMaterno,cargo,codinterno codinternogerencia, Gerencia ,agno , CENTROCOSTO,  DESCENTROCOSTO,
    tipoconvenio, sindicato,
    NVL(MAX(CASE WHEN mes = 1 THEN rentabruta END), 0) AS Enero,
    NVL(MAX(CASE WHEN mes = 2 THEN rentabruta END), 0) AS Febrero,
    NVL(MAX(CASE WHEN mes = 3 THEN rentabruta END), 0) AS Marzo,
    NVL(MAX(CASE WHEN mes = 4 THEN rentabruta END), 0) AS Abril,
    NVL(MAX(CASE WHEN mes = 5 THEN rentabruta END), 0) AS Mayo,
    NVL(MAX(CASE WHEN mes = 6 THEN rentabruta END), 0) AS Junio,
    NVL(MAX(CASE WHEN mes = 7 THEN rentabruta END), 0) AS Julio,
    NVL(MAX(CASE WHEN mes = 8 THEN rentabruta END), 0) AS Agosto,
    NVL(MAX(CASE WHEN mes = 9 THEN rentabruta END), 0) AS Septiembre,
    NVL(MAX(CASE WHEN mes = 10 THEN rentabruta END), 0) AS Octubre,
    NVL(MAX(CASE WHEN mes = 11 THEN rentabruta END), 0) AS Noviembre,
    NVL(MAX(CASE WHEN mes = 12 THEN rentabruta END), 0) AS Diciembre,
    NVL(SUM(rentabruta), 0) AS Total
 
FROM (
    SELECT EmpleadoRenta.VersionData,
           EmpleadoRenta.RUT,  EmpleadoRenta.periodo, EmpleadoRenta.agno, EmpleadoRenta.mes, 
EmpleadoRenta.rentabruta, Empleado.Nombre, Empleado.ApellidoPaterno, Empleado.ApellidoMaterno, 
                  
				  Gerencia.codinterno, Gerencia.Gerencia , 
				  EmpGerente.Nombre AS Ngerente, EmpGerente.ApellidoPaterno AS AGerente,Empleado.cargo,empleado.CENTROCOSTO, empleado.DESCENTROCOSTO,
				        ROW_NUMBER() OVER (PARTITION BY EmpleadoRenta.RUT, periodo ORDER BY VersionData DESC) AS rn , Empleado.tipoconvenio, Empleado.sindicato
FROM    T_EMPLEADORENTA EmpleadoRenta INNER JOIN
                 T_EMPLEADO Empleado  ON EmpleadoRenta.RUT = Empleado.RUT INNER JOIN
                 T_GERENCIA Gerencia ON Empleado.codinternogerencia = Gerencia.codinterno LEFT OUTER JOIN
                  T_EMPLEADO   EmpGerente ON Gerencia.RUT = EmpGerente.RUT
 
    
   
)    d
 
GROUP BY VersionData, RUT, Gerencia ,   codinterno, Nombre, ApellidoPaterno, ApellidoMaterno  ,agno,cargo,CENTROCOSTO, DESCENTROCOSTO
,    tipoconvenio, sindicato;
 
 