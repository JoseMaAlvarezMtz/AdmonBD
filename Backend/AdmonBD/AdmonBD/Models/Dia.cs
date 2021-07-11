using System;
using System.Collections.Generic;

#nullable disable

namespace AdmonBD.Models
{
    public partial class Dia
    {
        public Dia()
        {
            Distribucion = new HashSet<Distribucion>();
        }

        public int IdDia { get; set; }
        public string ClaveDia { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Distribucion> Distribucion { get; set; }
    }
}
