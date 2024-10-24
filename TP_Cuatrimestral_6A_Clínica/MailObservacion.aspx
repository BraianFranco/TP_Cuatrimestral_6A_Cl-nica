<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MailObservacion.aspx.cs" Inherits="TP_Cuatrimestral_6A_Clínica.MailObservacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftPanel" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="Content/Estilo_MailObservacion.css" rel="stylesheet" />

    <div id="ContenedorRegistroObservacion">
        <h1>Observacion enviada</h1>
        <br />

        <div class="col-md-11">
            <asp:Label ID="lblNumeroAsignado" runat="server" Text="Numero Asignado #1"></asp:Label>
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
            <asp:Label ID="lblCorreoPacienteObservacion" runat="server" Text="Correo del paciente"></asp:Label>
        </div>
        <div class="col-md-12">
            <asp:Button ID="btnVolverObservacion" CssClass="btn btn-danger" OnClick="btnVolverObservacion_Click" runat="server" Text="Volver" />
        </div>
    </div>
</asp:Content>
