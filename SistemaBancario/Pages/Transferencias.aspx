<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Transferencias.aspx.cs" Inherits="SistemaBancario.Pages.Transferencias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Transferencias de dinero</h1>
    <div>
        <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label><br />
    </div>
    <div>
        <asp:Label ID="lblCuentaOrigen" runat="server" Text="Número de cuenta origen"></asp:Label><br />
        <asp:DropDownList ID="ddnCuentaOrigen" AutoPostBack="true" OnSelectedIndexChanged="ddnCuentaOrigen_SelectedIndexChanged"  runat="server"></asp:DropDownList><br />
        <asp:Label ID="lblCuentaDestino" runat="server" Text="Número de cuenta destino"></asp:Label><br />
        <asp:DropDownList ID="ddnCuentaDestino" runat="server"></asp:DropDownList><br />
        <asp:Label ID="lblMonto" runat="server" Text="Digite un monto"></asp:Label><br />
        <asp:TextBox ID="txtMonto" runat="server"></asp:TextBox><asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtMonto" MinimumValue="1" Type="Integer" MaximumValue="999999" ErrorMessage="El monto debe ser mayor a cero"></asp:RangeValidator><br />
        <asp:RequiredFieldValidator ID="rrfMonto" runat="server" ControlToValidate="txtMonto" ErrorMessage="El monto es obligatorio"></asp:RequiredFieldValidator><br /><br />
        <asp:Button ID="btnEjecutar" runat="server" Text="Ejecutar" CssClass="btn btn-primary" OnClick="btnEjecutar_Click" />
    </div>
</asp:Content>
