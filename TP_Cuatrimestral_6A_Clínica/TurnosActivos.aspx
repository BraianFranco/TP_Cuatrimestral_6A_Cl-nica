<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TurnosActivos.aspx.cs" Inherits="TP_Cuatrimestral_6A_Clínica.TurnosActivos" %>


<asp:Content ID="TurnosActivos" ContentPlaceHolderID="ContentRight" runat="server">


    <div class="container mt-4">
        <h2>Turnos Activos</h2>



        <div class="container">


            <div class="row mb-3">
                <div class="col">
                    <input type="text" id="txtFiltro" class="form-control" placeholder="Buscar por Paciente o Médico" />
                </div>
                <div class="col-auto">
                    <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" CssClass="btn btn-primary" />
                </div>
            </div>


               <!-- GridView -->

            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="TurnoID"
                CssClass="table table-striped table-bordered table-hover" HeaderStyle-CssClass="thead-dark">
                <Columns>
                    <asp:BoundField DataField="TurnoID" HeaderText="ID Turno" />
                    <asp:BoundField DataField="Paciente" HeaderText="Paciente" />
                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:BoundField DataField="Hora" HeaderText="Hora" />
                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <asp:Button runat="server" Text="Ver Detalles" CommandName="Select" CssClass="btn btn-info btn-sm" />
                            <asp:Button runat="server" Text="Editar" CommandName="Edit" CssClass="btn btn-warning btn-sm" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>



        </div>
    </div>

</asp:Content>
