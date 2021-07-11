using System;
using System.Collections.Generic;

#nullable disable

namespace AdmonBD.Models
{
    public partial class Materia
    {
        public Materia()
        {
            Distribucion = new HashSet<Distribucion>();
        }

        public int IdMateria { get; set; }
        public string NombreMateria { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Distribucion> Distribucion { get; set; }
    }
}
