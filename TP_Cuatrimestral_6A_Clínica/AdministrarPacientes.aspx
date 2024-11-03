<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdministrarPacientes.aspx.cs" Inherits="TP_Cuatrimestral_6A_Clínica.AdministrarPacientes" %>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentRight" runat="server">
    <div class="container mt-4">
        <div style="text-align: center;">
            <h2>Pacientes</h2>
        </div>

        <div class="container">
            <div class="row mb-3">
                <div class="col">
                    <input type="text" id="txtFiltro" class="form-control" placeholder="Buscar por DNI" />
                </div>
                <div class="col-auto">
                    <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" CssClass="btn btn-primary" />
                </div>

                <div class="col-auto">
                    <asp:Button ID="btnAgregar" runat="server" Text="Agregar Paciente" CssClass="btn btn-primary" OnClick="btnAgregar_Click" />
                </div>

            </div>

            <!-- GridView -->
            <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>
            <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
            <asp:GridView ID="gvPacientes" runat="server" AutoGenerateColumns="False" OnRowCommand="gvPacientes_RowCommand" DataKeyNames="Dni"
                CssClass="table table-striped table-bordered table-hover" HeaderStyle-CssClass="thead-dark">
                <Columns>
                    <asp:BoundField DataField="Dni" HeaderText="DNI" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" /> 
                    <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                    <asp:BoundField DataField="Correo" HeaderText="Correo" />
                    <asp:BoundField DataField="NroTelefono" HeaderText="Teléfono" />
                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <asp:Button runat="server" Text="Editar" CommandName="Edit" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-warning btn-sm" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>

