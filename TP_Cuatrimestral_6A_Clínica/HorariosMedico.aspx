<%@ Page Title="Configurar Horarios Médico" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="HorariosMedico.aspx.cs" Inherits="TP_Cuatrimestral_6A_Clínica.WebForm3" %>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentRight" runat="server">
    <div class="col-md-11">
        <h2>Configurar Horarios del Médico</h2>
        <br />
        <table class="table">
            <tr>
                <th>Día</th>
                <th>Seleccionar</th>
                <th>Turno</th>
            </tr>
            <%-- Lunes --%>
            <tr>
                <td><label>Lunes</label></td>
                <td><asp:CheckBox ID="chkLunes" runat="server" /></td>
                <td>
                    <asp:DropDownList ID="ddlTurnoLunes" runat="server">
                        <asp:ListItem Value="1">Mañana</asp:ListItem>
                        <asp:ListItem Value="2">Tarde</asp:ListItem>
                        <asp:ListItem Value="3">Noche</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <%-- Martes --%>
            <tr>
                <td><label>Martes</label></td>
                <td><asp:CheckBox ID="chkMartes" runat="server" /></td>
                <td>
                    <asp:DropDownList ID="ddlTurnoMartes" runat="server">
                        <asp:ListItem Value="1">Mañana</asp:ListItem>
                        <asp:ListItem Value="2">Tarde</asp:ListItem>
                        <asp:ListItem Value="3">Noche</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <%-- Miércoles --%>
            <tr>
                <td><label>Miércoles</label></td>
                <td><asp:CheckBox ID="chkMiercoles" runat="server" /></td>
                <td>
                    <asp:DropDownList ID="ddlTurnoMiercoles" runat="server">
                        <asp:ListItem Value="1">Mañana</asp:ListItem>
                        <asp:ListItem Value="2">Tarde</asp:ListItem>
                        <asp:ListItem Value="3">Noche</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <%-- Jueves --%>
            <tr>
                <td><label>Jueves</label></td>
                <td><asp:CheckBox ID="chkJueves" runat="server" /></td>
                <td>
                    <asp:DropDownList ID="ddlTurnoJueves" runat="server">
                        <asp:ListItem Value="1">Mañana</asp:ListItem>
                        <asp:ListItem Value="2">Tarde</asp:ListItem>
                        <asp:ListItem Value="3">Noche</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <%-- Viernes --%>
            <tr>
                <td><label>Viernes</label></td>
                <td><asp:CheckBox ID="chkViernes" runat="server" /></td>
                <td>
                    <asp:DropDownList ID="ddlTurnoViernes" runat="server">
                        <asp:ListItem Value="1">Mañana</asp:ListItem>
                        <asp:ListItem Value="2">Tarde</asp:ListItem>
                        <asp:ListItem Value="3">Noche</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <%-- Sábado --%>
            <tr>
                <td><label>Sábado</label></td>
                <td><asp:CheckBox ID="chkSabado" runat="server" /></td>
                <td>
                    <asp:DropDownList ID="ddlTurnoSabado" runat="server">
                        <asp:ListItem Value="1">Mañana</asp:ListItem>
                        <asp:ListItem Value="2">Tarde</asp:ListItem>
                        <asp:ListItem Value="3">Noche</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <%-- Domingo --%>
            <tr>
                <td><label>Domingo</label></td>
                <td><asp:CheckBox ID="chkDomingo" runat="server" /></td>
                <td>
                    <asp:DropDownList ID="ddlTurnoDomingo" runat="server">
                        <asp:ListItem Value="1">Mañana</asp:ListItem>
                        <asp:ListItem Value="2">Tarde</asp:ListItem>
                        <asp:ListItem Value="3">Noche</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        <asp:Button ID="btnGuardarHorarios" runat="server" Text="Guardar Horarios" CssClass="btn btn-success" OnClick="BtnGuardarHorarios_Click" />
    </div>
</asp:Content>
