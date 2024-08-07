﻿using Dapper;
using IS3IncomabWebApi.CrossLayer.Interface;
using IS3IncomabWebApi.DomainLayer.Entity;
using IS3IncomabWebApi.DomainLayer.Interface;
using System.Data;

namespace IS3IncomabWebApi.Infraestructure.Repository
{
    public class CustomerRepository:ICustomerRepository
    {
        private readonly IConnectionDataBase _connectionDataBase;

        public CustomerRepository(IConnectionDataBase connectionDataBase)
        {
            _connectionDataBase = connectionDataBase;
        }

        public bool Insert(Customer customer)
        {
            using var db = _connectionDataBase.GetConnection;
            var query = "sp_customerInsert";
            var parameters = new DynamicParameters();
            parameters.Add("fullName", customer.FullName);
            parameters.Add("identityCard", customer.IdentityCard);
            parameters.Add("phone", customer.Phone);
            parameters.Add("address", customer.Address);
            parameters.Add("isWholeSale", customer.IsWholeSaler);
            parameters.Add("createBy", customer.CreateBy);

            var result = db.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
            return result > 0;
            
        }

        public bool Update(Customer customer)
        {
            using var db = _connectionDataBase.GetConnection;
            var query = "sp_customerUpdate";
            var parameters = new DynamicParameters();
            parameters.Add("customerId", customer.Id);
            parameters.Add("isActive", customer.IsActive);
            parameters.Add("fullName", customer.FullName);
            parameters.Add("identityCard", customer.IdentityCard);
            parameters.Add("modifyBy", customer.ModifyBy);
            parameters.Add("phone", customer.Phone);
            parameters.Add("address", customer.Address);
            parameters.Add("isWholeSale", customer.IsWholeSaler);

            var result = db.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
            return result > 0;
        }

        public bool DeleteLogic(Customer customer)
        {
            using var db = _connectionDataBase.GetConnection;
            var query = "sp_customerDeleteLogic";
            var parameters = new DynamicParameters();
            parameters.Add("customerId", customer.Id);
            parameters.Add("isActive", customer.IsActive);

            var result = db.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
            return result > 0;
        }

        public Customer Get(int customerId)
        {
            using var db = _connectionDataBase.GetConnection;
            var query = "sp_customerGetId";
            var parameters = new DynamicParameters();
            parameters.Add("customerId", customerId);

            var result = db.QuerySingle<Customer>(query, param: parameters, commandType: CommandType.StoredProcedure);
            return result;
        }

        public IEnumerable<Customer> GetAll()
        {
            using var db = _connectionDataBase.GetConnection;
            var query = "sp_customerGetAll";
            var result = db.Query<Customer>(query, commandType: CommandType.StoredProcedure);
            return result;
        }
    }
}
