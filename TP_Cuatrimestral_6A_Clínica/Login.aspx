<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TP_Cuatrimestral_6A_Clínica.Login" %>

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

                        <div class="mb-3">
                            <asp:TextBox ID="txtDni" CssClass="form-control modern-input" runat="server" placeholder="DNI..." required="true"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <asp:TextBox ID="txtContraseña" CssClass="form-control modern-input" runat="server" TextMode="Password" placeholder="Contraseña..." required="true"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <div class="form-check">
                                <asp:CheckBox ID="chkRecuerdame" runat="server" CssClass="form-check-input" />
                                <label class="form-check-label" for="chkRecuerdame">Recuerdame</label>
                            </div>
                        </div>
                        <div id="center">
                            <asp:Button ID="btnIngresar" runat="server" CssClass="btn btn-modern" Text="Ingresar" OnClick="btnIngresar_Click" />
                            <label></label>
                            <asp:Button ID="btnRegistrar" CausesValidation="false" UseSubmitBehavior="false" runat="server" CssClass="btn btn-modern" Text="Registrarse" OnClick="btnRegistrar_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="image-column">
                <img src="https://images.pexels.com/photos/8853189/pexels-photo-8853189.jpeg" alt="Imagen de fondo" class="background-image" />
            </div>
        </div>
    </form>
</body>
</html>
