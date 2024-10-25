<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Opciones.aspx.cs" Inherits="TP_Cuatrimestral_6A_Clínica.Opciones" %>

<asp:Content ID="Opciones" ContentPlaceHolderID="ContentRight" runat="server">
    <div class="container mt-4">
        <h2>Opciones de Cuenta</h2>
        <div id="formOpciones" runat="server" class="border p-4 rounded shadow">


            <div class="form-group">
                <asp:Button ID="btnAjustes" runat="server" CssClass="btn btn-info w-100 my-2" OnClick="btnAjustes_Click" Text="Ajustes" />
            </div>

            <div class="form-group">
                <asp:Button ID="btnSoporte" runat="server" CssClass="btn btn-primary w-100 my-2" OnClick="btnSoporte_Click" Text="Soporte" />
            </div>

            <div class="form-group">
                <asp:Button ID="btnCerrarSesion" runat="server" CssClass="btn btn-danger w-100 my-2" OnClick="btnCerrarSesion_Click" Text="Cerrar Sesión" />
            </div>

        </div>
    </div>
</asp:Content>
