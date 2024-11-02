using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Medico
    {

        public int Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public int IdPais { get; set; }
        public bool Activo { get; set; }

        public DateTime FechaAlta { get; set; }

        public Medico() { }

        public Medico(int dni, string telefono, string nombre, string apellido, string correo, int idPais)
        {
            Dni = dni;
            Nombre = nombre;
            Apellido = apellido;
            Telefono = telefono;
            Correo = correo;
            IdPais = idPais;
            Activo = true;

        }
    }
}