using System.Text;
 
using System.Data;
using System.Threading.Tasks;
using System.Data.OracleClient;
using System;
using System.Collections.Generic;
using ACDATA;
using System.Linq;

namespace ACORACLE
{


    public class ReportRepository
    {
        public List<MonthlyReportModel> totallotes = new List<MonthlyReportModel>() ;
        public List<MonthlyReportModel> totalproduccion = new List<MonthlyReportModel>();
        public class UbicacionInfo
        {
            // Propiedades de la clase
            public string TableName { get; set; }
            public int UbicacionValue { get; set; }
            public string UbicacionDesc { get; set; }
            public string Descfila { get; set; }

            // Constructor
            public UbicacionInfo(string tableName, int ubicacionValue, string ubicacionDesc, string descfila)
            {
                TableName = tableName;
                UbicacionValue = ubicacionValue;
                UbicacionDesc = ubicacionDesc;
                Descfila = descfila;
            }
        }

        private readonly string _connectionString;

        public ReportRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<MonthlyReportModel> GetMonthlyReport(int startYear, string tableName, int ubicacionValue, string ubicacionDesc)
        {
            var result = new List<MonthlyReportModel>();

            List<UbicacionInfo> ubicaciones = new List<UbicacionInfo>
          {
            new UbicacionInfo("T_VENTASUNIPPTO_PRODUCCION", 1, "PPTO MENSUAL",""  ),
            new UbicacionInfo("T_STOCKREAL_PRODUCCION", 2, "STOCK REAL","" ), 
            new UbicacionInfo("T_VENTAS_PRODUCCION", 3, "VENTAS" ,"" ),

          };

            // Recorrer y mostrar cada objeto
            foreach (var ubicacion in ubicaciones)
            {
    
                var query = GenerateReportQuery(startYear, ubicacion.TableName, 
                    ubicacion.UbicacionValue, 
                    ubicacion.UbicacionDesc, 
                    ubicacion.Descfila);

                using (var connection = new OracleConnection(_connectionString))
                {
                    connection.Open();
                    using (var command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(":START_YEAR", OracleType.Int32).Value = startYear;
                        
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var model = new MonthlyReportModel();
                               
                                try
                                {

                                    model.Ubicacion = reader["UBICACION"].ToString();
                                    model.UbicacionDescripcion = reader["UBICACION_DESC"].ToString();
                                    model.Codigo = reader["CODIGO"].ToString();
                                    model.NomTerm = reader["NOMBRE"].ToString();
                                    model.descfila = reader["DESCFILA"].ToString();

                                    // Campos con manejo de nulos
                                    model.MateriaPrima = reader["MATERIAPRIMA"]?.ToString();
                                    model.DescMateriaPrima = reader["DESCMATERIAPRIMA"]?.ToString();
                                    model.blister = reader["BLISTER"] != DBNull.Value ? Convert.ToInt32(reader["BLISTER"]) : 0;
                                    model.PeriodoEficacia = reader["PERIODO_EFICACIA"] != DBNull.Value ? Convert.ToInt32(reader["PERIODO_EFICACIA"]) : 0;
                                    model.UnidadTiempo = reader["UNIDADTIEMPO"]?.ToString();
                                    model.Lote = reader["LOTE"]?.ToString();
                                    model.ProduccionPt = reader["PRODUCCIONPT"] != DBNull.Value ? Convert.ToDecimal(reader["PRODUCCIONPT"]) : 0;
                                    model.TipoProduccion = reader["TIPOPRODUCCION"]?.ToString();
                                    model.NombreTabla = reader["NOMBRETABLA"]?.ToString();
                                    model.cantcomprimidos = reader["CANTCOMPRIMIDOS"] != DBNull.Value ? Convert.ToInt32(reader["CANTCOMPRIMIDOS"]) : 0;
                                    model.tipoproducto = reader["TIPOPRODUCTO"]?.ToString();
                                    model.origen = reader["ORIGEN"]?.ToString();
                                    model.comentarios = reader["COMENTARIOS"]?.ToString();
                                    // Valores 2018
                                    model.Ene18 = Convert.ToDecimal(reader["Ene18"]);
                                    model.Feb18 = Convert.ToDecimal(reader["Feb18"]);
                                    model.Mar18 = Convert.ToDecimal(reader["Mar18"]);
                                    model.Abr18 = Convert.ToDecimal(reader["Abr18"]);
                                    model.May18 = Convert.ToDecimal(reader["May18"]);
                                    model.Jun18 = Convert.ToDecimal(reader["Jun18"]);
                                    model.Jul18 = Convert.ToDecimal(reader["Jul18"]);
                                    model.Ago18 = Convert.ToDecimal(reader["Ago18"]);
                                    model.Sep18 = Convert.ToDecimal(reader["Sep18"]);
                                    model.Oct18 = Convert.ToDecimal(reader["Oct18"]);
                                    model.Nov18 = Convert.ToDecimal(reader["Nov18"]);
                                    model.Dic18 = Convert.ToDecimal(reader["Dic18"]);

                                    // Valores 2019
                                    model.Ene19 = Convert.ToDecimal(reader["Ene19"]);
                                    model.Feb19 = Convert.ToDecimal(reader["Feb19"]);
                                    model.Mar19 = Convert.ToDecimal(reader["Mar19"]);
                                    model.Abr19 = Convert.ToDecimal(reader["Abr19"]);
                                    model.May19 = Convert.ToDecimal(reader["May19"]);
                                    model.Jun19 = Convert.ToDecimal(reader["Jun19"]);
                                    model.Jul19 = Convert.ToDecimal(reader["Jul19"]);
                                    model.Ago19 = Convert.ToDecimal(reader["Ago19"]);
                                    model.Sep19 = Convert.ToDecimal(reader["Sep19"]);
                                    model.Oct19 = Convert.ToDecimal(reader["Oct19"]);
                                    model.Nov19 = Convert.ToDecimal(reader["Nov19"]);
                                    model.Dic19 = Convert.ToDecimal(reader["Dic19"]);

                                    // Valores 2020
                                    model.Ene20 = Convert.ToDecimal(reader["Ene20"]);
                                    model.Feb20 = Convert.ToDecimal(reader["Feb20"]);
                                    model.Mar20 = Convert.ToDecimal(reader["Mar20"]);
                                    model.Abr20 = Convert.ToDecimal(reader["Abr20"]);
                                    model.May20 = Convert.ToDecimal(reader["May20"]);
                                    model.Jun20 = Convert.ToDecimal(reader["Jun20"]);
                                    model.Jul20 = Convert.ToDecimal(reader["Jul20"]);
                                    model.Ago20 = Convert.ToDecimal(reader["Ago20"]);
                                    model.Sep20 = Convert.ToDecimal(reader["Sep20"]);
                                    model.Oct20 = Convert.ToDecimal(reader["Oct20"]);
                                    model.Nov20 = Convert.ToDecimal(reader["Nov20"]);
                                    model.Dic20 = Convert.ToDecimal(reader["Dic20"]);
                                }
                                catch (Exception ex)
                                {

                                   
                                }
                                // Campos básicos
                          

                                result.Add(model);
                            }

                        }
                    }
                }
            }

