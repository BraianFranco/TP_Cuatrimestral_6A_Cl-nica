using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Cuatrimestral_6A_Clínica
{
    public partial class TurnosFinalizados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid(); 
            }
        }

        private void BindGrid()
        {
            
            DataTable dt = new DataTable();
            dt.Columns.Add("TurnoID", typeof(int));
            dt.Columns.Add("Paciente", typeof(string));
            dt.Columns.Add("Fecha", typeof(DateTime));
            dt.Columns.Add("Hora", typeof(string));

          
            dt.Rows.Add(1, "Juan Pérez", DateTime.Now.AddDays(1), "10:00 AM");
            dt.Rows.Add(2, "María Gómez", DateTime.Now.AddDays(2), "11:00 AM");
            dt.Rows.Add(3, "Luis Fernández", DateTime.Now.AddDays(3), "02:00 PM");
            dt.Rows.Add(4, "Ana Martínez", DateTime.Now.AddDays(4), "03:00 PM");

            // Enlazar el DataTable al GridView
            gvTurnos.DataSource = dt;
            gvTurnos.DataBind();
        }









    }
}