 INSERT INTO t_Ventas_produccion  (agnomes,  codigo, descripcion, valor, CAMPO1, CAMPO2,agno, mes )


/*
select m.codprod, f.nomterm, sum(m.mocansal) SALIDAS
from movimiento m, tablas.foprte f
where to_char(m.n_mofecha,'yyyymm') =202409 and m.motipdoc ='GD' and m.motipbol ='GT'
and m.codprod = f.codterm
group by m.codprod, f.nomterm
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

    SELECT A.CODPROD CODIGO, B.NOMTERM DESCRIPCION, 
            SUM(nvl(A.MOCANSAL,0)-nvl(mocaning,0)) MOVIMIENTO,
           TO_CHAR(N_MOFECHA, 'YYYYMM') ANOMES
    FROM MOVIMIENTO A
    JOIN TABLAS.FOPRTE B ON A.CODPROD = B.CODTERM
    WHERE A.codprod = B.codterm  
      and A.motipdoc||SUBSTR(nvl(motipbol,'*'),1,1) in('FA*','BOD')  
    GROUP BY A.CODPROD, B.NOMTERM, TO_CHAR(N_MOFECHA, 'YYYYMM')  
    union  
    SELECT DET_EXP.CODPROD, FOPRTE.NOMTERM, Sum(DET_EXP.CANTIDAD) ,
    TO_CHAR(fecha,'YYYYMM')
    FROM FACTURAS.DET_EXP DET_EXP, 
          FACTURAS.ENC_EXP ENC_EXP, 
          tablas.FOPRTE FOPRTE 
     WHERE ENC_EXP.NROP = DET_EXP.NROP AND
           DET_EXP.CODPROD = FOPRTE.CODTERM  
   GROUP BY DET_EXP.CODPROD, FOPRTE.NOMTERM , TO_CHAR(fecha,'YYYYMM') 

    
) T ON F.ANOMES = T.ANOMES
  ) xxx 
  
  order by 3,anomes ;