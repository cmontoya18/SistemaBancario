<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CajeroAutomatico.aspx.cs" Inherits="SistemaBancario.Pages.CajeroAutomatico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Cajero automático</h1>
    <div>
        <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label><br />
    </div>
    <div>
        <asp:Label ID="lblTipoMovimiento" runat="server" Text="Tipo de movimiento"></asp:Label><br />
        <asp:DropDownList ID="ddnTipoMovimiento" runat="server"></asp:DropDownList><br />
        <asp:Label ID="lblNumeroCuenta" runat="server" Text="Número de cuenta"></asp:Label><br />
        <asp:DropDownList ID="ddnCuentas" runat="server"></asp:DropDownList><br />
        <asp:Label ID="lblMonto" runat="server" Text="Digite un monto"></asp:Label><br />
        <asp:TextBox ID="txtMonto" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rrfMonto" runat="server" ControlToValidate="txtMonto" ErrorMessage="El monto es obligatorio"></asp:RequiredFieldValidator><br /><br />
        <asp:Button ID="btnEjecutar" runat="server" Text="Ejecutar" CssClass="btn btn-primary" OnClick="btnEjecutar_Click" />
    </div>
</asp:Content>
