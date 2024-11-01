using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{

    public class Medico
    {
        public int Id { get; set; }
        public long Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NroTelefono { get; set; }
        public string Correo { get; set; }
        public bool Activo { get; set; } = true;
        public int IdPais { get; set; }
        public DateTime FechaAlta { get; set; }


        public Medico(int ID, long dni, string nombre, string apellido, string nroTelefono, string correo, int idPais, DateTime fechaAlta)
        {
            Id = ID;
            Dni = dni;
            Nombre = nombre;
            Apellido = apellido;
            NroTelefono = nroTelefono;
            Correo = correo;
            IdPais = idPais;
            FechaAlta = fechaAlta;
            Activo = true;
        }


        public Medico() { }
    }
}

