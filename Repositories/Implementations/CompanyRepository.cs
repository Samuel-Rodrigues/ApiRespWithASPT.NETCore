using Dapper;
using RespWithASPTNETCore.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace RespWithASPTNETCore.Repositories.Implementations
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly string connectionString;
        public CompanyRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public IEnumerable<Company> Get()
        {
            IEnumerable<Company> companys = null;
            using (var connection = new SqlConnection(connectionString))
            {
                companys = connection.Query<Company>("SELECT id, name as Name, cnpj as Cnpj, code as Code FROM Company");
            };

            return companys;
        }
        public Company Get(long companyId)
        {
            Company company = null;
            using (var connection = new SqlConnection(connectionString))
            {
                company = connection.QuerySingle<Company>("SELECT id, name as Name, cnpj as Cnpj, code as Code FROM Company WHERE id =@companyId", new { companyId });
            };
            return company;
        }
        public Company Create(Company company)
        {
            Company newCompany = null;
            long id = 0;
            using (var connection = new SqlConnection(connectionString))
            {

                id = connection.Query<int>("INSERT INTO Company (name, cnpj, code) values(@Name, @Cnpj, @Code) SELECT CAST(SCOPE_IDENTITY() as int)",
                    new { company.Name, company.Cnpj}).Single();
            };

            newCompany = Get(id);

            return newCompany;
        }
        public Company Update(Company company, long id)
        {
            Company updateCompany = null;
            using (var connection = new SqlConnection(connectionString))
            {

                connection.ExecuteScalar<Company>("UPDATE Company SET name=@Name, cnpj=@Cnpj, code=@Code WHERE id =@id",
                    new { company.Name, company.Cnpj, company.Code, id });
            };

            return updateCompany;
        }
        public void Delete(long companyId)
        {
            throw new NotImplementedException();
        }



    }
}
