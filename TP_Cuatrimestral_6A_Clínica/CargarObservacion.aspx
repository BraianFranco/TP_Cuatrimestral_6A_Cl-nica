<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CargarObservacion.aspx.cs" Inherits="TP_Cuatrimestral_6A_Clínica.CargarObservacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftPanel" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="Content/Estilo_Observaciones.css" rel="stylesheet" />

    <div id="ContenedorRegistroObservacion">
        <h1>Cargar Observación</h1>
        <br />

        <div class="col-md-11">
            <asp:TextBox type="number" ID="txtIdTurnoObservacion" CssClass="form-control bg-dark text-white" runat="server" placeholder="Ingrese el ID del Turno..."></asp:TextBox>
        </div>
        <div class="col-md-11">
            <asp:Label ID="lblDniPacienteObservacion" runat="server" Text="DNI del Paciente"></asp:Label>
        </div>
        <div class="col-md-11">
            <asp:Label ID="lblNombrePacienteObservacion" runat="server" Text="Nombre del Paciente"></asp:Label>
        </div>
        <div class="col-md-11">
            <asp:Label ID="lblApellidoPacienteObservacion" runat="server" Text="Apellido del Paciente"></asp:Label>
        </div>
        <div class="col-md-11">
            <asp:Label ID="lblEspecialidadObservacion" runat="server" Text="Especialidad por la cual se trato"></asp:Label>
        </div>
        <div class="col-md-11">
            <asp:Label ID="lblDniMedicoObservacion" runat="server" Text="Dni del Médico"></asp:Label>
        </div>
        <div class="col-md-11">
            <asp:Label ID="lblCorreoPacienteObservacion" runat="server" Text="Correo del paciente"></asp:Label>
        </div>
        <div class="col-md-11">
            <asp:Label ID="lblDiaAltaObservacion" runat="server" Text="Dia del Alta"></asp:Label>
        </div>
        <div class="col-md-11">
            <asp:Label ID="lblDireccionObservacion" runat="server" Text="Dirección del Paciente"></asp:Label>
        </div>
        <div class="col-md-11">
            <asp:Label ID="telPacienteObservacion" runat="server" Text="Teléfono del Paciente"></asp:Label>
        </div>
        <div class="col-md-11">
            <asp:Label ID="lblPais" runat="server" Text="País del Paciente"></asp:Label>
        </div>
        <div class="col-md-11">
            <textarea id="txtObservacion" stpe="txtObservacion" placeholder="Ingrese la Observación..."> </textarea>
        </div>
        <div class="col-md-12">
            <asp:Button ID="btnAgregarObservacion" CssClass="btn btn-danger" OnClick="btnAgregarObservacion_Click" runat="server" Text="AGREGAR" />
            <asp:Button ID="btnCancelarObservacion" CssClass="btn btn-danger" runat="server" Text="CANCELAR" />
        </div>

    </div>
</asp:Content>
