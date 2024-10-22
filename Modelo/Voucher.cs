using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Voucher
    {

        public string Codigo {  get;}
        public int IdCliente {  get; }
        public DateTime FechaCanje { get; }
        public int IdArticulo { get; }


        public Voucher(string codigo, int idCliente, DateTime fechaCanje, int idArticulo)
        {
            Codigo = codigo;
            IdCliente = idCliente;
            FechaCanje = fechaCanje;
            IdArticulo = idArticulo;
        }




        public override string ToString() { 
            return this.Codigo;
        }

    }
}
