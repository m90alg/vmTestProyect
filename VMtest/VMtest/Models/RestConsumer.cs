using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Web;
using RestSharp;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace VMtest.Models
{
    public class RestConsumer
    {
        public ExchageEstructure GetCurrencyExchange()
        {
            try
            {
                var client = new RestClient("http://www.bancoprovincia.com.ar/Principal");
                var request = new RestRequest("Dolar");
                var response = client.Execute(request);

                string[] ExchangeData = Regex.Split(response.Content, "\"(.*?)\"");

                ExchageEstructure NewEE = new();

                NewEE.Compra = Convert.ToDecimal(ExchangeData[1]);
                NewEE.Venta = Convert.ToDecimal(ExchangeData[3]);
                NewEE.Fecha = ExchangeData[5];


                return NewEE;
            }
            catch(Exception e)
            {
                throw new Exception("Error during consulting the dolar price.", e.InnerException );
            }
            
           
        }
    }
}
