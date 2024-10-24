
<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="NuevoTurno.aspx.cs" Inherits="TP_Cuatrimestral_6A_Clínica.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

        <style>
        body {
            background-color: #f0f0f0;
            color: #333; 
        }
        .form-container {
            background-color: #fff; 
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            max-width: 600px;
            margin: 0 auto;
        }
        .form-label {
            color: #333; 
        }
    </style>


</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    
    <div class="container mt-5">
        <div class="form-container">
            <!-- TextBox para ingresar el DNI -->
            <div class="form-group">
                <label for="txtDNI" class="form-label">Ingrese el DNI del paciente:</label>
                <asp:TextBox ID="txtDNI" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtDNI_TextChanged"></asp:TextBox>
            </div>

            <!-- DropDownList para seleccionar el tipo de especialidad -->
            <div class="form-group" runat="server" visible="false" id="especialidadGroup">
                <label for="ddlEspecialidad" class="form-label">Selecciona el tipo de especialidad:</label>
                <asp:DropDownList ID="ddlEspecialidad" runat="server" CssClass="form-control">
                    <asp:ListItem Text="Cardiología" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Pediatría" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Dermatología" Value="3"></asp:ListItem>
                </asp:DropDownList>
            </div>

            <!-- DropDownList para seleccionar el tipo de consulta o estudio -->
            <div class="form-group" runat="server" visible="false" id="consultaGroup">
                <label for="ddlConsulta" class="form-label">Seleccione el tipo de consulta o estudio:</label>
                <asp:DropDownList ID="ddlConsulta" runat="server" CssClass="form-control">
                    <asp:ListItem Text="Consulta General" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Ecografía" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Rayos X" Value="3"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
    </div>


</asp:Content>