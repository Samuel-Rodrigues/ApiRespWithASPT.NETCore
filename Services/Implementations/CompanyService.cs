using Microsoft.Extensions.FileProviders;
using RespWithASPTNETCore.Models;
using RespWithASPTNETCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RespWithASPTNETCore.Services.Implementations
{
    public class CompanyService : ICompanyService
    {
        private ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }
        public IEnumerable<Company> Get()
        {
            return _companyRepository.Get();
        }
        public Company Get(long companyId)
        {
            return _companyRepository.Get(companyId);
        }
        public Company Create(Company company)
        {
            Company newCompany = null;
            newCompany = _companyRepository.Create(company);
            return newCompany;
        }
        public Company Update(Company company, long id)
        {
            bool exists = ExistsCompany(id);

            if (exists)
            {
                return _companyRepository.Update(company, id);
            }
            else {
                return null;
            }
            
           
        }
        public void Delete(long companyId)
        {
            throw new NotImplementedException();
        }
        public bool ExistsCompany(long companyId)
        {
            if(_companyRepository.Get(companyId) != null)
            {
                return true;
             }
            else
            {
                return false;
            }
        }




    }
}
