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
    public class HoraController : ControllerBase
    {
        private readonly AdmonContext context;
        private string objeto = "HORA";

        public HoraController(AdmonContext admonContext)
        {
            this.context = admonContext;
        }

        [HttpGet]
        public IEnumerable<Hora> Get()
        {

            return context.Hora.ToList();
        }

        [HttpGet("{id}")]
        public Hora Get(int id)
        {

            return context.Hora.FirstOrDefault( j => j.IdHora == id);
        }

        [HttpPost]
        public string Post(Hora hora)
        {
            try
            {
                context.Hora.Add(hora);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return objeto + " agregada satisfactoriamente";
        }

        [HttpPut]
        public string Put(Hora hora)
        {
            try
            {
                var Editar = context.Hora.FirstOrDefault(j => j.IdHora == hora.IdHora);
                Editar.NombreHora = hora.NombreHora;
                Editar.HoraInicio = hora.HoraInicio;
                Editar.HoraFin = hora.HoraFin;
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
                context.Remove(context.Hora.Single(j => j.IdHora == id));
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
