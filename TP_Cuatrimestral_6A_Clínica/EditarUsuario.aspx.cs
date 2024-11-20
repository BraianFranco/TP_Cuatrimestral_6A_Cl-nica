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
    public partial class EditarUsuario : System.Web.UI.Page
    {
        ControladorUsuarios controladorUsuario = new ControladorUsuarios();
        Usuario usuarioSession = new Usuario();
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

                    usuarioSession = (Usuario)Session["Usuario"];

                    txtDniUsuario.Text = usuarioSession.Dni.ToString();
                    txtDniUsuario.ReadOnly = true;
                    txtContraseñaUsuario.Text = usuarioSession.Contraseña.ToString();
                    txtCorreoUsuario.Text = usuarioSession.Correo.ToString();


                }
            }
            catch (Exception)
            {

                throw;
            }

        }


        private void LimpiarControles()
        {
            txtDniUsuario.Text = string.Empty;
            txtCorreoUsuario.Text = string.Empty;
            txtContraseñaUsuario.Text = string.Empty;

        }

        private bool ValidarCamposUsuario()
        {
            bool Valido = true;


            if (string.IsNullOrEmpty(txtDniUsuario.Text.ToString()))
            {
                lblErrorDniUsuario.Text = "*Error - Ingrese un Dni";
                Valido = false;
            }
            else
            {
                lblErrorDniUsuario.Text = "";
            }
            if (string.IsNullOrEmpty(txtCorreoUsuario.Text.ToString()))
            {
                lblErrorCorreoUsuario.Text = "*Error - Ingrese un Correo";
                Valido = false;
            }
            else
            {
                lblErrorCorreoUsuario.Text = "";
            }
            if (string.IsNullOrEmpty(txtContraseñaUsuario.Text.ToString()))
            {
                lblErrorContraseñaUsuario.Text = "*Error - Ingrese una Contraseña";
                Valido = false;
            }
            else
            {
                lblErrorContraseñaUsuario.Text = "";
            }

            return Valido;
        }

        protected void btnAceptarUsuario_Click(object sender, EventArgs e)
        {

            if (ValidarCamposUsuario() == true)
            {
                int DniAux = Int32.Parse(txtDniUsuario.Text.ToString());
                string ContraAux = txtContraseñaUsuario.Text.ToString();
                string CorreoAux = txtCorreoUsuario.Text.ToString();


                if (controladorUsuario.ActualizarUsuario(DniAux, ContraAux, CorreoAux) == true)
                {
                    lblErrorUsuarioExistente.Text = "ÉXITO! SU USUARIO AH SIDO ACTUALIZADO!";
                    lblErrorUsuarioExistente.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblErrorUsuarioExistente.Text = "ERROR! SU USUARIO NO HA SIDO ACTUALIZADO!";
                    lblErrorUsuarioExistente.ForeColor = System.Drawing.Color.Red;
                }
            }


        }

        protected void btnCancelarUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("opciones.aspx");
        }
    }
}