            return result;
        }

        private string GenerateReportQuery(int startYear, string tableName, int ubicacionValue, string ubicacionDesc,string descfila)
        {
            return $@"
SELECT 
     '{tableName}'   AS NOMBRETABLA,
     {ubicacionValue} AS UBICACION,
    '{ubicacionDesc}' AS UBICACION_DESC,
  '{descfila}XXX' AS DESCFILA,

     
    MATERIAPRIMA,
    DESCMATERIAPRIMA,
    CANTBLIESTER BLISTER,
    CEIL( PERIODO_EFICACIAMESES) PERIODO_EFICACIA,
    'M'  UNIDADTIEMPO,
    LOTE,   
    CANTCOMPRIMIDOS,
    PT  PRODUCCIONPT ,
    DESTIPOPRODUCCION TIPOPRODUCCION,  
    CODIGOSAP CODIGO,
    NOMBRE,
    ORIGEN,
    TIPOPRODUCTO,
    'Comentarios' as COMENTARIOS, 
  
NVL(Ene18, 0) AS Ene18,
    NVL(Feb18, 0) AS Feb18,
    NVL(Mar18, 0) AS Mar18,
    NVL(Abr18, 0) AS Abr18,
    NVL(May18, 0) AS May18,
    NVL(Jun18, 0) AS Jun18,
    NVL(Jul18, 0) AS Jul18,
    NVL(Ago18, 0) AS Ago18,
    NVL(Sep18, 0) AS Sep18,
    NVL(Oct18, 0) AS Oct18,
    NVL(Nov18, 0) AS Nov18,
    NVL(Dic18, 0) AS Dic18,
    NVL(Ene19, 0) AS Ene19,
    NVL(Feb19, 0) AS Feb19,
    NVL(Mar19, 0) AS Mar19,
    NVL(Abr19, 0) AS Abr19,
    NVL(May19, 0) AS May19,
    NVL(Jun19, 0) AS Jun19,
    NVL(Jul19, 0) AS Jul19,
    NVL(Ago19, 0) AS Ago19,
    NVL(Sep19, 0) AS Sep19,
    NVL(Oct19, 0) AS Oct19,
    NVL(Nov19, 0) AS Nov19,
    NVL(Dic19, 0) AS Dic19,
    NVL(Ene20, 0) AS Ene20,
    NVL(Feb20, 0) AS Feb20,
    NVL(Mar20, 0) AS Mar20,
    NVL(Abr20, 0) AS Abr20,
    NVL(May20, 0) AS May20,
    NVL(Jun20, 0) AS Jun20,
    NVL(Jul20, 0) AS Jul20,
    NVL(Ago20, 0) AS Ago20,
    NVL(Sep20, 0) AS Sep20,
    NVL(Oct20, 0) AS Oct20,
    NVL(Nov20, 0) AS Nov20,
    NVL(Dic20, 0) AS Dic20
    FROM  V_SAP_BOM_FOPRTE  LEFT OUTER JOIN (
   
    select   
     CODIGO CODIGOV,
    NOMTERM NOMBREV,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR AND MES = 1 THEN VALOR ELSE 0 END), 0) AS Ene18,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR AND MES = 2 THEN VALOR ELSE 0 END), 0) AS Feb18,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR AND MES = 3 THEN VALOR ELSE 0 END), 0) AS Mar18,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR AND MES = 4 THEN VALOR ELSE 0 END), 0) AS Abr18,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR AND MES = 5 THEN VALOR ELSE 0 END), 0) AS May18,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR AND MES = 6 THEN VALOR ELSE 0 END), 0) AS Jun18,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR AND MES = 7 THEN VALOR ELSE 0 END), 0) AS Jul18,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR AND MES = 8 THEN VALOR ELSE 0 END), 0) AS Ago18,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR AND MES = 9 THEN VALOR ELSE 0 END), 0) AS Sep18,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR AND MES = 10 THEN VALOR ELSE 0 END), 0) AS Oct18,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR AND MES = 11 THEN VALOR ELSE 0 END), 0) AS Nov18,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR AND MES = 12 THEN VALOR ELSE 0 END), 0) AS Dic18,
    
    NVL(SUM(CASE WHEN AGNO = :START_YEAR + 1 AND MES = 1 THEN VALOR ELSE 0 END), 0) AS Ene19,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR + 1 AND MES = 2 THEN VALOR ELSE 0 END), 0) AS Feb19,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR + 1 AND MES = 3 THEN VALOR ELSE 0 END), 0) AS Mar19,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR + 1 AND MES = 4 THEN VALOR ELSE 0 END), 0) AS Abr19,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR + 1 AND MES = 5 THEN VALOR ELSE 0 END), 0) AS May19,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR + 1 AND MES = 6 THEN VALOR ELSE 0 END), 0) AS Jun19,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR + 1 AND MES = 7 THEN VALOR ELSE 0 END), 0) AS Jul19,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR + 1 AND MES = 8 THEN VALOR ELSE 0 END), 0) AS Ago19,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR + 1 AND MES = 9 THEN VALOR ELSE 0 END), 0) AS Sep19,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR + 1 AND MES = 10 THEN VALOR ELSE 0 END), 0) AS Oct19,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR + 1 AND MES = 11 THEN VALOR ELSE 0 END), 0) AS Nov19,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR + 1 AND MES = 12 THEN VALOR ELSE 0 END), 0) AS Dic19,
    
    NVL(SUM(CASE WHEN AGNO = :START_YEAR + 2 AND MES = 1 THEN VALOR ELSE 0 END), 0) AS Ene20,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR + 2 AND MES = 2 THEN VALOR ELSE 0 END), 0) AS Feb20,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR + 2 AND MES = 3 THEN VALOR ELSE 0 END), 0) AS Mar20,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR + 2 AND MES = 4 THEN VALOR ELSE 0 END), 0) AS Abr20,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR + 2 AND MES = 5 THEN VALOR ELSE 0 END), 0) AS May20,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR + 2 AND MES = 6 THEN VALOR ELSE 0 END), 0) AS Jun20,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR + 2 AND MES = 7 THEN VALOR ELSE 0 END), 0) AS Jul20,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR + 2 AND MES = 8 THEN VALOR ELSE 0 END), 0) AS Ago20,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR + 2 AND MES = 9 THEN VALOR ELSE 0 END), 0) AS Sep20,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR + 2 AND MES = 10 THEN VALOR ELSE 0 END), 0) AS Oct20,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR + 2 AND MES = 11 THEN VALOR ELSE 0 END), 0) AS Nov20,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR + 2 AND MES = 12 THEN VALOR ELSE 0 END), 0) AS Dic20
FROM 
     {tableName} , FOPRTE 
    WHERE  AGNO BETWEEN :START_YEAR AND :START_YEAR + 2  
    and   codigo  = SUBSTR(codterm, 1, INSTR(codterm, '-') - 1)
    AND  NOMTERM NOT LIKE '%[D]%'  AND  NVL(CODIGO  ,'X') <> 'X' AND TIPROD='CP'
   
