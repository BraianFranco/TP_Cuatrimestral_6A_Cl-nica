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
    public partial class Login : System.Web.UI.Page
    {   
        ControladorUsuarios controladorUsuarios = new ControladorUsuarios();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {

            /*
             
            recuperamos el cliente de la db y lo agregamos a la session y redirigimos a la pagina default

            */

            
           if(controladorUsuarios.Loguearse(Int32.Parse(txtDni.Text), txtContraseña.Text) == true)
            {
                Usuario UsuarioLogueado = controladorUsuarios.ObtenerUsuarioPorDni(Int32.Parse(txtDni.Text));
                Session.Add("Usuario", UsuarioLogueado);
                Response.Redirect("default.aspx");
                lblErrorLogin.Text = "";
            }
            else
            {   
                lblErrorLogin.Text = "ERROR - USUARIO O CONTRASEÑA INCORRECTOS";
                lblErrorLogin.ForeColor = System.Drawing.Color.Red;
            } 
            
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarUsuario2.0.aspx");
        }
    }
}