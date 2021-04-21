<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearCuentas.aspx.cs" Inherits="SistemaBancario.Pages.CrearCuentas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Creación de cuentas bancarias</h1>
    <div>
        <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label><br />
    </div>
    <div>
        <asp:Label ID="lblCuenta" runat="server" Text="Digite el número de cuenta" Font-Bold="False" Font-Size="12pt" ></asp:Label><br />
        <asp:TextBox ID="txtCuenta" runat="server"></asp:TextBox><br />
        <asp:RequiredFieldValidator ID="rfvCuenta" runat="server" ControlToValidate="txtCuenta" ErrorMessage="El campo cuenta es requerido"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="regexCuenta" runat="server"  ValidationExpression="\d{5}"  ControlToValidate="txtCuenta" ErrorMessage="Solo se permiten numeros y 5 digitos"></asp:RegularExpressionValidator><br />
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
        &nbsp;&nbsp;&nbsp;
        <a href="ConsultarMovimientos.aspx" class="btn btn-primary">Cancelar</a>
    </div>
</asp:Content>
