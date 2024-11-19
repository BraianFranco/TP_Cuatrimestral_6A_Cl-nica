using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Modelo;
using Controlador;
using System.Diagnostics;

namespace TP_Cuatrimestral_6A_Clínica
{
    public partial class WebForm2 : System.Web.UI.Page
    {


        private Dictionary<int, Tuple<TimeSpan, TimeSpan>> HorariosPorRango = new Dictionary<int, Tuple<TimeSpan, TimeSpan>>()
{
    { 1, new Tuple<TimeSpan, TimeSpan>(new TimeSpan(8, 0, 0), new TimeSpan(12, 0, 0)) },  // Mañana
    { 2, new Tuple<TimeSpan, TimeSpan>(new TimeSpan(12, 0, 0), new TimeSpan(16, 0, 0)) }, // Tarde
    { 3, new Tuple<TimeSpan, TimeSpan>(new TimeSpan(16, 0, 0), new TimeSpan(20, 0, 0)) }  // Noche
};


        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["Usuario"] == null)
            {
                Response.Redirect("Login.aspx");

            }


            if (!IsPostBack)
            {

                PanelTurno.Visible = false;
                lblError.Visible = false;
            }


        }



        protected void txtDNI_TextChanged(object sender, EventArgs e)
        {

            try
            {
                int dni = Int32.Parse(txtDNI.Text.Trim());


                ControladorPaciente cp = new ControladorPaciente();
                ControladorEspecialidad ce = new ControladorEspecialidad();


                bool existe = cp.PacienteExiste(dni);

                if (existe)
                {


                    // Paciente encontrado, mostramos los controles
                    lblDNI.Visible = false;
                    txtDNI.Visible = false;
                    lblError.Visible = false;
                    PanelTurno.Visible = true;


                    List<Especialidad> lstEspecialidades = ce.Listar();

                    foreach (Especialidad item in lstEspecialidades)
                    {

                        ddlEspecialidad.Items.Add(new ListItem(item.Nombre, item.Id.ToString()));

                    }


                }

                else
                {
                    // Paciente no encontrado
                    PanelTurno.Visible = false;
                    lblError.Text = "No se encontró un paciente con el DNI ingresado.";
                    lblError.Visible = true;
                }
            }
            catch { }


        }



        protected void ddlEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {


        }





        protected void ddlHorario_SelectedIndexChanged(object sender, EventArgs e)
        {
            ControladorMedico cm = new ControladorMedico();

            // Obtiene el horario seleccionado y el rango de horas
            int horarioSeleccionado = int.Parse(ddlHorario.SelectedValue);
            Tuple<TimeSpan, TimeSpan> rangoHorario = HorariosPorRango[horarioSeleccionado];

            // Limpia y carga las horas en el dropdown
            ddlHoras.Items.Clear();




            DateTime horaInicio = DateTime.Today.Add(rangoHorario.Item1);
            DateTime horaFin = DateTime.Today.Add(rangoHorario.Item2);

            while (horaInicio < horaFin)
            {
                ddlHoras.Items.Add(new ListItem(horaInicio.ToString("hh:mm tt"), horaInicio.ToString("HH:mm")));
                horaInicio = horaInicio.AddHours(1);
            }


        }



        protected void btnMedicosDisponibles_Click(object sender, EventArgs e)
        {
            ControladorMedico cm = new ControladorMedico();

            // Validar fecha

            DateTime fechaSeleccionada;
            if (!DateTime.TryParse(txtFecha.Text, out fechaSeleccionada))
            {
                lblError.Text = "Seleccione una fecha válida.";
                return;
            }


            // Validar hora

            TimeSpan horaSeleccionada;

            if (ddlHoras.SelectedValue == "" || !TimeSpan.TryParse(ddlHoras.SelectedValue, out horaSeleccionada))
            {
                lblError.Text = "Seleccione una hora válida.";
                return;
            }

            // Validar especialidad
            int idEspecialidad;

            if (!int.TryParse(ddlEspecialidad.SelectedValue, out idEspecialidad) || idEspecialidad == 0)
            {
                lblError.Text = "Seleccione una especialidad válida.";
                return;
            }



            // Combinar
            // fecha y hora
            DateTime fechaTurnoCompleta = fechaSeleccionada.Add(horaSeleccionada);


            List<Medico> medicosDisponibles = cm.ObtenerMedicosDisponiblesSP(idEspecialidad, fechaTurnoCompleta);


            if (medicosDisponibles.Count == 0)
            {
                lblError.Text = "No hay médicos disponibles para la fecha y hora seleccionadas.";
                gvMedicos.DataSource = null;
                gvMedicos.DataBind();
                return;
            }




            Session["IdEspecialidad"] = ddlEspecialidad.Text;
            Session["FechaTurno"] = fechaTurnoCompleta;
            Session["DniPaciente"] = txtDNI.Text;



            // Mostrar los médicos disponibles en el GridView
            gvMedicos.DataSource = medicosDisponibles;
            gvMedicos.DataBind();

            lblError.Text = string.Empty;


        }




        protected void gvMedicos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {


                int dniMedicoSeleccionado = Int32.Parse(e.CommandArgument.ToString());

                Turno nuevoTurno = new Turno(
                      dnimedico: dniMedicoSeleccionado,
                      dnipaciente: Int32.Parse(Session["DniPaciente"].ToString()),
                      idEspecialidad: Int32.Parse(Session["IdEspecialidad"].ToString()),
                      fechaturno: DateTime.Parse(Session["FechaTurno"].ToString()),
                      observaciones: "",
                      activo: true
                  );

                Session["Turno"] = nuevoTurno;

                Response.Redirect("ConfirmarTurno.aspx");


            }
        }



    }
}