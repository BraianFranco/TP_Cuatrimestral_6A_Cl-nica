using Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Controlador
{
    public class ControladorHorarioMedico
    {

        public void InsertarHorariosMedico(long dniMedico, List<HorarioMedico> horarios)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                foreach (var horario in horarios)
                {
                    string query = "INSERT INTO HorariosMedicos (DniMedico, DiaSemana, IdTurno) VALUES (@DniMedico, @DiaSemana, @IdTurno)";
                    datos.setearConsulta(query);
                    datos.setearParametro("@DniMedico", dniMedico);
                    datos.setearParametro("@DiaSemana", horario.DiaSemana);
                    datos.setearParametro("@IdTurno", horario.IdTurno);
                    datos.ejecutarAccion();

                    // Limpiar los parámetros después de cada ejecución
                    datos.limpiarParametros();
                }
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


        public void EliminarHorariosMedico(long dniMedico)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string query = "DELETE FROM HorariosMedicos WHERE DniMedico = @DniMedico";
                datos.setearConsulta(query);
                datos.setearParametro("@DniMedico", dniMedico);
                datos.ejecutarAccion();
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


        public void ActualizarHorariosMedico(long dniMedico, List<HorarioMedico> horarios)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                EliminarHorariosMedico(dniMedico);

                foreach (var horario in horarios)
                {
                    string query = "INSERT INTO HorariosMedicos (DniMedico, DiaSemana, IdTurno) VALUES (@DniMedico, @DiaSemana, @IdTurno)";
                    datos.setearConsulta(query);
                    datos.setearParametro("@DniMedico", dniMedico);
                    datos.setearParametro("@DiaSemana", horario.DiaSemana);
                    datos.setearParametro("@IdTurno", horario.IdTurno);
                    datos.ejecutarAccion();
                    datos.cerrarConexion(); 
                }
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



        public List<HorarioMedico> ObtenerHorariosPorMedico(long dniMedico)
        {
            List<HorarioMedico> horarios = new List<HorarioMedico>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT DniMedico, DiaSemana, IdTurno FROM HorariosMedicos WHERE DniMedico = @DniMedico");
                datos.setearParametro("@DniMedico", dniMedico);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    HorarioMedico horario = new HorarioMedico
                    {
                        DniMedico = Convert.ToInt64(datos.Lector["DniMedico"]),
                        DiaSemana = Convert.ToInt32(datos.Lector["DiaSemana"]),
                        IdTurno = Convert.ToInt32(datos.Lector["IdTurno"])
                    };

                    horarios.Add(horario);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

            return horarios;
        }

        public string FormatearHorarios(List<HorarioMedico> horarios)
        {
            string resultado = "";
            foreach (var horario in horarios)
            {
                string diaSemana = ObtenerNombreDiaSemana(horario.DiaSemana);
                string turno = ObtenerNombreTurno(horario.IdTurno);
                resultado += $"Día: {diaSemana}, Turno: {turno} <br />";
            }
            return resultado;
        }


        private string ObtenerNombreDiaSemana(int diaSemana)
        {
            string[] dias = { "Domingo", "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado" };
            return dias[diaSemana % 7];
        }

        private string ObtenerNombreTurno(int idTurno)
        {
            switch (idTurno)
            {
                case 1: return "Mañana";
                case 2: return "Tarde";
                case 3: return "Noche";
                default: return "Revisar";
            }
        }

    }
}