SELECt * FROM API_vENTAS order by 1
union  
SELECt 'api_movimiento' as titulo , count(*)  FROM  api_movimiento  
union 
SELECt 'API_BOLETA' as titulo , count(*) FROM API_BOLETA;  

 