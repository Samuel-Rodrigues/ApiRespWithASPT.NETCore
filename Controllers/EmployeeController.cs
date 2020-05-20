using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RespWithASPTNETCore.Models;
using RespWithASPTNETCore.Services;

namespace RespWithASPTNETCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetAll()
        {
            IEnumerable<Employee> employees = _employeeService.Get();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> GetById(long id)
        {
            try {
                Employee employee = _employeeService.Get(id);
                return Ok(employee);
            }
            catch {
                return NotFound();
            }

        }

        [HttpPost]
        public ActionResult<Employee> Create([FromBody]Employee employee)
        {
            Employee newEmployee = null;
            newEmployee = _employeeService.Create(employee);
            return Ok(newEmployee);
        }

        [HttpPut("{id}")]
        public ActionResult<Employee> Update([FromBody]Employee employee, long id)
        {
            try
            {
                Employee updateEmployee = null;
                updateEmployee = _employeeService.Update(employee, id);
                return Ok(updateEmployee);
            }
            catch {
                return NotFound("Id não encontrado");
            }

        }

        // #### //

        //Buscar funcionários por Id de uma empresa
        [HttpGet("companyid/{id}")]
        public ActionResult<IEnumerable<Employee>> GetEmployeesByCompanyId(long id)
            {
            return  Ok(_employeeService.GetEmployeesByCompanyId(id));
            }

    }
}