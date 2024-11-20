<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RestablecerContraseña.aspx.cs" Inherits="TP_Cuatrimestral_6A_Clínica.RestablecerContraseña" %>

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

                        <h1>Restablecer Contraseña</h1>
                        <br />

                        <div class="mb-3">
                            <div>
                                <asp:Label Style="color: red" ID="lblErrorDniUsuarioRestablecer" runat="server" Text=""></asp:Label>
                            </div>
                            <asp:TextBox ID="txtDniUsuarioRestablecer" type="number" min="10000000" max="99999999" oninvalid="this.setCustomValidity('Ingrese Un numero valido de 8 digitos')" oninput="setCustomValidity('')" CssClass="form-control modern-input" runat="server" placeholder="DNI..."></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <div>
                                <asp:Label Style="color: red" ID="lblErrorCorreoUsuarioRestablecer" runat="server" Text=""></asp:Label>
                            </div>
                            <asp:TextBox type="mail" ID="txtCorreoUsuarioRestablecer" CssClass="form-control modern-input " placeholder="Correo..." runat="server"></asp:TextBox>
                        </div>
                        <div id="center">
                            <asp:Button ID="btnAceptarRestablecer" CssClass="btn btn-modern" runat="server" OnClick="btnAceptarRestablecer_Click" Text="ACEPTAR" />
                            <asp:Button ID="btnCancelarRestablecer" CausesValidation="false" UseSubmitBehavior="false" CssClass="btn btn-modern" runat="server" OnClick="btnCancelarRestablecer_Click" Text="CANCELAR" />
                            <br />
                            <div>
                                <asp:Label ID="lblMensajeRestablecer" runat="server" Text=""></asp:Label>
                            </div>

                            <% if (AbrirCodigo == true)
                                {  %>
                            <br />
                            <asp:TextBox ID="txtCodigoRestablecer" runat="server" AutoPostBack="false" CssClass="form-control modern-input " Placeholder="X-X-X-X-X-X"></asp:TextBox>
                            <asp:Button ID="btnIngresarCodigo" CssClass="btn btn-modern" runat="server" OnClick="btnIngresarCodigo_Click" Text="INGRESAR" />
                            <div>
                                <asp:Label Style="color: red" ID="lblErrorCodigo" runat="server" Text=""></asp:Label>
                            </div>                                                      
                            <br />
                            <% } %>

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
