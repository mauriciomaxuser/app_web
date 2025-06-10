<%@ Page Title="Proyectos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="app_web.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h2 class="text-center mb-4">Gestión de Proyectos</h2>

        <%-- Assign ValidationGroup to ValidationSummary --%>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger" HeaderText="Por favor corrige estos errores:" ValidationGroup="NewProjectGroup" />

        <h4 class="mb-3">Agregar Nuevo Proyecto</h4>

        <div class="form-group">
            <label for="txtNombreProyecto">Nombre del Proyecto</label>
            <asp:TextBox ID="txtNombreProyecto" runat="server" CssClass="form-control" />
            <%-- Assign ValidationGroup to RequiredFieldValidator --%>
            <asp:RequiredFieldValidator ID="rfvNombreProyecto" runat="server" ControlToValidate="txtNombreProyecto"
                ErrorMessage="* El nombre del proyecto es obligatorio." CssClass="text-danger" Display="Dynamic" ValidationGroup="NewProjectGroup" />
        </div>

        <div class="form-group">
            <label for="txtDescripcionProyecto">Descripción</label>
            <asp:TextBox ID="txtDescripcionProyecto" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" />
            <%-- Assign ValidationGroup to RequiredFieldValidator --%>
            <asp:RequiredFieldValidator ID="rfvDescripcionProyecto" runat="server" ControlToValidate="txtDescripcionProyecto"
                ErrorMessage="* La descripción es obligatoria." CssClass="text-danger" Display="Dynamic" ValidationGroup="NewProjectGroup" />
        </div>

        <div class="form-group">
            <label for="txtFechaInicio">Fecha de Inicio (yyyy-mm-dd)</label>
            <asp:TextBox ID="txtFechaInicio" runat="server" CssClass="form-control" />
            <%-- Assign ValidationGroup to RequiredFieldValidator --%>
            <asp:RequiredFieldValidator ID="rfvFechaInicio" runat="server" ControlToValidate="txtFechaInicio"
                ErrorMessage="* La fecha de inicio es obligatoria." CssClass="text-danger" Display="Dynamic" ValidationGroup="NewProjectGroup" />
        </div>

        <div class="form-group">
            <label for="ddlResponsable">Responsable</label>
            <asp:DropDownList ID="ddlResponsable" runat="server" CssClass="form-control" />
            <%-- Assign ValidationGroup to RequiredFieldValidator --%>
            <asp:RequiredFieldValidator ID="rfvResponsable" runat="server" ControlToValidate="ddlResponsable"
                InitialValue="" ErrorMessage="* Seleccione un responsable." CssClass="text-danger" Display="Dynamic" ValidationGroup="NewProjectGroup" />
        </div>

        <%-- Assign ValidationGroup to the Add Button --%>
        <asp:Button ID="btnAgregarProyecto" runat="server" Text="Agregar Proyecto" CssClass="btn btn-primary mt-3 mb-5" OnClick="btnAgregarProyecto_Click" ValidationGroup="NewProjectGroup" />

        <h4 class="mb-3">Lista de Proyectos</h4>

        <asp:GridView ID="gvProyectos" runat="server" CssClass="table table-bordered table-striped"
            AutoGenerateColumns="False" DataKeyNames="IdProyecto"
            OnRowEditing="gvProyectos_RowEditing"
            OnRowCancelingEdit="gvProyectos_RowCancelingEdit"
            OnRowUpdating="gvProyectos_RowUpdating"
            OnRowDeleting="gvProyectos_RowDeleting">
            <Columns>
                <asp:BoundField DataField="IdProyecto" HeaderText="ID" ReadOnly="true" />
                <asp:BoundField DataField="NombreProyecto" HeaderText="Nombre" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                <asp:BoundField DataField="FechaInicio" HeaderText="Fecha de Inicio" DataFormatString="{0:yyyy-MM-dd}" />
                <asp:BoundField DataField="NombreResponsable" HeaderText="Responsable" ReadOnly="true" />
                <asp:CommandField ShowEditButton="true" ShowDeleteButton="true" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>