<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AgregarMedico.aspx.cs" Inherits="TP_Cuatrimestral_6A_Clínica.AgregarMedico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Content/Estilo_AgregarMedico.css" rel="stylesheet" />

    <form class="row g-3">
        <div id="ContenedorRegistroMedico">
            <div class="col-md-3">
                <asp:TextBox ID="txtDniMedico" CssClass="form-control bg-dark text-white" runat="server" placeholder="DNI..."></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:TextBox ID="txtNombreMedico" CssClass="form-control bg-dark text-white" runat="server" placeholder="Nombre..."></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:TextBox ID="txtApellido" CssClass="form-control bg-dark text-white"  placeholder="Apellido..." runat="server"></asp:TextBox>
            </div>
            <div class="col-md-4">
                <asp:TextBox type="password" ID="txtContraseñaMedico" CssClass="form-control bg-dark text-white"  placeholder="Contraseña..." runat="server"></asp:TextBox>
            </div>
            <div class="col-md-4">
                <asp:TextBox type="txtCorreoMedico" ID="txtCorreoMedico" placeholder="Correo electronico..." CssClass="form-control bg-dark text-white" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:TextBox ID="txtTelMedico" CssClass="form-control bg-dark text-white" runat="server" placeholder="Telefono..."></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:Label ID="lblPaisMedico" runat="server" Text="País" CssClass="text-black"></asp:Label>
                <asp:DropDownList ID="ddlPais" CssClass="btn btn-secondary dropdown-toggle bg-dark text-white" runat="server"></asp:DropDownList>
            </div>
            <div class="col-md-1">
                <asp:Label for="txtEntradaMedico" ID="lblEntradaMedico" runat="server" Text="Hora-Entrada"></asp:Label>
                <asp:TextBox type="number" ID="txtEntradaMedico" min="1" max="24" CssClass="form-control bg-dark text-white" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-1">
                <asp:Label ID="lblSalidaMedico" runat="server" Text="Hora-Salida"></asp:Label>
                <asp:TextBox type="number" ID="txtSalidaMedico" min="1" max="24" CssClass="form-control bg-dark text-white" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-5">
                <asp:Button ID="btnAgregarMedico" CssClass="btn btn-dark" runat="server" Text="AGREGAR" />
                <asp:Button ID="btnCancelarMedico" CssClass="btn btn-dark" runat="server" Text="CANCELAR" />
            </div>
        </div>

    </form>

</asp:Content>


