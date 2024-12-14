 
select versiondata,ngerente, agerente,codinternogerencia,gerencia, agno,
Enero	,	CEnero,
Febrero	,	CFebrero,
Marzo	,	CMarzo,
Abril	,	CAbril,
Mayo	,	CMayo,
Junio	,	CJunio,
Julio	,	CJulio,
Agosto	,	CAgosto,
Septiembre	,	CSeptiembre,
Octubre	,	COctubre,
Noviembre	,	CNoviembre,
Diciembre	,	CDiciembre,
Total	,	CTotal
from v_gerencia_totales where agno=2024  
union all 
select versiondata,ngerente, agerente,codinternogerencia,gerencia, agno,
Enero	,	CEnero,
Febrero	,	CFebrero,
Marzo	,	CMarzo,
Abril	,	CAbril,
Mayo	,	CMayo,
Junio	,	CJunio,
Julio	,	CJulio,
Agosto	,	CAgosto,
Septiembre	,	CSeptiembre,
Octubre	,	COctubre,
Noviembre	,	CNoviembre,
Diciembre	,	CDiciembre,
Total	,	CTotal
from v_gerencia_totales where agno=2025  
 
order by  gerencia, codinternogerencia,agno


