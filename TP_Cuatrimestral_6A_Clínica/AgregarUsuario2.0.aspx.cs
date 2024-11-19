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
    public partial class AgregarUsuario2__0 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    ControladorRoles CR = new ControladorRoles();
                    List<Rol> ListaRoles = new List<Rol>();
                    ListaRoles = CR.Listar();

                    dllRolUsuario.DataSource = ListaRoles;
                    dllRolUsuario.DataBind();

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnAgregarUsuario_Click(object sender, EventArgs e)
        {

            ControladorUsuarios CUsuario = new ControladorUsuarios();
            ControladorMedico CMedico = new ControladorMedico();
            Usuario usuario = new Usuario();


            if (ValidarCamposUsuario() == true)
            {  

                if (!CUsuario.UsuarioExistente(Int32.Parse(txtDniUsuario.Text)))
                {
                    usuario.Dni = Int32.Parse(txtDniUsuario.Text);
                    usuario.Correo = txtCorreoUsuario.Text;
                    usuario.Contraseña = txtContraseñaUsuario.Text;
                    usuario.IdRol = Int32.Parse(dllRolUsuario.SelectedValue);

                   //-- Aca Verifica si es médico

                    if (usuario.IdRol == 0)
                    {
                        if (CMedico.MedicoExiste(int.Parse(txtDniUsuario.Text)) == true)
                        {
                            CUsuario.InsertarUsuario(usuario);
                            LimpiarControles();


                            lblErrorUsuarioExistente.Text = "ÉXITO ! - USUARIO REGISTRADO (Espere a que un administrador verifique su cuenta)";
                            lblErrorUsuarioExistente.ForeColor = System.Drawing.Color.Green;

                            return;
                        }
                        else
                        {
                            lblErrorUsuarioExistente.Text = "ERROR ! - PRIMERO REGISTRE SU PERFIL DE MEDICO CON EL O LA RECEPCIONISTA";
                            lblErrorUsuarioExistente.ForeColor = System.Drawing.Color.Red;

                            return;
                        }
                    }

                    CUsuario.InsertarUsuario(usuario);
                    LimpiarControles();


                    lblErrorUsuarioExistente.Text = "ÉXITO ! - USUARIO REGISTRADO (Espere a que un administrador verifique su cuenta)";
                    lblErrorUsuarioExistente.ForeColor = System.Drawing.Color.Green;

                }
                else
                {
                    lblErrorUsuarioExistente.Text = "ERROR ! - USARIO EXISTENTE";
                    lblErrorUsuarioExistente.ForeColor = System.Drawing.Color.Red;

                }

            }


        }

        protected void btnCancelarUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }


        private void LimpiarControles()
        {
            txtDniUsuario.Text = string.Empty;
            txtCorreoUsuario.Text = string.Empty;
            txtContraseñaUsuario.Text = string.Empty;
            dllRolUsuario.SelectedIndex = 0;

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
                lblErrorCorreoUsuario.Text = "*Error - Ingrese un Nombre";
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
    }
}
