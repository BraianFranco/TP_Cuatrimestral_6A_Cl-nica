<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdministrarEspecialidades.aspx.cs" Inherits="TP_Cuatrimestral_6A_Clínica.AdministrarEspecialidades" %>


<asp:Content ID="Content4" ContentPlaceHolderID="ContentRight" runat="server">


    <div class="container mt-4">

        <div style="justify-items: center;">
            <h2>Especialidades</h2>
        </div>


        <div class="container">


            <div class="row mb-3">
                <div class="col">
                    <asp:TextBox id="txtFiltro" CssClass="form-control"  placeholder="Buscar por Nombre" runat="server"></asp:TextBox>
                </div>
                <div class="col-auto">
                    <asp:Button ID="btnFiltrar" runat="server" OnClick="btnFiltrar_Click" Text="Filtrar" CssClass="btn btn-primary" />
                </div>

                <div class="col-auto">
                    <asp:Button ID="btnAgregar" runat="server" Text="Agregar Especialidad" CssClass="btn btn-primary" OnClick="btnAgregar_Click" />
                </div>
            </div>

            <!-- GridView -->

            <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>
            <asp:GridView ID="gvEspecialidades" runat="server" AutoGenerateColumns="False"  OnRowDeleting="GridView1_RowDeleting1" OnRowCommand="gvEspecialidades_RowCommand" DataKeyNames="Id"
                CssClass="table table-striped table-bordered table-hover" HeaderStyle-CssClass="thead-dark">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>

                            <asp:Button runat="server" Text="Editar" CommandName="Edit" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-warning btn-sm" />
                            <asp:Button runat="server" ID="btnConfirmarEliminacionEspecialidad" CssClass="btn btn-danger btn-sm" CommandArgument='<%# Eval("Id") %>' CommandName="Delete" Text="Eliminar" />


                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

        </div>

        <%if (ConfirmaEliminacion)
            {  %>
            <label>¿Esta Seguro/a de eliminar esta Especialidad ?</label>
            <asp:Button runat="server" Text="Confirmar" CssClass="btn btn-outline-danger " OnClick="btnConfirmarEliminacionEspecialidad_Click" />
            <asp:Button runat="server" ID="btnCancelarEliminacionEspecialidad" Text="Cancelar" CssClass="btn btn-outline-danger " OnClick="btnCancelarEliminacionEspecialidad_Click" />

        <% } %>
    </div>

</asp:Content>
