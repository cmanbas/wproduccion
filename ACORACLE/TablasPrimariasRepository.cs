using ACDATA;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACORACLE
{
    
    // Repository
    public class MateriasPrimasRepository
    {
        private readonly string connectionString;

        public MateriasPrimasRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<MateriasPrimasDTO> GetMaterialesByBwart()
        {
            List<MateriasPrimasDTO> materiales = new List<MateriasPrimasDTO>();
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string selectQuery = @"SELECT MATNR, 
                                            MAKTX,
                                            CASE 
                                                WHEN SUBSTR(MATNR, 1, 2) != '32' THEN 'FN'
                                                ELSE 'IMP' 
                                            END AS ORIGEN 
                                     FROM sap_materiales 
                                      
                                     ORDER BY MAKTX";

                    using (OracleCommand command = new OracleCommand(selectQuery, connection))
                    {
                     

                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                MateriasPrimasDTO material = new MateriasPrimasDTO
                                {
                                    Matnr = reader["MATNR"].ToString(),
                                    Maktx = reader["MAKTX"].ToString(),
                                    Origen = reader["ORIGEN"].ToString()
                                };
                                materiales.Add(material);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener las materias primas: " + ex.Message);
                }
                finally
                {
                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
            return materiales;
        }


        public List<MateriasPrimasDTO> GetMaterialesCPFN()
        {
            List<MateriasPrimasDTO> materiales = new List<MateriasPrimasDTO>();
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string selectQuery = @"SELECT 
              DISTINCT  MATERIAPRIMA,
                DESCMATERIAPRIMA,
                TIPOPRODUCTO, 
                CASE 
                WHEN SUBSTR(MATERIAPRIMA, 1, 2) != '32' THEN 'FN'
                ELSE 'IMP' 
                END AS ORIGEN

                    FROM (
                                SELECT 
                                        SAP_BOM.IDNRK MATERIAPRIMA ,
                                        ( SELECT   MAKTX FROM  SAP_MATERIALES  SP WHERE SP.MATNR  = SAP_BOM.IDNRK ) DESCMATERIAPRIMA,
                    
                    
                                        NVL( ( select  tiprod from tablas.foprte where SUBSTR(CODTERM, 1, INSTR(CODTERM, '-') - 1)   =  SUBSTR(SAP_BOM.MATNR, 3) )   ,'S/I')  TIPOPRODUCTO 
                                        FROM     SAP_BOM SAP_BOM  INNER JOIN 
                                        SAP_MATERIALES ON SAP_BOM.IDNRK = SAP_MATERIALES.MATNR
                                        INNER JOIN foprte ON  SUBSTR(SAP_BOM.MATNR, 3) = SUBSTR(codterm, 1, INSTR(codterm, '-') - 1)
                                        INNER JOIN SAP_MATERIALES  SP2 ON SP2.MATNR  = SAP_BOM.MATNR 
                    )  PRODUCTOS  where TIPOPRODUCTO='CP' AND CASE 
                    WHEN SUBSTR(MATERIAPRIMA, 1, 2) != '32' THEN 'FN'
                    ELSE 'IMP' 
                    END ='FN'
                    ORDER BY DESCMATERIAPRIMA ,materiaprima ";

                    using (OracleCommand command = new OracleCommand(selectQuery, connection))
                    {


                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                MateriasPrimasDTO material = new MateriasPrimasDTO
                                {
                                    Matnr = reader["MATERIAPRIMA"].ToString(),
                                    Maktx = reader["DESCMATERIAPRIMA"].ToString(),
                                    Origen = reader["ORIGEN"].ToString()
                                };
                                materiales.Add(material);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener las materias primas: " + ex.Message);
                }
                finally
                {
                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
            return materiales;
        }






    }
}
