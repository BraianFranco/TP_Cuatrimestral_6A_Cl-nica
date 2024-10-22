using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;


namespace Controlador
{
    public class ControladorVoucher
    {
        private AccesoDatos db;


        public ControladorVoucher()
        {

            db = new AccesoDatos();

        }


        public bool VoucherEsValido(string codigo)
        {

            string consulta = $"SELECT V.IdCliente from Vouchers as V WHERE V.CodigoVoucher = @codigo";

            // verificar si existe en la db o si fué utilizado

            try
            {
                db.setearConsulta(consulta);
                db.setearParametro("@codigo", codigo);
                db.ejecutarLectura();

                /// si el lector no tiene filas es por que no hay ningun voucher en la db con ese código
           
                if(!db.Lector.HasRows) return false;


                while (db.Lector.Read())
                {
                    // si no es null significa que tiene cliente o usuario asociado y ya fue canjeado

                   if(db.Lector["IdCliente"] != DBNull.Value) return false;

                }
            }

            catch (Exception ex)
            {
                throw new Exception("Error al validar el voucher: " + ex.Message, ex);
            }
            finally
            {
                db.cerrarConexion();
            }

            return true;

        }
    }
}
