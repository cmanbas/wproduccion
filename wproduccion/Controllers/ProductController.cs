using ACDATA;
using ACORACLE;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace wproduccion.Controllers
{


    // ViewModels

    // ProductController.cs
    public class ProductController : Controller
    {
 
 

        public ActionResult Index()
        {
            ProductvnRepository productvn = new ProductvnRepository(ConfigurationManager.AppSettings["SQLSERVERORA"]);
                var rawData = productvn.GetAllProductDatavn();
            var processedData = ProcessProductData(rawData);
            return View(processedData);
        }

        private List<ProductViewModel> ProcessProductData(List<ProductData> rawData)
        {
            var groupedData = rawData.GroupBy(d => d.ProductoId);
            var processedData = new List<ProductViewModel>();

            foreach (var group in groupedData)
            {
                var product = group.First();
                var viewModel = new ProductViewModel
                {
                    MP = product.ProductoId,
                    Rows = new List<ProductRowViewModel>




                {
                    new ProductRowViewModel { ORDEN = 1, PRODUCTO = product.Nombre, ANOMES = "STOCK INI MES" },
                    new ProductRowViewModel { ORDEN = 2, PRODUCTO = product.CodigoProducto, ANOMES = "PRODUCCION*" + product.TipoProduccion },
                    new ProductRowViewModel { ORDEN = 3, PRODUCTO = product.CodigoPedido, ANOMES = "ENTREGAS" },
                    new ProductRowViewModel { ORDEN = 4, PRODUCTO = $"PERIODO DE EFICACIA: {product.PeriodoEficacia} M", ANOMES = "OTRAS SALIDAS" },
                    new ProductRowViewModel { ORDEN = 5, PRODUCTO = "..", ANOMES = "CUARENTENA" },
                    new ProductRowViewModel { ORDEN = 6, PRODUCTO = "..", ANOMES = "PPTO VENTAS" },
                    new ProductRowViewModel { ORDEN = 7, PRODUCTO = $"TAMAÑO LOTE: {product.TamanoLote} {product.UnidadLote} ({product.PesoLote} Kg)", ANOMES = "VTAS REALES" },
                    new ProductRowViewModel { ORDEN = 8, PRODUCTO = product.TipoEmpaque, ANOMES = "DIAS STOCK" },
                    new ProductRowViewModel { ORDEN = 9, PRODUCTO = product.UnidadesPorEmpaque.ToString(), ANOMES = "" }
                }
                };

                foreach (var data in group)
                {
                    if (data.Agno.HasValue && data.Mes.HasValue)
                    {
                        var monthKey = $"{data.Agno}-{data.Mes:D2}";
                        viewModel.Rows[0].MonthlyData[monthKey] = data.StockIniMes;
                        viewModel.Rows[1].MonthlyData[monthKey] = data.Produccion;
                        viewModel.Rows[2].MonthlyData[monthKey] = data.Entregas;
                        viewModel.Rows[3].MonthlyData[monthKey] = data.OtrasSalidas;
                        viewModel.Rows[4].MonthlyData[monthKey] = data.Cuarentena;
                        viewModel.Rows[5].MonthlyData[monthKey] = data.PptoVentas;
                        viewModel.Rows[6].MonthlyData[monthKey] = data.VtasReales;
                        viewModel.Rows[7].MonthlyData[monthKey] = data.DiasStock;
                    }
                }

                processedData.Add(viewModel);
            }

            return processedData;
        }
    }


}