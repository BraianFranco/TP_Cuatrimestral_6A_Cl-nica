<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EditarUsuario.aspx.cs" Inherits="TP_Cuatrimestral_6A_Clínica.EditarUsuario" %>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentRight" runat="server">
    <link href="Content/Estilo_AgregarPaciente.css" rel="stylesheet" />

    <div id="ContenedorRegistroPaciente">
        <h1>Editar Usuario</h1>
        <br />
        <div class="col-md-11">
            <div>
                <asp:Label Style="color: red" ID="lblErrorDniUsuario" runat="server" Text=""></asp:Label>
            </div>
            <asp:TextBox style="background-color:bisque" ID="txtDniUsuario" type="number" min="10000000" max="99999999" oninvalid="this.setCustomValidity('Ingrese Un numero valido de 8 digitos')" oninput="setCustomValidity('')" CssClass="form-control modern-input" runat="server" placeholder="DNI..."></asp:TextBox>
        </div>
        <div class="col-md-11">
            <div>
                <asp:Label Style="color: red" ID="lblErrorContraseñaUsuario" runat="server" Text=""></asp:Label>
            </div>
            <asp:TextBox ID="txtContraseñaUsuario" CssClass="form-control modern-input " runat="server" placeholder="Contraseña..."></asp:TextBox>
        </div>
        <div class="col-md-11">
            <div>
                <asp:Label Style="color: red" ID="lblErrorCorreoUsuario" runat="server" Text=""></asp:Label>
            </div>
            <asp:TextBox type="email" ID="txtCorreoUsuario" CssClass="form-control modern-input " placeholder="Correo..." runat="server"></asp:TextBox>
        </div>
        <div id="center">
            <asp:Button ID="btnAceptarUsuario" CssClass="btn btn-success" runat="server" OnClick="btnAceptarUsuario_Click" Text="ACEPTAR" />
            <asp:Button ID="btnCancelarUsuario" CssClass="btn btn-danger" runat="server" OnClick="btnCancelarUsuario_Click" Text="CANCELAR" />
            <br />
            <div>
                <asp:Label ID="lblErrorUsuarioExistente" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </div>

</asp:Content>
