<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CargarObservacion.aspx.cs" Inherits="TP_Cuatrimestral_6A_Clínica.CargarObservacion" %>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="Content/Estilo_Observaciones.css" rel="stylesheet" />

    <div id="ContenedorRegistroObservacion" class="container mt-4">
        <h1 class="text-center">Cargar Observación</h1>
        <br />

        <div class="form-group">
            <label for="txtIdTurnoObservacion">ID del Turno</label>
            <asp:TextBox ID="txtIdTurnoObservacion" CssClass="form-control bg-dark text-white" runat="server" placeholder="Ingrese el ID del Turno..."></asp:TextBox>
        </div>

      
        <div class="row">
            <div class="col-md-6">
                <asp:Label ID="lblDniPacienteObservacion" runat="server" Text="DNI del Paciente" CssClass="d-block"></asp:Label>
                <asp:Label ID="lblNombrePacienteObservacion" runat="server" Text="Nombre del Paciente" CssClass="d-block"></asp:Label>
                <asp:Label ID="lblApellidoPacienteObservacion" runat="server" Text="Apellido del Paciente" CssClass="d-block"></asp:Label>
            </div>
            <div class="col-md-6">
                <asp:Label ID="lblEspecialidadObservacion" runat="server" Text="Especialidad por la cual se trató" CssClass="d-block"></asp:Label>
                <asp:Label ID="lblDniMedicoObservacion" runat="server" Text="DNI del Médico" CssClass="d-block"></asp:Label>
                <asp:Label ID="lblCorreoPacienteObservacion" runat="server" Text="Correo del Paciente" CssClass="d-block"></asp:Label>
            </div>
        </div>

       
        <div class="row">
            <div class="col-md-6">
                <asp:Label ID="lblDiaAltaObservacion" runat="server" Text="Día del Alta" CssClass="d-block"></asp:Label>
                <asp:Label ID="lblDireccionObservacion" runat="server" Text="Dirección del Paciente" CssClass="d-block"></asp:Label>
                <asp:Label ID="telPacienteObservacion" runat="server" Text="Teléfono del Paciente" CssClass="d-block"></asp:Label>
            </div>
            <div class="col-md-6">
                <asp:Label ID="lblPais" runat="server" Text="País del Paciente" CssClass="d-block"></asp:Label>
            </div>
        </div>

      
        <div class="form-group">
            <label for="txtObservacion">Observación</label>
            <textarea id="txtObservacion" class="form-control" placeholder="Ingrese la Observación..."></textarea>
        </div>
        
      
        <div class="form-group text-center">
            <asp:Button ID="btnAgregarObservacion" CssClass="btn btn-danger mx-2" OnClick="btnAgregarObservacion_Click" runat="server" Text="AGREGAR" />
            <asp:Button ID="btnCancelarObservacion" CssClass="btn btn-danger mx-2" runat="server" Text="CANCELAR" OnClick="btnCancelarObservacion_Click" />
        </div>
    </div>

</asp:Content>
