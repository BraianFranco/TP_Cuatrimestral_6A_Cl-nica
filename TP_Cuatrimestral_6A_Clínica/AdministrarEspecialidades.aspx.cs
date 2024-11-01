using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Cuatrimestral_6A_Clínica
{
    public partial class AdministrarEspecialidades : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarEspecialidades();
            }
        }

        private void CargarEspecialidades()
        {
       
            DataTable dtEspecialidades = new DataTable();
            dtEspecialidades.Columns.Add("Id", typeof(int));
            dtEspecialidades.Columns.Add("Especialidad", typeof(string));
            dtEspecialidades.Columns.Add("Descripcion", typeof(string));

       
            dtEspecialidades.Rows.Add(1, "Cardiología", "Diagnóstico y tratamiento de enfermedades del corazón");
            dtEspecialidades.Rows.Add(2, "Neurología", "Trastornos del sistema nervioso");
            dtEspecialidades.Rows.Add(3, "Dermatología", "Problemas de la piel, cabello y uñas");
            dtEspecialidades.Rows.Add(4, "Pediatría", "Atención médica a niños y adolescentes");
            dtEspecialidades.Rows.Add(5, "Oftalmología", "Enfermedades de los ojos");

            GridView1.DataSource = dtEspecialidades;
            GridView1.DataBind();
        }





    }
}