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
    public partial class RestablecerContraseña : System.Web.UI.Page
    {
        ControladorUsuarios controladorUsuarios = new ControladorUsuarios();
        public bool AbrirCodigo = false;
        public bool AbrirContraNueva = false;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAceptarRestablecer_Click(object sender, EventArgs e)
        {


            if (ValidarCamposUsuario() == true)
            {



                if (ValidarUsuarioExistente() == true)
                {
                    AbrirCodigo = true;
                    lblMensajeRestablecer.Text = "Se le envio un codigo de 6 digitos a su correo , ingreselo para poder restablecer";
                    lblMensajeRestablecer.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblMensajeRestablecer.Text = "ERROR - EL DNI O CORREO NO COINCIDEN CON NINGUN USARIO";
                    lblMensajeRestablecer.ForeColor = System.Drawing.Color.Red;
                }

            }

        }

        protected void btnCancelarRestablecer_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void btnIngresarCodigo_Click(object sender, EventArgs e)
        {

            if (ValidarCodigo() == true)
            {

                Session.Add("DniNuevaContraseña", txtDniUsuarioRestablecer.Text);
                Response.Redirect("NuevaContraseña.aspx");

            }
            else
            {
                AbrirCodigo = true;
            }

        }


        private bool ValidarCamposUsuario()
        {
            bool Valido = true;


            if (string.IsNullOrEmpty(txtDniUsuarioRestablecer.Text.ToString()))
            {
                lblErrorDniUsuarioRestablecer.Text = "*Error - Ingrese un Dni";
                Valido = false;
            }
            else
            {
                lblErrorDniUsuarioRestablecer.Text = "";
            }
            if (string.IsNullOrEmpty(txtCorreoUsuarioRestablecer.Text.ToString()))
            {
                lblErrorCorreoUsuarioRestablecer.Text = "*Error - Ingrese un Correo";
                Valido = false;
            }
            else
            {
                lblErrorCorreoUsuarioRestablecer.Text = "";
            }

            return Valido;
        }

        private bool ValidarUsuarioExistente()
        {
            bool Valido = false;

            Usuario usuarioRestablecer = controladorUsuarios.ObtenerUsuarioPorDni(Int32.Parse(txtDniUsuarioRestablecer.Text));

            int Dnisession = usuarioRestablecer.Dni;
            string CorreoSession = usuarioRestablecer.Correo;

            if (Dnisession == int.Parse(txtDniUsuarioRestablecer.Text) == true && CorreoSession.Trim() == txtCorreoUsuarioRestablecer.Text.Trim())
            {
                Valido = true;
            }


            return Valido;
        }

        private bool ValidarCodigo()
        {

            bool CodigoValido = false;

            if (txtCodigoRestablecer.Text.Equals("654321"))
            {

                CodigoValido = true;
            }
            else
            {
                lblErrorCodigo.Text = "ERROR - CODIGO INCORRECTO";
            }

            if (string.IsNullOrEmpty(txtCodigoRestablecer.Text.ToString()))
            {

                CodigoValido = false;
                lblErrorCodigo.Text = "ERROR - INGRESE EL CODIGO";
            }

            return CodigoValido;
        }

    }
}