﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdministrarMedicos.aspx.cs" Inherits="TP_Cuatrimestral_6A_Clínica.AdministrarMedicos" %>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentRight" runat="server">
    <div class="container mt-4">
        <div style="justify-items: center;">
            <h2>Médicos</h2>
        </div>

        <div class="container">

            <div class="row mb-3">
                <div class="col">
                    <asp:TextBox type="number" ID="txtFiltrar" max="99999999" CssClass="form-control" placeholder="Buscar por DNI" runat="server"></asp:TextBox>
                </div>
                <div class="col-auto">
                    <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" OnClick="btnFiltrar_Click" CssClass="btn btn-primary" />
                </div>

                <div class="col-auto">
                    <asp:Button ID="btnAgregar" runat="server" Text="Agregar Médico" CssClass="btn btn-primary" OnClick="btnAgregar_Click" />
                </div>

            </div>

            <!-- GridView -->


            <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>
            <asp:GridView ID="GridView1" DataValueField="Dni" runat="server" OnRowDeleting="GridView1_RowDeleting1" OnRowCommand="GridView1_RowCommand" AutoGenerateColumns="False"
                CssClass="table table-striped table-bordered table-hover" HeaderStyle-CssClass="thead-dark">
                <Columns>

                    <asp:BoundField DataField="Dni" HeaderText="DNI" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                    <asp:BoundField DataField="Correo" HeaderText="Correo" />
                    <asp:BoundField DataField="IdPais" HeaderText="País" />

                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>

                     <asp:Button runat="server" Text="Editar" CommandName="Edit" CommandArgument='<%# Eval("Dni") %>' CssClass="btn btn-warning btn-sm" /> 

                            <% if (ObtenerRolUsuarioSession() == 2)
                                {  %>
                            <asp:Button runat="server" ID="ConfirmarEliminacionMedico" CssClass="btn btn-danger btn-sm" CommandName="Delete" Text="Eliminar" CommandArgument='<%# Eval("Dni") %>' />
                            <% } %>

                            <asp:Button runat="server" Text="Horarios" CommandName="Horarios" CommandArgument='<%# Eval("Dni") %>' CssClass="btn btn-info btn-sm" />

                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>

        <%if (ConfirmaEliminacion)
            {  %>
        <label>Esta Seguro/a de eliminar este Médico ?</label>
        <asp:Button runat="server" Text="Confirmar" CssClass="btn btn-outline-danger " OnClick="ConfirmarEliminacionMedico_Click" />
        <asp:Button runat="server" ID="btnCancelarEliminacionMedico" Text="Cancelar" CssClass="btn btn-outline-danger " OnClick="btnCancelarEliminacionMedico_Click" />

        <% } %>
    </div>

    <!-- Modal para el horario de los medicos -->

    <div class="modal fade" id="modalHorarios" tabindex="-1" role="dialog" aria-labelledby="modalHorariosLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="modalHorariosLabel">Horarios del Médico</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body text-center">
                    <asp:Label ID="lblHorarios" CssClass="text-center" runat="server" Text="Horarios aquí..."></asp:Label>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

