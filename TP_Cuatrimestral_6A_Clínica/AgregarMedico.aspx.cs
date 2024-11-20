using System;
using Modelo;
using Controlador;
using System.Collections.Generic;


namespace TP_Cuatrimestral_6A_Clínica
{
    public partial class AgregarMedico : System.Web.UI.Page
    {

        ControladorMedico controladorMedico = new ControladorMedico();

        private long? MedicoDni
        {
            get
            {
                long dni;
                if (long.TryParse(Request.QueryString["Dni"], out dni))
                    return dni;
                return null;
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
                    ControladorPais CP = new ControladorPais();
                    List<Pais> ListaPaises = CP.Listar();
                    ddlPais.DataSource = ListaPaises;
                    ddlPais.DataBind();

                    // Si hay datos del medico en sesion los restauro
                    if (Session["MedicoDni"] != null) txtDniMedico.Text = Session["MedicoDni"].ToString();
                    if (Session["MedicoNombre"] != null) txtNombreMedico.Text = Session["MedicoNombre"].ToString();
                    if (Session["MedicoApellido"] != null) txtApellidoMedico.Text = Session["MedicoApellido"].ToString();
                    if (Session["MedicoCorreo"] != null) txtCorreoMedico.Text = Session["MedicoCorreo"].ToString();
                    if (Session["MedicoTelefono"] != null) txtTelMedico.Text = Session["MedicoTelefono"].ToString();
                    if (Session["MedicoPais"] != null) ddlPais.SelectedValue = Session["MedicoPais"].ToString();

                    // Limpio los datos de la sesión 
                    Session.Remove("MedicoDni");
                    Session.Remove("MedicoNombre");
                    Session.Remove("MedicoApellido");
                    Session.Remove("MedicoCorreo");
                    Session.Remove("MedicoTelefono");
                    Session.Remove("MedicoPais");

                    if (MedicoDni.HasValue)
                    {
                        CargarDatosMedico(MedicoDni.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                // Muestra o registra el error si es necesario
                throw ex;
            }
        }


        private void CargarDatosMedico(long dni)
        {
            var medico = controladorMedico.ObtenerMedicoPorDni(dni);
            if (medico != null)
            {
                txtDniMedico.Text = medico.Dni.ToString();
                txtDniMedico.Enabled = false;
                txtNombreMedico.Text = medico.Nombre;
                txtApellidoMedico.Text = medico.Apellido;
                txtTelMedico.Text = medico.Telefono;
                txtCorreoMedico.Text = medico.Correo;
                ddlPais.SelectedValue = medico.IdPais.ToString();
                // chkActivo.Checked = medico.Activo;
            }
            else
            {
                lblErrorMedicoExistente.Text = "Error - Médico no encontrado.";
                lblErrorMedicoExistente.ForeColor = System.Drawing.Color.Red;
            }
        }



       




        protected void BtnAgregarMedico_Click(object sender, EventArgs e)
        {


            if (ValidarCamposMedico())
            {
                

                Medico medico = new Medico
                {
                    Dni = (int)(MedicoDni ?? long.Parse(txtDniMedico.Text)),
                    Nombre = txtNombreMedico.Text,
                    Apellido = txtApellidoMedico.Text,
                    Telefono = txtTelMedico.Text,
                    Correo = txtCorreoMedico.Text,
                    IdPais = int.Parse(ddlPais.SelectedValue)
                };

                /*
                    // Capturo los horarios desde sesion
                    List<HorarioMedico> horarios = (List<HorarioMedico>)Session["HorariosMedico"];
                    ControladorHorarioMedico controladorHorario = new ControladorHorarioMedico();
                */
                try
                {
                    if (MedicoDni.HasValue)
                    {

                        controladorMedico.ActualizarMedico(medico);
                        //  controladorHorario.ActualizarHorariosMedico(medico.Dni, horarios); 
                        lblConfirmacion.Text = "Médico actualizado correctamente.";
                        lblConfirmacion.ForeColor = System.Drawing.Color.Green;
                        lblConfirmacion.Visible = true;
                    }
                    else
                    {
                        if (!controladorMedico.MedicoExiste(medico.Dni))
                        {
                            controladorMedico.InsertarMedico(medico);
                            //      controladorHorario.InsertarHorariosMedico(medico.Dni, horarios); 
                            //     LimpiarControles();
                            lblErrorMedicoExistente.Text = "Éxito - Médico agregado.";
                            lblErrorMedicoExistente.ForeColor = System.Drawing.Color.Green;
                            lblErrorMedicoExistente.Visible = true;
                        }
                        else
                        {
                            lblErrorMedicoExistente.Text = "Error - Médico ya existe.";
                            lblErrorMedicoExistente.ForeColor = System.Drawing.Color.Red;
                            lblErrorMedicoExistente.Visible = true;
                        }
                    }

                    //    Session["HorariosMedico"] = null;
                }
                catch (Exception ex)
                {
                    lblErrorMedicoExistente.Text = "Error - " + ex.Message;
                    lblErrorMedicoExistente.ForeColor = System.Drawing.Color.Red;
                    lblErrorMedicoExistente.Visible = true;
                }
            }
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




