<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Administrar.aspx.cs" Inherits="TP_Cuatrimestral_6A_Clínica.Administrar" %>


<asp:Content ID="Content4" ContentPlaceHolderID="ContentRight" runat="server">

     <div class="container mt-4">
        <h1>Administrar</h1>
        <br />

        <asp:Button ID="Pacientes" CssClass="btn btn-primary w-100 my-2" OnClick="Pacientes_Click" runat="server" Text="Pacientes" />
        <asp:Button ID="Medicos" CssClass="btn btn-info w-100 my-2" OnClick="Medicos_Click" runat="server" Text="Médicos" />
        <asp:Button ID="Especilidades" CssClass="btn btn-success w-100 my-2" OnClick="Especilidades_Click" runat="server" Text="Especialidades" />

    </div>

</asp:Content>
