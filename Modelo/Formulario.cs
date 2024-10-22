using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Formulario
    {

        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Ciudad { get; set; }
        public string CP { get; set; }
        public bool AceptaTerminos { get; set; }

        public Formulario()
        {
            Dni = string.Empty;
            Nombre = string.Empty;
            Apellido = string.Empty;
            Direccion = string.Empty;
            Email = string.Empty;
            Ciudad = string.Empty;
            CP = string.Empty;
            AceptaTerminos = false;
        }
    }
}
