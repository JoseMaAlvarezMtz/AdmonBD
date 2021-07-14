using System;
using System.Collections.Generic;

#nullable disable

namespace AdmonBD.Models
{
    public partial class DistribucionDto
    {
        public int IdDistribucion { get; set; }
        public int IdPlan { get; set; }
        public int Plan { get; set; }
        public int IdClavemateria { get; set; }
        public string Clavemateria { get; set; }
        public int IdMateria { get; set; }
        public string Materia { get; set; }
        public int IdGrupo { get; set; }
        public int Grupo { get; set; }
        public int IdHora { get; set; }
        public string Hora { get; set; }
        public int IdDia { get; set; }
        public string Dia { get; set; }
        public int IdSalon { get; set; }
        public string Salon { get; set; }
        public int Semestre { get; set; }
        public string Semestrecadena { get; set; }


    }
}
