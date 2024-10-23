using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Controlador
{
    public class ControladorPais
    {
        public List<Pais> Listar()
        {
            List<Pais> lista = new List<Pais>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select ID, Nombre from Paises");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
              
                    Pais aux = new Pais();
                    aux.ID= (int)datos.Lector["ID"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
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



    }
}
