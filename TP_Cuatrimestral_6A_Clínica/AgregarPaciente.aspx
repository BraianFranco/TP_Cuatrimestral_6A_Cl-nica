<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AgregarPaciente.aspx.cs" Inherits="TP_Cuatrimestral_6A_Clínica.AgregarPaciente" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentRight" runat="server">
    <link href="Content/Estilo_AgregarPaciente.css" rel="stylesheet" />

    <div id="ContenedorRegistroPaciente">
        <h1>Cargar Paciente</h1>
        <br />

        <div class="col-md-11">
            <asp:Label Style="color: red" ID="lblErrorDniPaciente" runat="server" Text=""></asp:Label>
            <asp:TextBox type="number" min="10000000" max="99999999" oninvalid="this.setCustomValidity('Ingrese Un numero valido de 8 digitos')" oninput="setCustomValidity('')" ID="txtDniPaciente" CssClass="form-control" runat="server" placeholder="DNI..."></asp:TextBox>
        </div>
        <div class="col-md-11">
            <asp:Label Style="color: red" ID="lblErrorNombrePaciente" runat="server" Text=""></asp:Label>
            <asp:TextBox ID="txtNombrePaciente" CssClass="form-control " runat="server" placeholder="Nombre..."></asp:TextBox>
        </div>
        <div class="col-md-11">
            <asp:Label Style="color: red" ID="lblErrorApellidoPaciente" runat="server" Text=""></asp:Label>
            <asp:TextBox ID="txtApellidoPaciente" CssClass="form-control " placeholder="Apellido..." runat="server"></asp:TextBox>
        </div>
        <div class="col-md-11">
            <asp:Label Style="color: red" ID="lblErrorCorreoPaciente" runat="server" Text=""></asp:Label>
            <asp:TextBox type="email" ID="txtCorreoPaciente" placeholder="Correo electronico..." CssClass="form-control " runat="server"></asp:TextBox>
        </div>
        <div class="col-md-11">
            <asp:Label Style="color: red" ID="lblErrorTelPaciente" runat="server" Text=""></asp:Label>
            <asp:TextBox ID="txtTelPaciente" CssClass="form-control " runat="server" placeholder="Teléfono..."></asp:TextBox>
        </div>
        <div class="col-md-11">
            <asp:Label Style="color: red" ID="lblErrorNacimientoPaciente" runat="server" Text=""></asp:Label>
            <asp:TextBox type="Date" ID="txtFechaNacimientoPaciente" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-11">
            <asp:Label Style="color: red" ID="lblErrorDireccionPaciente" runat="server" Text=""></asp:Label>
            <asp:TextBox ID="txtDireccionPaciente" CssClass="form-control " runat="server" placeholder="Direccion..."></asp:TextBox>
        </div>
        <div class="col-md-11">
            <asp:Label ID="lblPaisPaciente" runat="server" Text="País" CssClass="text-black"></asp:Label>
            <asp:DropDownList ID="ddlPais" DataTextField="Nombre" DataValueField="ID" CssClass="btn btn-secondary dropdown-toggle " runat="server"></asp:DropDownList>
        </div>
        <div class="col-md-12">
            <asp:Button ID="btnAgregarPaciente" CssClass="btn btn-danger" OnClick="BtnAgregarPaciente_Click" runat="server" Text="AGREGAR" />
            <asp:Button ID="btnCancelar" CssClass="btn btn-danger" OnClick="btnCancelar_Click" runat="server" Text="CANCELAR" />
            <asp:Label ID="lblErrorPacienteExistente" runat="server" Text=""></asp:Label>
        </div>
    </div>

</asp:Content>

