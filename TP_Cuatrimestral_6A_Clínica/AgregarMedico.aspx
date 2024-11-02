<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AgregarMedico.aspx.cs" Inherits="TP_Cuatrimestral_6A_Clínica.AgregarMedico" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentRight" runat="server">
    <link href="Content/Estilo_AgregarMedico.css" rel="stylesheet" />


    <div id="ContenedorRegistroMedico">
        <h1>Cargar Médico</h1>
        <br />

        <div class="col-md-11">
            <asp:Label Style="color: red" ID="lblErrorDniMedico" runat="server" Text=""></asp:Label>
            <asp:TextBox ID="txtDniMedico" type="number" min="10000000" max="99999999" oninvalid="this.setCustomValidity('Ingrese Un numero valido de 8 digitos')" oninput="setCustomValidity('')" CssClass="form-control" runat="server" placeholder="DNI..."></asp:TextBox>
        </div>
        <div class="col-md-11">
            <asp:Label Style="color: red" ID="lblErrorNombreMedico" runat="server" Text=""></asp:Label>
            <asp:TextBox ID="txtNombreMedico" CssClass="form-control " runat="server" placeholder="Nombre..."></asp:TextBox>
        </div>
        <div class="col-md-11">
            <asp:Label Style="color: red" ID="lblErrorApellidoMedico" runat="server" Text=""></asp:Label>
            <asp:TextBox ID="txtApellidoMedico" CssClass="form-control " placeholder="Apellido..." runat="server"></asp:TextBox>
        </div>
        <div class="col-md-11">
            <asp:TextBox type="password" ID="txtContraseñaMedico" CssClass="form-control " placeholder="Contraseña..." runat="server"></asp:TextBox>
        </div>
        <div class="col-md-11">
            <asp:Label Style="color: red" ID="lblErrorCorreoMedico" runat="server" Text=""></asp:Label>
            <asp:TextBox type="email" ID="txtCorreoMedico" placeholder="Correo electronico..." CssClass="form-control  " runat="server"></asp:TextBox>
        </div>
        <div class="col-md-11">
            <asp:Label Style="color: red" ID="lblErrorMedicoTel" runat="server" Text=""></asp:Label>
            <asp:TextBox ID="txtTelMedico" CssClass="form-control " runat="server" placeholder="Teléfono..."></asp:TextBox>
        </div>
        <div class="col-md-11">
            <asp:Label ID="lblPaisMedico" runat="server" Text="País" CssClass="text-black"></asp:Label>
            <asp:DropDownList ID="ddlPais" DataTextField="Nombre" DataValueField="ID" CssClass="btn btn-secondary dropdown-toggle " runat="server"></asp:DropDownList>
        </div>
        <div class="col-md-11">
            <asp:Button ID="btnAgregarMedico" CssClass="btn btn-danger" OnClick="BtnAgregarMedico_Click" runat="server" Text="AGREGAR" />
            <asp:Button ID="btnCancelarMedico" CssClass="btn btn-danger" OnClick="btnCancelarMedico_Click" runat="server" Text="CANCELAR" />
            <asp:Label ID="lblErrorMedicoExistente" runat="server" Text=""></asp:Label>
        </div>
    </div>

</asp:Content>