GROUP BY  
    CODIGO,
    NOMTERM   -- Agregada esta columna al GROUP BY
  )   MESES
    
 
  
    
  ON  CODIGO  = CODIGOV and ORIGEN='FN' and DESTIPOPRODUCCION <>'S/I' ".Replace("{tableName}", tableName);
        }

        public List<MonthlyReportModel> GetMonthlyReportnv2(int startYear, string tableName, int ubicacionValue, string ubicacionDesc)
        {
            var result = new List<MonthlyReportModel>();


            // Recorrer y mostrar cada objeto
            //result.Add(new MonthlyReportModel());
            //result.Add(new MonthlyReportModel());
            //result.Add(new MonthlyReportModel());

            var query = GenerateReportQuerynv(startYear, tableName, 1, "", "yyy");
                  
                using (var connection = new OracleConnection(_connectionString))
                {
                    connection.Open();
                    using (var command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(":START_YEAR", OracleType.Int32).Value = startYear;

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var model = new MonthlyReportModel();

                                try
                                {
                                    model.MateriaPrima = reader["MATERIAPRIMA"]?.ToString();
                                    model.DescMateriaPrima = reader["DESCMATERIAPRIMA"]?.ToString();

                                    model.Ubicacion = reader["UBICACION"].ToString();
                                    model.UbicacionDescripcion = reader["UBICACION_DESC"].ToString();
                                    model.Codigo = reader["CODIGO"].ToString();
                                    model.NomTerm = reader["NOMBRE"].ToString();
                                    model.descfila = reader["DESCFILA"].ToString();
                                    model.zpt = reader["ZPT"].ToString();
                                    model.pais = reader["CODPAIS"] != DBNull.Value ? Convert.ToInt32(reader["CODPAIS"]) : 0;
                                    model.descpais = reader["DESCPAIS"]?.ToString();   
                                // Campos con manejo de nulos
                                 
                                    model.blister = reader["BLISTER"] != DBNull.Value ? Convert.ToInt32(reader["BLISTER"]) : 0;
                                    model.PeriodoEficacia = reader["PERIODO_EFICACIA"] != DBNull.Value ? Convert.ToInt32(reader["PERIODO_EFICACIA"]) : 0;
                                    model.UnidadTiempo = reader["UNIDADTIEMPO"]?.ToString();
                                    model.Lote = reader["LOTE"]?.ToString();
                                    model.ProduccionPt = reader["PRODUCCIONPT"] != DBNull.Value ? Convert.ToDecimal(reader["PRODUCCIONPT"]) : 0;
                                    model.TipoProduccion = reader["TIPOPRODUCCION"]?.ToString();
                                    model.NombreTabla = reader["NOMBRETABLA"]?.ToString();
                                    model.cantcomprimidos = reader["CANTCOMPRIMIDOS"] != DBNull.Value ? Convert.ToInt32(reader["CANTCOMPRIMIDOS"]) : 0;
                                    model.tipoproducto = reader["TIPOPRODUCTO"]?.ToString();
                                    model.origen = reader["ORIGEN"]?.ToString();
                                    model.comentarios = reader["COMENTARIOS"]?.ToString();
                                    model.cblister = reader["CBLISTER"] != DBNull.Value ? Convert.ToInt32(reader["CBLISTER"]) : 0;
                                    model.sem = reader["SEM"] != DBNull.Value ? Convert.ToInt32(reader["SEM"]) : 0;
 

                                 // Valores 2018
                                     model.Ene18 = Convert.ToDecimal(reader["Ene18"]);
                                    model.Feb18 = Convert.ToDecimal(reader["Feb18"]);
                                    model.Mar18 = Convert.ToDecimal(reader["Mar18"]);
                                    model.Abr18 = Convert.ToDecimal(reader["Abr18"]);
                                    model.May18 = Convert.ToDecimal(reader["May18"]);
                                    model.Jun18 = Convert.ToDecimal(reader["Jun18"]);
                                    model.Jul18 = Convert.ToDecimal(reader["Jul18"]);
                                    model.Ago18 = Convert.ToDecimal(reader["Ago18"]);
                                    model.Sep18 = Convert.ToDecimal(reader["Sep18"]);
                                    model.Oct18 = Convert.ToDecimal(reader["Oct18"]);
                                    model.Nov18 = Convert.ToDecimal(reader["Nov18"]);
                                    model.Dic18 = Convert.ToDecimal(reader["Dic18"]);

                                    // Valores 2019
                                    model.Ene19 = Convert.ToDecimal(reader["Ene19"]);
                                    model.Feb19 = Convert.ToDecimal(reader["Feb19"]);
                                    model.Mar19 = Convert.ToDecimal(reader["Mar19"]);
                                    model.Abr19 = Convert.ToDecimal(reader["Abr19"]);
                                    model.May19 = Convert.ToDecimal(reader["May19"]);
                                    model.Jun19 = Convert.ToDecimal(reader["Jun19"]);
                                    model.Jul19 = Convert.ToDecimal(reader["Jul19"]);
                                    model.Ago19 = Convert.ToDecimal(reader["Ago19"]);
                                    model.Sep19 = Convert.ToDecimal(reader["Sep19"]);
                                    model.Oct19 = Convert.ToDecimal(reader["Oct19"]);
                                    model.Nov19 = Convert.ToDecimal(reader["Nov19"]);
                                    model.Dic19 = Convert.ToDecimal(reader["Dic19"]);

                                    // Valores 2020
                                    model.Ene20 = Convert.ToDecimal(reader["Ene20"]);
                                    model.Feb20 = Convert.ToDecimal(reader["Feb20"]);
                                    model.Mar20 = Convert.ToDecimal(reader["Mar20"]);
                                    model.Abr20 = Convert.ToDecimal(reader["Abr20"]);
                                    model.May20 = Convert.ToDecimal(reader["May20"]);
                                    model.Jun20 = Convert.ToDecimal(reader["Jun20"]);
                                    model.Jul20 = Convert.ToDecimal(reader["Jul20"]);
                                    model.Ago20 = Convert.ToDecimal(reader["Ago20"]);
                                    model.Sep20 = Convert.ToDecimal(reader["Sep20"]);
                                    model.Oct20 = Convert.ToDecimal(reader["Oct20"]);
                                    model.Nov20 = Convert.ToDecimal(reader["Nov20"]);
                                    model.Dic20 = Convert.ToDecimal(reader["Dic20"]);
                                }
                                catch (Exception ex)
                                {
                                string ee = ex.Message.ToString();
                                }
                                // Campos básicos


                                result.Add(model);
                            }

                        }
                    }
                }

           var groupedData = result
          .Where(d => d.Ubicacion == "2")
          .GroupBy(d => d.MateriaPrima)
          .Select(g => new MonthlyReportModel
          {
              MateriaPrima = g.Key,
              DescMateriaPrima = "Suma de " + g.Key,
              Ubicacion = "2",
          
              Ene18 = g.Sum(d => d.Ene18),
              Feb18 = g.Sum(d => d.Feb18),
              Mar18 = g.Sum(d => d.Mar18),
              Abr18 = g.Sum(d => d.Abr18),
              May18 = g.Sum(d => d.May18),
              Jun18 = g.Sum(d => d.Jun18),
              Jul18 = g.Sum(d => d.Jul18),
              Ago18 = g.Sum(d => d.Ago18),
              Sep18 = g.Sum(d => d.Sep18),
              Oct18 = g.Sum(d => d.Oct18),
              Nov18 = g.Sum(d => d.Nov18),
              Dic18 = g.Sum(d => d.Dic18),
              Ene19 = g.Sum(d => d.Ene19),
              Feb19 = g.Sum(d => d.Feb19),
              Mar19 = g.Sum(d => d.Mar19),
              Abr19 = g.Sum(d => d.Abr19),
              May19 = g.Sum(d => d.May19),
              Jun19 = g.Sum(d => d.Jun19),
              Jul19 = g.Sum(d => d.Jul19),
              Ago19 = g.Sum(d => d.Ago19),
              Sep19 = g.Sum(d => d.Sep19),
              Oct19 = g.Sum(d => d.Oct19),
              Nov19 = g.Sum(d => d.Nov19),
              Dic19 = g.Sum(d => d.Dic19),
              Ene20 = g.Sum(d => d.Ene20),
              Feb20 = g.Sum(d => d.Feb20),
              Mar20 = g.Sum(d => d.Mar20),
              Abr20 = g.Sum(d => d.Abr20),
              May20 = g.Sum(d => d.May20),
              Jun20 = g.Sum(d => d.Jun20),
              Jul20 = g.Sum(d => d.Jul20),
              Ago20 = g.Sum(d => d.Ago20),
              Sep20 = g.Sum(d => d.Sep20),
              Oct20 = g.Sum(d => d.Oct20),
              Nov20 = g.Sum(d => d.Nov20),
              Dic20 = g.Sum(d => d.Dic20)
 

 


               
          })
          .ToList();
            var finalResult = new List<MonthlyReportModel>();
            string currentMateriaPrima = null;

            foreach (var item in result)
            {
                if (item.MateriaPrima != currentMateriaPrima)
                {
                    var summaryRow = groupedData.FirstOrDefault(g => g.MateriaPrima == item.MateriaPrima);
                    if (summaryRow != null)
                    {
                        summaryRow.Ubicacion = "1";
                      
                        summaryRow.UbicacionDescripcion = "LOTES";
                        summaryRow.DescMateriaPrima = item.DescMateriaPrima;


                        finalResult.Add(summaryRow);
                    }
                    currentMateriaPrima = item.MateriaPrima;
                }
                finalResult.Add(item);
            }
            var sss = finalResult;


            foreach (var codigo in finalResult.Select(x => x.Codigo).Distinct())
            {
                // Obtener registros de cada ubicación para el código actual
                var ubicacion1 = result.FirstOrDefault(x => x.Ubicacion == "1" && x.UbicacionDescripcion.Contains("STOCK")  && x.Codigo == codigo);
                var ubicacion5 = result.FirstOrDefault(x => x.Ubicacion == "6" && x.Codigo == codigo);
                var ubicacion8 = result.FirstOrDefault(x => x.Ubicacion == "8" && x.Codigo == codigo);

                // Si no existe alguna de las ubicaciones necesarias, continuar con el siguiente código
                if (ubicacion1 == null || ubicacion5 == null || ubicacion8 == null)
                    continue;

                // Actualizar los valores de AñoMes en ubicacion8
                ubicacion8.Ene18 = UpdateMonthValue(ubicacion1.Ene18, ubicacion5.Ene18);
                ubicacion8.Feb18 = UpdateMonthValue(ubicacion1.Feb18, ubicacion5.Feb18);
                ubicacion8.Mar18 = UpdateMonthValue(ubicacion1.Mar18, ubicacion5.Mar18);
                ubicacion8.Abr18 = UpdateMonthValue(ubicacion1.Abr18, ubicacion5.Abr18);
                ubicacion8.May18 = UpdateMonthValue(ubicacion1.May18, ubicacion5.May18);
                ubicacion8.Jun18 = UpdateMonthValue(ubicacion1.Jun18, ubicacion5.Jun18);
                ubicacion8.Jul18 = UpdateMonthValue(ubicacion1.Jul18, ubicacion5.Jul18);
                ubicacion8.Ago18 = UpdateMonthValue(ubicacion1.Ago18, ubicacion5.Ago18);
                ubicacion8.Sep18 = UpdateMonthValue(ubicacion1.Sep18, ubicacion5.Sep18);
                ubicacion8.Oct18 = UpdateMonthValue(ubicacion1.Oct18, ubicacion5.Oct18);
                ubicacion8.Nov18 = UpdateMonthValue(ubicacion1.Nov18, ubicacion5.Nov18);
                ubicacion8.Dic18 = UpdateMonthValue(ubicacion1.Dic18, ubicacion5.Dic18);

                // Repetir para otros años (2019, 2020, etc.)
                ubicacion8.Ene19 = UpdateMonthValue(ubicacion1.Ene19, ubicacion5.Ene19);
                ubicacion8.Feb19 = UpdateMonthValue(ubicacion1.Feb19, ubicacion5.Feb19);
                ubicacion8.Mar19 = UpdateMonthValue(ubicacion1.Mar19, ubicacion5.Mar19);
                ubicacion8.Abr19 = UpdateMonthValue(ubicacion1.Abr19, ubicacion5.Abr19);
                ubicacion8.May19 = UpdateMonthValue(ubicacion1.May19, ubicacion5.May19);
                ubicacion8.Jun19 = UpdateMonthValue(ubicacion1.Jun19, ubicacion5.Jun19);
                ubicacion8.Jul19 = UpdateMonthValue(ubicacion1.Jul19, ubicacion5.Jul19);
                ubicacion8.Ago19 = UpdateMonthValue(ubicacion1.Ago19, ubicacion5.Ago19);
                ubicacion8.Sep19 = UpdateMonthValue(ubicacion1.Sep19, ubicacion5.Sep19);
                ubicacion8.Oct19 = UpdateMonthValue(ubicacion1.Oct19, ubicacion5.Oct19);
                ubicacion8.Nov19 = UpdateMonthValue(ubicacion1.Nov19, ubicacion5.Nov19);
                ubicacion8.Dic19 = UpdateMonthValue(ubicacion1.Dic19, ubicacion5.Dic19);

                // Añadir los meses de 2020
                ubicacion8.Ene20 = UpdateMonthValue(ubicacion1.Ene20, ubicacion5.Ene20);
                ubicacion8.Feb20 = UpdateMonthValue(ubicacion1.Feb20, ubicacion5.Feb20);
                ubicacion8.Mar20 = UpdateMonthValue(ubicacion1.Mar20, ubicacion5.Mar20);
                ubicacion8.Abr20 = UpdateMonthValue(ubicacion1.Abr20, ubicacion5.Abr20);
                ubicacion8.May20 = UpdateMonthValue(ubicacion1.May20, ubicacion5.May20);
                ubicacion8.Jun20 = UpdateMonthValue(ubicacion1.Jun20, ubicacion5.Jun20);
                ubicacion8.Jul20 = UpdateMonthValue(ubicacion1.Jul20, ubicacion5.Jul20);
                ubicacion8.Ago20 = UpdateMonthValue(ubicacion1.Ago20, ubicacion5.Ago20);
                ubicacion8.Sep20 = UpdateMonthValue(ubicacion1.Sep20, ubicacion5.Sep20);
                ubicacion8.Oct20 = UpdateMonthValue(ubicacion1.Oct20, ubicacion5.Oct20);
                ubicacion8.Nov20 = UpdateMonthValue(ubicacion1.Nov20, ubicacion5.Nov20);
                ubicacion8.Dic20 = UpdateMonthValue(ubicacion1.Dic20, ubicacion5.Dic20);
            }

            finalResult.Add(new MonthlyReportModel());
            finalResult.Add(new MonthlyReportModel());
            finalResult.Add(new MonthlyReportModel());


           


            return finalResult;
        }

       
        public List<MonthlyReportModel> GetMonthlyReportnv(int startYear, string tableName, int ubicacionValue, string ubicacionDesc,string calculopl)
        {
          StockCalculo stockCalculo = new StockCalculo();


             


            /* ++++++++++++++++++++++++++++ */

        
            /* ++++++++++++++++++++++++++++ */

            var result = new List<MonthlyReportModel>();
            string currentMateriaPrima = null;

            var query = GenerateReportQuerynv(startYear, tableName, 1, "", "yyy");

            // Primera fase: Carga de datos
            using (var connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                using (var command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(":START_YEAR", OracleType.Int32).Value = startYear;
              
                    totallotes.Add(LoadModelFromReaderheader("TOTAL LOTES"));
                    totalproduccion.Add(LoadModelFromReaderheader("UNIDADES PROD."));
                    result.Add(totallotes[0]);
                    result.Add(totalproduccion[0]);



                    using (var reader = command.ExecuteReader())
                    {
                   
                        while (reader.Read())
                        {
                            var materiaPrima = reader["MATERIAPRIMA"]?.ToString();

                            // Agregar encabezados de materia prima
                            if (materiaPrima != currentMateriaPrima && materiaPrima != null)
                            {
                                var headerModel = new MonthlyReportModel
                                {
                                    Ubicacion = "1",
                                    UbicacionDescripcion = "LOTES",
                                    MateriaPrima = materiaPrima,
                                    DescMateriaPrima = reader["DESCMATERIAPRIMA"]?.ToString()
                                };
                                result.Add(headerModel);
                                currentMateriaPrima = materiaPrima;
                            }

                            var model = new MonthlyReportModel();
                            try
                            {
                                LoadModelFromReader(model, reader);
                                result.Add(model);
                            }
                            catch (Exception ex)
                            {
                                string ee = ex.Message.ToString();
                            }
                        }
                    }
                }
            }
            InitializeMonthlyTotals( totallotes[0]);
            InitializeMonthlyTotals(totalproduccion[0]);
      
 
            ProcessAllCalculations(result, startYear);
   
            ProcessLotesCalculations(result);

            var lotesRows2 = result
           .Where(r => r.UbicacionDescripcion == "LOTES")
           .ToList();
            foreach (var lotesRow in lotesRows2)
            {
                totallotes[0].Ene18 += lotesRow.Ene18;
                totallotes[0].Feb18 += lotesRow.Feb18;
                totallotes[0].Mar18 += lotesRow.Mar18;
                totallotes[0].Abr18 += lotesRow.Abr18;
                totallotes[0].May18 = lotesRow.May18;
                totallotes[0].Jun18 = lotesRow.Jun18;
                totallotes[0].Jul18 = lotesRow.Jul18;
                totallotes[0].Ago18 = lotesRow.Ago18;
                totallotes[0].Sep18 = lotesRow.Sep18;
                totallotes[0].Oct18 = lotesRow.Oct18;
                totallotes[0].Nov18 = lotesRow.Nov18;
                totallotes[0].Dic18 = lotesRow.Dic18;
                // Asignar valores de lotesRow a totallotes[0] para el año 2019
                totallotes[0].Ene19 = lotesRow.Ene19;
                totallotes[0].Feb19 = lotesRow.Feb19;
                totallotes[0].Mar19 = lotesRow.Mar19;
                totallotes[0].Abr19 = lotesRow.Abr19;
                totallotes[0].May19 = lotesRow.May19;
                totallotes[0].Jun19 = lotesRow.Jun19;
                totallotes[0].Jul19 = lotesRow.Jul19;
                totallotes[0].Ago19 = lotesRow.Ago19;
                totallotes[0].Sep19 = lotesRow.Sep19;
                totallotes[0].Oct19 = lotesRow.Oct19;
                totallotes[0].Nov19 = lotesRow.Nov19;
                totallotes[0].Dic19 = lotesRow.Dic19;
                // Asignar valores de lotesRow a totallotes[0] para el año 2020
                totallotes[0].Ene20 = lotesRow.Ene20;
                totallotes[0].Feb20 = lotesRow.Feb20;
                totallotes[0].Mar20 = lotesRow.Mar20;
                totallotes[0].Abr20 = lotesRow.Abr20;
                totallotes[0].May20 = lotesRow.May20;
                totallotes[0].Jun20 = lotesRow.Jun20;
                totallotes[0].Jul20 = lotesRow.Jul20;
                totallotes[0].Ago20 = lotesRow.Ago20;
                totallotes[0].Sep20 = lotesRow.Sep20;
                totallotes[0].Oct20 = lotesRow.Oct20;
                totallotes[0].Nov20 = lotesRow.Nov20;
                totallotes[0].Dic20 = lotesRow.Dic20;

            }


            result[0] = totallotes[0];
            result[1] = totalproduccion[0];
            result.Add(new MonthlyReportModel());
            result.Add(new MonthlyReportModel());
            result.Add(new MonthlyReportModel());

       
            return result;
        }
        private void LoadModelFromReader(MonthlyReportModel model, OracleDataReader reader)
        {
            // Propiedades básicas
            model.MateriaPrima = reader["MATERIAPRIMA"]?.ToString();
            model.DescMateriaPrima = reader["DESCMATERIAPRIMA"]?.ToString();
            model.Ubicacion = reader["UBICACION"].ToString();
            model.UbicacionDescripcion = reader["UBICACION_DESC"].ToString();
            model.Codigo = reader["CODIGO"].ToString();
            model.NomTerm = reader["NOMBRE"].ToString();
            model.descfila = reader["DESCFILA"].ToString();
            model.zpt = reader["ZPT"].ToString();
            model.pais = reader["CODPAIS"] != DBNull.Value ? Convert.ToInt32(reader["CODPAIS"]) : 0;
            model.descpais = reader["DESCPAIS"]?.ToString();
            model.blister = reader["BLISTER"] != DBNull.Value ? Convert.ToInt32(reader["BLISTER"]) : 0;
            model.PeriodoEficacia = reader["PERIODO_EFICACIA"] != DBNull.Value ? Convert.ToInt32(reader["PERIODO_EFICACIA"]) : 0;
            model.UnidadTiempo = reader["UNIDADTIEMPO"]?.ToString();
            model.Lote = reader["LOTE"]?.ToString();
            model.ProduccionPt = reader["PRODUCCIONPT"] != DBNull.Value ? Convert.ToDecimal(reader["PRODUCCIONPT"]) : 0;
            model.TipoProduccion = reader["TIPOPRODUCCION"]?.ToString();
            model.NombreTabla = reader["NOMBRETABLA"]?.ToString();
            model.cantcomprimidos = reader["CANTCOMPRIMIDOS"] != DBNull.Value ? Convert.ToInt32(reader["CANTCOMPRIMIDOS"]) : 0;
            model.tipoproducto = reader["TIPOPRODUCTO"]?.ToString();
            model.origen = reader["ORIGEN"]?.ToString();
            model.comentarios = reader["COMENTARIOS"]?.ToString();
            model.cblister = reader["CBLISTER"] != DBNull.Value ? Convert.ToInt32(reader["CBLISTER"]) : 0;
            model.sem = reader["SEM"] != DBNull.Value ? Convert.ToInt32(reader["SEM"]) : 0;

            // Valores mensuales 2018
            model.Ene18 = Convert.ToDecimal(reader["Ene18"]);
            model.Feb18 = Convert.ToDecimal(reader["Feb18"]);
            model.Mar18 = Convert.ToDecimal(reader["Mar18"]);
            model.Abr18 = Convert.ToDecimal(reader["Abr18"]);
            model.May18 = Convert.ToDecimal(reader["May18"]);
            model.Jun18 = Convert.ToDecimal(reader["Jun18"]);
            model.Jul18 = Convert.ToDecimal(reader["Jul18"]);
            model.Ago18 = Convert.ToDecimal(reader["Ago18"]);
            model.Sep18 = Convert.ToDecimal(reader["Sep18"]);
            model.Oct18 = Convert.ToDecimal(reader["Oct18"]);
            model.Nov18 = Convert.ToDecimal(reader["Nov18"]);
            model.Dic18 = Convert.ToDecimal(reader["Dic18"]);

            // Valores mensuales 2019
            model.Ene19 = Convert.ToDecimal(reader["Ene19"]);
            model.Feb19 = Convert.ToDecimal(reader["Feb19"]);
            model.Mar19 = Convert.ToDecimal(reader["Mar19"]);
            model.Abr19 = Convert.ToDecimal(reader["Abr19"]);
            model.May19 = Convert.ToDecimal(reader["May19"]);
            model.Jun19 = Convert.ToDecimal(reader["Jun19"]);
            model.Jul19 = Convert.ToDecimal(reader["Jul19"]);
            model.Ago19 = Convert.ToDecimal(reader["Ago19"]);
            model.Sep19 = Convert.ToDecimal(reader["Sep19"]);
            model.Oct19 = Convert.ToDecimal(reader["Oct19"]);
            model.Nov19 = Convert.ToDecimal(reader["Nov19"]);
            model.Dic19 = Convert.ToDecimal(reader["Dic19"]);

            // Valores mensuales 2020
            model.Ene20 = Convert.ToDecimal(reader["Ene20"]);
            model.Feb20 = Convert.ToDecimal(reader["Feb20"]);
            model.Mar20 = Convert.ToDecimal(reader["Mar20"]);
            model.Abr20 = Convert.ToDecimal(reader["Abr20"]);
            model.May20 = Convert.ToDecimal(reader["May20"]);
            model.Jun20 = Convert.ToDecimal(reader["Jun20"]);
            model.Jul20 = Convert.ToDecimal(reader["Jul20"]);
            model.Ago20 = Convert.ToDecimal(reader["Ago20"]);
            model.Sep20 = Convert.ToDecimal(reader["Sep20"]);
            model.Oct20 = Convert.ToDecimal(reader["Oct20"]);
            model.Nov20 = Convert.ToDecimal(reader["Nov20"]);
            model.Dic20 = Convert.ToDecimal(reader["Dic20"]);
            model.cEne18 = Convert.ToInt32(reader["cEne18"]);
            model.cFeb18 = Convert.ToInt32(reader["cFeb18"]);
            model.cMar18 = Convert.ToInt32(reader["cMar18"]);
            model.cAbr18 = Convert.ToInt32(reader["cAbr18"]);
            model.cMay18 = Convert.ToInt32(reader["cMay18"]);
            model.cJun18 = Convert.ToInt32(reader["cJun18"]);
            model.cJul18 = Convert.ToInt32(reader["cJul18"]);
            model.cAgo18 = Convert.ToInt32(reader["cAgo18"]);
            model.cSep18 = Convert.ToInt32(reader["cSep18"]);
            model.cOct18 = Convert.ToInt32(reader["cOct18"]);
            model.cNov18 = Convert.ToInt32(reader["cNov18"]);
            model.cDic18 = Convert.ToInt32(reader["cDic18"]);


            // Valores de comentarios 2019
            model.cEne19 = Convert.ToInt32(reader["cEne19"]);
            model.cFeb19 = Convert.ToInt32(reader["cFeb19"]);
            model.cMar19 = Convert.ToInt32(reader["cMar19"]);
            model.cAbr19 = Convert.ToInt32(reader["cAbr19"]);
            model.cMay19 = Convert.ToInt32(reader["cMay19"]);
            model.cJun19 = Convert.ToInt32(reader["cJun19"]);
            model.cJul19 = Convert.ToInt32(reader["cJul19"]);
            model.cAgo19 = Convert.ToInt32(reader["cAgo19"]);
            model.cSep19 = Convert.ToInt32(reader["cSep19"]);
            model.cOct19 = Convert.ToInt32(reader["cOct19"]);
            model.cNov19 = Convert.ToInt32(reader["cNov19"]);
            model.cDic19 = Convert.ToInt32(reader["cDic19"]);

            // Valores de comentarios 2020
            model.cEne20 = Convert.ToInt32(reader["cEne20"]);
            model.cFeb20 = Convert.ToInt32(reader["cFeb20"]);
            model.cMar20 = Convert.ToInt32(reader["cMar20"]);
            model.cAbr20 = Convert.ToInt32(reader["cAbr20"]);
            model.cMay20 = Convert.ToInt32(reader["cMay20"]);
            model.cJun20 = Convert.ToInt32(reader["cJun20"]);
            model.cJul20 = Convert.ToInt32(reader["cJul20"]);
            model.cAgo20 = Convert.ToInt32(reader["cAgo20"]);
            model.cSep20 = Convert.ToInt32(reader["cSep20"]);
            model.cOct20 = Convert.ToInt32(reader["cOct20"]);
            model.cNov20 = Convert.ToInt32(reader["cNov20"]);
            model.cDic20 = Convert.ToInt32(reader["cDic20"]);
        }

        private MonthlyReportModel LoadModelFromReaderheader (string encabezado )
        {
            MonthlyReportModel model = new MonthlyReportModel();
            // Propiedades básicas
            model.MateriaPrima = "";
            model.DescMateriaPrima = "";
            model.Ubicacion = " .";
            model.UbicacionDescripcion = encabezado;
            model.Codigo = "";  
            model.NomTerm = "";
            model.descfila = "";
            model.zpt = "";
            model.pais =   0;
            model.descpais = "";
            model.blister = 0;
            model.PeriodoEficacia =   0;
            model.UnidadTiempo = "";
            model.Lote = "";
            model.ProduccionPt = 0;
            model.TipoProduccion = " ";
            model.NombreTabla = "";
            model.cantcomprimidos = 0;
            model.tipoproducto = "";
            model.origen = "";
            model.comentarios ="";
            model.cblister =  0;
            model.sem =   0;

            model.Ene18 = 0;
            model.Feb18 = 0;
            model.Mar18 = 0;
            model.Abr18 = 0;
            model.May18 = 0;
            model.Jun18 = 0;
            model.Jul18 = 0;
            model.Ago18 = 0;
            model.Sep18 = 0;
            model.Oct18 = 0;
            model.Nov18 = 0;
            model.Dic18 = 0;

            // Valores mensuales 2019
            model.Ene19 = 0;
            model.Feb19 = 0;
            model.Mar19 = 0;
            model.Abr19 = 0;
            model.May19 = 0;
            model.Jun19 = 0;
            model.Jul19 = 0;
            model.Ago19 = 0;
            model.Sep19 = 0;
            model.Oct19 = 0;
            model.Nov19 = 0;
            model.Dic19 = 0;

            // Valores mensuales 2020
            model.Ene20 = 0;
            model.Feb20 = 0;
            model.Mar20 = 0;
            model.Abr20 = 0;
            model.May20 = 0;
            model.Jun20 = 0;
            model.Jul20 = 0;
            model.Ago20 = 0;
            model.Sep20 = 0;
            model.Oct20 = 0;
            model.Nov20 = 0;
            model.Dic20 = 0;

            model.cEne18 = 0;
            model.cFeb18 = 0;
            model.cMar18 = 0;
            model.cAbr18 = 0;
            model.cMay18 = 0;
            model.cJun18 = 0;
            model.cJul18 = 0;
            model.cAgo18 = 0;
            model.cSep18 = 0;
            model.cOct18 = 0;
            model.cNov18 = 0;
            model.cDic18 = 0;

            // Valores de comentarios 2019
            model.cEne19 = 0;
            model.cFeb19 = 0;
            model.cMar19 = 0;
            model.cAbr19 = 0;
            model.cMay19 = 0;
            model.cJun19 = 0;
            model.cJul19 = 0;
            model.cAgo19 = 0;
            model.cSep19 = 0;
            model.cOct19 = 0;
            model.cNov19 = 0;
            model.cDic19 = 0;

            // Valores de comentarios 2020
            model.cEne20 = 0;
            model.cFeb20 = 0;
            model.cMar20 = 0;
            model.cAbr20 = 0;
            model.cMay20 = 0;
            model.cJun20 = 0;
            model.cJul20 = 0;
            model.cAgo20 = 0;
            model.cSep20 = 0;
            model.cOct20 = 0;
            model.cNov20 = 0;
            model.cDic20 = 0;
            return model;
        }
        private void ProcessAllCalculations(List<MonthlyReportModel> allRecords, int startYear)
        {
            // Agrupar por MateriaPrima y Codigo, excluyendo registros de encabezado
            var productGroups = allRecords
                .Where(r => !string.IsNullOrEmpty(r.Codigo)) // Excluir headers
                .GroupBy(r => new { r.MateriaPrima, r.Codigo });

            foreach (var group in productGroups)
            {
                var models = group.ToList();
                var location2 = models.FirstOrDefault(m => m.Ubicacion == "1");
                var location6 = models.FirstOrDefault(m => m.Ubicacion == "6");
                var location8 = models.FirstOrDefault(m => m.Ubicacion == "8");

                if (location2 != null && location6 != null && location8 != null)
                {
                    UpdateLocation8Values(location8, location2, location6, startYear);
                }
            }
        }
        private void ProcessAllstock(List<MonthlyReportModel> allRecords, int startYear)
        {
            // Agrupar por MateriaPrima y Codigo, excluyendo registros de encabezado
            var productGroups = allRecords
                .Where(r => !string.IsNullOrEmpty(r.Codigo) ) // Excluir headers
                .GroupBy(r => new { r.MateriaPrima, r.Codigo });

            foreach (var group in productGroups)
            {
                var models = group.ToList();
                var location2 = models.FirstOrDefault(m => m.Ubicacion == "1");
                var location6 = models.FirstOrDefault(m => m.Ubicacion == "2");
                var location8 = models.FirstOrDefault(m => m.Ubicacion == "5");

                if (location2 != null && location6 != null && location8 != null)
                {
                    UpdateLocationStock(location8, location2, location6, startYear);
                }
            }
        }




        private void UpdateLocation8Values(MonthlyReportModel location8, MonthlyReportModel location2, MonthlyReportModel location6, int startyear)
        {
            // Actualizar valores 2018
            location8.Ene18 = SafeDivide(location2.Ene18, location6.Ene18);
            location8.Feb18 = SafeDivide(location2.Feb18, location6.Feb18);
            location8.Mar18 = SafeDivide(location2.Mar18, location6.Mar18);
            location8.Abr18 = SafeDivide(location2.Abr18, location6.Abr18);
            location8.May18 = SafeDivide(location2.May18, location6.May18);
            location8.Jun18 = SafeDivide(location2.Jun18, location6.Jun18);
            location8.Jul18 = SafeDivide(location2.Jul18, location6.Jul18);
            location8.Ago18 = SafeDivide(location2.Ago18, location6.Ago18);
            location8.Sep18 = SafeDivide(location2.Sep18, location6.Sep18);
            location8.Oct18 = SafeDivide(location2.Oct18, location6.Oct18);
            location8.Nov18 = SafeDivide(location2.Nov18, location6.Nov18);
            location8.Dic18 = SafeDivide(location2.Dic18, location6.Dic18);

            // Actualizar valores 2019
            location8.Ene19 = SafeDivide(location2.Ene19, location6.Ene19);
            location8.Feb19 = SafeDivide(location2.Feb19, location6.Feb19);
            location8.Mar19 = SafeDivide(location2.Mar19, location6.Mar19);
            location8.Abr19 = SafeDivide(location2.Abr19, location6.Abr19);
            location8.May19 = SafeDivide(location2.May19, location6.May19);
            location8.Jun19 = SafeDivide(location2.Jun19, location6.Jun19);
            location8.Jul19 = SafeDivide(location2.Jul19, location6.Jul19);
            location8.Ago19 = SafeDivide(location2.Ago19, location6.Ago19);
            location8.Sep19 = SafeDivide(location2.Sep19, location6.Sep19);
            location8.Oct19 = SafeDivide(location2.Oct19, location6.Oct19);
            location8.Nov19 = SafeDivide(location2.Nov19, location6.Nov19);
            location8.Dic19 = SafeDivide(location2.Dic19, location6.Dic19);

            // Actualizar valores 2020
            location8.Ene20 = SafeDivide(location2.Ene20, location6.Ene20);
            location8.Feb20 = SafeDivide(location2.Feb20, location6.Feb20);
            location8.Mar20 = SafeDivide(location2.Mar20, location6.Mar20);
            location8.Abr20 = SafeDivide(location2.Abr20, location6.Abr20);
            location8.May20 = SafeDivide(location2.May20, location6.May20);
            location8.Jun20 = SafeDivide(location2.Jun20, location6.Jun20);
            location8.Jul20 = SafeDivide(location2.Jul20, location6.Jul20);
            location8.Ago20 = SafeDivide(location2.Ago20, location6.Ago20);
            location8.Sep20 = SafeDivide(location2.Sep20, location6.Sep20);
            location8.Oct20 = SafeDivide(location2.Oct20, location6.Oct20);
            location8.Nov20 = SafeDivide(location2.Nov20, location6.Nov20);
            location8.Dic20 = SafeDivide(location2.Dic20, location6.Dic20);
        }
        private void UpdateLocationStock(MonthlyReportModel location8, MonthlyReportModel location2, MonthlyReportModel location6, int startyear)
        {
            // Actualizar valores 2018
            location8.Ene18 = SafeDivide(location2.Ene18, location6.Ene18);
            location8.Feb18 = SafeDivide(location2.Feb18, location6.Feb18);
            location8.Mar18 = SafeDivide(location2.Mar18, location6.Mar18);
            location8.Abr18 = SafeDivide(location2.Abr18, location6.Abr18);
            location8.May18 = SafeDivide(location2.May18, location6.May18);
            location8.Jun18 = SafeDivide(location2.Jun18, location6.Jun18);
            location8.Jul18 = SafeDivide(location2.Jul18, location6.Jul18);
            location8.Ago18 = SafeDivide(location2.Ago18, location6.Ago18);
            location8.Sep18 = SafeDivide(location2.Sep18, location6.Sep18);
            location8.Oct18 = SafeDivide(location2.Oct18, location6.Oct18);
            location8.Nov18 = SafeDivide(location2.Nov18, location6.Nov18);
            location8.Dic18 = SafeDivide(location2.Dic18, location6.Dic18);

            // Actualizar valores 2019
            location8.Ene19 = SafeDivide(location2.Ene19, location6.Ene19);
            location8.Feb19 = SafeDivide(location2.Feb19, location6.Feb19);
            location8.Mar19 = SafeDivide(location2.Mar19, location6.Mar19);
            location8.Abr19 = SafeDivide(location2.Abr19, location6.Abr19);
            location8.May19 = SafeDivide(location2.May19, location6.May19);
            location8.Jun19 = SafeDivide(location2.Jun19, location6.Jun19);
            location8.Jul19 = SafeDivide(location2.Jul19, location6.Jul19);
            location8.Ago19 = SafeDivide(location2.Ago19, location6.Ago19);
            location8.Sep19 = SafeDivide(location2.Sep19, location6.Sep19);
            location8.Oct19 = SafeDivide(location2.Oct19, location6.Oct19);
            location8.Nov19 = SafeDivide(location2.Nov19, location6.Nov19);
            location8.Dic19 = SafeDivide(location2.Dic19, location6.Dic19);

            // Actualizar valores 2020
            location8.Ene20 = SafeDivide(location2.Ene20, location6.Ene20);
            location8.Feb20 = SafeDivide(location2.Feb20, location6.Feb20);
            location8.Mar20 = SafeDivide(location2.Mar20, location6.Mar20);
            location8.Abr20 = SafeDivide(location2.Abr20, location6.Abr20);
            location8.May20 = SafeDivide(location2.May20, location6.May20);
            location8.Jun20 = SafeDivide(location2.Jun20, location6.Jun20);
            location8.Jul20 = SafeDivide(location2.Jul20, location6.Jul20);
            location8.Ago20 = SafeDivide(location2.Ago20, location6.Ago20);
            location8.Sep20 = SafeDivide(location2.Sep20, location6.Sep20);
            location8.Oct20 = SafeDivide(location2.Oct20, location6.Oct20);
            location8.Nov20 = SafeDivide(location2.Nov20, location6.Nov20);
            location8.Dic20 = SafeDivide(location2.Dic20, location6.Dic20);
        }
        private decimal SafeDivide(decimal numerator, decimal denominator)
        {
            var salid = denominator == 0 ? 0 : (numerator / denominator );
            return salid * 30;
        }
        decimal UpdateMonthValue(decimal value1, decimal value5)
        {
            if (value5 == 0)
                return 0;

            return (value1 / value5) * 30;
        }
        decimal UpdateMonthValueNV(decimal value1, decimal value5,int blister)
        {
            if (value5 == 0)
                return 0;

            return (value1 / value5) * 30;
        }
        private string GenerateReportQuerynv(int startYear, string tableName, int ubicacionValue, string ubicacionDesc, string descfila)
        {
            return $@"
    SELECT 
    0 DESCFILA,
    'DATOSPROD' NOMBRETABLA,
    UBICACION,
    descripcion AS UBICACION_DESC,
    MATERIAPRIMA,
    DESCMATERIAPRIMA,    
    CODIGOSAP CODIGO,
    NOMBRE,
    CANTBLIESTER BLISTER,
    PERIODO_EFICACIAMESES PERIODO_EFICACIA,
    'M'  UNIDADTIEMPO,
    LOTE,   
    CANTCOMPRIMIDOS,
    PT  PRODUCCIONPT ,
    DESTIPOPRODUCCION TIPOPRODUCCION,  
    ORIGEN,
    CODPAIS,
    PAIS_EXPORTACION DESCPAIS,
    BWART ZPT,
    TIPOPRODUCTO,
    ' ' COMENTARIOS,
    SEM SEM,
    0 CBLISTER,
    NVL(Ene18, 0) AS Ene18,
    NVL(Feb18, 0) AS Feb18,
    NVL(Mar18, 0) AS Mar18,
    NVL(Abr18, 0) AS Abr18,
    NVL(May18, 0) AS May18,
    NVL(Jun18, 0) AS Jun18,
    NVL(Jul18, 0) AS Jul18,
    NVL(Ago18, 0) AS Ago18,
    NVL(Sep18, 0) AS Sep18,
    NVL(Oct18, 0) AS Oct18,
    NVL(Nov18, 0) AS Nov18,
    NVL(Dic18, 0) AS Dic18,
    NVL(Ene19, 0) AS Ene19,
    NVL(Feb19, 0) AS Feb19,
    NVL(Mar19, 0) AS Mar19,
    NVL(Abr19, 0) AS Abr19,
    NVL(May19, 0) AS May19,
    NVL(Jun19, 0) AS Jun19,
    NVL(Jul19, 0) AS Jul19,
    NVL(Ago19, 0) AS Ago19,
    NVL(Sep19, 0) AS Sep19,
    NVL(Oct19, 0) AS Oct19,
    NVL(Nov19, 0) AS Nov19,
    NVL(Dic19, 0) AS Dic19,
    NVL(Ene20, 0) AS Ene20,
    NVL(Feb20, 0) AS Feb20,
    NVL(Mar20, 0) AS Mar20,
    NVL(Abr20, 0) AS Abr20,
    NVL(May20, 0) AS May20,
    NVL(Jun20, 0) AS Jun20,
    NVL(Jul20, 0) AS Jul20,
    NVL(Ago20, 0) AS Ago20,
    NVL(Sep20, 0) AS Sep20,
    NVL(Oct20, 0) AS Oct20,
    NVL(Nov20, 0) AS Nov20,
    NVL(Dic20, 0) AS Dic20,
    NVL(cEne18, 0) AS cEne18,
    NVL(cFeb18, 0) AS cFeb18,
    NVL(cMar18, 0) AS cMar18,
    NVL(cAbr18, 0) AS cAbr18,
    NVL(cMay18, 0) AS cMay18,
    NVL(cJun18, 0) AS cJun18,
    NVL(cJul18, 0) AS cJul18,
    NVL(cAgo18, 0) AS cAgo18,
    NVL(cSep18, 0) AS cSep18,
    NVL(cOct18, 0) AS cOct18,
    NVL(cNov18, 0) AS cNov18,
    NVL(cDic18, 0) AS cDic18,
    NVL(cEne19, 0) AS cEne19,
    NVL(cFeb19, 0) AS cFeb19,
    NVL(cMar19, 0) AS cMar19,
    NVL(cAbr19, 0) AS cAbr19,
    NVL(cMay19, 0) AS cMay19,
    NVL(cJun19, 0) AS cJun19,
    NVL(cJul19, 0) AS cJul19,
    NVL(cAgo19, 0) AS cAgo19,
    NVL(cSep19, 0) AS cSep19,
    NVL(cOct19, 0) AS cOct19,
    NVL(cNov19, 0) AS cNov19,
    NVL(cDic19, 0) AS cDic19,
    NVL(cEne20, 0) AS cEne20,
    NVL(cFeb20, 0) AS cFeb20,
    NVL(cMar20, 0) AS cMar20,
    NVL(cAbr20, 0) AS cAbr20,
    NVL(cMay20, 0) AS cMay20,
    NVL(cJun20, 0) AS cJun20,
    NVL(cJul20, 0) AS cJul20,
    NVL(cAgo20, 0) AS cAgo20,
    NVL(cSep20, 0) AS cSep20,
    NVL(cOct20, 0) AS cOct20,
    NVL(cNov20, 0) AS cNov20,
    NVL(cDic20, 0) AS cDic20 

    FROM  V_SAP_BOM_FOPRTEV2  LEFT OUTER JOIN (
   
    select   
    UBICACION UBICACIONV, 
    CODIGO CODIGOV,
    DESCRIPCION NOMBREV,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR AND MES = 1 THEN VALOR ELSE 0 END), 0) AS Ene18,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR AND MES = 2 THEN VALOR ELSE 0 END), 0) AS Feb18,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR AND MES = 3 THEN VALOR ELSE 0 END), 0) AS Mar18,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR AND MES = 4 THEN VALOR ELSE 0 END), 0) AS Abr18,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR AND MES = 5 THEN VALOR ELSE 0 END), 0) AS May18,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR AND MES = 6 THEN VALOR ELSE 0 END), 0) AS Jun18,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR AND MES = 7 THEN VALOR ELSE 0 END), 0) AS Jul18,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR AND MES = 8 THEN VALOR ELSE 0 END), 0) AS Ago18,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR AND MES = 9 THEN VALOR ELSE 0 END), 0) AS Sep18,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR AND MES = 10 THEN VALOR ELSE 0 END), 0) AS Oct18,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR AND MES = 11 THEN VALOR ELSE 0 END), 0) AS Nov18,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR AND MES = 12 THEN VALOR ELSE 0 END), 0) AS Dic18,
    
    NVL(SUM(CASE WHEN AGNO = :START_YEAR + 1 AND MES = 1 THEN VALOR ELSE 0 END), 0) AS Ene19,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR + 1 AND MES = 2 THEN VALOR ELSE 0 END), 0) AS Feb19,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR + 1 AND MES = 3 THEN VALOR ELSE 0 END), 0) AS Mar19,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR + 1 AND MES = 4 THEN VALOR ELSE 0 END), 0) AS Abr19,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR + 1 AND MES = 5 THEN VALOR ELSE 0 END), 0) AS May19,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR + 1 AND MES = 6 THEN VALOR ELSE 0 END), 0) AS Jun19,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR + 1 AND MES = 7 THEN VALOR ELSE 0 END), 0) AS Jul19,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR + 1 AND MES = 8 THEN VALOR ELSE 0 END), 0) AS Ago19,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR + 1 AND MES = 9 THEN VALOR ELSE 0 END), 0) AS Sep19,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR + 1 AND MES = 10 THEN VALOR ELSE 0 END), 0) AS Oct19,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR + 1 AND MES = 11 THEN VALOR ELSE 0 END), 0) AS Nov19,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR + 1 AND MES = 12 THEN VALOR ELSE 0 END), 0) AS Dic19,
    
    NVL(SUM(CASE WHEN AGNO = :START_YEAR + 2 AND MES = 1 THEN VALOR ELSE 0 END), 0) AS Ene20,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR + 2 AND MES = 2 THEN VALOR ELSE 0 END), 0) AS Feb20,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR + 2 AND MES = 3 THEN VALOR ELSE 0 END), 0) AS Mar20,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR + 2 AND MES = 4 THEN VALOR ELSE 0 END), 0) AS Abr20,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR + 2 AND MES = 5 THEN VALOR ELSE 0 END), 0) AS May20,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR + 2 AND MES = 6 THEN VALOR ELSE 0 END), 0) AS Jun20,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR + 2 AND MES = 7 THEN VALOR ELSE 0 END), 0) AS Jul20,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR + 2 AND MES = 8 THEN VALOR ELSE 0 END), 0) AS Ago20,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR + 2 AND MES = 9 THEN VALOR ELSE 0 END), 0) AS Sep20,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR + 2 AND MES = 10 THEN VALOR ELSE 0 END), 0) AS Oct20,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR + 2 AND MES = 11 THEN VALOR ELSE 0 END), 0) AS Nov20,
    NVL(SUM(CASE WHEN AGNO = :START_YEAR + 2 AND MES = 12 THEN VALOR ELSE 0 END), 0) AS Dic20,

    NVL(sum(CASE WHEN AGNO = :START_YEAR AND MES = 1 and nvl(comentarios,' ') <> ' ' THEN 1 ELSE null END), 0) AS cEne18,
    NVL(sum(CASE WHEN AGNO = :START_YEAR AND MES = 2 and nvl(comentarios,' ') <> ' ' THEN 1 ELSE null END), 0) AS cFeb18,
    NVL(sum(CASE WHEN AGNO = :START_YEAR AND MES = 3 and nvl(comentarios,' ') <> ' ' THEN 1 ELSE null END), 0) AS cMar18,
    NVL(sum(CASE WHEN AGNO = :START_YEAR AND MES = 4 and nvl(comentarios,' ') <> ' ' THEN 1 ELSE null END), 0) AS cAbr18,
    NVL(sum(CASE WHEN AGNO = :START_YEAR AND MES = 5 and nvl(comentarios,' ') <> ' ' THEN 1 ELSE null END), 0) AS cMay18,
    NVL(sum(CASE WHEN AGNO = :START_YEAR AND MES = 6 and nvl(comentarios,' ') <> ' ' THEN 1 ELSE null END), 0) AS cJun18,
    NVL(sum(CASE WHEN AGNO = :START_YEAR AND MES = 7 and nvl(comentarios,' ') <> ' ' THEN 1 ELSE null END), 0) AS cJul18,
    NVL(sum(CASE WHEN AGNO = :START_YEAR AND MES = 8 and nvl(comentarios,' ') <> ' ' THEN 1 ELSE null END), 0) AS cAgo18,
    NVL(sum(CASE WHEN AGNO = :START_YEAR AND MES = 9 and nvl(comentarios,' ') <> ' ' THEN 1 ELSE null END), 0) AS cSep18,
    NVL(sum(CASE WHEN AGNO = :START_YEAR AND MES = 10 and nvl(comentarios,' ') <> ' ' THEN 1 ELSE null END), 0) AS cOct18,
    NVL(sum(CASE WHEN AGNO = :START_YEAR AND MES = 11 and nvl(comentarios,' ') <> ' ' THEN 1 ELSE null END), 0) AS cNov18,
    NVL(sum(CASE WHEN AGNO = :START_YEAR AND MES = 12 and nvl(comentarios,' ') <> ' ' THEN 1 ELSE null END), 0) AS cDic18,

    -- Para el año START_YEAR + 1
    NVL(sum(CASE WHEN AGNO = :START_YEAR + 1 AND MES = 1 and nvl(comentarios,' ') <> ' ' THEN 1 ELSE null END), 0) AS cEne19,
    NVL(sum(CASE WHEN AGNO = :START_YEAR + 1 AND MES = 2 and nvl(comentarios,' ') <> ' ' THEN 1 ELSE null END), 0) AS cFeb19,
    NVL(sum(CASE WHEN AGNO = :START_YEAR + 1 AND MES = 3 and nvl(comentarios,' ') <> ' ' THEN 1 ELSE null END), 0) AS cMar19,
    NVL(sum(CASE WHEN AGNO = :START_YEAR + 1 AND MES = 4 and nvl(comentarios,' ') <> ' ' THEN 1 ELSE null END), 0) AS cAbr19,
    NVL(sum(CASE WHEN AGNO = :START_YEAR + 1 AND MES = 5 and nvl(comentarios,' ') <> ' ' THEN 1 ELSE null END), 0) AS cMay19,
    NVL(sum(CASE WHEN AGNO = :START_YEAR + 1 AND MES = 6 and nvl(comentarios,' ') <> ' ' THEN 1 ELSE null END), 0) AS cJun19,
    NVL(sum(CASE WHEN AGNO = :START_YEAR + 1 AND MES = 7 and nvl(comentarios,' ') <> ' ' THEN 1 ELSE null END), 0) AS cJul19,
    NVL(sum(CASE WHEN AGNO = :START_YEAR + 1 AND MES = 8 and nvl(comentarios,' ') <> ' ' THEN 1 ELSE null END), 0) AS cAgo19,
    NVL(sum(CASE WHEN AGNO = :START_YEAR + 1 AND MES = 9 and nvl(comentarios,' ') <> ' ' THEN 1 ELSE null END), 0) AS cSep19,
    NVL(sum(CASE WHEN AGNO = :START_YEAR + 1 AND MES = 10 and nvl(comentarios,' ') <> ' ' THEN 1 ELSE null END), 0) AS cOct19,
    NVL(sum(CASE WHEN AGNO = :START_YEAR + 1 AND MES = 11 and nvl(comentarios,' ') <> ' ' THEN 1 ELSE null END), 0) AS cNov19,
    NVL(sum(CASE WHEN AGNO = :START_YEAR + 1 AND MES = 12 and nvl(comentarios,' ') <> ' ' THEN 1 ELSE null END), 0) AS cDic19,

    -- Para el año START_YEAR + 2
    NVL(sum(CASE WHEN AGNO = :START_YEAR + 2 AND MES = 1 and nvl(comentarios,' ') <> ' ' THEN 1 ELSE null END), 0) AS cEne20,
    NVL(sum(CASE WHEN AGNO = :START_YEAR + 2 AND MES = 2 and nvl(comentarios,' ') <> ' ' THEN 1 ELSE null END), 0) AS cFeb20,
    NVL(sum(CASE WHEN AGNO = :START_YEAR + 2 AND MES = 3 and nvl(comentarios,' ') <> ' ' THEN 1 ELSE null END), 0) AS cMar20,
    NVL(sum(CASE WHEN AGNO = :START_YEAR + 2 AND MES = 4 and nvl(comentarios,' ') <> ' ' THEN 1 ELSE null END), 0) AS cAbr20,
    NVL(sum(CASE WHEN AGNO = :START_YEAR + 2 AND MES = 5 and nvl(comentarios,' ') <> ' ' THEN 1 ELSE null END), 0) AS cMay20,
    NVL(sum(CASE WHEN AGNO = :START_YEAR + 2 AND MES = 6 and nvl(comentarios,' ') <> ' ' THEN 1 ELSE null END), 0) AS cJun20,
    NVL(sum(CASE WHEN AGNO = :START_YEAR + 2 AND MES = 7 and nvl(comentarios,' ') <> ' ' THEN 1 ELSE null END), 0) AS cJul20,
    NVL(sum(CASE WHEN AGNO = :START_YEAR + 2 AND MES = 8 and nvl(comentarios,' ') <> ' ' THEN 1 ELSE null END), 0) AS cAgo20,
    NVL(sum(CASE WHEN AGNO = :START_YEAR + 2 AND MES = 9 and nvl(comentarios,' ') <> ' ' THEN 1 ELSE null END), 0) AS cSep20,
    NVL(sum(CASE WHEN AGNO = :START_YEAR + 2 AND MES = 10 and nvl(comentarios,' ') <> ' ' THEN 1 ELSE null END), 0) AS cOct20,
    NVL(sum(CASE WHEN AGNO = :START_YEAR + 2 AND MES = 11 and nvl(comentarios,' ') <> ' ' THEN 1 ELSE null END), 0) AS cNov20,
    NVL(sum(CASE WHEN AGNO = :START_YEAR + 2 AND MES = 12 and nvl(comentarios,' ') <> ' ' THEN 1 ELSE null END), 0) AS cDic20


