<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultarMovimientos.aspx.cs" Inherits="SistemaBancario.Pages.ConsultarMovimientos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Consultar Movimientos</h1>
    <div>
        <asp:GridView ID="grdMovimientos" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-condensed">
            <Columns>
                <asp:BoundField DataField="numeroCuenta" HeaderText="Cuenta" />
                <asp:BoundField DataField="saldo" HeaderText="Saldo" HtmlEncode="false" DataFormatString="{0:C2}" />
                <asp:BoundField DataField="fechaModificacion" HeaderText="Última modificación" DataFormatString="{0: dd/MM/yyyy}" />
                <asp:TemplateField HeaderText="Movimientos">
                    <ItemTemplate>
                        <a href="ListaMovimientos.aspx?id=<%# Eval("idCuenta") %>">Ver movimientos</a>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <div>
        <a href="CrearCuentas.aspx" class="btn btn-primary">Crear cuenta</a>
    </div>
</asp:Content>
