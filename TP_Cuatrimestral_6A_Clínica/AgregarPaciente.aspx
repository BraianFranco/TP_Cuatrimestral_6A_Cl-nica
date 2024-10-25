<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AgregarPaciente.aspx.cs" Inherits="TP_Cuatrimestral_6A_Clínica.AgregarPaciente" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Content/Estilo_AgregarPaciente.css" rel="stylesheet" />

    <form class="row g-3">
        <div id="ContenedorRegistroMedico">
            <h1>Cargar Paciente</h1>
            <br />

            <div class="col-md-11">
                <asp:TextBox ID="txtDniPaciente" CssClass="form-control bg-dark text-white" runat="server" placeholder="DNI..."></asp:TextBox>
            </div>
            <div class="col-md-11">
                <asp:TextBox ID="txtNombrePaciente" CssClass="form-control bg-dark text-white" runat="server" placeholder="Nombre..."></asp:TextBox>
            </div>
            <div class="col-md-11">
                <asp:TextBox ID="txtApellidoPaciente" CssClass="form-control bg-dark text-white" placeholder="Apellido..." runat="server"></asp:TextBox>
            </div>
            <div class="col-md-11">
                <asp:TextBox type="password" ID="txtContraseñaMedico" CssClass="form-control bg-dark text-white" placeholder="Contraseña..." runat="server"></asp:TextBox>
            </div>
            <div class="col-md-11">
                <asp:TextBox type="email" ID="txtCorreoPaciente" placeholder="Correo electronico..." CssClass="form-control bg-dark text-white" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-11">
                <asp:TextBox ID="txtTelPaciente" CssClass="form-control bg-dark text-white" runat="server" placeholder="Teléfono..."></asp:TextBox>
            </div>
            <div class="col-md-11">
                <asp:Label ID="lblFechaNacPaciente" runat="server" Text="Fecha de Nacimiento" CssClass="text-black"></asp:Label>
                <asp:TextBox type="Date" ID="FechaNacimientoPaciente" CssClass="form-control bg-dark text-white" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-11">
                <asp:Label ID="lblPaisPaciente" runat="server" Text="País" CssClass="text-black"></asp:Label>
                <asp:DropDownList ID="ddlPais" CssClass="btn btn-secondary dropdown-toggle bg-dark text-white" runat="server"></asp:DropDownList>
            </div>
            <div class="col-md-12">
                <asp:Button ID="btnAgregarPaciente" CssClass="btn btn-danger" runat="server" Text="AGREGAR" />
                <asp:Button ID="btnCancelar" CssClass="btn btn-danger" runat="server" Text="CANCELAR" />
            </div>
        </div>

    </form>

</asp:Content>

