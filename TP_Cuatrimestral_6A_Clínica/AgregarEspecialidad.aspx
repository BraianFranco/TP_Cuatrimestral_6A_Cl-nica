<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AgregarEspecialidad.aspx.cs" Inherits="TP_Cuatrimestral_6A_Clínica.AgregarEspecialidad" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentRight" runat="server">

    <link href="Content/Estilo_AgregarEspecialidad.css" rel="stylesheet" />

    <div id="ContenedorRegistroMedico">
        <h1>Cargar Especialidad</h1>
        <br />
        <div class="col-md-11">
            <asp:Label Style="color: red" ID="lblErrorNombreEspecialidad" runat="server" Text=""></asp:Label>
            <asp:TextBox ID="txtNombreEspecialidad" CssClass="form-control " runat="server" placeholder="Nombre de la especialidad..."></asp:TextBox>
        </div>
        <div class="col-md-11">
            <asp:Label Style="color: red" ID="lblErrorDesEspecialidad" runat="server" Text=""></asp:Label>
            <asp:TextBox ID="txtDescripcionEspecialidad" CssClass="form-control " runat="server" placeholder="Descripcion de la especialidad..."></asp:TextBox>
        </div>
        <div class="col-md-12">
            <asp:Button ID="btnAgregarEspecialidad" CssClass="btn btn-danger" OnClick="btnAgregarEspecialidad_Click" runat="server" Text="AGREGAR" />
            <asp:Button ID="btnCancelarEspecialidad" CssClass="btn btn-danger" OnClick="btnCancelarEspecialidad_Click"  runat="server" Text="CANCELAR" />
            <asp:Label  ID="lblErrorEspecialidadExistente" runat="server" Text=""></asp:Label>
        </div>
    </div>

</asp:Content>

