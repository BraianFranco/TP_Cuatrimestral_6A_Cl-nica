using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Especialidad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public int DniEspecialidad { get; set; }



        public Especialidad(int id, string nombre, int dniespecialidad)
        {

            Id = id;
            Nombre = nombre;
            DniEspecialidad = dniespecialidad;
        }

        public Especialidad() { }


    }
}
