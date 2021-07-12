using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdmonBD.Models;

namespace AdmonBD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalonController : ControllerBase
    {
        private readonly AdmonContext context;
        private string objeto = "SALON";

        public SalonController(AdmonContext admonContext)
        {
            this.context = admonContext;
        }

        [HttpGet]
        public IEnumerable<Salon> Get()
        {

            return context.Salon.ToList();
        }

        [HttpGet("{id}")]
        public Salon Get(int id)
        {

            return context.Salon.FirstOrDefault( j => j.IdSalon == id);
        }

        [HttpPost]
        public string Post(Salon salon)
        {
            try
            {
                context.Salon.Add(salon);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return objeto + " agregada satisfactoriamente";
        }

        [HttpPut]
        public string Put(Salon salon)
        {
            try
            {
                var Editar = context.Salon.FirstOrDefault(j => j.IdSalon == salon.IdSalon);
                Editar.NombreSalon = salon.NombreSalon;
                Editar.Capacidad = salon.Capacidad;
                Editar.Ubicacion = salon.Ubicacion;
                context.SaveChanges();
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
            return objeto + " actualizada satisfactoriamente";
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            try
            {
                context.Remove(context.Salon.Single(j => j.IdSalon == id));
                context.SaveChanges();
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
            return objeto + " borrada satisfactoriamente";
        }
    }
}
