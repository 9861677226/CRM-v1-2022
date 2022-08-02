using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data.Interfaces.Models.Company
{
    public class CompanyModel
    { 
      
        public int CompanyId { get; set; }

       
        public string CompanyName { get; set; }

        
        public string CompanyDesc { get; set; } 
    }
}
