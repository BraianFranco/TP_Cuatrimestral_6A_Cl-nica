using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controlador;
using Modelo;

namespace TP_Cuatrimestral_6A_Clínica
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RolUsuario.Text = ObtenerNombreRolUsuario();
        }
       

        public int ObtenerDniUsuarioSession()
        {
            int dniSession = ((Usuario)Session["Usuario"]).Dni;

            return dniSession;
        }

        public string ObtenerNombreRolUsuario()
        {
            ControladorRoles controladorroles = new ControladorRoles();

            int idRolSession = ((Usuario)Session["Usuario"]).IdRol;

            string nombrerol = controladorroles.ObtenerNombreRolPorId(idRolSession);

            return nombrerol;
        }

        public int ObtenerRolUsuarioSession()
        {
            int rol = ((Usuario)Session["Usuario"]).IdRol;

            return rol;
        }
    }
}