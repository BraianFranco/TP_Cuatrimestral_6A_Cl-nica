<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AgregarEspecialidad.aspx.cs" Inherits="TP_Cuatrimestral_6A_Clínica.AgregarEspecialidad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="Content/Estilo_AgregarEspecialidad.css" rel="stylesheet" />

    <form class="row g-3">
        <div id="ContenedorRegistroMedico">
            <h1>Cargar Especialidad</h1>
            <br />
            <div class="col-md-11">
                <asp:TextBox ID="txtNombreEspecialidad" CssClass="form-control bg-dark text-white" runat="server" placeholder="Nombre de la especialidad..."></asp:TextBox>
            </div>
            <div class="col-md-11">
                <asp:TextBox ID="txtDniEspecialidad" CssClass="form-control bg-dark text-white" runat="server" placeholder="Dni del Médico..."></asp:TextBox>
            </div>
            <div class="col-md-11">
                <asp:TextBox type="number" ID="txtEntradaMedico" min="1" max="24" CssClass="form-control bg-dark text-white" runat="server" placeholder="Hora Entrada..."></asp:TextBox>
            </div>
            <div class="col-md-11">
                <asp:TextBox type="number" ID="txtSalidaMedico" min="1" max="24" CssClass="form-control bg-dark text-white" runat="server" placeholder="Hora Salida..."></asp:TextBox>
            </div>
            <div class="col-md-11">
                <select class="form-select bg-dark text-white" aria-label="Default select example">
                    <option selected>Seleccione el Día</option>
                    <option value="1">Lunes</option>
                    <option value="2">Martes</option>
                    <option value="3">Miercoles</option>
                    <option value="1">Jueves</option>
                    <option value="2">Viernes</option>
                </select>
            </div>
            <div class="col-md-12">
                <asp:Button ID="btnAgregarEspecialidad" CssClass="btn btn-danger" runat="server" Text="AGREGAR" />
                <asp:Button ID="btnCancelarEspecialidad" CssClass="btn btn-danger" runat="server" Text="CANCELAR" />
            </div>
        </div>
    </form>

</asp:Content>

