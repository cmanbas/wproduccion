using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACDATA
{
    public class MonthlyReportModel
    {
        public string Ubicacion { get; set; }
        public string UbicacionDescripcion { get; set; }
        public string Codigo { get; set; }
        public string NomTerm { get; set; }
        public string comentarios { get; set; }
        public string descfila { get; set; }

        public string MateriaPrima { get; set; }
        public string NombreTabla { get; set; }
        public string DescMateriaPrima { get; set; }
        public int blister { get; set; }
        public int PeriodoEficacia { get; set; }
        public string UnidadTiempo { get; set; }
        public string Lote { get; set; }
        public int numLote { get; set; }
        public decimal ProduccionPt { get; set; }
        public string TipoProduccion { get; set; }
        public int cantcomprimidos { get; set; }
        public string  tipoproducto { get; set; }
        public string origen { get; set; }
        public decimal lotesrec { get; set; }

        public int cblister { get; set; }
        public int sem { get; set; }
        public string zpt { get; set; }
        public int pais { get; set; }
        public string descpais { get; set; }

        public decimal Ene18 { get; set; }
        public int cEne18 { get; set; }
        public int vEne18 { get; set; } // Campo adicional
        public decimal Feb18 { get; set; }
        public int cFeb18 { get; set; }
        public int vFeb18 { get; set; } // Campo adicional
        public decimal Mar18 { get; set; }
        public int cMar18 { get; set; }
        public int vMar18 { get; set; } // Campo adicional
        public decimal Abr18 { get; set; }
        public int cAbr18 { get; set; }
        public int vAbr18 { get; set; } // Campo adicional
        public decimal May18 { get; set; }
        public int cMay18 { get; set; }
        public int vMay18 { get; set; } // Campo adicional
        public decimal Jun18 { get; set; }
        public int cJun18 { get; set; }
        public int vJun18 { get; set; } // Campo adicional
        public decimal Jul18 { get; set; }
        public int cJul18 { get; set; }
        public int vJul18 { get; set; } // Campo adicional
        public decimal Ago18 { get; set; }
        public int cAgo18 { get; set; }
        public int vAgo18 { get; set; } // Campo adicional
        public decimal Sep18 { get; set; }
        public int cSep18 { get; set; }
        public int vSep18 { get; set; } // Campo adicional
        public decimal Oct18 { get; set; }
        public int cOct18 { get; set; }
        public int vOct18 { get; set; } // Campo adicional
        public decimal Nov18 { get; set; }
        public int cNov18 { get; set; }
        public int vNov18 { get; set; } // Campo adicional
        public decimal Dic18 { get; set; }
        public int cDic18 { get; set; }
        public int vDic18 { get; set; } // Campo adicional

        // Propiedades 2019
        public decimal Ene19 { get; set; }
        public int cEne19 { get; set; }
        public int vEne19 { get; set; } // Campo adicional
        public decimal Feb19 { get; set; }
        public int cFeb19 { get; set; }
        public int vFeb19 { get; set; } // Campo adicional
        public decimal Mar19 { get; set; }
        public int cMar19 { get; set; }
        public int vMar19 { get; set; } // Campo adicional
        public decimal Abr19 { get; set; }
        public int cAbr19 { get; set; }
        public int vAbr19 { get; set; } // Campo adicional
        public decimal May19 { get; set; }
        public int cMay19 { get; set; }
        public int vMay19 { get; set; } // Campo adicional
        public decimal Jun19 { get; set; }
        public int cJun19 { get; set; }
        public int vJun19 { get; set; } // Campo adicional
        public decimal Jul19 { get; set; }
        public int cJul19 { get; set; }
        public int vJul19 { get; set; } // Campo adicional
        public decimal Ago19 { get; set; }
        public int cAgo19 { get; set; }
        public int vAgo19 { get; set; } // Campo adicional
        public decimal Sep19 { get; set; }
        public int cSep19 { get; set; }
        public int vSep19 { get; set; } // Campo adicional
        public decimal Oct19 { get; set; }
        public int cOct19 { get; set; }
        public int vOct19 { get; set; } // Campo adicional
        public decimal Nov19 { get; set; }
        public int cNov19 { get; set; }
        public int vNov19 { get; set; } // Campo adicional
        public decimal Dic19 { get; set; }
        public int cDic19 { get; set; }
        public int vDic19 { get; set; } // Campo adicional

        // Propiedades 2020
        public decimal Ene20 { get; set; }
        public int cEne20 { get; set; }
        public int vEne20 { get; set; } // Campo adicional
        public decimal Feb20 { get; set; }
        public int cFeb20 { get; set; }
        public int vFeb20 { get; set; } // Campo adicional
        public decimal Mar20 { get; set; }
        public int cMar20 { get; set; }
        public int vMar20 { get; set; } // Campo adicional
        public decimal Abr20 { get; set; }
        public int cAbr20 { get; set; }
        public int vAbr20 { get; set; } // Campo adicional
        public decimal May20 { get; set; }
        public int cMay20 { get; set; }
        public int vMay20 { get; set; } // Campo adicional
        public decimal Jun20 { get; set; }
        public int cJun20 { get; set; }
        public int vJun20 { get; set; } // Campo adicional
        public decimal Jul20 { get; set; }
        public int cJul20 { get; set; }
        public int vJul20 { get; set; } // Campo adicional
        public decimal Ago20 { get; set; }
        public int cAgo20 { get; set; }
        public int vAgo20 { get; set; } // Campo adicional
        public decimal Sep20 { get; set; }
        public int cSep20 { get; set; }
        public int vSep20 { get; set; } // Campo adicional
        public decimal Oct20 { get; set; }
        public int cOct20 { get; set; }
        public int vOct20 { get; set; } // Campo adicional
        public decimal Nov20 { get; set; }
        public int cNov20 { get; set; }
        public int vNov20 { get; set; } // Campo adicional
        public decimal Dic20 { get; set; }
        public int cDic20 { get; set; }
        public int vDic20 { get; set; } // Campo adicional
    }
    public class TotalotesDTO
    {
        public string Ubicacion { get; set; }
        public string UbicacionDescripcion { get; set; }
        public string Codigo { get; set; }
        public string NomTerm { get; set; }
        public string comentarios { get; set; }
        public string descfila { get; set; }

        public string MateriaPrima { get; set; }
        public string NombreTabla { get; set; }
        public string DescMateriaPrima { get; set; }
        public int blister { get; set; }
        public int PeriodoEficacia { get; set; }
        public string UnidadTiempo { get; set; }
        public string Lote { get; set; }
        public int numLote { get; set; }
        public decimal ProduccionPt { get; set; }
        public string TipoProduccion { get; set; }
        public int cantcomprimidos { get; set; }
        public string tipoproducto { get; set; }
        public string origen { get; set; }
        public decimal lotesrec { get; set; }

        public int cblister { get; set; }
        public int sem { get; set; }
        public string zpt { get; set; }
        public int pais { get; set; }
        public string descpais { get; set; }

        public decimal Ene18 { get; set; }
        public decimal Feb18 { get; set; }
        public decimal Mar18 { get; set; }
        public decimal Abr18 { get; set; }
        public decimal May18 { get; set; }
        public decimal Jun18 { get; set; }
        public decimal Jul18 { get; set; }
        public decimal Ago18 { get; set; }
        public decimal Sep18 { get; set; }
        public decimal Oct18 { get; set; }
        public decimal Nov18 { get; set; }
        public decimal Dic18 { get; set; }

        // Propiedades 2019
        public decimal Ene19 { get; set; }
        public decimal Feb19 { get; set; }
        public decimal Mar19 { get; set; }
        public decimal Abr19 { get; set; }
        public decimal May19 { get; set; }
        public decimal Jun19 { get; set; }
        public decimal Jul19 { get; set; }
        public decimal Ago19 { get; set; }
        public decimal Sep19 { get; set; }
        public decimal Oct19 { get; set; }
        public decimal Nov19 { get; set; }
        public decimal Dic19 { get; set; }

        // Propiedades 2020
        public decimal Ene20 { get; set; }
        public decimal Feb20 { get; set; }
        public decimal Mar20 { get; set; }
        public decimal Abr20 { get; set; }
        public decimal May20 { get; set; }
        public decimal Jun20 { get; set; }
        public decimal Jul20 { get; set; }
        public decimal Ago20 { get; set; }
        public decimal Sep20 { get; set; }
        public decimal Oct20 { get; set; }
        public decimal Nov20 { get; set; }
        public decimal Dic20 { get; set; }
    }
}
