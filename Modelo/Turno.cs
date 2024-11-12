using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Turno
    {
        public int Id { get; set; }

        public int DniMedico { get; set; }

        public int DniPaciente { get; set; }

        public int  IdEspecialidad { get; set; }

        public DateTime FechaTurno { get; set; }

        public string Estado { get; set; }

        public string Observaciones { get; set; }

        public bool Activo { get; set; }


        public Turno() { }


        public Turno(int id, int dnimedico, int dnipaciente, int idEspecialidad, DateTime fechaturno, string estado, string observaciones ,bool activo)
        {


            Id = id;
            DniMedico = dnimedico;
            DniPaciente = dnipaciente;
            IdEspecialidad = idEspecialidad;
            FechaTurno = fechaturno;
            Estado = estado;
            Activo = activo;
            Observaciones = observaciones;
        }

    }
}

