using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Web.Http;

namespace VirtualMindApp.Controllers
{
    [Route("Cotizacion")]
    public class CotizacionController : ApiController
    {
        [HttpGet]
        [Route("Cotizacion/{MONEDA?}")]
        public Task<Cotizacion> GetCotizacion(string moneda = null)
        {
            switch (moneda.ToLower())
            {
                case "dolar":
                    return new DollarPrice().Price();
                case "pesos":
                    return new PesoPrice().Price();
                case "real":
                    return new RealPrice().Price();
            }
            return Task.FromResult<Cotizacion>(null);
        }

        abstract class QuotationStrategy
        {
            public abstract Task<Cotizacion> Price();
        }


        class DollarPrice : QuotationStrategy
        {
            public override Task<Cotizacion> Price()
            {
                return GetProvinciaAsync("https://www.bancoprovincia.com.ar/Principal/Dolar");
            }

            static HttpClient client = new HttpClient();
            static async Task<Cotizacion> GetProvinciaAsync(string path)
            {
                try
                {
                    List<string> cotizacion = new List<string>();
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync(path);
                    if (response.IsSuccessStatusCode)
                    {
                        cotizacion = await response.Content.ReadAsAsync<List<string>>();
                    }

                    return new Cotizacion
                    {
                        Venta = Convert.ToDecimal(cotizacion[0]),

                        Compra = Convert.ToDecimal(cotizacion[1]),

                        Actualizada = cotizacion[2]
                    };
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        class PesoPrice : QuotationStrategy
        {
            public override Task<Cotizacion> Price()
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Unauthorized));
            }
        }

        class RealPrice : QuotationStrategy
        {
            public override Task<Cotizacion> Price()
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Unauthorized));
            }
        }

        public class Cotizacion
        {
            public Decimal Venta { get; set; }
            public Decimal Compra { get; set; }
            public string Actualizada { get; set; }
        }
    }
}
