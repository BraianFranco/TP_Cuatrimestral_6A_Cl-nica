using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace Modelo
{
    public class Usuario
    {

        public int IdUsuario { get; set; }
        public int Dni { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public int IdRol { get; set; }
        public bool Activo { get; set; }

        public Usuario() { }

        public Usuario(int dni , string correo, string contraseña , int idrol)
        {
            Dni = dni;
            Correo = correo;
            Contraseña = contraseña;
            IdRol = idrol;
            Correo = correo;
        }
    }
}

