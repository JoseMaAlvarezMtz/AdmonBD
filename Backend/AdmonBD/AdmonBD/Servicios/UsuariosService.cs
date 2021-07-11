using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using AdmonBD.Repositorys;
using AdmonBD.Models;

namespace AdmonBD.Servicios
{
    public class UsuariosService
    {
        private UsuariosRepository UsuariosRepository;

        public UsuariosService(UsuariosRepository usuariosRepository)
        {
            this.UsuariosRepository = usuariosRepository;
        }

        public IEnumerable<Usuarios> Consulta()
        {
            return UsuariosRepository.Consulta();

        }
    }
}
