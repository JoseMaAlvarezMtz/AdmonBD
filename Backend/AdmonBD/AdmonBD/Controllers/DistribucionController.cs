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
    public class DistribucionController : ControllerBase
    {
        private readonly AdmonContext context;
        private string objeto = "DISTRIBUCION";

        public DistribucionController(AdmonContext admonContext)
        {
            this.context = admonContext;
        }

        [HttpGet]
        public IEnumerable<Distribucion> Get()
        {

            return context.Distribucion.ToList();
        }

        [HttpGet("{id}")]
        public Distribucion Get(int id)
        {

            return context.Distribucion.FirstOrDefault( j => j.IdDistribucion == id);
        }

        [HttpPost]
        public string Post(Distribucion distribucion)
        {
            try
            {
                context.Distribucion.Add(distribucion);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return objeto + " agregada satisfactoriamente";
        }

        [HttpPut]
        public string Put(Distribucion distribucion)
        {
            try
            {
                var Editar = context.Distribucion.FirstOrDefault(j => j.IdDistribucion == distribucion.IdDistribucion);
                Editar.IdPlan = distribucion.IdPlan;
                Editar.IdClavemateria = distribucion.IdClavemateria;
                Editar.IdHora = distribucion.IdHora;
                Editar.IdDia = distribucion.IdDia;
                Editar.IdSalon = distribucion.IdSalon;
                Editar.Semestre = distribucion.Semestre;
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
                context.Remove(context.Distribucion.Single(j => j.IdDistribucion== id));
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
