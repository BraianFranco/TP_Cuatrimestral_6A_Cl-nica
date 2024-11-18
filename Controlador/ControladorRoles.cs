using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
    public class ControladorRoles
    {

        public List<Rol> Listar()
        {
            List<Rol> lista = new List<Rol>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select Id, Nombre ,Descripcion from Roles");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {

                    Rol aux = new Rol();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    lista.Add(aux);


                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public string ObtenerNombreRolPorId(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select Nombre from Roles where Id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();
                datos.Lector.Read();

                string Nombre = (string)datos.Lector["Nombre"];

                return Nombre;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }


}
