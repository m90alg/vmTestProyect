using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VMtest.Models
{
    public class TransactionRequest
    {
        public string Usuario { get; set; }
        public string Moneda { get; set; }
        public decimal Monto { get; set; }
    }
}
