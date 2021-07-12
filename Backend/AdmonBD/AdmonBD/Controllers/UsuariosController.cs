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
    public class UsuariosController : ControllerBase
    {
        private readonly AdmonContext context;

        public UsuariosController(AdmonContext admonContext)
        {
            this.context = admonContext;
        }

        [HttpGet]
        public IEnumerable<Usuarios> Get()
        {

            return context.Usuarios.ToList();
        }
    }
}
