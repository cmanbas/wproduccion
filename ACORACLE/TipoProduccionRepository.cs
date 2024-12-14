using ACDATA;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;

public class TipoProduccionRepository
{
    private string connectionString;

    public TipoProduccionRepository(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public void InsertTipoProduccion(TipoProduccionDTO tipoProduccion)
    {
        using (OracleConnection connection = new OracleConnection(connectionString))
        {
            connection.Open();
            OracleTransaction transaction = connection.BeginTransaction();
            try
            {
                string insertQuery = @"INSERT INTO FACTURAS.T_TIPO_PRODUCCION 
                                   (CODINTERNO, DESCRIPCION,   FECHACREACION)
                                   VALUES (SEQ_T_TIPO_PRODUCCION.NEXTVAL, :descripcion,   :fechacreacion)";

                using (OracleCommand command = new OracleCommand(insertQuery, connection))
                {
                    command.Parameters.Add(new OracleParameter(":descripcion", tipoProduccion.DESCRIPCION));
   
                    command.Parameters.Add(new OracleParameter(":fechacreacion", tipoProduccion.FECHACREACION));
                    command.Transaction = transaction;
                    command.ExecuteNonQuery();
                }

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception("Error al insertar tipo de producción: " + ex.Message);
            }
        }
    }

    public List<TipoProduccionDTO> GetTiposProduccion()
    {
        List<TipoProduccionDTO> tiposProduccion = new List<TipoProduccionDTO>();
        using (OracleConnection connection = new OracleConnection(connectionString))
        {
            try
            {
                connection.Open();
                string selectQuery = "SELECT CODINTERNO, DESCRIPCION,  FECHACREACION FROM FACTURAS.T_TIPO_PRODUCCION ORDER BY DESCRIPCION";
                using (OracleCommand command = new OracleCommand(selectQuery, connection))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TipoProduccionDTO tipoProduccion = new TipoProduccionDTO
                            {
                                CODINTERNO = Convert.ToInt32(reader["CODINTERNO"]),
                                DESCRIPCION = reader["DESCRIPCION"].ToString(),
                
                                FECHACREACION = Convert.ToDateTime(reader["FECHACREACION"])
                            };
                            tiposProduccion.Add(tipoProduccion);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los tipos de producción: " + ex.Message);
            }
        }
        return tiposProduccion;
    }

    public void UpdateTipoProduccion(TipoProduccionDTO tipoProduccion)
    {
        using (OracleConnection connection = new OracleConnection(connectionString))
        {
            connection.Open();
            OracleTransaction transaction = connection.BeginTransaction();
            try
            {
                string updateQuery = @"UPDATE FACTURAS.T_TIPO_PRODUCCION
                                   SET DESCRIPCION = :descripcion, FECHACREACION = :fechacreacion
                                   WHERE CODINTERNO = :codinterno";

                using (OracleCommand command = new OracleCommand(updateQuery, connection))
                {
                    command.Parameters.Add(new OracleParameter(":descripcion", tipoProduccion.DESCRIPCION));
 
                    command.Parameters.Add(new OracleParameter(":fechacreacion", tipoProduccion.FECHACREACION));
                    command.Parameters.Add(new OracleParameter(":codinterno", tipoProduccion.CODINTERNO));
                    command.Transaction = transaction;
                    command.ExecuteNonQuery();
                }

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception("Error al actualizar tipo de producción: " + ex.Message);
            }
        }
    }

    public void DeleteTipoProduccion(int codinterno)
    {
        using (OracleConnection connection = new OracleConnection(connectionString))
        {
            connection.Open();
            OracleTransaction transaction = connection.BeginTransaction();
            try
            {
                string deleteQuery = @"DELETE FROM FACTURAS.T_TIPO_PRODUCCION
                                   WHERE CODINTERNO = :codinterno";

                using (OracleCommand command = new OracleCommand(deleteQuery, connection))
                {
                    command.Parameters.Add(new OracleParameter(":codinterno", codinterno));
                    command.Transaction = transaction;
                    command.ExecuteNonQuery();
                }

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception("Error al eliminar el tipo de producción: " + ex.Message);
            }
        }
    }
}