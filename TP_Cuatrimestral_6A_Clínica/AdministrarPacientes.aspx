﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdministrarPacientes.aspx.cs" Inherits="TP_Cuatrimestral_6A_Clínica.AdministrarPacientes" %>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentRight" runat="server">
    <div class="container mt-4">
        <div style="text-align: center;">
            <h2>Pacientes</h2>
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
                    <asp:Button ID="btnAgregar" runat="server" Text="Agregar Paciente" CssClass="btn btn-primary" OnClick="btnAgregar_Click" />
                </div>

            </div>

            <!-- GridView -->
            <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>
            <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
            <asp:GridView ID="gvPacientes" runat="server" AutoGenerateColumns="False" OnRowDeleting="GridView1_RowDeleting1" OnRowCommand="gvPacientes_RowCommand" DataKeyNames="Dni"
                CssClass="table table-striped table-bordered table-hover" HeaderStyle-CssClass="thead-dark">
                <Columns>
                    <asp:BoundField DataField="Dni" HeaderText="DNI" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                    <asp:BoundField DataField="Correo" HeaderText="Correo" />
                    <asp:BoundField DataField="NroTelefono" HeaderText="Teléfono" />
                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>

                            <%if (ObtenerRolUsuarioSession() == 2)
                                { %>

                            <asp:Button runat="server" Text="Editar" CommandName="Edit" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-warning btn-sm" />
                            <asp:Button runat="server" ID="btnConfirmarEliminacionPacienteAdmin" CssClass="btn btn-danger btn-sm" Text="Eliminar" CommandName="Delete" CommandArgument='<%# Eval("Dni") %>' />

                            <% } %>


                            <%if (ObtenerRolUsuarioSession() == 1)
                                { %>

                            <asp:Button runat="server" Text="Editar" CommandName="Edit" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-warning btn-sm" />

                            <% } %>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>

        <%if (ConfirmaEliminacion)
            {  %>

        <label>Esta Seguro/a de eliminar este Paciente?</label>
        <asp:Button runat="server" Text="Confirmar" CssClass="btn btn-outline-danger " OnClick="btnConfirmarEliminacionPaciente_Click" />
        <asp:Button runat="server" ID="btnCancelarEliminacionPaciente" Text="Cancelar" CssClass="btn btn-outline-danger " OnClick="btnCancelarEliminacionPaciente_Click" />

        <% } %>
    </div>
</asp:Content>

