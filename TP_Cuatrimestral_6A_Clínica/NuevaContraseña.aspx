<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="NuevaContraseña.aspx.cs" Inherits="TP_Cuatrimestral_6A_Clínica.NuevaContraseña" %>

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

                        <h1>Nueva Contraseña</h1>
                        <br />

                        <div class="mb-3">
                            <div>
                                <asp:Label Style="color: red" ID="lblErrorContraNueva" runat="server" Text=""></asp:Label>
                            </div>
                            <asp:TextBox ID="txtContraNueva" type="password" CssClass="form-control modern-input" runat="server" placeholder="Contraseña nueva..."></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <div>
                                <asp:Label Style="color: red" ID="lblErrorContraNueva2" runat="server" Text=""></asp:Label>
                            </div>
                            <asp:TextBox ID="txtContraNueva2" type="password" CssClass="form-control modern-input" runat="server" placeholder="Repita la Contraseña..."></asp:TextBox>
                        </div>
                        <div id="center">
                            <asp:Button ID="btnAceptarRestablecer" CssClass="btn btn-modern" runat="server" Text="RESTABLECER" OnClick="btnAceptarRestablecer_Click" />
                            <asp:Button ID="btnCancelarRestablecer" CausesValidation="false" UseSubmitBehavior="false" CssClass="btn btn-modern" runat="server" Text="CANCELAR" Onclick="btnCancelarRestablecer_Click" />
                            <br />
                            <div>
                                <asp:Label ID="lblMensajeRestablecer" runat="server" Text=""></asp:Label>
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
