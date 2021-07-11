using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdmonBD.Models;
using AdmonBD.Servicios;

namespace AdmonBD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private UsuariosService UsuariosService;

        public UsuariosController(UsuariosService usuariosRepository)
        {
            this.UsuariosService = usuariosRepository;
        }

        [HttpGet]
        public IEnumerable<Usuarios> Get()
        {

            return UsuariosService.Consulta();
        }
    }
}
