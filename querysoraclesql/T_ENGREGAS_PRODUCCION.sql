INSERT INTO t_ENTREGAS_produccion (agnomes,  codigo, descripcion, valor, CAMPO1, CAMPO2,agno, mes )


/*
select m.codprod, f.nomterm, sum(m.mocansal) SALIDAS
from movimiento m, tablas.foprte f
where to_char(m.n_mofecha,'yyyymm') =202409 and m.motipdoc ='GD' and m.motipbol ='GT'
and m.codprod = f.codterm
group by m.codprod, f.nomterm
delete from t_Ventas_produccion
*/

select * from (

WITH FECHAS AS (
  SELECT TO_CHAR(ADD_MONTHS(DATE '2022-01-01', LEVEL - 1), 'YYYYMM') AS ANOMES,
         EXTRACT(YEAR FROM ADD_MONTHS(DATE '2022-01-01', LEVEL - 1)) AS AGNO,
         EXTRACT(MONTH FROM ADD_MONTHS(DATE '2022-01-01', LEVEL - 1)) AS MES
  FROM DUAL
  CONNECT BY LEVEL <= 12 * (EXTRACT(YEAR FROM SYSDATE) - 2023 + 3)
)
SELECT F.ANOMES, 
       NVL(T.CODIGO, T.CODIGO) AS CODIGO, 
       NVL(T.DESCRIPCION, T.DESCRIPCION) AS DESCRIPCION, 
       NVL(T.MOVIMIENTO, 0)  MOVIMIENTO,
       0 AS CAMPO1,
       0 AS CAMPO2,
       F.AGNO,
       F.MES
FROM FECHAS F
LEFT JOIN (

  
   
     select m.codprod CODIGO, f.nomterm DESCRIPCION, sum(m.mocansal) MOVIMIENTO,    TO_CHAR(n_mofecha, 'YYYYMM') ANOMES
from movimiento m, tablas.foprte f
where  m.motipdoc ='GD' and m.motipbol ='GT'
and m.codprod = f.codterm
group by m.codprod, f.nomterm, TO_CHAR(n_mofecha, 'YYYYMM')

    
) T ON F.ANOMES = T.ANOMES
  ) xxx-- where codigo='125025-5'
  
  order by 1,anomes ;