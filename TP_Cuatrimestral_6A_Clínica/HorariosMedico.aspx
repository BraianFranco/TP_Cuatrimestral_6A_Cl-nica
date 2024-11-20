<%@ Page Title="Configurar Horarios Médico" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="HorariosMedico.aspx.cs" Inherits="TP_Cuatrimestral_6A_Clínica.WebForm3" %>

<asp:Content ID="Horarios" ContentPlaceHolderID="ContentRight" runat="server">
    <div class="container mt-4">
        <div class="row">
            <div class="col-12">
                <h2 class="text-center mb-4">Horarios del Médico</h2>
                <table class="table table-bordered table-hover">
                    <thead class="table-light">
                        <tr>
                            <th>Día</th>
                            <th>Hora Inicio</th>
                            <th>Hora Fin</th>
                        </tr>
                    </thead>
                    <tbody>
                        <!-- Lunes -->
                        <tr>
                            <td>
                                <asp:CheckBox ID="chkLunes" runat="server" CssClass="form-check-input" />
                                <asp:Label ID="lblLunes" runat="server" Text="Lunes" CssClass="ms-2"></asp:Label>
                            </td>
                            <td>
                                <input type="time" id="horaInicioLunes" runat="server" min="06:00" max="23:00" step="3600" class="form-control" />
                            </td>
                            <td>
                                <input type="time" id="horaFinLunes" runat="server" min="06:00" max="23:00" step="3600" class="form-control" />
                            </td>
                        </tr>
                        <!-- Martes -->
                        <tr>
                            <td>
                                <asp:CheckBox ID="chkMartes" runat="server" CssClass="form-check-input" />
                                <asp:Label ID="lblMartes" runat="server" Text="Martes" CssClass="ms-2"></asp:Label>
                            </td>
                            <td>
                                <input type="time" id="horaInicioMartes" runat="server" min="06:00" max="23:00" step="3600" class="form-control" />
                            </td>
                            <td>
                                <input type="time" id="horaFinMartes" runat="server" min="06:00" max="23:00" step="3600" class="form-control" />
                            </td>
                        </tr>
                        <!-- Miércoles -->
                        <tr>
                            <td>
                                <asp:CheckBox ID="chkMiercoles" runat="server" CssClass="form-check-input" />
                                <asp:Label ID="lblMiercoles" runat="server" Text="Miércoles" CssClass="ms-2"></asp:Label>
                            </td>
                            <td>
                                <input type="time" id="horaInicioMiercoles" runat="server" min="06:00" max="23:00" step="3600" class="form-control" />
                            </td>
                            <td>
                                <input type="time" id="horaFinMiercoles" runat="server" min="06:00" max="23:00" step="3600" class="form-control" />
                            </td>
                        </tr>
                        <!-- Jueves -->
                        <tr>
                            <td>
                                <asp:CheckBox ID="chkJueves" runat="server" CssClass="form-check-input" />
                                <asp:Label ID="lblJueves" runat="server" Text="Jueves" CssClass="ms-2"></asp:Label>
                            </td>
                            <td>
                                <input type="time" id="horaInicioJueves" runat="server" min="06:00" max="23:00" step="3600" class="form-control" />
                            </td>
                            <td>
                                <input type="time" id="horaFinJueves" runat="server" min="06:00" max="23:00" step="3600" class="form-control" />
                            </td>
                        </tr>
                        <!-- Viernes -->
                        <tr>
                            <td>
                                <asp:CheckBox ID="chkViernes" runat="server" CssClass="form-check-input" />
                                <asp:Label ID="lblViernes" runat="server" Text="Viernes" CssClass="ms-2"></asp:Label>
                            </td>
                            <td>
                                <input type="time" id="horaInicioViernes" runat="server" min="06:00" max="23:00" step="3600" class="form-control" />
                            </td>
                            <td>
                                <input type="time" id="horaFinViernes" runat="server" min="06:00" max="23:00" step="3600" class="form-control" />
                            </td>
                        </tr>
                        <!-- Sábado -->
                        <tr>
                            <td>
                                <asp:CheckBox ID="chkSabado" runat="server" CssClass="form-check-input" />
                                <asp:Label ID="lblSabado" runat="server" Text="Sábado" CssClass="ms-2"></asp:Label>
                            </td>
                            <td>
                                <input type="time" id="horaInicioSabado" runat="server" min="06:00" max="23:00" step="3600" class="form-control" />
                            </td>
                            <td>
                                <input type="time" id="horaFinSabado" runat="server" min="06:00" max="23:00" step="3600" class="form-control" />
                            </td>
                        </tr>
                        <!-- Domingo -->
                        <tr>
                            <td>
                                <asp:CheckBox ID="chkDomingo" runat="server" CssClass="form-check-input" />
                                <asp:Label ID="lblDomingo" runat="server" Text="Domingo" CssClass="ms-2"></asp:Label>
                            </td>
                            <td>
                                <input type="time" id="horaInicioDomingo" runat="server" min="06:00" max="23:00" step="3600" class="form-control" />
                            </td>
                            <td>
                                <input type="time" id="horaFinDomingo" runat="server" min="06:00" max="23:00" step="3600" class="form-control" />
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
        <div class="row">
            <div class="col-12 text-center mt-3">
                <asp:Button ID="btnGuardarHorarios" runat="server" Text="Guardar Horarios" CssClass="btn btn-primary" OnClick="btnGuardarHorarios_Click" />
            </div>
        </div>
        <div class="row">
            <div class="col-12 text-center mt-2">
                <asp:Label runat="server" ID="lblMensaje" CssClass="text-danger"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>

