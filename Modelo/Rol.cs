using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Rol
    {
        public int Id {  get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public Rol() { }


        public Rol(int id, string nombre, string descripcion)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;

        }
    }
}
