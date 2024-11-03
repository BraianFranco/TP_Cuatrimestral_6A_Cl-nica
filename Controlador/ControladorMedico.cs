using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controlador
{
    public class ControladorMedico
    {

        public List<Medico> Listar()
        {
            List<Medico> lista = new List<Medico>();

            AccesoDatos Ad = new AccesoDatos();

            Ad.setearConsulta("select Dni, NroTelefono , Nombre , Apellido , Correo , Activo , IdPais from Medico");

            try
            {

                Ad.ejecutarLectura();

                while (Ad.Lector.Read())
                {

                    Medico aux = new Medico();

                    aux.Dni = Convert.ToInt32(Ad.Lector["Dni"]); // BIGINT -> long
                    aux.Nombre = Ad.Lector["Nombre"].ToString(); // VARCHAR -> string
                    aux.Apellido = Ad.Lector["Apellido"].ToString(); // VARCHAR -> string
                    aux.Telefono = Ad.Lector["NroTelefono"].ToString(); // VARCHAR -> string
                    aux.Correo = Ad.Lector["Correo"].ToString(); // VARCHAR -> string
                    aux.IdPais = Convert.ToInt32(Ad.Lector["IdPais"]); // INT -> int
                    aux.Activo = Convert.ToBoolean(Ad.Lector["Activo"]); // BIT -> bool

                    lista.Add(aux);
                }

            }
            catch (Exception ex) { throw ex; }

            finally { Ad.cerrarConexion(); }

            return lista;

        }

        public bool MedicoExiste(int dni)
        {
            AccesoDatos Ad = new AccesoDatos();
            Ad.setearConsulta("select count(*) from Medico where Dni = @DNI");
            Ad.setearParametro("@DNI", dni);

            try
            {
                Ad.ejecutarLectura();
                if (Ad.Lector.Read())
                {
                    return (int)Ad.Lector[0] > 0;
                }
            }
            catch (Exception ex) { throw ex; }
            finally { Ad.cerrarConexion(); }

            return false;
        }

        public void InsertarMedico(Medico medico)
        {

            AccesoDatos Ad = new AccesoDatos();
            Ad.setearConsulta("insert into Medico (Dni, Nombre , Apellido , NroTelefono , Correo , IdPais, Activo) values (@Dni, @Nombre , @Apellido , @NroTelefono , @Correo , @IdPais, @Activo)");
            Ad.setearParametro("@Dni", medico.Dni);
            Ad.setearParametro("@Nombre", medico.Nombre);
            Ad.setearParametro("@Apellido", medico.Apellido);
            Ad.setearParametro("@NroTelefono", medico.Telefono);
            Ad.setearParametro("@Correo", medico.Correo);
            Ad.setearParametro("@IdPais", medico.IdPais);
            Ad.setearParametro("@Activo", true);

            try
            {
                Ad.ejecutarAccion();
            }
            catch (Exception ex) { throw ex; }
            finally { Ad.cerrarConexion(); }


        }

    }
}
