using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
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
            Ad.setearConsulta("select count(*) from Usuarios where Dni = @Dni AND Activo = 1");
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

        public bool Loguearse(int dni, string contraseña)
        {
            AccesoDatos Ad = new AccesoDatos();
            Ad.setearConsulta("select Dni , Contraseña , Verificacion , IdRol from Usuarios where Dni = @Dni AND Contraseña = @contraseña  AND Verificacion = 'Verificado'");
            Ad.setearParametro("@Dni", dni);
            Ad.setearParametro("@contraseña", contraseña);

            try
            {
                Ad.ejecutarLectura();
                if (Ad.Lector.Read())
                {
                    return true;
                }
            }
            catch (Exception ex) { throw ex; }
            finally { Ad.cerrarConexion(); }

            return false;

        }

        public Usuario ObtenerUsuarioPorDni(int dni)
        {
            AccesoDatos Ad = new AccesoDatos();
            Ad.setearConsulta("select  IdUsuario , Correo , Dni , Verificacion , Contraseña , IdRol , Activo from Usuarios where Dni = @Dni AND Activo = 1 ");
            Ad.setearParametro("@Dni", dni);
            Ad.ejecutarLectura();

            try
            {

                if (Ad.Lector.Read())
                {

                    return new Usuario
                    {

                        IdUsuario = Convert.ToInt32(Ad.Lector["IdUsuario"]),
                        Correo = Ad.Lector["Correo"].ToString(),
                        Dni = Convert.ToInt32(Ad.Lector["Dni"]),
                        Verificacion = Ad.Lector["Verificacion"].ToString(),
                        Contraseña = Ad.Lector["Contraseña"].ToString(),
                        IdRol = Convert.ToInt32(Ad.Lector["IdRol"]),
                        Activo = Convert.ToBoolean(Ad.Lector["Activo"]),

                    };

                }

                return null;

            }
            finally
            {
                Ad.cerrarConexion();
            }

        }


        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();

            AccesoDatos Ad = new AccesoDatos();

            Ad.setearConsulta("select IdUsuario, Dni , Correo , Contraseña , IdRol , Activo , Verificacion from Usuarios");

            try
            {

                Ad.ejecutarLectura();

                while (Ad.Lector.Read())
                {

                    Usuario aux = new Usuario();

                    if (aux.Activo == true)
                    {
                        aux.IdUsuario = Convert.ToInt32(Ad.Lector["IdUsuario"]);
                        aux.Dni = Convert.ToInt32(Ad.Lector["Dni"]);
                        aux.Correo = Ad.Lector["Correo"].ToString();
                        aux.Contraseña = Ad.Lector["Contraseña"].ToString();
                        aux.IdRol = Convert.ToInt32(Ad.Lector["IdRol"]);
                        aux.Activo = Convert.ToBoolean(Ad.Lector["Activo"]);
                        aux.Verificacion = Ad.Lector["Verificacion"].ToString();

                        lista.Add(aux);
                    }

                }

            }
            catch (Exception ex) { throw ex; }

            finally { Ad.cerrarConexion(); }

            return lista;

        }

        public void ValidarUsuario(int id)
        {
            AccesoDatos Ad = new AccesoDatos();
            Ad.setearConsulta("UPDATE Usuarios SET Verificacion = 'Verificado' where IdUsuario = @Id");
            Ad.setearParametro("@Id", id);

            try
            {
                Ad.ejecutarAccion();
            }
            catch (Exception ex) { throw ex; }
            finally { Ad.cerrarConexion(); }
        }

    }
}
