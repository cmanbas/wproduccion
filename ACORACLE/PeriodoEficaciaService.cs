using ACDATA;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;

namespace ACORACLE
{
    public class PeriodoEficaciaService
    {
        public static string _connectionstring;
        public static int filasvalida = 0;
        public static string mensaje = "";

        public static List<PeriodoEficaciaDTO> GetAllPeriodosEficacia()
        {
            filasvalida = 0;
            List<PeriodoEficaciaDTO> periodos = new List<PeriodoEficaciaDTO>();

            try
            {
                using (OracleConnection conn = new OracleConnection(_connectionstring))
                {
                    OracleCommand cmd = new OracleCommand(@"
                        SELECT CODINTERNOPE, CANTMESES, DESCRIPCION
                        FROM FACTURAS.T_PERIODO_EFICACIA
                        ORDER BY CODINTERNOPE", conn);
                    conn.Open();
                    OracleDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        periodos.Add(new PeriodoEficaciaDTO
                        {
                            codinternope = Convert.ToInt32(reader["CODINTERNOPE"]),
                            cantmeses = Convert.ToInt32(reader["CANTMESES"]),
                            descripcion = reader["DESCRIPCION"].ToString()
                        });
                        filasvalida = 1;
                    }
                }
                return periodos;
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                return new List<PeriodoEficaciaDTO>();
            }
        }

        public static bool CreatePeriodoEficacia(PeriodoEficaciaDTO periodo)
        {
            using (OracleConnection conn = new OracleConnection(_connectionstring))
            {
                OracleTransaction transaction = null;
                try
                {
                    conn.Open();
                    transaction = conn.BeginTransaction();
                    OracleCommand cmd = new OracleCommand(@"
                        INSERT INTO FACTURAS.T_PERIODO_EFICACIA (
                            CODINTERNOPE, CANTMESES, DESCRIPCION
                        ) VALUES (
                            FACTURAS.SEQ_T_PERIODO_EFICACIA.NEXTVAL, :cantmeses, :descripcion
                        )", conn);
                    cmd.Transaction = transaction;
                    cmd.Parameters.Add(new OracleParameter("cantmeses", periodo.cantmeses));
                    cmd.Parameters.Add(new OracleParameter("descripcion", periodo.descripcion));
                    filasvalida = cmd.ExecuteNonQuery();

                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    mensaje = ex.Message;
                    transaction?.Rollback();
                    return false;
                }
            }
        }

        public static bool UpdatePeriodoEficacia(PeriodoEficaciaDTO periodo)
        {
            using (OracleConnection conn = new OracleConnection(_connectionstring))
            {
                OracleTransaction transaction = null;
                try
                {
                    conn.Open();
                    transaction = conn.BeginTransaction();
                    OracleCommand cmd = new OracleCommand(@"
                        UPDATE FACTURAS.T_PERIODO_EFICACIA SET 
                            CANTMESES = :cantmeses, 
                            DESCRIPCION = :descripcion
                        WHERE CODINTERNOPE = :codinternope", conn);
                    cmd.Transaction = transaction;
                    cmd.Parameters.Add(new OracleParameter("cantmeses", periodo.cantmeses));
                    cmd.Parameters.Add(new OracleParameter("descripcion", periodo.descripcion));
                    cmd.Parameters.Add(new OracleParameter("codinternope", periodo.codinternope));

                    filasvalida = cmd.ExecuteNonQuery();
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    mensaje = ex.Message;
                    transaction?.Rollback();
                    return false;
                }
            }
        }

        public static bool DeletePeriodoEficacia(int codinternope)
        {
            using (OracleConnection conn = new OracleConnection(_connectionstring))
            {
                OracleTransaction transaction = null;
                try
                {
                    conn.Open();
                    transaction = conn.BeginTransaction();
                    OracleCommand cmd = new OracleCommand("DELETE FROM FACTURAS.T_PERIODO_EFICACIA WHERE CODINTERNOPE = :codinternope", conn);
                    cmd.Transaction = transaction;
                    cmd.Parameters.Add(new OracleParameter("codinternope", codinternope));
                    filasvalida = cmd.ExecuteNonQuery();
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    mensaje = ex.Message;
                    transaction?.Rollback();
                    return false;
                }
            }
        }

        public static PeriodoEficaciaDTO GetPeriodoEficaciaById(int codinternope)
        {
            PeriodoEficaciaDTO periodo = null;

            try
            {
                using (OracleConnection conn = new OracleConnection(_connectionstring))
                {
                    OracleCommand cmd = new OracleCommand(@"
                        SELECT CODINTERNOPE, CANTMESES, DESCRIPCION
                        FROM FACTURAS.T_PERIODO_EFICACIA
                        WHERE CODINTERNOPE = :codinternope", conn);

                    cmd.Parameters.Add(new OracleParameter("codinternope", codinternope));

                    conn.Open();
                    OracleDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        filasvalida = 1;
                        periodo = new PeriodoEficaciaDTO
                        {
                            codinternope = Convert.ToInt32(reader["CODINTERNOPE"]),
                            cantmeses = Convert.ToInt32(reader["CANTMESES"]),
                            descripcion = reader["DESCRIPCION"].ToString()
                        };
                    }
                }
                return periodo;
            }
            catch (Exception ex)
            {
                filasvalida = -1;
                mensaje = ex.Message;
                return null;
            }
        }
    }
}