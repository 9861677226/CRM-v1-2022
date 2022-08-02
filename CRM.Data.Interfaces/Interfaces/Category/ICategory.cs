using CRM.Data.Interfaces.Models.Category;
using CRM.Data.Interfaces.Models.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data.Interfaces.Interfaces.Category
{
    public interface ICategory
    {
        int Add(CategoryModel categoryModel);
        int Update(CategoryModel categoryModel);
        int Delete(int id);
        List<CategoryModel> GetAll();
        List<CompanyModel> GetAllCompany();
        CategoryModel GetById(int id);
        int GetMaxId();
    }
}
