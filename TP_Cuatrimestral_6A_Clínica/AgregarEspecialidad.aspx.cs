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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAgregarEspecialidad_Click(object sender, EventArgs e)
        {
            ControladorEspecialidad CEspecialidad = new ControladorEspecialidad();
            Especialidad especialidad = new Especialidad();


            if (ValidarCamposMedico() == true)
            {
                if (!CEspecialidad.EspecialidadExistente(txtNombreEspecialidad.Text))
                {
                    especialidad.Nombre = txtNombreEspecialidad.Text;
                    especialidad.DniEspecialidad = Int32.Parse(txtDniEspecialidad.Text);

                    CEspecialidad.InsertarEspecialidad(especialidad);
                    LimpiarControles();


                    lblErrorEspecialidadExistente.Text = "ÉXITO ! - Especialidad cargada";
                    lblErrorEspecialidadExistente.ForeColor = System.Drawing.Color.Green;

                }
                else
                {
                    lblErrorEspecialidadExistente.Text = "ERROR ! - Especialidad existente";
                    lblErrorEspecialidadExistente.ForeColor = System.Drawing.Color.Red;

                }

            }
        }

        protected void btnCancelarEspecialidad_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdministrarEspecialidades.aspx");
        }


        private void LimpiarControles()
        {
            txtNombreEspecialidad.Text = string.Empty;
            txtDniEspecialidad.Text = string.Empty;

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
            if (string.IsNullOrEmpty(txtDniEspecialidad.Text))
            {
                lblErrorDniEspecialidad.Text = "Error - Ingrese un Dni";
                Valido = false;
            }
            else
            {
                lblErrorDniEspecialidad.Text = "";
            }

            return Valido;
        }
    }
}