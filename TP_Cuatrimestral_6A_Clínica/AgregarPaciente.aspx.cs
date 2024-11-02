using Controlador;
using Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace TP_Cuatrimestral_6A_Clínica
{
    public partial class AgregarPaciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!IsPostBack)
                {
                    ControladorPais CP = new ControladorPais();
                    List<Pais> ListaPaises = new List<Pais>();
                    ListaPaises = CP.Listar();

                    ddlPais.DataSource = ListaPaises;
                    ddlPais.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void BtnAgregarPaciente_Click(object sender, EventArgs e)
        {
            ControladorPaciente CPaciente = new ControladorPaciente();
            Paciente paciente = new Paciente();


            if (ValidarCamposPaciente() == true)
            {
                if (!CPaciente.PacienteExiste(Int32.Parse(txtDniPaciente.Text)))
                {
                    paciente.dni = Int32.Parse(txtDniPaciente.Text);
                    paciente.nombre = txtNombrePaciente.Text;
                    paciente.apellido = txtApellidoPaciente.Text;
                    paciente.tel = txtTelPaciente.Text;
                    paciente.fechanacimiento = DateTime.Parse(txtFechaNacimientoPaciente.Text);
                    paciente.correo = txtCorreoPaciente.Text;
                    paciente.idPais = Int32.Parse(ddlPais.SelectedValue);
                    paciente.direccion = txtDireccionPaciente.Text;

                    CPaciente.InsertarPaciente(paciente);
                    LimpiarControles();


                    lblErrorPacienteExistente.Text = "ÉXITO ! - Paciente cargado";
                    lblErrorPacienteExistente.ForeColor = System.Drawing.Color.Green;

                }
                else
                {
                    lblErrorPacienteExistente.Text = "ERROR ! - Paciente existente";
                    lblErrorPacienteExistente.ForeColor = System.Drawing.Color.Red;

                }

            }
        }

        private void LimpiarControles()
        {
            txtNombrePaciente.Text = string.Empty;
            txtApellidoPaciente.Text = string.Empty;
            txtDniPaciente.Text = string.Empty;
            txtCorreoPaciente.Text = string.Empty;
            txtDireccionPaciente.Text = string.Empty;
            txtTelPaciente.Text = string.Empty;
            ddlPais.SelectedIndex = 0;
            txtFechaNacimientoPaciente.Text = string.Empty;

        }

        private bool ValidarCamposPaciente()
        {
            bool Valido = true;


            if (string.IsNullOrEmpty(txtDniPaciente.Text.ToString()))
            {
                lblErrorDniPaciente.Text = "Error - Ingrese un Dni";
                Valido = false;
            }
            else
            {
                lblErrorDniPaciente.Text = "";
            }
            if (string.IsNullOrEmpty(txtNombrePaciente.Text.ToString()))
            {
                lblErrorNombrePaciente.Text = "Error - Ingrese un Nombre";
                Valido = false;
            }
            else
            {
                lblErrorNombrePaciente.Text = "";
            }
            if (string.IsNullOrEmpty(txtApellidoPaciente.Text.ToString()))
            {
                lblErrorApellidoPaciente.Text = "Error - Ingrese un Apellido";
                Valido = false;
            }
            else
            {
                lblErrorApellidoPaciente.Text = "";
            }
            if (string.IsNullOrEmpty(txtCorreoPaciente.Text.ToString()))
            {
                lblErrorCorreoPaciente.Text = "Error - Ingrese un Correo";
                Valido = false;
            }
            else
            {
                lblErrorCorreoPaciente.Text = "";
            }
            if (string.IsNullOrEmpty(txtDireccionPaciente.Text.ToString()))
            {
                lblErrorDireccionPaciente.Text = "Error - Ingrese una Dirección";
                Valido = false;
            }
            else
            {
                lblErrorDireccionPaciente.Text = "";
            }
            if (string.IsNullOrEmpty(txtTelPaciente.Text.ToString()))
            {
                lblErrorTelPaciente.Text = "Error - Ingrese un Teléfono";
                Valido = false;
            }
            else
            {
                lblErrorTelPaciente.Text = "";
            }
            if (string.IsNullOrEmpty(txtFechaNacimientoPaciente.Text.ToString()))
            {
                lblErrorNacimientoPaciente.Text = "Error - Ingrese una Fecha de nacimiento";
                Valido = false;
            }
            else
            {
                lblErrorNacimientoPaciente.Text = "";
            }

            return Valido;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdministrarPacientes.aspx");
        }
    }

}