using CRM.Data.Interfaces;
using CRM.Data.Interfaces.Interfaces.Category;
using CRM.Data.Interfaces.Models.Category;
using CRM.Data.Interfaces.Models.Company;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data.Repositories
{
    public class CategoryRepository : ICategory
    {
        private readonly IDapper _dapper;

        public CategoryRepository(IDapper dapper)
        {
            _dapper = dapper;
        }
        public int Add(CategoryModel categoryModel)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("Flag", 1, DbType.Int32);
            dbparams.Add("company_id", categoryModel.CompanyId, DbType.Int32);
            dbparams.Add("category_id", categoryModel.CategoryId, DbType.Int32);
            dbparams.Add("category_name", categoryModel.CategoryName, DbType.String);
            dbparams.Add("category_desc", categoryModel.CategoryDesc, DbType.String);
            return _dapper.Insert<int>("usp_categorymaster", dbparams, commandType: CommandType.StoredProcedure);
        }

        public int Delete(int id)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("Flag", 3, DbType.Int32);
            dbparams.Add("category_id", id, DbType.Int32);
            return _dapper.Delete<int>("usp_categorymaster", dbparams, commandType: CommandType.StoredProcedure);
        }

        public List<CategoryModel> GetAll()
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("Flag", 7, DbType.Int32);
            var categoryModels = _dapper.GetAll<CategoryModel>("usp_categorymaster", dbparams, commandType: CommandType.StoredProcedure);
            return categoryModels;
        }

        public List<CompanyModel> GetAllCompany()
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("Flag", 5, DbType.Int32);
            var companyModels = _dapper.GetAll<CompanyModel>("usp_categorymaster", dbparams, commandType: CommandType.StoredProcedure);
            return companyModels;
        }

        public CategoryModel GetById(int id)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("Flag", 4, DbType.Int32);
            dbparams.Add("category_id", id, DbType.Int32);
            var categoryModel = _dapper.Get<CategoryModel>("usp_categorymaster", dbparams, commandType: CommandType.StoredProcedure);
            return categoryModel;
        }

        public int GetMaxId()
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("Flag", 6, DbType.Int32);
            return _dapper.Get<int>("usp_categorymaster", dbparams, commandType: CommandType.StoredProcedure);
        }

        public int Update(CategoryModel categoryModel)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("Flag", 2, DbType.Int32);
            dbparams.Add("company_id", categoryModel.CompanyId, DbType.Int32);
            dbparams.Add("category_id", categoryModel.CategoryId, DbType.Int32);
            dbparams.Add("category_name", categoryModel.CategoryName, DbType.String);
            dbparams.Add("category_desc", categoryModel.CategoryDesc, DbType.String);
            return _dapper.Update<int>("usp_categorymaster", dbparams, commandType: CommandType.StoredProcedure);
        }
    }
}
