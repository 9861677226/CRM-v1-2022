using CRM.Data.Interfaces.Models.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data.Interfaces.Interfaces.Company
{
    public interface ICompany
    {
        int Add(CompanyModel companyModel);
        int Update(CompanyModel companyModel);
        int Delete(int id);
        List<CompanyModel> GetAll();
        CompanyModel GetById(int id);
        int GetMaxId();
    }
}
