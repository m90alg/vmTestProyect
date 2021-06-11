using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VMtest.Models
{
    public class Transactions
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Moneda { get; set; }
        public decimal Monto { get; set; }
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }
    }
}
