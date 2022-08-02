using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data.Interfaces.Models.Product
{
    public class ProductModel
    {
        public int ProductId { get; set; }  
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }
        public decimal ProductMRP { get; set; }
        public int Stock { get; set; }
        public string FinYear { get; set; }
    }
}
