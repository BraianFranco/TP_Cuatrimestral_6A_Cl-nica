using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{

    public class Paciente
    {

        public int dni { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }

        public string tel { get; set; }

        public DateTime fechanacimiento { get; set; }

        public string correo { get; set; }

        public int idPais { get; set; }

        public string direccion { get; set; }

        public bool activo { get; set; }

        public DateTime FechaAlta { get; set; }

        public Paciente() { }


        public Paciente(int Dni, string Nombre, string Apellido, string Tel, DateTime FechaNac, string Correo, int IdPais, string Direccion)
        {


            dni = Dni;
            nombre = Nombre;
            apellido = Apellido;
            tel = Tel;
            fechanacimiento = FechaNac;
            correo = Correo;
            idPais = IdPais;
            direccion = Direccion;
            activo = true;
        }

    }
}
