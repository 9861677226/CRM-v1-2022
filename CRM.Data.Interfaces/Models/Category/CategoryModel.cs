using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data.Interfaces.Models.Category
{
    public class CategoryModel
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }


        public string CategoryDesc { get; set; }
    }
}