FROM 
     t_produccion_datos , FOPRTE 
    WHERE  AGNO BETWEEN :START_YEAR AND :START_YEAR + 2  
    and   codigo  = SUBSTR(codterm, 1, INSTR(codterm, '-') - 1)
    AND  NOMTERM NOT LIKE '%[D]%'  AND  NVL(CODIGO  ,'X') <> 'X' AND TIPROD='CP'
   
GROUP BY 
    UBICACION,
    CODIGO,
    DESCRIPCION   -- Agregada esta columna al GROUP BY
  )   MESES
    
 
  
    
  ON  CODIGO  = CODIGOV AND UBICACION=UBICACIONV
  WHERE  ORIGEN='FN' AND TIPOPRODUCTO='CP' " + (tableName!="0"? "  AND  MATERIAPRIMA ='" + tableName + "'" : " " )+
 " ORDER BY MATERIAPRIMA, CODIGOSAP, UBICACION, descripcion    "  ;
        }


        private void ProcessLotesCalculations(List<MonthlyReportModel> allRecords)
        {
            // Procesar cada fila de LOTES
            var lotesRows = allRecords
                .Where(r => r.UbicacionDescripcion == "LOTES")
                .ToList();

            foreach (var lotesRow in lotesRows)
            {
                var materiaPrima = lotesRow.MateriaPrima;

                // Obtener todos los códigos para esta materia prima
                var codigosProducto = allRecords
                    .Where(r => r.MateriaPrima == materiaPrima &&
                           !string.IsNullOrEmpty(r.Codigo))
                    .Select(r => r.Codigo)
                    .Distinct()
                    .ToList();

                // Inicializar totales para esta materia prima
                InitializeMonthlyTotals(lotesRow);

                // Procesar cada código
                foreach (var codigo in codigosProducto)
                {
                    // Obtener todas las ubicaciones para este código
                    var ubicacionesProducto = allRecords
                        .Where(r => r.MateriaPrima == materiaPrima &&
                               r.Codigo == codigo &&  r.Ubicacion =="2" &&
                               !string.IsNullOrEmpty(r.Ubicacion))
                        .ToList();

                    // Obtener el valor de blister para este código
                    var blisterValue = ubicacionesProducto.FirstOrDefault()?.blister ?? 0;
                    if (blisterValue <= 0) continue;

                    // Sumar valores de todas las ubicaciones para este código
                    var sumaMensual = new MonthlyReportModel();
                    InitializeMonthlyTotals(sumaMensual);

                    foreach (var ubicacion in ubicacionesProducto)
                    {
                        // Sumar valores 2018
                        sumaMensual.Ene18 += ubicacion.Ene18;
                        sumaMensual.Feb18 += ubicacion.Feb18;
                        sumaMensual.Mar18 += ubicacion.Mar18;
                        sumaMensual.Abr18 += ubicacion.Abr18;
                        sumaMensual.May18 += ubicacion.May18;
                        sumaMensual.Jun18 += ubicacion.Jun18;
                        sumaMensual.Jul18 += ubicacion.Jul18;
                        sumaMensual.Ago18 += ubicacion.Ago18;
                        sumaMensual.Sep18 += ubicacion.Sep18;
                        sumaMensual.Oct18 += ubicacion.Oct18;
                        sumaMensual.Nov18 += ubicacion.Nov18;
                        sumaMensual.Dic18 += ubicacion.Dic18;

                        // Sumar valores 2019
                        sumaMensual.Ene19 += ubicacion.Ene19;
                        sumaMensual.Feb19 += ubicacion.Feb19;
                        sumaMensual.Mar19 += ubicacion.Mar19;
                        sumaMensual.Abr19 += ubicacion.Abr19;
                        sumaMensual.May19 += ubicacion.May19;
                        sumaMensual.Jun19 += ubicacion.Jun19;
                        sumaMensual.Jul19 += ubicacion.Jul19;
                        sumaMensual.Ago19 += ubicacion.Ago19;
                        sumaMensual.Sep19 += ubicacion.Sep19;
                        sumaMensual.Oct19 += ubicacion.Oct19;
                        sumaMensual.Nov19 += ubicacion.Nov19;
                        sumaMensual.Dic19 += ubicacion.Dic19;

                        // Sumar valores 2020
                        sumaMensual.Ene20 += ubicacion.Ene20;
                        sumaMensual.Feb20 += ubicacion.Feb20;
                        sumaMensual.Mar20 += ubicacion.Mar20;
                        sumaMensual.Abr20 += ubicacion.Abr20;
                        sumaMensual.May20 += ubicacion.May20;
                        sumaMensual.Jun20 += ubicacion.Jun20;
                        sumaMensual.Jul20 += ubicacion.Jul20;
                        sumaMensual.Ago20 += ubicacion.Ago20;
                        sumaMensual.Sep20 += ubicacion.Sep20;
                        sumaMensual.Oct20 += ubicacion.Oct20;
                        sumaMensual.Nov20 += ubicacion.Nov20;
                        sumaMensual.Dic20 += ubicacion.Dic20;



                        totalproduccion[0].Ene18 += ubicacion.Ene18;
                        totalproduccion[0].Feb18 += ubicacion.Feb18;
                        totalproduccion[0].Mar18 += ubicacion.Mar18;
                        totalproduccion[0].Abr18 += ubicacion.Abr18;
                        totalproduccion[0].May18 += ubicacion.May18;
                        totalproduccion[0].Jun18 += ubicacion.Jun18;
                        totalproduccion[0].Jul18 += ubicacion.Jul18;
                        totalproduccion[0].Ago18 += ubicacion.Ago18;
                        totalproduccion[0].Sep18 += ubicacion.Sep18;
                        totalproduccion[0].Oct18 += ubicacion.Oct18;
                        totalproduccion[0].Nov18 += ubicacion.Nov18;
                        totalproduccion[0].Dic18 += ubicacion.Dic18;
                        // Sumar valores 2019
                        totalproduccion[0].Ene19 += ubicacion.Ene19;
                        totalproduccion[0].Feb19 += ubicacion.Feb19;
                        totalproduccion[0].Mar19 += ubicacion.Mar19;
                        totalproduccion[0].Abr19 += ubicacion.Abr19;
                        totalproduccion[0].May19 += ubicacion.May19;
                        totalproduccion[0].Jun19 += ubicacion.Jun19;
                        totalproduccion[0].Jul19 += ubicacion.Jul19;
                        totalproduccion[0].Ago19 += ubicacion.Ago19;
                        totalproduccion[0].Sep19 += ubicacion.Sep19;
                        totalproduccion[0].Oct19 += ubicacion.Oct19;
                        totalproduccion[0].Nov19 += ubicacion.Nov19;
                        totalproduccion[0].Dic19 += ubicacion.Dic19;
                        // Sumar valores 2020
                        totalproduccion[0].Ene20 += ubicacion.Ene20;
                        totalproduccion[0].Feb20 += ubicacion.Feb20;
                        totalproduccion[0].Mar20 += ubicacion.Mar20;
                        totalproduccion[0].Abr20 += ubicacion.Abr20;
                        totalproduccion[0].May20 += ubicacion.May20;
                        totalproduccion[0].Jun20 += ubicacion.Jun20;
                        totalproduccion[0].Jul20 += ubicacion.Jul20;
                        totalproduccion[0].Ago20 += ubicacion.Ago20;
                        totalproduccion[0].Sep20 += ubicacion.Sep20;
                        totalproduccion[0].Oct20 += ubicacion.Oct20;
                        totalproduccion[0].Nov20 += ubicacion.Nov20;
                        totalproduccion[0].Dic20 += ubicacion.Dic20;
                    }

                    // Dividir por blister y sumar al total de la materia prima
                    lotesRow.Ene18 += SafeDivisionLotes(sumaMensual.Ene18, blisterValue);
                    lotesRow.Feb18 += SafeDivisionLotes(sumaMensual.Feb18, blisterValue);
                    lotesRow.Mar18 += SafeDivisionLotes(sumaMensual.Mar18, blisterValue);
                    lotesRow.Abr18 += SafeDivisionLotes(sumaMensual.Abr18, blisterValue);
                    lotesRow.May18 += SafeDivisionLotes(sumaMensual.May18, blisterValue);
                    lotesRow.Jun18 += SafeDivisionLotes(sumaMensual.Jun18, blisterValue);
                    lotesRow.Jul18 += SafeDivisionLotes(sumaMensual.Jul18, blisterValue);
                    lotesRow.Ago18 += SafeDivisionLotes(sumaMensual.Ago18, blisterValue);
                    lotesRow.Sep18 += SafeDivisionLotes(sumaMensual.Sep18, blisterValue);
                    lotesRow.Oct18 += SafeDivisionLotes(sumaMensual.Oct18, blisterValue);
                    lotesRow.Nov18 += SafeDivisionLotes(sumaMensual.Nov18, blisterValue);
                    lotesRow.Dic18 += SafeDivisionLotes(sumaMensual.Dic18, blisterValue);

                    lotesRow.Ene19 += SafeDivisionLotes(sumaMensual.Ene19, blisterValue);
                    lotesRow.Feb19 += SafeDivisionLotes(sumaMensual.Feb19, blisterValue);
                    lotesRow.Mar19 += SafeDivisionLotes(sumaMensual.Mar19, blisterValue);
                    lotesRow.Abr19 += SafeDivisionLotes(sumaMensual.Abr19, blisterValue);
                    lotesRow.May19 += SafeDivisionLotes(sumaMensual.May19, blisterValue);
                    lotesRow.Jun19 += SafeDivisionLotes(sumaMensual.Jun19, blisterValue);
                    lotesRow.Jul19 += SafeDivisionLotes(sumaMensual.Jul19, blisterValue);
                    lotesRow.Ago19 += SafeDivisionLotes(sumaMensual.Ago19, blisterValue);
                    lotesRow.Sep19 += SafeDivisionLotes(sumaMensual.Sep19, blisterValue);
                    lotesRow.Oct19 += SafeDivisionLotes(sumaMensual.Oct19, blisterValue);
                    lotesRow.Nov19 += SafeDivisionLotes(sumaMensual.Nov19, blisterValue);
                    lotesRow.Dic19 += SafeDivisionLotes(sumaMensual.Dic19, blisterValue);

                    lotesRow.Ene20 += SafeDivisionLotes(sumaMensual.Ene20, blisterValue);
                    lotesRow.Feb20 += SafeDivisionLotes(sumaMensual.Feb20, blisterValue);
                    lotesRow.Mar20 += SafeDivisionLotes(sumaMensual.Mar20, blisterValue);
                    lotesRow.Abr20 += SafeDivisionLotes(sumaMensual.Abr20, blisterValue);
                    lotesRow.May20 += SafeDivisionLotes(sumaMensual.May20, blisterValue);
                    lotesRow.Jun20 += SafeDivisionLotes(sumaMensual.Jun20, blisterValue);
                    lotesRow.Jul20 += SafeDivisionLotes(sumaMensual.Jul20, blisterValue);
                    lotesRow.Ago20 += SafeDivisionLotes(sumaMensual.Ago20, blisterValue);
                    lotesRow.Sep20 += SafeDivisionLotes(sumaMensual.Sep20, blisterValue);
                    lotesRow.Oct20 += SafeDivisionLotes(sumaMensual.Oct20, blisterValue);
                    lotesRow.Nov20 += SafeDivisionLotes(sumaMensual.Nov20, blisterValue);
                    lotesRow.Dic20 += SafeDivisionLotes(sumaMensual.Dic20, blisterValue);
                  
                }
            }
           

        }
        decimal SafeDivisionLotes(decimal numerator, int denominator)
        {
            return denominator != 0 ? numerator / denominator : 0;
        }
        private void InitializeMonthlyTotals(MonthlyReportModel model)
        {
            // 2018
            model.Ene18 = 0; model.Feb18 = 0; model.Mar18 = 0;
            model.Abr18 = 0; model.May18 = 0; model.Jun18 = 0;
            model.Jul18 = 0; model.Ago18 = 0; model.Sep18 = 0;
            model.Oct18 = 0; model.Nov18 = 0; model.Dic18 = 0;

            // 2019
            model.Ene19 = 0; model.Feb19 = 0; model.Mar19 = 0;
            model.Abr19 = 0; model.May19 = 0; model.Jun19 = 0;
            model.Jul19 = 0; model.Ago19 = 0; model.Sep19 = 0;
            model.Oct19 = 0; model.Nov19 = 0; model.Dic19 = 0;

            // 2020
            model.Ene20 = 0; model.Feb20 = 0; model.Mar20 = 0;
            model.Abr20 = 0; model.May20 = 0; model.Jun20 = 0;
            model.Jul20 = 0; model.Ago20 = 0; model.Sep20 = 0;
            model.Oct20 = 0; model.Nov20 = 0; model.Dic20 = 0;
        }
      



    }
}
