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

        ControladorPaciente controladorPaciente = new ControladorPaciente();

        private long? PacienteDni
        {
            get
            {
                long dni;
                if (long.TryParse(Request.QueryString["Dni"], out dni))
                    return dni;
                return null;
            }
        }


        private void CargarDatosPaciente(long dni)
        {
            var paciente = controladorPaciente.ObtenerPorDni(dni);
            if (paciente != null)
            {
                txtDniPaciente.Text = paciente.dni.ToString();
                txtDniPaciente.Enabled = false; 
                txtNombrePaciente.Text = paciente.nombre;
                txtApellidoPaciente.Text = paciente.apellido;
                txtTelPaciente.Text = paciente.tel;
                txtFechaNacimientoPaciente.Text = paciente.fechanacimiento.ToString("yyyy-MM-dd");
                txtCorreoPaciente.Text = paciente.correo;
                ddlPais.SelectedValue = paciente.idPais.ToString();
                txtDireccionPaciente.Text = paciente.direccion;
            }
            else
            {
                lblErrorPacienteExistente.Text = "Error - Paciente no encontrado.";
                lblErrorPacienteExistente.ForeColor = System.Drawing.Color.Red;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Usuario"] == null)
            {
                Response.Redirect("Login.aspx");

            }

            try
            {
                if (!IsPostBack)
                {
                    // Cargar lista de países en el dropdown
                    ControladorPais CP = new ControladorPais();
                    ddlPais.DataSource = CP.Listar();
                    ddlPais.DataBind();

                    // Si el paciente ya existe, cargar sus datos
                    if (PacienteDni.HasValue)
                    {
                        CargarDatosPaciente(PacienteDni.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                lblErrorPacienteExistente.Text = "Error - " + ex.Message;
                lblErrorPacienteExistente.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void BtnAgregarPaciente_Click(object sender, EventArgs e)
        {
            if (ValidarCamposPaciente())
            {
                Paciente paciente = new Paciente
                {
                    dni = (int)(PacienteDni ?? long.Parse(txtDniPaciente.Text)),
                    nombre = txtNombrePaciente.Text,
                    apellido = txtApellidoPaciente.Text,
                    tel = txtTelPaciente.Text,
                    fechanacimiento = DateTime.Parse(txtFechaNacimientoPaciente.Text),
                    correo = txtCorreoPaciente.Text,
                    idPais = int.Parse(ddlPais.SelectedValue),
                    direccion = txtDireccionPaciente.Text
                };

                try
                {
                    if (PacienteDni.HasValue)
                    {
                        // Actualizar paciente existente
                        controladorPaciente.Actualizar(paciente);
                        lblConfirmacion.Text = "Paciente actualizado correctamente.";
                        lblConfirmacion.ForeColor = System.Drawing.Color.Green;
                        lblConfirmacion.Visible = true; 
                    }
                    else
                    {
                        // Insertar nuevo paciente
                        if (!controladorPaciente.PacienteExiste(paciente.dni))
                        {
                            controladorPaciente.InsertarPaciente(paciente);
                            LimpiarControles();
                            lblErrorPacienteExistente.Text = "Éxito - PACIENTE AGREGADO.";
                            lblErrorPacienteExistente.ForeColor = System.Drawing.Color.Green;
                            lblConfirmacion.Visible = true;
                        }
                        else
                        {
                            lblErrorPacienteExistente.Text = "Error - PACIENTE YA EXISTENTE.";
                            lblErrorPacienteExistente.ForeColor = System.Drawing.Color.Red;
                            lblErrorPacienteExistente.Visible = true;
                        }
                    }

                   // Aca iria el response redirect????;
                }
                catch (Exception ex)
                {
                    lblErrorPacienteExistente.Text = "Error - " + ex.Message;
                    lblErrorPacienteExistente.ForeColor = System.Drawing.Color.Red;
                    lblErrorPacienteExistente.Visible = true;
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