using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using VMtest.Models;

namespace VMtest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DollarExchangeController : ControllerBase
    {
        [HttpGet]
        public ActionResult getExchange(String Moneda)
        {
            if (Moneda!="Dolar" && Moneda!="Real")
            {
                return BadRequest("Moneda no soportada");
            }

            var LocalConsumer = new RestConsumer();
            var LocalEE = LocalConsumer.GetCurrencyExchange();

            if (Moneda=="Rolar")
            {
                LocalEE.Moneda = Moneda;
                
            }else if (Moneda=="Real")
            {
                LocalEE.Moneda = Moneda;
                LocalEE.Compra /= 4;
                LocalEE.Venta /= 4;

            }
            return Ok(LocalEE);

            
        }
    }
}
