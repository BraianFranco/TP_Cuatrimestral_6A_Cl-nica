<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Administrar.aspx.cs" Inherits="TP_Cuatrimestral_6A_Clínica.Administrar" %>


<asp:Content ID="Content4" ContentPlaceHolderID="ContentRight" runat="server">

    <div class="container mt-4">
        <h1>Administrar</h1>
        <br />

        <%if (ObtenerRolUsuarioSession() == 2)
            { %>

        <asp:Button ID="PacientesAdmin" CssClass="btn btn-primary w-100 my-2" OnClick="Pacientes_Click" runat="server" Text="Pacientes" />
        <asp:Button ID="MedicosAdmin" CssClass="btn btn-info w-100 my-2" OnClick="Medicos_Click" runat="server" Text="Médicos" />
        <asp:Button ID="EspecilidadesAdmin" CssClass="btn btn-success w-100 my-2" OnClick="Especilidades_Click" runat="server" Text="Especialidades" />
        <asp:Button runat="server" PostBackUrl="~/ValidarUsuarios.aspx" CssClass="btn btn-warning w-100 my-2" Text="Validar Usuarios"></asp:Button>

        <% } %>
        <%if (ObtenerRolUsuarioSession() == 1)
            { %>

        <asp:Button ID="PacientesRecepcista" CssClass="btn btn-primary w-100 my-2" OnClick="Pacientes_Click" runat="server" Text="Pacientes" />
        <asp:Button ID="MedicosRecepcista" CssClass="btn btn-info w-100 my-2" OnClick="Medicos_Click" runat="server" Text="Médicos" />
        <asp:Button ID="EspecilidadesRecepcista" CssClass="btn btn-success w-100 my-2" OnClick="Especilidades_Click" runat="server" Text="Especialidades" />

        <% } %>

        <%if (ObtenerRolUsuarioSession() == 0)
            { %>

        <asp:Button ID="PacientesMedico" CssClass="btn btn-primary w-100 my-2" OnClick="Pacientes_Click" runat="server" Text="Pacientes" />

        <% } %>
    </div>

</asp:Content>
