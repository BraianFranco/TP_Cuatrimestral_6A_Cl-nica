<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarUsuario2.0.aspx.cs" Inherits="TP_Cuatrimestral_6A_Clínica.AgregarUsuario2__0" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="preconnect" href="https://fonts.googleapis.com" />
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin="" />
    <link href="https://fonts.googleapis.com/css2?family=Libre+Bodoni:ital,wght@0,400..700;1,400..700&display=swap" rel="stylesheet" />
    <link href="Content/Estilo_Login.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="form-column">

                <div class="Rectangulo">

                    <img src="https://i.imgur.com/xkufGX8.png" alt="Logo" class="img-fluid border rounded shadow" />

                    <div id="ContenidoRectangulo">

                        <h1>Registrar Usuario</h1>
                        <br />

                        <div class="mb-3">
                            <div>
                                <asp:Label Style="color: red" ID="lblErrorDniUsuario" runat="server" Text=""></asp:Label>
                            </div>                      
                            <asp:TextBox ID="txtDniUsuario" type="number" min="10000000" max="99999999" oninvalid="this.setCustomValidity('Ingrese Un numero valido de 8 digitos')" oninput="setCustomValidity('')" CssClass="form-control modern-input" runat="server" placeholder="DNI..."></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <div>
                                <asp:Label Style="color: red" ID="lblErrorContraseñaUsuario" runat="server" Text=""></asp:Label>
                            </div>       
                            <asp:TextBox type="password" ID="txtContraseñaUsuario" CssClass="form-control modern-input " runat="server" placeholder="Contraseña..."></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <div>
                                 <asp:Label Style="color: red" ID="lblErrorCorreoUsuario" runat="server" Text=""></asp:Label>
                            </div>                      
                            <asp:TextBox type="mail" ID="txtCorreoUsuario" CssClass="form-control modern-input " placeholder="Correo..." runat="server"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <asp:Label ID="lblRolUsuario" runat="server" Text="Tipo" CssClass="text-black"></asp:Label>
                            <asp:DropDownList ID="dllRolUsuario" DataTextField="Nombre" DataValueField="Id" CssClass="form-control modern-input " runat="server"></asp:DropDownList>
                        </div>
                        <div id="center">
                            <asp:Button ID="btnAgregarUsuario" CssClass="btn btn-modern" runat="server"  OnClick="btnAgregarUsuario_Click" Text="AGREGAR" />
                            <asp:Button ID="btnCancelarUsuario" CssClass="btn btn-modern" runat="server" OnClick="btnCancelarUsuario_Click" Text="CANCELAR" />
                            <br />
                            <div>
                                <asp:Label ID="lblErrorUsuarioExistente" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="image-column">
                    <img src="https://images.pexels.com/photos/8853189/pexels-photo-8853189.jpeg" alt="Imagen de fondo" class="background-image" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
