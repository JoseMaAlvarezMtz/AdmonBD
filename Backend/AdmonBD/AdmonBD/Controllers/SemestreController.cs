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
    public class SemestreController : ControllerBase
    {
        private readonly AdmonContext context;
        private string objeto = "SEMESTRE";

        public SemestreController(AdmonContext admonContext)
        {
            this.context = admonContext;
        }

        [HttpGet]
        public IEnumerable<Semestre> Get()
        {

            return context.Semestre.ToList();
        }

        [HttpGet("{id}")]
        public Semestre Get(int id)
        {

            return context.Semestre.FirstOrDefault( j => j.Semestre1 == id);
        }

        [HttpPost]
        public string Post(Semestre semestre)
        {
            try
            {
                context.Semestre.Add(semestre);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return objeto + " agregada satisfactoriamente";
        }

        [HttpPut]
        public string Put(Semestre semestre)
        {
            try
            {
                var Editar = context.Semestre.FirstOrDefault(j => j.Semestre1 == semestre.Semestre1);
                Editar.Descripcion = semestre.Descripcion;
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
                context.Remove(context.Semestre.Single(j => j.Semestre1 == id));
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
