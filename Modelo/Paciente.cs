using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Paciente
    {
        public int Id { get; set; }
        public long Dni { get; set; }
        public string NroTelefono { get; set; }
        public DateTime FechaNac { get; set; }
        public string Correo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaAlta { get; set; }
        public int IdPais { get; set; }
        public string Direccion { get; set; }
        public bool Activo { get; set; }

    }
}
