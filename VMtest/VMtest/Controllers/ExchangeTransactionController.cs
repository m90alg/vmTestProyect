using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VMtest.Models;

namespace VMtest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeTransactionController : ControllerBase
    {
        readonly VmtContext Context;
        public ExchangeTransactionController(VmtContext LocalContext)
        {
            Context = LocalContext;
        }

        [HttpPost]
        public ActionResult Exchange(TransactionRequest CtTransaction)
        {
            

            if (CtTransaction.Moneda != "Dolar" && CtTransaction.Moneda != "Real")
            {
                return BadRequest("Moneda no soportada");
            }

            Transactions NewTR = new();
            var LocalEE = new RestConsumer().GetCurrencyExchange();

            var Sum = (from TRL in Context.Transactions
                        where TRL.Usuario == CtTransaction.Usuario
                        && TRL.Moneda == CtTransaction.Moneda
                        && TRL.Fecha.Year == DateTime.UtcNow.Year
                        && TRL.Fecha.Month== DateTime.UtcNow.Month
                        select TRL.Monto).Sum();

            

            if (CtTransaction.Moneda == "Dolar")
            {
                if (Sum + CtTransaction.Monto > 200)
                    return BadRequest("Limite Máximo alcanzado en el mes para la moneda, " + CtTransaction.Moneda + " " + Sum.ToString());

                NewTR.Monto = CtTransaction.Monto;
                NewTR.Total = CtTransaction.Monto * LocalEE.Venta;
            }
            else
            {
                if (Sum + CtTransaction.Monto/LocalEE.Compra > 300)
                    return BadRequest("Limite Máximo alcanzado en el mes para la moneda, " + CtTransaction.Moneda + " " + Sum.ToString());

                NewTR.Total = CtTransaction.Monto;
                NewTR.Monto = CtTransaction.Monto / LocalEE.Compra;
            }
            
            NewTR.Usuario = CtTransaction.Usuario;
            NewTR.Moneda = CtTransaction.Moneda;
            NewTR.Fecha = System.DateTime.UtcNow;

            Context.Add(NewTR);
            Context.SaveChanges();
            return  Ok(NewTR) ;

        }
    }
}
