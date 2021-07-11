using System;
using System.Collections.Generic;

#nullable disable

namespace AdmonBD.Models
{
    public partial class Distribucion
    {
        public int IdDistribucion { get; set; }
        public int IdPlan { get; set; }
        public int IdClavemateria { get; set; }
        public int IdMateria { get; set; }
        public int IdGrupo { get; set; }
        public int IdHora { get; set; }
        public int IdDia { get; set; }
        public int IdSalon { get; set; }
        public int Semestre { get; set; }

        public virtual ClaveMateria IdClavemateriaNavigation { get; set; }
        public virtual Dia IdDiaNavigation { get; set; }
        public virtual Grupo IdGrupoNavigation { get; set; }
        public virtual Hora IdHoraNavigation { get; set; }
        public virtual Materia IdMateriaNavigation { get; set; }
        public virtual PlanEstudios IdPlanNavigation { get; set; }
        public virtual Salon IdSalonNavigation { get; set; }
        public virtual Semestre SemestreNavigation { get; set; }
    }
}
