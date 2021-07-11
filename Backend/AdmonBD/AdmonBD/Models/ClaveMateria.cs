using System;
using System.Collections.Generic;

#nullable disable

namespace AdmonBD.Models
{
    public partial class ClaveMateria
    {
        public ClaveMateria()
        {
            Distribucion = new HashSet<Distribucion>();
        }

        public int IdClavemateria { get; set; }
        public string NombreClave { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Distribucion> Distribucion { get; set; }
    }
}
