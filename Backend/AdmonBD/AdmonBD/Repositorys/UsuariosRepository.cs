using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdmonBD.Models;

namespace AdmonBD.Repositorys
{
    public class UsuariosRepository : Repository<Usuarios>
    {
        public UsuariosRepository (AdmonContext context) : base (context)
        {
            base.context = context;
        }

        public IEnumerable<Usuarios> Consulta()
        {
            return context.Usuarios.Select(c => new Usuarios
            {
                IdUsuario = c.IdUsuario,
                Usuario = c.Usuario,
                Contrasena = c.Contrasena
            })
            .ToList();
        }
    }
}
