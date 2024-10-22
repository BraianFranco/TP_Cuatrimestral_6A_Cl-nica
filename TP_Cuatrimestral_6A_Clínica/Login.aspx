<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TP_Cuatrimestral_6A_Clínica.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="preconnect" href="https://fonts.googleapis.com"/>
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin=""/>
    <link href="https://fonts.googleapis.com/css2?family=Libre+Bodoni:ital,wght@0,400..700;1,400..700&display=swap" rel="stylesheet"/>
    <link href="Content/Estilo_Login.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="Rectangulo">
            <div id="ContenidoRectangulo">
                <div id="HeaderRectangulo">
                    <h1 id="Titulo">SWISS CLINICAL</h1>
                </div>
                <div class="mb-3">               
                    <asp:TextBox ID="txtDni" CssClass="form-control-bg-dark" runat="server" placeholder="DNI..."></asp:TextBox>
                </div>
                <div class="mb-3">
                    
                    <asp:TextBox type="password" ID="txtContraseña" CssClass="form-control-bg-dark" runat="server" placeholder="Contraseña..." ></asp:TextBox>
                </div>
                <select class="form-select" aria-label="Default select example">
                    <option selected="">- Tipo de cuenta -</option>
                    <option value="1">Medico</option>
                    <option value="2">Recepcionista</option>
                    <option value="3">Administrador</option>
                </select>

                <div id="center">
                    <asp:Button ID="btnIngresar" runat="server" CssClass="btn btn-default btn-lg" Text="Ingresar" OnClick="btnIngresar_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>

