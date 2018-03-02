using Dapper;
using Domain.StoreContext.Entities;
using Domain.StoreContext.Queries;
using Domain.StoreContext.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Infra.StoreContext.Repositories
{
    public class CostumerRepository : BaseRepository, ICostumerRepository
    {
        public bool CheckCustomerExistsByDocument(string document)
        {
            return DbContext.SqlConnection.Query<bool>("spuCheckDocument", new { Document = document }, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

        public bool CheckCustomerExistsByEmail(string email)
        {
            return DbContext.SqlConnection.Query<bool>("spuCheckEmail", new { Document = email }, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

        public IEnumerable<ListCustomerQueryResult> GetAllCustomer()
        {
            return DbContext.SqlConnection.Query<ListCustomerQueryResult>("SELECT [Id],CONCAT(FirstName, ' ', LastName) As 'Name',[Document],[Email]FROM [Customer] NOLOCK");
        }

        public GetCustomerQueryResult GetCustomerById(Guid id)
        {
            return DbContext.SqlConnection.Query<GetCustomerQueryResult>("SELECT [Id],CONCAT(FirstName, ' ', LastName) As 'Name',[Document],[Email]FROM [Customer] NOLOCK WHERE [Id]=@id", new { Id = id }).FirstOrDefault();
        }

        public IEnumerable<ListCustomerOrderQueryResult> GetCustomerOrdersById(Guid id)
        {
            return DbContext.SqlConnection.Query<ListCustomerOrderQueryResult>("SELECT [Id],CONCAT(FirstName, ' ', LastName) As 'Name',[Document],[Email]FROM [Customer] NOLOCK WHERE [Id]=@id", new { Id = id });
        }

        public CustomerOrdersCountResult GetCustomerOrdersCountResult(string document)
        {
            return DbContext.SqlConnection.Query<CustomerOrdersCountResult>("spuGetCustomerOrdersCountResult", new { Document = document }, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

        public void SaveCustomer(Customer customer)
        {
            var transaction = DbContext.SqlConnection.BeginTransaction();

            try
            {
                DbContext.SqlConnection.Execute("spuCreateCustomer", new { customer.Id, customer.Name.FirstName, customer.Name.LastName, Document = customer.Document.Number, Email = customer.Email.Address, customer.Phone }, commandType: CommandType.StoredProcedure);

                foreach (var address in customer.Addresses)
                {
                    DbContext.SqlConnection.Execute("spuCreateAddress", new { address.Id, CustomerId = customer.Id, address.Number, address.Complement, address.District, address.City, address.State, address.Country, address.ZipCode, Type = address.AddressType }, commandType: CommandType.StoredProcedure);
                }
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
        }
    }
}