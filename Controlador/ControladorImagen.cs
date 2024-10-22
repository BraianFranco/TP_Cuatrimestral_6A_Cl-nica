using Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
    public class ControladorImagen
    {

        public AccesoDatos db;
        public Imagen imagen;
     

        public ControladorImagen() { 
        
            db = new AccesoDatos();
            imagen = new Imagen();
       

        }

        static public Imagen getImagenByArticuloId(int id)
        {
            AccesoDatos db = new AccesoDatos();
            Imagen imagen = new Imagen();

            try
            {

                
                db.setearConsulta("SELECT Id, IdArticulo,ImagenUrl FROM IMAGENES where IdArticulo = @IdArt");

                db.setearParametro("IdArt",id);

                db.ejecutarLectura();

                if (db.Lector.Read())
                {              
                    imagen.Id = (int)db.Lector["Id"]; 
                    imagen.IdArticulo = (int)db.Lector["IdArticulo"];
                    imagen.Url = db.Lector["ImagenUrl"].ToString();
                }

                return imagen;

            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }finally
            {

                db.cerrarConexion();

            }




        }




        static public List<String> getListImagenUrlsByArticuloId(int id)
        {
            AccesoDatos db = new AccesoDatos();

            List<string> urlImagenes = new List<string>();
         
            try
            {
                db.setearConsulta("SELECT ImagenUrl FROM IMAGENES where IdArticulo = @IdArt");
                db.setearParametro("IdArt", id);
                db.ejecutarLectura();


                while (db.Lector.Read())
                {
                    urlImagenes.Add(db.Lector["ImagenUrl"].ToString());

                }

                return urlImagenes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {

                db.cerrarConexion();

            }


        }













        public List<Imagen> Listar()
        {
            List<Imagen> lista = new List<Imagen>();

            AccesoDatos Ad = new AccesoDatos();

            Ad.setearConsulta("select Id, IdArticulo, ImagenUrl FROM IMAGENES");
            Ad.ejecutarLectura();

            while (Ad.Lector.Read())
            {

                Imagen aux = new Imagen();
                aux.Id = (int)Ad.Lector["Id"];
                aux.IdArticulo = (int)Ad.Lector["IdArticulo"];
                aux.Url = (string)Ad.Lector["ImagenUrl"];

                lista.Add(aux);
            }


            Ad.cerrarConexion();

            return lista;

        }




    }
}
