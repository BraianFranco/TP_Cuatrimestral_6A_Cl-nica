<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TP_Cuatrimestral_6A_Clínica.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/Estilo_Login.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="Rectangulo">
            <div id="ContenidoRectangulo">
                <div id="HeaderRectangulo">
                    <h1>SWISS CLINICAL - LOGUEO </h1>
                </div>
                <div class="mb-3">
                    <label for="IngresoDni" class="form-label">DNI</label>
                    <input class="form-control bg-dark" id="IngresoDni"/>    
                </div>
                <div class="mb-3">
                    <label for="exampleInputPassword1" class="form-label">Contraseña</label>
                    <input type="password" class="form-control-bg-dark" id="exampleInputPassword1"/>
                </div>
                <select class="form-select" aria-label="Default select example">
                    <option value="1">Medico</option>
                    <option value="2">Recepcionista</option>
                    <option value="3">Administrador</option>
                </select>
                <button type="submit" class="btn btn-primary bg-dark">Ingresar</button>
            </div>
        </div>
    </form>
</body>
</html>
