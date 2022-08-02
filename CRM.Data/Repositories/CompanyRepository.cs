using CRM.Data.Interfaces;
using CRM.Data.Interfaces.Interfaces.Company;
using CRM.Data.Interfaces.Models.Company;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data.Repositores
{
    public class CompanyRepository : ICompany
    {
        private readonly IDapper _dapper;

        public CompanyRepository(IDapper dapper)
        {
            _dapper = dapper;
        }

        public int Add(CompanyModel companyModel)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("Flag", 1, DbType.Int32);
            dbparams.Add("company_name", companyModel.CompanyName, DbType.String);
            dbparams.Add("company_desc", companyModel.CompanyDesc, DbType.String);
            return  _dapper.Insert<int>("usp_companymaster", dbparams, commandType: CommandType.StoredProcedure);
        }

        public int Delete(int id)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("Flag", 3, DbType.Int32);
            dbparams.Add("company_id", id, DbType.Int32);
            return _dapper.Delete<int>("usp_companymaster", dbparams, commandType: CommandType.StoredProcedure);
        }

        public List<CompanyModel> GetAll()
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("Flag", 5, DbType.Int32);
            var companyModels = _dapper.GetAll<CompanyModel>("usp_companymaster", dbparams, commandType: CommandType.StoredProcedure);
            return companyModels;
        }

        public int GetMaxId()
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("Flag", 6, DbType.Int32);
            return _dapper.Get<int>("usp_companymaster", dbparams, commandType: CommandType.StoredProcedure);
           
        }

        public CompanyModel GetById(int id)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("Flag", 4, DbType.Int32);
            dbparams.Add("company_id", id, DbType.Int32);
            var companyModel = _dapper.Get<CompanyModel>("usp_companymaster", dbparams, commandType: CommandType.StoredProcedure);
            return companyModel;
        }

        public int Update(CompanyModel companyModel)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("Flag", 2, DbType.Int32);
            dbparams.Add("company_id", companyModel.CompanyId, DbType.Int32);
            dbparams.Add("company_name", companyModel.CompanyName, DbType.String);
            dbparams.Add("company_desc", companyModel.CompanyDesc, DbType.String);
            return _dapper.Update<int>("usp_companymaster", dbparams, commandType: CommandType.StoredProcedure);
        }
    }
}
