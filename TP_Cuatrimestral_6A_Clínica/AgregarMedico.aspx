<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AgregarMedico.aspx.cs" Inherits="TP_Cuatrimestral_6A_Clínica.AgregarMedico" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentRight" runat="server">
    <link href="Content/Estilo_AgregarMedico.css" rel="stylesheet" />

    <form class="row g-3">       
        <div id="ContenedorRegistroMedico">
            <h1>Cargar Médico</h1>
            <br />

            <div class="col-md-11">
                <asp:TextBox ID="txtDniMedico" CssClass="form-control " runat="server" placeholder="DNI..."></asp:TextBox>
            </div>
            <div class="col-md-11">
                <asp:TextBox ID="txtNombreMedico" CssClass="form-control " runat="server" placeholder="Nombre..."></asp:TextBox>
            </div>
            <div class="col-md-11">
                <asp:TextBox ID="txtApellido" CssClass="form-control "  placeholder="Apellido..." runat="server"></asp:TextBox>
            </div>
            <div class="col-md-11">
                <asp:TextBox type="password" ID="txtContraseñaMedico" CssClass="form-control "  placeholder="Contraseña..." runat="server"></asp:TextBox>
            </div>
            <div class="col-md-11">
                <asp:TextBox type="email" ID="txtCorreoMedico" placeholder="Correo electronico..." CssClass="form-control " runat="server"></asp:TextBox>
            </div>
            <div class="col-md-11">
                <asp:TextBox ID="txtTelMedico" CssClass="form-control " runat="server" placeholder="Teléfono..."></asp:TextBox>
            </div>
            <div class="col-md-11">
                <asp:Label ID="lblPaisMedico" runat="server" Text="País" CssClass="text-black"></asp:Label>
                <asp:DropDownList ID="ddlPais" CssClass="btn btn-secondary dropdown-toggle form-select" runat="server"></asp:DropDownList>
            </div>
            <div class="col-md-11">
                <asp:Button ID="btnAgregarMedico" CssClass="btn btn-danger" runat="server" Text="AGREGAR" />
                <asp:Button ID="btnCancelarMedico" CssClass="btn btn-danger" runat="server" Text="CANCELAR" />
            </div>
        </div>

    </form>

</asp:Content>


