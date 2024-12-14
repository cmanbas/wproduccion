using ACDATA;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACORACLE
{
    public class VentasRepository
    {
        private string _connectionString;

        public VentasRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<VentasData> ObtenerVentas()
        {
            var ventasList = new List<VentasData>();

            using (var connection = new OracleConnection(_connectionString))
            {
                connection.Open();
                using (var command = new OracleCommand("SELECT ANOMES, CODIGO, DESCRIPCION, VALOR, CAMPO1, CAMPO2, AGNO, MES FROM FACTURAS.T_VENTASUNIPPTO_PRODUCCION", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            VentasData ventas = new VentasData();

                            // Asignar valores desde el lector de datos
                            ventas.anomes = reader["ANOMES"].ToString();
                            ventas.codigo = reader["CODIGO"].ToString();
                            ventas.descripcion = reader["DESCRIPCION"].ToString();

                            // Convertir y asignar valores numéricos
                            ventas.valor = Convert.ToDecimal(reader["VALOR"]);
                            //ventas.campo1 = Convert.ToInt32(reader["CAMPO1"]);
                            //ventas.campo2 = Convert.ToInt32(reader["CAMPO2"]);
                            ventas.agno = Convert.ToInt32(reader["AGNO"]);
                            ventas.mes = Convert.ToInt32(reader["MES"]);

                            // Agregar la instancia de VentasData a la lista
                            ventasList.Add(ventas);
                        }
                    }
                }
            }

            return ventasList;
        }
    }
}
