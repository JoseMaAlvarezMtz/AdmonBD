using System;
using System.Collections.Generic;

#nullable disable

namespace AdmonBD.Models
{
    public partial class Salon
    {
        public Salon()
        {
            Distribucion = new HashSet<Distribucion>();
        }

        public int IdSalon { get; set; }
        public string NombreSalon { get; set; }
        public int Capacidad { get; set; }
        public string Ubicacion { get; set; }

        public virtual ICollection<Distribucion> Distribucion { get; set; }
    }
}
