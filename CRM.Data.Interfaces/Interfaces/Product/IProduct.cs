using CRM.Data.Interfaces.Models.Category;
using CRM.Data.Interfaces.Models.Company;
using CRM.Data.Interfaces.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data.Interfaces.Interfaces.Product
{
    public interface IProduct
    {
        int Add(ProductModel productModel);
        int Update(ProductModel productModel);
        int Delete(int id);
        List<ProductModel> GetAll();
        List<string> GetFinYear();
        List<CompanyModel> GetAllCompany();
        List<CategoryModel> GetAllCategory(int id);
        ProductModel GetById(int id);
        int GetMaxId();
    }
}
