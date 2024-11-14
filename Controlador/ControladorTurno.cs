using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
    public class ControladorTurno
    {

        public List<Turno> Listar()
        {
            List<Turno> lista = new List<Turno>();

            AccesoDatos Ad = new AccesoDatos();

            Ad.setearConsulta("select Id, DniMedico , DniPaciente , IdEspecialidad , FechaTurno , Activo , EstadoTurno, Observaciones from Turnos");

            try
            {

                Ad.ejecutarLectura();

                while (Ad.Lector.Read())
                {

                    Turno aux = new Turno();

                    aux.Id = (int)Ad.Lector["Id"];
                    aux.DniMedico = (int)Convert.ToInt64(Ad.Lector["DniMedico"]);
                    aux.DniPaciente = (int)Convert.ToInt64(Ad.Lector["DniPaciente"]);
                    aux.IdEspecialidad = (int)Ad.Lector["IdEspecialidad"];
                    aux.FechaTurno = Convert.ToDateTime(Ad.Lector["FechaTurno"]);
                    aux.Estado = Ad.Lector["EstadoTurno"].ToString();
                    aux.Activo = (bool)Ad.Lector["Activo"];
                    aux.Observaciones = Ad.Lector["Observaciones"].ToString();

                    lista.Add(aux);
                }

            }
            catch (Exception ex) { throw ex; }

            finally { Ad.cerrarConexion(); }

            return lista;

        }

        public void FinalizarOCancelarturno(int id , string estado)
        {
            AccesoDatos Ad = new AccesoDatos();
            Ad.setearConsulta("UPDATE Turnos SET EstadoTurno = @ESTADO WHERE Id = @Id");
            Ad.setearParametro("@ID", id);
            Ad.setearParametro("@ESTADO", estado);

            try
            {
                Ad.ejecutarAccion();
            }
            catch (Exception ex) { throw ex; }
            finally { Ad.cerrarConexion(); }
        }

        public List<Turno> FiltrarPorDniPaciente(int dni)
        {

            AccesoDatos Ad = new AccesoDatos();
            List<Turno> listaTurnosFiltrada = new List<Turno>();

            try
            {

                string Consulta = "select Id , DniMedico, DniPaciente, IdEspecialidad , FechaTurno , Activo , Observaciones , EstadoTurno  from Turnos where DniPaciente like " + dni;

                Ad.setearConsulta(Consulta);
                Ad.ejecutarLectura();


                while (Ad.Lector.Read())
                {

                    Turno aux = new Turno();

                    aux.Id = (int)Ad.Lector["Id"];
                    aux.DniMedico = (int)Convert.ToInt64(Ad.Lector["DniMedico"]);
                    aux.DniPaciente = (int)Convert.ToInt64(Ad.Lector["DniPaciente"]);
                    aux.IdEspecialidad = (int)Ad.Lector["IdEspecialidad"];
                    aux.FechaTurno = Convert.ToDateTime(Ad.Lector["FechaTurno"]);
                    aux.Activo = (bool)Ad.Lector["Activo"];
                    aux.Observaciones = Ad.Lector["Observaciones"].ToString();
                    aux.Estado = Ad.Lector["EstadoTurno"].ToString();

                    listaTurnosFiltrada.Add(aux);

                }

                return listaTurnosFiltrada;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
