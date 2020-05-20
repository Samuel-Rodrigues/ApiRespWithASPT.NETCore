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
    public class CompanyController : ControllerBase
    {
        private ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Company>> GetAll()
        {
            IEnumerable<Company> companys = _companyService.Get();
            return Ok(companys);
        }

        [HttpGet("{id}")]
        public ActionResult<Company> GetById(long id)
        {
            try {
                Company company = _companyService.Get(id);
                return Ok(company);
            }
            catch {
                return NotFound();
            }

        }

        [HttpPost]
        public ActionResult<Company> Create([FromBody]Company company)
        {
            Company newCompany = null;
            newCompany = _companyService.Create(company);
            return Ok(newCompany);
        }

        [HttpPut("{id}")]
        public ActionResult<Company> Update([FromBody]Company company, long id)
        {
            try
            {
                Company updateCompany = null;
                updateCompany = _companyService.Update(company, id);
                return Ok(updateCompany);
            }
            catch {
                return NotFound("Id não encontrado");
            }
            
        }

    }
}