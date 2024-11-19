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

        //lectura
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


        // insert
        public Turno(int dnimedico, int dnipaciente, int idEspecialidad, DateTime fechaturno, string observaciones, bool activo)
        {
            Id = 0; // El Id lo asigna la base de datos
            DniMedico = dnimedico;
            DniPaciente = dnipaciente;
            IdEspecialidad = idEspecialidad;
            FechaTurno = fechaturno;
            Estado = "Nuevo";
            Observaciones = observaciones;
            Activo = activo;
        }


    }
}

