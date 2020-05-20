using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace RespWithASPTNETCore.Models
{
    public class Employee
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Code { get; set; }
        public string Occupation { get; set; }
        public long CompanyId { get; set; }
    }
}