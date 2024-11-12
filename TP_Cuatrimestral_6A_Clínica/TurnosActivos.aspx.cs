﻿using Controlador;
using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Cuatrimestral_6A_Clínica
{
    public partial class TurnosActivos : System.Web.UI.Page
    {

        ControladorTurno controladorTurno = new ControladorTurno();
        ControladorPaciente controladorPaciente = new ControladorPaciente();
        ControladorMedico controladorMedico = new ControladorMedico();
        ControladorEspecialidad controladorEspecialidad = new ControladorEspecialidad();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTurnos();
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


        //    GridView1.DataSource = dt;
        //    GridView1.DataBind();
        //}


        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }



        private void CargarTurnos()
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

                GridView1.DataSource = dtTurnos;
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al cargar Turnos: " + ex.Message;
            }
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

                    List<Turno>  listaTurnos = controladorTurno.FiltrarPorDniPaciente(Int32.Parse(txtFiltrar.Text));


                    foreach (var Turno in listaTurnos)
                    {
                         Paciente paciente = controladorPaciente.FiltrarPorDni(Turno.DniPaciente);
                         Medico medico = controladorMedico.FiltrarPorDni(Turno.DniMedico);
                         Especialidad especialidad = controladorEspecialidad.ObtenerPorId(Turno.IdEspecialidad);

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


                    if(listaTurnos.Count > 0)
                    {
                        GridView1.DataSource = dtTurnosFiltrada;
                        GridView1.DataBind();

                        lblMensaje.Text = "";
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
                CargarTurnos();
            }

        }
    }
}