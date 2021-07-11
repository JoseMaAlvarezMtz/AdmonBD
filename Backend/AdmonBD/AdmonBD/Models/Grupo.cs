using System;
using System.Collections.Generic;

#nullable disable

namespace AdmonBD.Models
{
    public partial class Grupo
    {
        public Grupo()
        {
            Distribucion = new HashSet<Distribucion>();
        }

        public int IdGrupo { get; set; }
        public int NumeroGrupo { get; set; }

        public virtual ICollection<Distribucion> Distribucion { get; set; }
    }
}
