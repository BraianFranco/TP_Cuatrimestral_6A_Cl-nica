using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Pais
    {

        public int ID { get; set; }
        public string Nombre { get; set; }


        public Pais(int id, string nombre)
        {
            ID = id;
            Nombre = nombre;
        }

        public Pais()
        {
        }

        public override string ToString()
        {
            return this.Nombre;
        }
    }
}
