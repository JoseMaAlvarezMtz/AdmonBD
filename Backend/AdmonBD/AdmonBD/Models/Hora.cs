using System;
using System.Collections.Generic;

#nullable disable

namespace AdmonBD.Models
{
    public partial class Hora
    {
        public Hora()
        {
            Distribucion = new HashSet<Distribucion>();
        }

        public int IdHora { get; set; }
        public string NombreHora { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }

        public virtual ICollection<Distribucion> Distribucion { get; set; }
    }
}
