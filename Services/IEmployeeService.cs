using RespWithASPTNETCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RespWithASPTNETCore.Services
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> Get();
        Employee Get(long employeeId);
        Employee Create(Employee employee);
        Employee Update(Employee employee, long id);
        void Delete(long employeeId);

        // ### //
        IEnumerable<Employee> GetEmployeesByCompanyId(long companyId);
    }
}
