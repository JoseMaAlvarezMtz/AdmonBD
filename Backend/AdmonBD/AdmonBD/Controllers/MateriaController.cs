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
    public class MateriaController : ControllerBase
    {
        private readonly AdmonContext context;
        private string objeto = "MATERIA";

        public MateriaController(AdmonContext admonContext)
        {
            this.context = admonContext;
        }

        [HttpGet]
        public IEnumerable<Materia> Get()
        {

            return context.Materia.ToList();
        }

        [HttpGet("{id}")]
        public Materia Get(int id)
        {

            return context.Materia.FirstOrDefault( j => j.IdMateria == id);
        }

        [HttpPost]
        public string Post(Materia materia)
        {
            try
            {
                context.Materia.Add(materia);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return objeto + " agregada satisfactoriamente";
        }

        [HttpPut]
        public string Put(Materia materia)
        {
            try
            {
                var Editar = context.Materia.FirstOrDefault(j => j.IdMateria == materia.IdMateria);
                Editar.NombreMateria = materia.NombreMateria;
                Editar.Descripcion = materia.Descripcion;
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
                context.Remove(context.Materia.Single(j => j.IdMateria == id));
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
