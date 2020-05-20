using Microsoft.Extensions.FileProviders;
using RespWithASPTNETCore.Models;
using RespWithASPTNETCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RespWithASPTNETCore.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public IEnumerable<Employee> Get()
        {
            return _employeeRepository.Get();
        }
        public Employee Get(long employeeId)
        {
            return _employeeRepository.Get(employeeId);
        }
        public Employee Create(Employee employee)
        {
            Employee newEmployee = null;
            newEmployee = _employeeRepository.Create(employee);
            return newEmployee;
        }
        public Employee Update(Employee employee, long id)
        {
            bool exists = ExistsEmployee(id);

            if (exists)
            {
                return _employeeRepository.Update(employee, id);
            }
            else {
                return null;
            }
            
           
        }
        public void Delete(long employeeId)
        {
            throw new NotImplementedException();
        }
        public bool ExistsEmployee(long employeeId)
        {
            if(_employeeRepository.Get(employeeId) != null)
            {
                return true;
             }
            else
            {
                return false;
            }
        }


        // ### //

        public IEnumerable<Employee> GetEmployeesByCompanyId (long companyId)
        {
            return _employeeRepository.GetEmployeesByCompanyId(companyId);
        }



    }
}
