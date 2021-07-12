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
    public class DiaController : ControllerBase
    {
        private readonly AdmonContext context;
        private string objeto = "DIA";

        public DiaController(AdmonContext admonContext)
        {
            this.context = admonContext;
        }

        [HttpGet]
        public IEnumerable<Dia> Get()
        {

            return context.Dia.ToList();
        }

        [HttpGet("{id}")]
        public Dia Get(int id)
        {

            return context.Dia.FirstOrDefault( j => j.IdDia== id);
        }

        [HttpPost]
        public string Post(Dia dia)
        {
            try
            {
                context.Dia.Add(dia);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return objeto + " agregada satisfactoriamente";
        }

        [HttpPut]
        public string Put(Dia dia)
        {
            try
            {
                var Editar = context.Dia.FirstOrDefault(j => j.IdDia == dia.IdDia);
                Editar.ClaveDia = dia.ClaveDia;
                Editar.Descripcion = dia.Descripcion;

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
                context.Remove(context.Dia.Single(j => j.IdDia == id));
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
