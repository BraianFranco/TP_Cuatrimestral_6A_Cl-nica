<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TurnosActivos.aspx.cs" Inherits="TP_Cuatrimestral_6A_Clínica.TurnosActivos" %>


<asp:Content ID="TurnosActivos" ContentPlaceHolderID="ContentRight" runat="server">


    <div class="container mt-4">
        
        <div style="justify-items:center;">
            <h2>Turnos Activos</h2>
        </div>
        



        <div class="container">


            <div class="row mb-3">
                <div class="col">
                     <asp:TextBox type="number" id="txtFiltrar" max="99999999" CssClass="form-control"  placeholder="Buscar por DNI del Paciente..." runat="server"></asp:TextBox>
                </div>
                <div class="col-auto">
                    <asp:Button ID="btnFiltrar" OnClick="btnFiltrar_Click" runat="server" Text="Filtrar" CssClass="btn btn-primary" />
                </div>
            </div>


               <!-- GridView -->

            <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
                CssClass="table table-striped table-bordered table-hover" HeaderStyle-CssClass="thead-dark">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Turno" />
                    <asp:BoundField DataField="nombrepaciente" HeaderText="Paciente" />
                    <asp:BoundField DataField="nombremedico" HeaderText="Medico" />
                    <asp:BoundField DataField="especialidad" HeaderText="Especialidad" />
                    <asp:BoundField DataField="Observaciones" HeaderText="Observaciones" />
                    <asp:BoundField DataField="FechaTurno" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:BoundField DataField="Estado" HeaderText="Estado" />


                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <asp:Button runat="server" Text="Detalles" CommandName="Select" CssClass="btn btn-info btn-sm" />
                            <asp:Button runat="server" Text="Editar" CommandName="Edit" CssClass="btn btn-warning btn-sm" />
                            <asp:Button runat="server" Text="Cancelar" CommandName="delete" CssClass="btn btn-danger btn-sm" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>



        </div>
    </div>

</asp:Content>
