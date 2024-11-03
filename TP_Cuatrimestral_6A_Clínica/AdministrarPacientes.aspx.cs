using Controlador;
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

        protected void Page_Load(object sender, EventArgs e)
        {
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
    }
}