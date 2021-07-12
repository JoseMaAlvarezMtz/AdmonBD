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
    public class ClaveMateriaController : ControllerBase
    {
        private readonly AdmonContext context;
        private string objeto = "CLAVE DE MATERIA";

        public ClaveMateriaController(AdmonContext admonContext)
        {
            this.context = admonContext;
        }

        [HttpGet]
        public IEnumerable<ClaveMateria> Get()
        {

            return context.ClaveMateria.ToList();
        }

        [HttpGet("{id}")]
        public ClaveMateria Get(string id)
        {

            return context.ClaveMateria.FirstOrDefault( j => j.NombreClave == id);
        }

        [HttpPost]
        public string Post(ClaveMateria claveMateria)
        {
            try
            {
                context.ClaveMateria.Add(claveMateria);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return objeto + " agregada satisfactoriamente";
        }

        [HttpPut]
        public string Put(ClaveMateria claveMateria)
        {
            try
            {
                var Editar = context.ClaveMateria.FirstOrDefault(j => j.NombreClave == claveMateria.NombreClave);
                Editar.Descripcion = claveMateria.Descripcion;
                context.SaveChanges();
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
            return objeto + " actualizada satisfactoriamente";
        }

        [HttpDelete("{id}")]
        public string Delete(string id)
        {
            try
            {
                context.Remove(context.ClaveMateria.Single(j => j.NombreClave == id));
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
