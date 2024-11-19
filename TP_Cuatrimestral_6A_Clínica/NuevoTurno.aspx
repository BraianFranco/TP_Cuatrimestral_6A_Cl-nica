<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="NuevoTurno.aspx.cs" Inherits="TP_Cuatrimestral_6A_Clínica.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        body {
            background-color: #f0f0f0;
            color: #333;
        }

        .form-container {
            background-color: #fff;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            max-width: 600px;
            margin: 0 auto;
        }

        .form-label {
            color: #333;
        }
    </style>


</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentRight" runat="server">


    <div class="container mt-5">
        <div class="form-container">
            <!-- TextBox para ingresar el DNI -->
            <div class="form-group">

                <asp:Label runat="server" for="txtDNI" ID="lblDNI" class="form-label">Ingrese el DNI del paciente:</asp:Label>
                <asp:TextBox ID="txtDNI" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtDNI_TextChanged"></asp:TextBox>
                <asp:Label ID="lblError" runat="server" CssClass="text-danger" Visible="false"></asp:Label>

            </div>



            <asp:Panel ID="PanelTurno" runat="server" Visible="false">

                <!-- se muestra cuando el dni es correcto -->



                <!-- DropDownList para seleccionar la especialidad -->
                <div class="form-group">
                    <label for="ddlEspecialidad" class="form-label">Selecciona la especialidad:</label>
                    <asp:DropDownList ID="ddlEspecialidad" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlEspecialidad_SelectedIndexChanged">
                        <asp:ListItem Text="Seleccione" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div>

                    <div>

                        <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control" type="date" />

                    </div>



                    <asp:DropDownList ID="ddlHorario" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlHorario_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem Text="Mañana" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Tarde" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Noche" Value="3"></asp:ListItem>
                    </asp:DropDownList>


                    <asp:UpdatePanel ID="UpdatePanelHoras" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlHoras" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlHorario" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>

                </div>



                <div class="form-group">
                    <asp:Button ID="btnMedicosDisponibles" runat="server" Text="Médicos disponibles" CssClass="btn btn-primary" OnClick="btnMedicosDisponibles_Click" />
                </div>


                <div class="form-group">
                    <asp:Label ID="lblMedicosDisponibles" runat="server" Text="Lista de Médicos Disponibles" CssClass="form-label"></asp:Label>
                    <asp:GridView ID="gvMedicos" runat="server" CssClass="table table-striped" AutoGenerateColumns="False" OnRowCommand="gvMedicos_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="Dni" HeaderText="DNI" />
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="Apellido" HeaderText="Apellido" />

                            <asp:TemplateField HeaderText="Acciones">
                                <ItemTemplate>
                                    <asp:Button runat="server" Text="Seleccionar" CommandName="Select" CommandArgument='<%# Eval("Dni") %>' CssClass="btn btn-warning btn-sm" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>

            </asp:Panel>

        </div>
    </div>


</asp:Content>
