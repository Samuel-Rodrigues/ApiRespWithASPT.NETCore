﻿using RespWithASPTNETCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RespWithASPTNETCore.Repositories
{
    public interface ICompanyRepository
    {
        IEnumerable<Company> Get();
        Company Get(long companyId);
        Company Create(Company company);
        Company Update(Company company, long id);
        void Delete(long companyId);
    }
}
