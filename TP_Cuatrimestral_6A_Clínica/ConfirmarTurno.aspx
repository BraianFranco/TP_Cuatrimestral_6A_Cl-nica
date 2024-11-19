<%@ Page Title="Confirmar Turno" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ConfirmarTurno.aspx.cs" Inherits="TP_Cuatrimestral_6A_Clínica.ConfirmarTurno" %>

<asp:Content ID="ConfirmarTurno" ContentPlaceHolderID="ContentRight" runat="server">
    <div class="container mt-4">
        <h2>Confirmar Turno</h2>
        <asp:Panel ID="pnlConfirmarTurno" runat="server" CssClass="card p-4 shadow">


            <div class="form-group">
                <label>DNI Paciente:</label>
                <asp:Label ID="lblDniPaciente" runat="server" CssClass="form-label"></asp:Label>
            </div>
            <div class="form-group">
                <label>Especialidad:</label>
                <asp:Label ID="lblEspecialidad" runat="server" CssClass="form-label"></asp:Label>
            </div>
            <div class="form-group">
                <label>Fecha y Hora:</label>
                <asp:Label ID="lblFechaHora" runat="server" CssClass="form-label"></asp:Label>
            </div>
            <div class="form-group">
                <label>Médico Seleccionado:</label>
                <asp:Label ID="lblMedico" runat="server" CssClass="form-label"></asp:Label>
            </div>



            <div class="form-group">
                <label for="txtObservaciones">Observaciones (opcional):</label>
                <asp:TextBox ID="txtObservaciones" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
            </div>



            <div class="form-group text-center mt-4">
                <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar Turno" CssClass="btn btn-success mx-2" OnClick="btnConfirmar_Click" />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-danger mx-2" OnClick="btnCancelar_Click" />
            </div>




            <!-- Modal Confirmación -->


            <div class="modal fade" id="modalConfirmacion" tabindex="-1" aria-labelledby="modalConfirmacionLabel" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="modalConfirmacionLabel">Turno Confirmado</h5>
                            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Cerrar"></button>
                        </div>
                        <div class="modal-body">
                            ¡El turno ha sido confirmado exitosamente!
           
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnVolver" runat="server" Text="Volver" CssClass="btn btn-primary" OnClick="btnVolver_Click" />
                        </div>
                    </div>
                </div>
            </div>

        </asp:Panel>
    </div>
</asp:Content>
