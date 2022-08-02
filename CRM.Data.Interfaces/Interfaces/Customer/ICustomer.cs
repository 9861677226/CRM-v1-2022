using CRM.Data.Interfaces.Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data.Interfaces.Interfaces.Customer
{
    public interface ICustomer
    {
        int Add(CustomerModel customerModel);
        int Update(CustomerModel customerModel);
        int Delete(int id);
        List<CustomerModel> GetAll();
        CustomerModel GetById(int id);
        int GetMaxId();
    }
}
