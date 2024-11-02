using System;
using Modelo;
using Controlador;
using System.Collections.Generic;


namespace TP_Cuatrimestral_6A_Clínica
{
    public partial class AgregarMedico : System.Web.UI.Page
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

        protected void BtnAgregarMedico_Click(object sender, EventArgs e)
        {
            ControladorMedico CPaciente = new ControladorMedico();
            Medico medico = new Medico();


            if (ValidarCamposMedico() == true)
            {
                if (!CPaciente.MedicoExiste(Int32.Parse(txtDniMedico.Text)))
                {
                    medico.Dni = Int32.Parse(txtDniMedico.Text);
                    medico.Nombre = txtNombreMedico.Text;
                    medico.Apellido = txtApellidoMedico.Text;
                    medico.Telefono = txtTelMedico.Text;
                    medico.Correo = txtCorreoMedico.Text;
                    medico.IdPais = Int32.Parse(ddlPais.SelectedValue);

                    CPaciente.InsertarMedico(medico);
                    LimpiarControles();


                    lblErrorMedicoExistente.Text = "ÉXITO ! - Médico cargado";
                    lblErrorMedicoExistente.ForeColor = System.Drawing.Color.Green;

                }
                else
                {
                    lblErrorMedicoExistente.Text = "ERROR ! - Médico existente";
                    lblErrorMedicoExistente.ForeColor = System.Drawing.Color.Red;

                }

            }
        }

        private void LimpiarControles()
        {
            txtDniMedico.Text = string.Empty;
            txtNombreMedico.Text = string.Empty;
            txtApellidoMedico.Text = string.Empty;
            txtCorreoMedico.Text = string.Empty;
            txtTelMedico.Text = string.Empty;
            ddlPais.SelectedIndex = 0;

        }

        private bool ValidarCamposMedico()
        {
            bool Valido = true;


            if (string.IsNullOrEmpty(txtDniMedico.Text.ToString()))
            {
                lblErrorDniMedico.Text = "Error - Ingrese un Dni";
                Valido = false;
            }
            else
            {
                lblErrorDniMedico.Text = "";
            }
            if (string.IsNullOrEmpty(txtNombreMedico.Text.ToString()))
            {
                lblErrorNombreMedico.Text = "Error - Ingrese un Nombre";
                Valido = false;
            }
            else
            {
                lblErrorNombreMedico.Text = "";
            }
            if (string.IsNullOrEmpty(txtApellidoMedico.Text.ToString()))
            {
                lblErrorApellidoMedico.Text = "Error - Ingrese un Apellido";
                Valido = false;
            }
            else
            {
                lblErrorApellidoMedico.Text = "";
            }
            if (string.IsNullOrEmpty(txtCorreoMedico.Text.ToString()))
            {
                lblErrorCorreoMedico.Text = "Error - Ingrese un Correo";
                Valido = false;
            }
            else
            {
                lblErrorCorreoMedico.Text = "";
            }
            if (string.IsNullOrEmpty(txtTelMedico.Text.ToString()))
            {
                lblErrorMedicoTel.Text = "Error - Ingrese un Teléfono";
                Valido = false;
            }
            else
            {
                lblErrorMedicoTel.Text = "";
            }

            return Valido;
        }

        protected void btnCancelarMedico_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdministrarMedicos.aspx");
        }
    }

}
