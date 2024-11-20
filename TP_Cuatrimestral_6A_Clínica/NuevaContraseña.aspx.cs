using Controlador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Cuatrimestral_6A_Clínica
{
    public partial class NuevaContraseña : System.Web.UI.Page
    {
        ControladorUsuarios controladorUsuarios = new ControladorUsuarios();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAceptarRestablecer_Click(object sender, EventArgs e)
        {
            if (ValidarCamposContraseña())
            {
                if (txtContraNueva.Text.Equals(txtContraNueva2.Text))
                {
                    try
                    {
                        int Dniaux = Int32.Parse(Session["DniNuevaContraseña"].ToString());

                        controladorUsuarios.CambiarContraseña(Dniaux, txtContraNueva.Text);

                        txtContraNueva.Text = "";
                        txtContraNueva2.Text = "";

                        lblMensajeRestablecer.Text = "CONTRASEÑA RESTABLECIDA CON EXITO";
                        lblMensajeRestablecer.ForeColor = System.Drawing.Color.Green;

                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                }
                else
                {
                    lblMensajeRestablecer.Text = "ERROR - LAS CONTRASEÑAS NO SON IGUALES";
                    lblMensajeRestablecer.ForeColor = System.Drawing.Color.Red;
                }
            }

        }

        protected void btnCancelarRestablecer_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        private bool ValidarCamposContraseña()
        {
            bool Valido = true;


            if (string.IsNullOrEmpty(txtContraNueva.Text.ToString()))
            {
                lblErrorContraNueva.Text = "*Error - Ingrese una contraseña";
                Valido = false;
            }
            else
            {
                lblErrorContraNueva.Text = "";
            }
            if (string.IsNullOrEmpty(txtContraNueva2.Text.ToString()))
            {
                lblErrorContraNueva2.Text = "*Error - Ingrese una contraseña";
                Valido = false;
            }
            else
            {
                lblErrorContraNueva2.Text = "";
            }

            return Valido;
        }
    }
}