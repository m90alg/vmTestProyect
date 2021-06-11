using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VMtest.Models
{
    public class ExchangeTransaction
    {
        readonly VmtContext context;

        public ExchangeTransaction()
        {
        }

        public ExchangeTransaction(VmtContext LocalContext)
        {
            context = LocalContext;
        }
        public Transactions Exchange(TransactionRequest LocalTR)
        {
            /*var Sum = context.Transactions
                .Where(a=>a.Usuario==LocalTR.Usuario && a.Moneda==LocalTR.Moneda )
                .GroupBy( a=> new { a.Usuario, a.Moneda })
                .Select(a => a.Monto).Sum();--
            var Sum2 = (from TRL in context.Transactions
                       where TRL.Usuario == LocalTR.Usuario 
                       && TRL.Moneda==LocalTR.Moneda
                       select TRL.Monto).Sum();*/

            Transactions NewTR = new();
            var LocalEE = new RestConsumer().GetCurrencyExchange();

            NewTR.Usuario = LocalTR.Usuario;
            NewTR.Moneda = LocalTR.Moneda;

            if (LocalTR.Moneda == "Dolar")
                { 
                    NewTR.Monto = LocalTR.Monto;
                    NewTR.Total = LocalTR.Monto * LocalEE.Venta;
                }
            else
            {
                NewTR.Total = LocalTR.Monto;
                NewTR.Monto = LocalTR.Monto * LocalEE.Compra;
            }

            context.Add(NewTR);
            context.SaveChanges();
            return NewTR;
            
        }
    }
}
