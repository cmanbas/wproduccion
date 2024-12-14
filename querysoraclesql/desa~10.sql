delete from MOVIMIENTO where  TO_CHAR(N_MOFECHA, 'YYYY-MM-DD') >='2024-10-12' ;
delete from VENTA_TRG_LOG;

delete from VENTAS where  TO_CHAR(N_VEFECEMI, 'YYYY-MM-DD') >='2024-10-12' ;

 