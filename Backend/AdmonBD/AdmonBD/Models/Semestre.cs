using System;
using System.Collections.Generic;

#nullable disable

namespace AdmonBD.Models
{
    public partial class Semestre
    {
        public Semestre()
        {
            Distribucion = new HashSet<Distribucion>();
        }

        public int Semestre1 { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Distribucion> Distribucion { get; set; }
    }
}
