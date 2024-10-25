<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Administrar.aspx.cs" Inherits="TP_Cuatrimestral_6A_Clínica.Administrar" %>


<asp:Content ID="Content4" ContentPlaceHolderID="ContentRight" runat="server">

     <div class="container mt-4">
        <h1>Administrar</h1>
        <br />

        <asp:Button ID="btnAgregarEspecialidad" CssClass="btn btn-success w-100 my-2" OnClick="btnAgregarEspecialidad_Click" runat="server" Text="Agregar Especialidad" />
        <asp:Button ID="btnAgregarMedico" CssClass="btn btn-info w-100 my-2" OnClick="btnAgregarMedico_Click" runat="server" Text="Agregar Médico" />
        <asp:Button ID="btnAgregarPaciente" CssClass="btn btn-primary w-100 my-2" OnClick="btnAgregarPaciente_Click" runat="server" Text="Agregar Paciente" />
    </div>

</asp:Content>
