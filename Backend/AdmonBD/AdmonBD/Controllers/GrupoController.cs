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
    public class GrupoController : ControllerBase
    {
        private readonly AdmonContext context;
        private string objeto = "GRUPO";

        public GrupoController(AdmonContext admonContext)
        {
            this.context = admonContext;
        }

        [HttpGet]
        public IEnumerable<Grupo> Get()
        {

            return context.Grupo.ToList();
        }

        [HttpGet("{id}")]
        public Grupo Get(int id)
        {

            return context.Grupo.FirstOrDefault( j => j.IdGrupo == id);
        }

        [HttpPost]
        public string Post(Grupo grupo)
        {
            try
            {
                context.Grupo.Add(grupo);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return objeto + " agregada satisfactoriamente";
        }

        [HttpPut]
        public string Put(Grupo grupo)
        {
            try
            {
                var Editar = context.Grupo.FirstOrDefault(j => j.IdGrupo == grupo.IdGrupo);
                Editar.NumeroGrupo = grupo.NumeroGrupo;
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
                context.Remove(context.Grupo.Single(j => j.IdGrupo == id));
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
