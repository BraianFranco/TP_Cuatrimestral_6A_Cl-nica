using Controlador;
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
    public partial class AdministrarPacientes : System.Web.UI.Page
    {

        ControladorPaciente controladorPaciente = new ControladorPaciente();
        public bool ConfirmaEliminacion { get; set; }
        private static int DNIAUX;
        protected void Page_Load(object sender, EventArgs e)
        {

            ConfirmaEliminacion = false;

            if (Session["Usuario"] == null)
            {
                Response.Redirect("Login.aspx");

            }
            if (!IsPostBack)
            {
                CargarPacientes();
            }
        }
        protected void gvPacientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvPacientes.Rows[index];

                long pacienteDni = Convert.ToInt64(gvPacientes.DataKeys[index].Value);

                Response.Redirect($"AgregarPaciente.aspx?Dni={pacienteDni}");
            }
        }
        private void CargarPacientes()
        {
            try
            {
                
                var listaPacientes = controladorPaciente.Listar();


      
                DataTable dtPacientes = new DataTable();
                dtPacientes.Columns.Add("Dni", typeof(long));
                dtPacientes.Columns.Add("Nombre", typeof(string));
                dtPacientes.Columns.Add("Apellido", typeof(string));
                dtPacientes.Columns.Add("NroTelefono", typeof(string));
                dtPacientes.Columns.Add("FechaNac", typeof(DateTime));
                dtPacientes.Columns.Add("Correo", typeof(string));
                dtPacientes.Columns.Add("IdPais", typeof(int));
                dtPacientes.Columns.Add("Direccion", typeof(string));
                dtPacientes.Columns.Add("Activo", typeof(bool));

                foreach (var paciente in listaPacientes)
                {
                    dtPacientes.Rows.Add(
                        paciente.dni,
                        paciente.nombre,
                        paciente.apellido,
                        paciente.tel,
                        paciente.fechanacimiento,
                        paciente.correo,
                        paciente.idPais,
                        paciente.direccion,
                        paciente.activo
                    );
                }

                gvPacientes.DataSource = dtPacientes;
                gvPacientes.DataBind();
    
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al cargar pacientes: " + ex.Message;
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarPaciente.aspx");
        }

        protected void GridView1_RowDeleting1(object sender, GridViewDeleteEventArgs e)
        {

            try
            {
                int indice = Convert.ToInt32(e.RowIndex);
                int dniAux = Int32.Parse(gvPacientes.Rows[indice].Cells[0].Text);

                DNIAUX = dniAux;

                ConfirmaEliminacion = true;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        protected void btnCancelarEliminacionPaciente_Click(object sender, EventArgs e)
        {
            ConfirmaEliminacion = false;
        }

        protected void btnConfirmarEliminacionPaciente_Click(object sender, EventArgs e)
        {
            if (DNIAUX.ToString() != string.Empty)
            {
                controladorPaciente.EliminarPaciente(DNIAUX);

                Response.Redirect("AdministrarPacientes.aspx");
            }

        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFiltrar.Text))
            {
                try
                {

                    DataTable dtPacientesFiltrada = new DataTable();
                    dtPacientesFiltrada.Columns.Add("Dni", typeof(long));
                    dtPacientesFiltrada.Columns.Add("Nombre", typeof(string));
                    dtPacientesFiltrada.Columns.Add("Apellido", typeof(string));
                    dtPacientesFiltrada.Columns.Add("NroTelefono", typeof(string));
                    dtPacientesFiltrada.Columns.Add("FechaNac", typeof(DateTime));
                    dtPacientesFiltrada.Columns.Add("Correo", typeof(string));
                    dtPacientesFiltrada.Columns.Add("IdPais", typeof(int));
                    dtPacientesFiltrada.Columns.Add("Direccion", typeof(string));
                    dtPacientesFiltrada.Columns.Add("Activo", typeof(bool));

                    Paciente paciente = controladorPaciente.FiltrarPorDni(Int32.Parse(txtFiltrar.Text));


                    dtPacientesFiltrada.Rows.Add(
                        paciente.dni,
                        paciente.nombre,
                        paciente.apellido,
                        paciente.tel,
                        paciente.fechanacimiento,
                        paciente.correo,
                        paciente.idPais,
                        paciente.direccion,
                        paciente.activo
                    );


                    gvPacientes.DataSource = dtPacientesFiltrada;
                    gvPacientes.DataBind();

                    lblMensaje.Text = "";


                }
                catch (Exception)
                {
                    lblMensaje.Text = "ERROR - NO EXISTE PACIENTE CON ESE DNI";
                }
            }
            else
            {
                CargarPacientes();
            }

        }
    }
}