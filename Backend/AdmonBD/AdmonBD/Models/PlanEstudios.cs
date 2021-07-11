using System;
using System.Collections.Generic;

#nullable disable

namespace AdmonBD.Models
{
    public partial class PlanEstudios
    {
        public PlanEstudios()
        {
            Distribucion = new HashSet<Distribucion>();
        }

        public int IdPlan { get; set; }
        public int ClavePlan { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Distribucion> Distribucion { get; set; }
    }
}
