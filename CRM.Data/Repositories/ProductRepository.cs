using CRM.Data.Interfaces;
using CRM.Data.Interfaces.Interfaces.Product;
using CRM.Data.Interfaces.Models.Category;
using CRM.Data.Interfaces.Models.Company;
using CRM.Data.Interfaces.Models.Product;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data.Repositories
{
    public class ProductRepository : IProduct
    {
        private readonly IDapper _dapper;

        public ProductRepository(IDapper dapper)
        {
            _dapper = dapper;
        }
        public int Add(ProductModel productModel)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("Flag", 1, DbType.Int32);
            dbparams.Add("company_id", productModel.CompanyId, DbType.Int32);
            dbparams.Add("category_id", productModel.CategoryId, DbType.Int32);
            dbparams.Add("product_id", productModel.ProductId, DbType.Int32);
            dbparams.Add("product_name", productModel.ProductName, DbType.String);
            dbparams.Add("product_desc", productModel.ProductDesc, DbType.String);
            dbparams.Add("product_mrp", productModel.ProductMRP, DbType.Decimal);
            dbparams.Add("stock", productModel.Stock, DbType.Int32);
            dbparams.Add("fin_yr", productModel.FinYear, DbType.String);
            return _dapper.Insert<int>("usp_stockmaster", dbparams, commandType: CommandType.StoredProcedure);
        }

        public int Delete(int id)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("Flag", 3, DbType.Int32);
            dbparams.Add("product_id", id, DbType.Int32);
            return _dapper.Delete<int>("usp_stockmaster", dbparams, commandType: CommandType.StoredProcedure);
        }

        public List<ProductModel> GetAll()
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("Flag", 7, DbType.Int32);
            var productModels = _dapper.GetAll<ProductModel>("usp_stockmaster", dbparams, commandType: CommandType.StoredProcedure);
            return productModels;
        }

        public List<CategoryModel> GetAllCategory(int id)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("Flag", 8, DbType.Int32);
            dbparams.Add("company_id", id, DbType.Int32);
            var categoryModels = _dapper.GetAll<CategoryModel>("usp_stockmaster", dbparams, commandType: CommandType.StoredProcedure);
            return categoryModels;
        }

        public List<CompanyModel> GetAllCompany()
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("Flag", 5, DbType.Int32);
            var companyModels = _dapper.GetAll<CompanyModel>("usp_stockmaster", dbparams, commandType: CommandType.StoredProcedure);
            return companyModels;
        }

        public ProductModel GetById(int id)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("Flag", 4, DbType.Int32);
            dbparams.Add("product_id", id, DbType.Int32);
            var productModel = _dapper.Get<ProductModel>("usp_stockmaster", dbparams, commandType: CommandType.StoredProcedure);
            return productModel;
        }

        public int GetMaxId()
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("Flag", 6, DbType.Int32);
            return _dapper.Get<int>("usp_stockmaster", dbparams, commandType: CommandType.StoredProcedure);
        }

        public List<string> GetFinYear()
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("Flag", 8, DbType.Int32);
            return _dapper.GetAll<string>("usp_stockmaster", dbparams, commandType: CommandType.StoredProcedure);
        }

        public int Update(ProductModel productModel)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("Flag", 2, DbType.Int32);
            dbparams.Add("company_id", productModel.CompanyId, DbType.Int32);
            dbparams.Add("category_id", productModel.CategoryId, DbType.Int32);
            dbparams.Add("product_id", productModel.ProductId, DbType.Int32);
            dbparams.Add("product_name", productModel.ProductName, DbType.String);
            dbparams.Add("product_desc", productModel.ProductDesc, DbType.String);
            dbparams.Add("product_mrp", productModel.ProductMRP, DbType.Decimal);
            dbparams.Add("stock", productModel.Stock, DbType.Int32);
            dbparams.Add("fin_yr", productModel.FinYear, DbType.String);
            return _dapper.Update<int>("usp_stockmaster", dbparams, commandType: CommandType.StoredProcedure);
        }
    }
}
