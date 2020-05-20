using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RespWithASPTNETCore.Models
{
    public class Company
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Cnpj { get; set; }
        public string Code { get; set; }
    }
}
