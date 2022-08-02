using CRM.Data.Interfaces;
using CRM.Data.Interfaces.Interfaces.Customer;
using CRM.Data.Interfaces.Models.Customer;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data.Repositories
{
    public class CustomerRepository : ICustomer
    {
        private readonly IDapper _dapper;

        public CustomerRepository(IDapper dapper)
        {
            _dapper = dapper;
        }
        public int Add(CustomerModel customerModel)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("Flag", 1, DbType.Int32);
            dbparams.Add("customer_name", customerModel.CustomerName, DbType.String);
            dbparams.Add("customer_mobile", customerModel.CustomerMobile, DbType.String);
            dbparams.Add("customer_email", customerModel.CustomerEmail, DbType.String);
            dbparams.Add("customer_dob", customerModel.CustomerDOB, DbType.String);
            dbparams.Add("customer_address", customerModel.CustomerAddress, DbType.String);
            dbparams.Add("customer_occupation", customerModel.CustomerOccupation, DbType.String);
            dbparams.Add("channel", customerModel.Channel, DbType.String);
            return _dapper.Insert<int>("usp_customermaster", dbparams, commandType: CommandType.StoredProcedure);
        }

        public int Delete(int id)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("Flag", 3, DbType.Int32);
            dbparams.Add("customer_id", id, DbType.Int32);
            return _dapper.Delete<int>("usp_customermaster", dbparams, commandType: CommandType.StoredProcedure);
        }

        public List<CustomerModel> GetAll()
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("Flag", 5, DbType.Int32);
            var customerModels = _dapper.GetAll<CustomerModel>("usp_customermaster", dbparams, commandType: CommandType.StoredProcedure);
            return customerModels;
        }

        public CustomerModel GetById(int id)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("Flag", 4, DbType.Int32);
            dbparams.Add("customer_id", id, DbType.Int32);
            var companyModel = _dapper.Get<CustomerModel>("usp_customermaster", dbparams, commandType: CommandType.StoredProcedure);
            return companyModel;
        }

        public int GetMaxId()
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("Flag", 6, DbType.Int32);
            return _dapper.Get<int>("usp_customermaster", dbparams, commandType: CommandType.StoredProcedure);

        }

        public int Update(CustomerModel customerModel)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("Flag", 2, DbType.Int32);
            dbparams.Add("customer_id", customerModel.CustomerId, DbType.Int32);
            dbparams.Add("customer_name", customerModel.CustomerName, DbType.String);
            dbparams.Add("customer_mobile", customerModel.CustomerMobile, DbType.String);
            dbparams.Add("customer_email", customerModel.CustomerEmail, DbType.String);
            dbparams.Add("customer_dob", customerModel.CustomerDOB, DbType.String);
            dbparams.Add("customer_address", customerModel.CustomerAddress, DbType.String);
            dbparams.Add("customer_occupation", customerModel.CustomerOccupation, DbType.String);
            dbparams.Add("channel", customerModel.Channel, DbType.String);
            return _dapper.Update<int>("usp_customermaster", dbparams, commandType: CommandType.StoredProcedure);
        }
    }
}
