<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Turnos.aspx.cs" Inherits="TP_Cuatrimestral_6A_Clínica.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <ul class="nav nav-tabs mb-3">
        <li class="nav-item">
            <a class="nav-link active" aria-current="page" href="#">Activos</a>
        </li>
        <li class="nav-item">
            <a class="nav-link" href="#">Reprogramados</a>
        </li>
        <li class="nav-item">
            <a class="nav-link" href="#">Cancelados</a>
        </li>
    </ul>

    <div class="container">
        <div class="row mb-3">
            <div class="col text-right">
                <a href="NuevoTurno.aspx" class="btn btn-danger">Nuevo Turno</a>
                <a href="CargarObservacion.aspx" class="btn btn-danger">Nueva Observación</a>
            </div>
        </div>
    </div>


    <div class="container">
        <asp:GridView ID="gvTurnos" runat="server" AutoGenerateColumns="false" CssClass="table table-striped">
            <Columns>
                <asp:BoundField DataField="TurnoID" HeaderText="ID" />
                <asp:BoundField DataField="Paciente" HeaderText="Paciente" />
                <asp:BoundField DataField="Medico" HeaderText="Médico" />
                <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="Hora" HeaderText="Hora" />
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>

