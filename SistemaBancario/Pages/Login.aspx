<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SistemaBancario.Pages.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="text-center">Login</h1>
    <div>
        <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
    </div>
    <div class="text-center">
        <asp:Label ID="lblUsuario" runat="server" Text="Digite su usuario"></asp:Label> <br />
        <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox> <br />
        <asp:RequiredFieldValidator ID="rfvUsuario" ControlToValidate="txtUsuario" runat="server" ErrorMessage="Campo requerido"></asp:RequiredFieldValidator> <br />
        <asp:Label ID="lblClave" runat="server" Text="Digite su clave"></asp:Label> <br />
        <asp:TextBox ID="txtClave" runat="server"></asp:TextBox> <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtClave" runat="server" ErrorMessage="Campo requerido"></asp:RequiredFieldValidator><br />
        <asp:Button ID="btnEntrar" runat="server" Text="Entrar"  CssClass=" btn btn-primary" OnClick="btnEntrar_Click"/>
    </div>
</asp:Content>
