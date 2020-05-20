using Dapper;
using RespWithASPTNETCore.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace RespWithASPTNETCore.Repositories.Implementations
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly string connectionString;
        public EmployeeRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public IEnumerable<Employee> Get()
        {
            IEnumerable<Employee> employees = null;
            using (var connection = new SqlConnection(connectionString))
            {
                employees = connection.Query<Employee>("SELECT id as Id, name as Name, email as Email, code as Code, occupation as Occupation, companyId as CompanyId FROM Employee");
            };

            return employees;
        }
        public Employee Get(long employeeId)
        {
            Employee employee = null;
            using (var connection = new SqlConnection(connectionString))
            {
                employee = connection.QuerySingle<Employee>("SELECT id as Id, name as Name, email as Email, code as Code, occupation as Occupation, companyId as CompanyId FROM Employee WHERE id =@employeeId", 
                    new { employeeId });
            };
            return employee;
        }
        public Employee Create(Employee employee)
        {
            Employee newEmployee = null;
            long id = 0;
            using (var connection = new SqlConnection(connectionString))
            {

                id = connection.Query<int>("INSERT INTO Employee (name, email, code, occupation, companyId) values(@Name, @Email, @Code, @Occupation, @CompanyId) SELECT CAST(SCOPE_IDENTITY() as int)",
                    new { employee.Name, employee.Email, employee.Code, employee.Occupation, employee.CompanyId}).Single();
            };

            newEmployee = Get(id);

            return newEmployee;
        }
        public Employee Update(Employee employee, long id)
        {
            Employee updateEmployee = null;
            using (var connection = new SqlConnection(connectionString))
            {

                connection.ExecuteScalar<Employee>("UPDATE Employee SET name=@Name, email=@Email, code=@Code, occupation=@Occupation, companyId=@CompanyId WHERE id =@id",
                    new { employee.Name, employee.Email, employee.Code, employee.Occupation, employee.CompanyId, id });
            };

            return updateEmployee;
        }
        public void Delete(long companyId)
        {
            throw new NotImplementedException();
        }

        // ### //

        public IEnumerable<Employee> GetEmployeesByCompanyId(long companyId)
        {
            IEnumerable<Employee> employees = null;
            using (var connection = new SqlConnection(connectionString))
            {
                employees = connection.Query<Employee>("SELECT E.name as Name, E.email as Email, E.id as Id, E.code as Code, E.occupation as Occupation, E.companyId as CompanyId FROM Employee as E JOIN Company as C on C.id = E.companyId WHERE C.id = @companyId", 
                    new { companyId });
            };

            return employees;
        }

    }
}
