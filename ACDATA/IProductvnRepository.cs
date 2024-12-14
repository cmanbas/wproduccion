using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACDATA
{
    public interface IProductvnRepository
    {
        List<ProductData> GetAllProductDatavn();
    }
}
