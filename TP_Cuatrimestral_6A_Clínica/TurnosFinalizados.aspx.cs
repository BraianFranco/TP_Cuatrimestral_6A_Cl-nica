using Controlador;
using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Cuatrimestral_6A_Clínica
{
    public partial class TurnosFinalizados : System.Web.UI.Page
    {

        ControladorTurno controladorTurno = new ControladorTurno();
        ControladorPaciente controladorPaciente = new ControladorPaciente();
        ControladorMedico controladorMedico = new ControladorMedico();
        ControladorEspecialidad controladorEspecialidad = new ControladorEspecialidad();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Login.aspx");

            }

            if (!IsPostBack)
            {
                if (ObtenerIdRolUsuarioSession() == 0)
                {
                    CargarTurnosFinalizadosParaMedico();
                }
                else
                {
                    CargarTurnosFinalizados();
                }
            }
        }

        //private void BindGrid()
        //{

        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("TurnoID", typeof(int));
        //    dt.Columns.Add("Paciente", typeof(string));
        //    dt.Columns.Add("Fecha", typeof(DateTime));
        //    dt.Columns.Add("Hora", typeof(string));


        //    dt.Rows.Add(1, "Juan Pérez", DateTime.Now.AddDays(1), "10:00 AM");
        //    dt.Rows.Add(2, "María Gómez", DateTime.Now.AddDays(2), "11:00 AM");
        //    dt.Rows.Add(3, "Luis Fernández", DateTime.Now.AddDays(3), "02:00 PM");
        //    dt.Rows.Add(4, "Ana Martínez", DateTime.Now.AddDays(4), "03:00 PM");

        //    // Enlazar el DataTable al GridView
        //    gvTurnos.DataSource = dt;
        //    gvTurnos.DataBind();
        //


        private void CargarTurnosFinalizados()
        {
            try
            {
                var listaTurnos = controladorTurno.Listar();


                DataTable dtTurnos = new DataTable();

                dtTurnos.Columns.Add("Id", typeof(int));
                dtTurnos.Columns.Add("nombrepaciente", typeof(string));
                dtTurnos.Columns.Add("nombremedico", typeof(string));
                dtTurnos.Columns.Add("especialidad", typeof(string));
                dtTurnos.Columns.Add("Observaciones", typeof(string));
                dtTurnos.Columns.Add("FechaTurno", typeof(DateTime));
                dtTurnos.Columns.Add("Estado", typeof(string));


                foreach (var Turno in listaTurnos)
                {
                    Paciente paciente = controladorPaciente.FiltrarPorDni(Turno.DniPaciente);
                    Medico medico = controladorMedico.FiltrarPorDni(Turno.DniMedico);
                    Especialidad especialidad = controladorEspecialidad.ObtenerPorId(Turno.IdEspecialidad);

                    if (Turno.Activo == true)
                    {
                        if (Turno.Estado.Equals("Cancelado") || Turno.Estado.Equals("Finalizado"))
                        {
                            dtTurnos.Rows.Add(
                            Turno.Id,
                            paciente.nombre,
                            medico.Nombre,
                            especialidad.Nombre,
                            Turno.Observaciones,
                            Turno.FechaTurno,
                            Turno.Estado
                            );
                        }
                    }

                }

                gvTurnos.DataSource = dtTurnos;
                gvTurnos.DataBind();

            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al cargar Turnos: " + ex.Message;
            }
        }

        private void CargarTurnosFinalizadosParaMedico()
        {
            try
            {
                var listaTurnos = controladorTurno.Listar();


                DataTable dtTurnos = new DataTable();

                dtTurnos.Columns.Add("Id", typeof(int));
                dtTurnos.Columns.Add("nombrepaciente", typeof(string));
                dtTurnos.Columns.Add("nombremedico", typeof(string));
                dtTurnos.Columns.Add("especialidad", typeof(string));
                dtTurnos.Columns.Add("Observaciones", typeof(string));
                dtTurnos.Columns.Add("FechaTurno", typeof(DateTime));
                dtTurnos.Columns.Add("Estado", typeof(string));

                int DniMedicoSession = ObtenerDniUsuarioSession();

                foreach (var Turno in listaTurnos)
                {
                    Paciente paciente = controladorPaciente.FiltrarPorDni(Turno.DniPaciente);
                    Medico medico = controladorMedico.FiltrarPorDni(Turno.DniMedico);
                    Especialidad especialidad = controladorEspecialidad.ObtenerPorId(Turno.IdEspecialidad);


                    if (Turno.Activo == true)
                    {
                        if (Turno.Estado.Equals("Cancelado") || Turno.Estado.Equals("Finalizado"))
                        {
                            if (Turno.DniMedico == DniMedicoSession)
                            {
                                dtTurnos.Rows.Add(
                                Turno.Id,
                                paciente.nombre,
                                medico.Nombre,
                                especialidad.Nombre,
                                Turno.Observaciones,
                                Turno.FechaTurno,
                                Turno.Estado
                              );
                            }


                        }
                    }


                }

                gvTurnos.DataSource = dtTurnos;
                gvTurnos.DataBind();

            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al cargar Turnos: " + ex.Message;
            }
        }

        public int ObtenerDniUsuarioSession()
        {
            int rol = ((Usuario)Session["Usuario"]).Dni;

            return rol;
        }

        public int ObtenerIdRolUsuarioSession()
        {
            int rol = ((Usuario)Session["Usuario"]).IdRol;

            return rol;
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFiltrar.Text))
            {
                try
                {

                    DataTable dtTurnosFiltrada = new DataTable();

                    dtTurnosFiltrada.Columns.Add("Id", typeof(int));
                    dtTurnosFiltrada.Columns.Add("nombrepaciente", typeof(string));
                    dtTurnosFiltrada.Columns.Add("nombremedico", typeof(string));
                    dtTurnosFiltrada.Columns.Add("especialidad", typeof(string));
                    dtTurnosFiltrada.Columns.Add("Observaciones", typeof(string));
                    dtTurnosFiltrada.Columns.Add("FechaTurno", typeof(DateTime));
                    dtTurnosFiltrada.Columns.Add("Estado", typeof(string));

                    List<Turno> listaTurnos = controladorTurno.FiltrarPorDniPaciente(Int32.Parse(txtFiltrar.Text));

                    
                    foreach (var Turno in listaTurnos)
                    {
                        Paciente paciente = controladorPaciente.FiltrarPorDni(Turno.DniPaciente);
                        Medico medico = controladorMedico.FiltrarPorDni(Turno.DniMedico);
                        Especialidad especialidad = controladorEspecialidad.ObtenerPorId(Turno.IdEspecialidad);


                        if (Turno.Estado.Equals("Cancelado") || Turno.Estado.Equals("Finalizado"))
                        {
                            dtTurnosFiltrada.Rows.Add(
                            Turno.Id,
                            paciente.nombre,
                            medico.Nombre,
                            especialidad.Nombre,
                            Turno.Observaciones,
                            Turno.FechaTurno,
                            Turno.Estado
                            );
                        }

                    }

                    if (listaTurnos.Count > 0)
                    {
                        gvTurnos.DataSource = dtTurnosFiltrada;
                        gvTurnos.DataBind();

                        lblMensaje.Text = "";
                    }
                    else if (dtTurnosFiltrada.Rows.Equals(null))
                    {
                        lblMensaje.Text = "ERROR - NO EXISTE TURNO CON ESE DNI";
                    }
                    else
                    {
                        lblMensaje.Text = "ERROR - NO EXISTE TURNO CON ESE DNI";
                    }


                }
                catch (Exception)
                {
                    lblMensaje.Text = "ERROR - NO EXISTE TURNO CON ESE DNI";
                }
            }
            else
            {
                CargarTurnosFinalizados();
            }

        }
    }
}