<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ValidarUsuarios.aspx.cs" Inherits="TP_Cuatrimestral_6A_Clínica.WebForm6" %>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentRight" runat="server">

    <div class="container mt-4">

        <div style="justify-items: center;">
            <h2>VALIDAR USUARIO</h2>
        </div>


        <div class="container">


            <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>
            <asp:GridView ID="gvUsuariosPendientes" runat="server" AutoGenerateColumns="False" OnRowEditing="gvUsuariosPendientes_RowEditing"  DataKeyNames="Id"
                CssClass="table table-striped table-bordered table-hover" HeaderStyle-CssClass="thead-dark">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" />
                    <asp:BoundField DataField="Dni" HeaderText="Dni" />
                    <asp:BoundField DataField="Correo" HeaderText="Correo" />
                    <asp:BoundField DataField="IdRol" HeaderText="Rol" />
                    <asp:BoundField DataField="Verificacion" HeaderText="Verificación" />
                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>

                            <asp:Button runat="server" Text="Aceptar" CommandName="Edit" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-success btn-sm" />
                            <asp:Button runat="server" Text="Ignorar" ID="btnConfirmarEliminacionEspecialidad" CssClass="btn btn-danger btn-sm"  />


                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

        </div>
    </div>
</asp:Content>
