using Controlador;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Cuatrimestral_6A_Clínica
{
    public partial class AgregarEspecialidad : System.Web.UI.Page
    {

        ControladorEspecialidad controladorEspecialidad = new ControladorEspecialidad();

        private int? EspecialidadId
        {
            get
            {
                int id;
                if (int.TryParse(Request.QueryString["Id"], out id))
                    return id;
                return null;
            }
        }

        private void CargarDatosEspecialidad(int id)
        {
            var especialidad = controladorEspecialidad.ObtenerPorId(id);
            if (especialidad != null)
            {
                txtNombreEspecialidad.Text = especialidad.Nombre;
                txtDescripcionEspecialidad.Text = especialidad.Descripcion;
            }
            else
            {
                lblErrorEspecialidadExistente.Text = "Error - Especialidad no encontrada.";
                lblErrorEspecialidadExistente.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Login.aspx");

            }

            if (!IsPostBack)
            {
                if (EspecialidadId.HasValue)
                {
                    CargarDatosEspecialidad(EspecialidadId.Value);
                }
            }

        }

        protected void btnAgregarEspecialidad_Click(object sender, EventArgs e)
        {

            if (ValidarCamposMedico())
            {
                Especialidad especialidad = new Especialidad
                {
                    Nombre = txtNombreEspecialidad.Text,
                    Descripcion = txtDescripcionEspecialidad.Text
                };

                try
                {
                    if (EspecialidadId.HasValue)
                    {
                        especialidad.Id = EspecialidadId.Value;
                        controladorEspecialidad.Actualizar(especialidad);
                        lblErrorEspecialidadExistente.Text = "Éxito - Especialidad actualizada.";
                        lblErrorEspecialidadExistente.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        if (!controladorEspecialidad.EspecialidadExistente(txtNombreEspecialidad.Text))
                        {
                            controladorEspecialidad.InsertarEspecialidad(especialidad);
                            LimpiarControles();
                            lblErrorEspecialidadExistente.Text = "Éxito - Especialidad agregada.";
                            lblErrorEspecialidadExistente.ForeColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            lblErrorEspecialidadExistente.Text = "Error - Especialidad ya existe.";
                            lblErrorEspecialidadExistente.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblErrorEspecialidadExistente.Text = "Error - " + ex.Message;
                    lblErrorEspecialidadExistente.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        protected void btnCancelarEspecialidad_Click(object sender, EventArgs e)
        {
            Response.Redirect("Administrar.aspx");
        }


        private void LimpiarControles()
        {
            txtNombreEspecialidad.Text = string.Empty;
            txtDescripcionEspecialidad.Text = string.Empty;

        }

        private bool ValidarCamposMedico()
        {
            bool Valido = true;


            if (string.IsNullOrEmpty(txtNombreEspecialidad.Text))
            {
                lblErrorNombreEspecialidad.Text = "Error - Ingrese un Nombre de Especialidad";
                Valido = false;
            }
            else
            {
                lblErrorNombreEspecialidad.Text = "";
            }
            if (string.IsNullOrEmpty(txtDescripcionEspecialidad.Text))
            {
                lblErrorDesEspecialidad.Text = "Error - Ingrese una Descripcion";
                Valido = false;
            }
            else
            {
                lblErrorDesEspecialidad.Text = "";
            }

            return Valido;
        }
    }
}