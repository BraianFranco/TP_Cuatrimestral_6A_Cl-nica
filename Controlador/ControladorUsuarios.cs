using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
    public class ControladorUsuarios
    {

        public void InsertarUsuario(Usuario usuario)
        {

            AccesoDatos Ad = new AccesoDatos();
            Ad.setearConsulta("insert into Usuarios (Dni , Correo , Contraseña , IdRol) values (@Dni, @Correo , @Contraseña , @IdRol)");
            Ad.setearParametro("@Dni", usuario.Dni);
            Ad.setearParametro("@Correo", usuario.Correo);
            Ad.setearParametro("@Contraseña", usuario.Contraseña);
            Ad.setearParametro("@IdRol", usuario.IdRol);

            try
            {
                Ad.ejecutarAccion();
            }
            catch (Exception ex) { throw ex; }
            finally { Ad.cerrarConexion(); }

        }

        public bool UsuarioExistente(int dni)
        {
            AccesoDatos Ad = new AccesoDatos();
            Ad.setearConsulta("select count(*) from Usuarios where Dni = @Dni");
            Ad.setearParametro("@Dni", dni);

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
    }
}
