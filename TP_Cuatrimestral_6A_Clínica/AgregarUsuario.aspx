<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AgregarUsuario.aspx.cs" Inherits="TP_Cuatrimestral_6A_Clínica.AgregarUsuario" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentRight" runat="server">
    <link href="Content/Estilo_AgregarMedico.css" rel="stylesheet" />


    <div id="ContenedorRegistroMedico">
        <h1>Registrar Usuario</h1>
        <br />

        <div class="col-md-11">
            <asp:Label Style="color: red" ID="lblErrorDniUsuario" runat="server" Text=""></asp:Label>
            <asp:TextBox ID="txtDniUsuario" type="number" min="10000000" max="99999999" oninvalid="this.setCustomValidity('Ingrese Un numero valido de 8 digitos')" oninput="setCustomValidity('')" CssClass="form-control" runat="server" placeholder="DNI..."></asp:TextBox>
        </div>
        <div class="col-md-11">
            <asp:Label Style="color: red" ID="lblErrorContraseñaUsuario" runat="server" Text=""></asp:Label>
            <asp:TextBox type="password" ID="txtContraseñaUsuario" CssClass="form-control " runat="server" placeholder="Contraseña..."></asp:TextBox>
        </div>
        <div class="col-md-11">
            <asp:Label Style="color: red" ID="lblErrorCorreoUsuario" runat="server" Text=""></asp:Label>
            <asp:TextBox type="mail" ID="txtCorreoUsuario" CssClass="form-control " placeholder="Correo..." runat="server"></asp:TextBox>
        </div>
        <div class="col-md-11">
            <asp:Label ID="lblRolUsuario" runat="server" Text="Tipo" CssClass="text-black"></asp:Label>
            <asp:DropDownList ID="dllRolUsuario" DataTextField="Nombre" DataValueField="Id" CssClass="btn btn-secondary dropdown-toggle " runat="server"></asp:DropDownList>
        </div>          
        <div class="col-md-11">
            <asp:Button ID="btnAgregarUsuario" CssClass="btn btn-danger" OnClick="btnAgregarUsuario_Click" runat="server" Text="AGREGAR" />
            <asp:Button ID="btnCancelarUsuario" CssClass="btn btn-danger" OnClick="btnCancelarUsuario_Click" runat="server" Text="CANCELAR" />
            <br />
            <div>
                <asp:Label ID="lblErrorUsuarioExistente" runat="server" Text=""></asp:Label>
            </div>

        </div>
    </div>

</asp:Content>
