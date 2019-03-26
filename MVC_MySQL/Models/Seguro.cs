using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_MySQL.Models
{
    public class Seguro
    {
        public int Id { get; set; }
        public string NumApolice { get; set; }
        public string CpfCnpj { get; set; }
        public string Placa { get; set; }
        public decimal ValPremio { get; set; }
    }
}
