<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="app_web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Gestión de Desarrolladores</h2>

    <h4>Nuevo Desarrollador</h4>

    <%-- Assign ValidationGroup to ValidationSummary --%>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger" HeaderText="Por favor corrige estos errores:" ValidationGroup="NewDeveloperGroup" />

    <asp:Panel runat="server" CssClass="mb-3">
        <asp:TextBox ID="txtNombre" runat="server" Placeholder="Nombre" CssClass="form-control mb-2"></asp:TextBox>
        <%-- Assign ValidationGroup to RequiredFieldValidator --%>
        <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="* El nombre es obligatorio." CssClass="text-danger" Display="Dynamic" ValidationGroup="NewDeveloperGroup" />
        
        <asp:TextBox ID="txtApellido" runat="server" Placeholder="Apellido" CssClass="form-control mb-2"></asp:TextBox>
        <%-- Assign ValidationGroup to RequiredFieldValidator --%>
        <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ControlToValidate="txtApellido" ErrorMessage="* El apellido es obligatorio." CssClass="text-danger" Display="Dynamic" ValidationGroup="NewDeveloperGroup" />
        
        <asp:TextBox ID="txtEspecialidad" runat="server" Placeholder="Especialidad" CssClass="form-control mb-2"></asp:TextBox>
        <%-- Assign ValidationGroup to RequiredFieldValidator --%>
        <asp:RequiredFieldValidator ID="rfvEspecialidad" runat="server" ControlToValidate="txtEspecialidad" ErrorMessage="* La especialidad es obligatoria." CssClass="text-danger" Display="Dynamic" ValidationGroup="NewDeveloperGroup" />

        <%-- Assign ValidationGroup to the Add Button --%>
        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn btn-primary" OnClick="btnAgregar_Click" ValidationGroup="NewDeveloperGroup" />
    </asp:Panel>

    <asp:GridView ID="gvDesarrolladores" runat="server" AutoGenerateColumns="False" CssClass="table table-striped"
        DataKeyNames="IdDesarrollador" OnRowEditing="gvDesarrolladores_RowEditing"
        OnRowUpdating="gvDesarrolladores_RowUpdating" OnRowCancelingEdit="gvDesarrolladores_RowCancelingEdit"
        OnRowDeleting="gvDesarrolladores_RowDeleting">
        <Columns>
            <asp:BoundField DataField="IdDesarrollador" HeaderText="ID" ReadOnly="True" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
            <asp:BoundField DataField="Especialidad" HeaderText="Especialidad" />
            <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>
</asp:Content>