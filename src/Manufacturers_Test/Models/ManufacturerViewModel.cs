using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manufacturers_Test.Models
{
    public class ManufacturerViewModel
    {
        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; }
        public IEnumerable<Product> products { get; set; }
    }
}
