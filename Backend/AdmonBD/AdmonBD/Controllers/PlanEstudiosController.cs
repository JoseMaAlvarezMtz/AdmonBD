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
    public class PlanEstudiosController : ControllerBase
    {
        private readonly AdmonContext context;
        private string objeto = "PLAN DE ESTUDIOS";

        public PlanEstudiosController(AdmonContext admonContext)
        {
            this.context = admonContext;
        }

        [HttpGet]
        public IEnumerable<PlanEstudios> Get()
        {

            return context.PlanEstudios.ToList();
        }

        [HttpGet("{id}")]
        public PlanEstudios Get(int id)
        {

            return context.PlanEstudios.FirstOrDefault( j => j.IdPlan == id);
        }

        [HttpPost]
        public string Post(PlanEstudios planEstudios)
        {
            try
            {
                context.PlanEstudios.Add(planEstudios);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return objeto + " agregada satisfactoriamente";
        }

        [HttpPut]
        public string Put(PlanEstudios planEstudios)
        {
            try
            {
                var Editar = context.PlanEstudios.FirstOrDefault(j => j.IdPlan == planEstudios.IdPlan);
                Editar.ClavePlan = planEstudios.ClavePlan;
                Editar.Descripcion = planEstudios.Descripcion;
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
                context.Remove(context.PlanEstudios.Single(j => j.IdPlan == id));
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
