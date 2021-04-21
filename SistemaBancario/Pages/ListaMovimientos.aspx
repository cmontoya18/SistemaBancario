<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaMovimientos.aspx.cs" Inherits="SistemaBancario.Pages.ListaMovimientos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Lista de movimientos</h1>
    <div>
        <asp:GridView ID="grdListaMovimientos" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-condensed">
            <Columns>
                <asp:BoundField DataField="fechaDelMovimiento" HeaderText="Fecha" DataFormatString="{0: dd/MM/yyyy}" />
                <asp:BoundField DataField="numeroCuenta" HeaderText ="Cuenta" />
                <asp:BoundField DataField="nombre" HeaderText="Tipo" />
                <asp:BoundField DataField="monto" HeaderText="Monto" HtmlEncode="false" DataFormatString="{0:C2}" />
            </Columns>
        </asp:GridView>
    </div>
    <div>
        <a href="ConsultarMovimientos.aspx" class="btn btn-primary">Regresar</a>
    </div>
</asp:Content>
