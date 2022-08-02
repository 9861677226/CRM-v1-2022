using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data.Interfaces.Models.Customer
{
    public class CustomerModel
    {
        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string CustomerMobile { get; set; }

        public string CustomerEmail { get; set; }

        public string CustomerDOB { get; set; }

        public string CustomerAddress { get; set; }

        public string CustomerOccupation { get; set; }

        public string Channel { get; set; }
    }
}
