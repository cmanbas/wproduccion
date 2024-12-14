using ACDATA;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACORACLE
{
    public class AgnoMesrepository
    {
        private readonly string _connectionString;

        public AgnoMesrepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public class CellValueResult
        {
            public bool Success { get; set; }
            public decimal Valor { get; set; }
            public string Comentario { get; set; }
        }


        public class UpdateResult
        {
            public bool Success { get; set; }
            public string Message { get; set; }
            public decimal? NewValue { get; set; }
        }

        public UpdateResult SetCellValueold(string codigo, string materiaPrima, string periodo, int ubicacion, decimal newValue, string comment, string _connectionString)
        {
            try
            {
                using (var connection = new OracleConnection(_connectionString))
                {
                    connection.Open();

                    // Procesamiento del periodo
                    string mes = "";
                    string año = "";

                    if (periodo.Contains("-"))
                    {
                        var partes = periodo.Split('-');
                        mes = partes[0];
                        año = partes[1];
                    }
                    else if (periodo.Length >= 5)
                    {
                        mes = periodo.Substring(0, 3);
                        año = periodo.Substring(3);
                    }
                    else
                    {
                        throw new ArgumentException($"Formato de periodo no válido: {periodo}");
                    }

                    año = año.Trim();
                    if (año.Length > 2)
                    {
                        año = año.Substring(año.Length - 2);
                    }

                    int año20 = int.Parse("20" + año);
                    int mesNumero = MapMesANumero(mes);

                    // Construir AGNOMES (YYYYMM)
                    string agnomes = año20.ToString() + mesNumero.ToString().PadLeft(2, '0');

                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Verificar si existe el registro
                            var queryExiste = @"
                        SELECT COUNT(*)
                        FROM t_produccion_datos
                        WHERE CODIGO = :codigo 
                        AND UBICACION = :ubicacion
                        AND AGNOMES = :agnomes";

                            int existeRegistro = 0;

                            using (var cmdExiste = new OracleCommand(queryExiste, connection))
                            {
                                cmdExiste.Transaction = transaction;
                                cmdExiste.Parameters.Add(":codigo", OracleType.VarChar).Value = codigo;
                                cmdExiste.Parameters.Add(":ubicacion", OracleType.Int32).Value = ubicacion;
                                cmdExiste.Parameters.Add(":agnomes", OracleType.VarChar).Value = agnomes;
                                existeRegistro = Convert.ToInt32(cmdExiste.ExecuteScalar());
                            }

                            string queryPrincipal;
                            OracleCommand command = new OracleCommand();
                            command.Connection = connection;
                            command.Transaction = transaction;

                            if (existeRegistro > 0)
                            {
                                // Query UPDATE
                                queryPrincipal = @"
                            UPDATE t_produccion_datos 
                            SET VALOR = :valor,
                                COMENTARIOS = :comentario
                            WHERE CODIGO = :codigo 
                            AND UBICACION = :ubicacion
                            AND AGNOMES = :agnomes";

                                command.CommandText = queryPrincipal;

                                // Parámetros para UPDATE
                                command.Parameters.Add(":codigo", OracleType.VarChar).Value = codigo;
                                command.Parameters.Add(":ubicacion", OracleType.Int32).Value = ubicacion;
                                command.Parameters.Add(":valor", OracleType.Number).Value = newValue;
                                command.Parameters.Add(":agnomes", OracleType.VarChar).Value = agnomes;
                                command.Parameters.Add(":comentario", OracleType.VarChar).Value =
                               string.IsNullOrEmpty(comment) ? DBNull.Value : (object)comment;
                            }
                            else
                            {
                                // Query INSERT
                                queryPrincipal = @"
                            INSERT INTO t_produccion_datos 
                            (CORRELATIVO, CODIGO, AGNO, MES, UBICACION, VALOR, AGNOMES, COMENTARIOS, DESCRIPCION)
                            VALUES 
                            (T_PRODUCCION_DATOS_SEQ.NEXTVAL, :codigo, :agno, :mes, :ubicacion, :valor, :agnomes, :comentario, :descripcion)";

                                command.CommandText = queryPrincipal;

                                // Parámetros para INSERT
                                command.Parameters.Add(":codigo", OracleType.VarChar).Value = codigo;
                                command.Parameters.Add(":agno", OracleType.Int32).Value = año20;
                                command.Parameters.Add(":mes", OracleType.Int32).Value = mesNumero;
                                command.Parameters.Add(":ubicacion", OracleType.Int32).Value = ubicacion;
                                command.Parameters.Add(":valor", OracleType.Number).Value = newValue;
                                command.Parameters.Add(":agnomes", OracleType.VarChar).Value = agnomes;
                                command.Parameters.Add(":comentario", OracleType.VarChar).Value =
                                string.IsNullOrEmpty(comment) ? DBNull.Value : (object)comment;
                                command.Parameters.Add(":descripcion", OracleType.VarChar).Value = materiaPrima;
                            }

                            command.ExecuteNonQuery();
                            transaction.Commit();

                            return new UpdateResult
                            {
                                Success = true,
                                Message = existeRegistro > 0 ? "Registro actualizado exitosamente" : "Registro creado exitosamente",
                                NewValue = newValue
                            };
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw new Exception($"Error al procesar el registro: {ex.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return new UpdateResult
                {
                    Success = false,
                    Message = $"Error: {ex.Message}"
                };
            }
        }
        private int MapMesANumero(string mes)
        {
            switch (mes.ToUpper())
            {
                case "ENE": return 1;
                case "FEB": return 2;
                case "MAR": return 3;
                case "ABR": return 4;
                case "MAY": return 5;
                case "JUN": return 6;
                case "JUL": return 7;
                case "AGO": return 8;
                case "SEP": return 9;
                case "OCT": return 10;
                case "NOV": return 11;
                case "DIC": return 12;
                default: throw new ArgumentException($"Mes no válido: {mes}");
            }
        }
 


        public CellValueResult GetCellValue(ParametrosActualizacionDTO parametrosActualizacionDTO )
        {
            using (var connection = new OracleConnection(_connectionString))
            {
                connection.Open();

                var query = @"
             SELECT NVL(VALOR, 0) AS VALOR,
                   nvl(COMENTARIOS,' ') as  COMENTARIOS
             FROM t_produccion_datos
             WHERE CODIGO = :codigo 
                AND UBICACION = :ubicacion
                AND AGNOMES = :agnomes";
                CellValueResult cellValueResult = new CellValueResult();
                cellValueResult.Success = false;
                using (var command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(":codigo", OracleType.VarChar).Value = parametrosActualizacionDTO.Codigo.Substring(2,6);
                    command.Parameters.Add(":ubicacion", OracleType.Int32).Value = parametrosActualizacionDTO.Ubicacion;
                    command.Parameters.Add(":agnomes", OracleType.VarChar).Value = parametrosActualizacionDTO.Periodo.Replace("-", "");

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            cellValueResult.Success = true;
                            cellValueResult.Valor = reader.IsDBNull(0) ? 0 : Convert.ToDecimal(reader["VALOR"]);
                            cellValueResult.Comentario = reader.IsDBNull(1) ? null : reader["COMENTARIOS"].ToString();
                           
                        }
                        else
                        {
                            cellValueResult.Success = true;
                            cellValueResult.Valor = 0;
                            cellValueResult.Comentario = "";
                        }
                        return cellValueResult;
                    }
                }
            }
        }
        public UpdateResult SetCellValue(ParametrosActualizacionDTO parametros, string _connectionString)
        {
            try
            {
                using (var connection = new OracleConnection(_connectionString))
                {
                    connection.Open();
                    string mes = "";
                    string anio = "";
                    var partes = parametros.Periodo.Split('-');
                    anio = partes[0];
                    mes = partes[1];
                    parametros.Codigo = parametros.Codigo.Substring(2);

                    int anioCompleto = int.Parse("20" + anio);
                    int mesNumero = int.Parse(partes[1]);

                    // Construir AGNOMES (YYYYMM)
                    string agnomes = anioCompleto.ToString() + mes.ToString().PadLeft(2, '0');

                    using (var transaccion = connection.BeginTransaction())
                    {
                        try
                        {
                            // Verificar si existe el registro
                            var queryExiste = @"
                        SELECT COUNT(*)
                        FROM t_produccion_datos
                        WHERE CODIGO = :codigo 
                        AND UBICACION = :ubicacion
                        AND AGNOMES = :agnomes";

                            int existeRegistro = 0;

                            using (var cmdExiste = new OracleCommand(queryExiste, connection))
                            {
                                cmdExiste.Transaction = transaccion;
                                cmdExiste.Parameters.Add(":codigo", OracleType.VarChar).Value = parametros.Codigo;
                                cmdExiste.Parameters.Add(":ubicacion", OracleType.Int32).Value = parametros.Ubicacion;
                                cmdExiste.Parameters.Add(":agnomes", OracleType.VarChar).Value = parametros.Periodo.Replace("-", "");
                                existeRegistro = Convert.ToInt32(cmdExiste.ExecuteScalar());
                            }

                            if (existeRegistro > 0)
                            {
                                // Obtener el registro original para el log
                                var queryOriginal = @"
                            SELECT VALOR, AGNO, MES, COMENTARIOS ,CORRELATIVO
                            FROM t_produccion_datos
                            WHERE CODIGO = :codigo 
                            AND UBICACION = :ubicacion
                            AND AGNOMES = :agnomes";

                                decimal valorOriginal = 0; int corrdata = 0;
                                int agnoOriginal = 0, mesOriginal = 0;
                                string comentariosOriginal = null;

                                using (var cmdOriginal = new OracleCommand(queryOriginal, connection))
                                {
                                    cmdOriginal.Transaction = transaccion;
                                    cmdOriginal.Parameters.Add(":codigo", OracleType.VarChar).Value = parametros.Codigo;
                                    cmdOriginal.Parameters.Add(":ubicacion", OracleType.Int32).Value = parametros.Ubicacion;
                                    cmdOriginal.Parameters.Add(":agnomes", OracleType.VarChar).Value = parametros.Periodo.Replace("-", "");

                                    using (var reader = cmdOriginal.ExecuteReader())
                                    {
                                        if (reader.Read())
                                        {
                                            valorOriginal = reader.GetDecimal(0);
                                            agnoOriginal = reader.GetInt32(1);
                                            mesOriginal = reader.GetInt32(2);
                                            comentariosOriginal = reader.IsDBNull(3) ? null : reader.GetString(3);
                                            corrdata = reader.GetInt32(4);  
                                        }
                                    }
                                }

                                // Insertar el registro original en T_PRODUCCION_DATOS_LOG
                                var logQuery = @"
                            INSERT INTO t_produccion_datos_log 
                            (CORRELATIVO, CODIGO, UBICACION, AGNOMES, VALOR, AGNO, MES, COMENTARIOS, FECHACREACION)
                            VALUES 
                            (:correlativo, :codigo, :ubicacion, :agnomes, :valor, :agno, :mes, :comentario, SYSDATE)";

                                using (var logCommand = new OracleCommand(logQuery, connection))
                                {
                                    logCommand.Transaction = transaccion;
                                    logCommand.Parameters.Add(":correlativo", OracleType.VarChar).Value = corrdata;
                                    logCommand.Parameters.Add(":codigo", OracleType.VarChar).Value = parametros.Codigo;
                                    logCommand.Parameters.Add(":ubicacion", OracleType.Int32).Value = parametros.Ubicacion;
                                    logCommand.Parameters.Add(":agnomes", OracleType.VarChar).Value = parametros.Periodo.Replace("-","");
                                    logCommand.Parameters.Add(":valor", OracleType.Number).Value = valorOriginal;
                                    logCommand.Parameters.Add(":agno", OracleType.Int32).Value = agnoOriginal;
                                    logCommand.Parameters.Add(":mes", OracleType.Int32).Value = mesOriginal;
                                    logCommand.Parameters.Add(":comentario", OracleType.VarChar).Value =
                                        string.IsNullOrEmpty(comentariosOriginal) ? DBNull.Value : (object)comentariosOriginal;

                                    logCommand.ExecuteNonQuery();
                                }

                                // Realizar el UPDATE
                                var queryUpdate = @"
                            UPDATE t_produccion_datos 
                            SET VALOR = :valor,
                                COMENTARIOS = :comentario
                            WHERE CODIGO = :codigo 
                            AND UBICACION = :ubicacion
                            AND AGNOMES = :agnomes";

                                using (var updateCommand = new OracleCommand(queryUpdate, connection))
                                {
                                    updateCommand.Transaction = transaccion;
                                    updateCommand.Parameters.Add(":codigo", OracleType.VarChar).Value = parametros.Codigo;
                                    updateCommand.Parameters.Add(":ubicacion", OracleType.Int32).Value = parametros.Ubicacion;
                                    updateCommand.Parameters.Add(":valor", OracleType.Number).Value = parametros.NuevoValor;
                                    updateCommand.Parameters.Add(":agnomes", OracleType.VarChar).Value = parametros.Periodo.Replace("-", "");
                                    updateCommand.Parameters.Add(":comentario", OracleType.VarChar).Value =
                                        string.IsNullOrEmpty(parametros.Comentario) ? DBNull.Value : (object)parametros.Comentario;

                                    updateCommand.ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                // Realizar el INSERT
                                var queryInsert = @"
                            INSERT INTO t_produccion_datos 
                            (CORRELATIVO, CODIGO, AGNO, MES, UBICACION, VALOR, AGNOMES, COMENTARIOS, DESCRIPCION)
                            VALUES 
                            (SEQ_T_PRODUCCION_DATOS.NEXTVAL, :codigo, :agno, :mes, :ubicacion, :valor, :agnomes, :comentario, :descripcion)";

                                using (var insertCommand = new OracleCommand(queryInsert, connection))
                                {
                                    insertCommand.Transaction = transaccion;
                                    insertCommand.Parameters.Add(":codigo", OracleType.VarChar).Value = parametros.Codigo;
                                    insertCommand.Parameters.Add(":agno", OracleType.Int32).Value = anio;
                                    insertCommand.Parameters.Add(":mes", OracleType.Int32).Value = mesNumero;
                                    insertCommand.Parameters.Add(":ubicacion", OracleType.Int32).Value = parametros.Ubicacion;
                                    insertCommand.Parameters.Add(":valor", OracleType.Number).Value = parametros.NuevoValor;
                                    insertCommand.Parameters.Add(":agnomes", OracleType.VarChar).Value = parametros.Periodo.Replace("-", "");
                                    insertCommand.Parameters.Add(":comentario", OracleType.VarChar).Value =
                                        string.IsNullOrEmpty(parametros.Comentario) ? DBNull.Value : (object)parametros.Comentario;
                                    insertCommand.Parameters.Add(":descripcion", OracleType.VarChar).Value = string.IsNullOrEmpty(parametros.MateriaPrima) ? DBNull.Value : (object)parametros.MateriaPrima;

                                    insertCommand.ExecuteNonQuery();
                                }
                            }

                            transaccion.Commit();

                            return new UpdateResult
                            {
                                Success = true,
                                Message = existeRegistro > 0 ? "Registro actualizado exitosamente" : "Registro creado exitosamente",
                                NewValue = parametros.NuevoValor
                            };
                        }
                        catch (Exception ex)
                        {
                            transaccion.Rollback();
                            throw new Exception($"Error al procesar el registro: {ex.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return new UpdateResult
                {
                    Success = false,
                    Message = $"Error: {ex.Message}"
                };
            }
        }


    }
}
