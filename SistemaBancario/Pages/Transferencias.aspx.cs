using SistemaBancario.Clases;
using SistemaBancario.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaBancario.Pages
{
    public partial class Transferencias : System.Web.UI.Page
    {
        //Este proceso se encarga de llenar las listas
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack == false)
            {
                Usuario objUsuario = (Usuario)Session["Usuario"];
                int idPersona = objUsuario.idPersona;

                using (SistemaBancarioEntities bd = new SistemaBancarioEntities())
                {
                    var listaCuentasUsuario = (from m in bd.spConsultaCuentas(objUsuario.idPersona)
                                               select m).ToList();
                    ddnCuentaOrigen.Items.Add(new ListItem("Seleccione una cuenta de origen"));

                    foreach (var cuentas in listaCuentasUsuario)
                    {
                        var item = new ListItem(cuentas.numeroCuenta, cuentas.idCuenta.ToString());
                        ddnCuentaOrigen.Items.Add(item);
                    }
                    ddnCuentaOrigen.DataBind();
                }
                ddnCuentaDestino.Items.Add(new ListItem("Seleccione una cuenta de destino"));
                ddnCuentaDestino.DataBind();
            }
        }

        //Esta clase se encarga de llenar el dropdownlist de cuentas de destino basado en la cuenta de origen elegida.
        private void CargarCuentasDestino()
        {
            ddnCuentaDestino.Items.Clear();
            string idCuentaOrigen = ddnCuentaOrigen.SelectedItem.Value;
            //Se valida que la cuenta de origen haya sido seleccionada.
            if (idCuentaOrigen == "")
            {
                ddnCuentaDestino.Items.Add(new ListItem("Seleccione una cuenta de destino"));
                ddnCuentaDestino.DataBind();
            }
            else
            {
                using (SistemaBancarioEntities bd = new SistemaBancarioEntities())
                {

                    var listaCuentasDestino = (from c in bd.spConsultaCuentaDestino(int.Parse(idCuentaOrigen))
                                               select c).ToList();

                    ddnCuentaDestino.Items.Add(new ListItem("Seleccione una cuenta de destino"));
                    foreach (var cuentas in listaCuentasDestino)
                    {
                        var item = new ListItem(cuentas.numeroCuenta, cuentas.idCuenta.ToString());
                        ddnCuentaDestino.Items.Add(item);
                    }
                    ddnCuentaDestino.DataBind();
                }
            }
        }

        //Este proceso se encarga de ejecutar la acción de realizar la transferencia
        protected void btnEjecutar_Click(object sender, EventArgs e)
        {
            try
            {
                //Se valida que el usuario haya selecciodo una opcion
                if (ddnCuentaOrigen.SelectedIndex == 0 || ddnCuentaDestino.SelectedIndex == 0)
                {
                    lblMensaje.Text = "Debe seleccionar una opcion en ambas listas";
                }
                else
                {
                    int monto = int.Parse(txtMonto.Text);

                    //Se valida que el monto no sea mayor o igual a 250 mil colones 
                    if (monto >= 250000)
                    {
                        lblMensaje.Text = "Solo se permiten transferencias menores a 250 mil colones";
                    }
                    else
                    {
                        //Si el monto es inferior a 250 mil colones se procede a insertar en la base de datos
                        using (SistemaBancarioEntities bd = new SistemaBancarioEntities())
                        {
                            var cuenta = (from c in bd.spConsultaCuentaPorNumero(ddnCuentaOrigen.SelectedItem.Text)
                                          select c).FirstOrDefault();

                            //Si el saldo de la cuenta es menor a lo que se desea transferir no se permite
                            if (cuenta.saldo < monto)
                            {
                                lblMensaje.Text = "El monto a transferir es mayor al saldo de la cuenta";
                            }
                            else
                            {
                                int idCuentaOrigen = int.Parse(ddnCuentaOrigen.SelectedItem.Value);
                                int idCuentaDestino = int.Parse(ddnCuentaDestino.SelectedItem.Value);

                                bd.spInsertaTransferencias(idCuentaOrigen, idCuentaDestino, monto, DateTime.Now);
                                bd.spInsertaMovimiento(idCuentaOrigen, 3, (monto * -1), DateTime.Now);
                                bd.spInsertaMovimiento(idCuentaDestino, 4, monto, DateTime.Now);
                                bd.spActualizaCuenta((monto * -1), idCuentaOrigen, DateTime.Now);
                                bd.spActualizaCuenta(monto, idCuentaDestino, DateTime.Now);
                                bd.SaveChanges();

                                lblMensaje.Text = "La transferencia se ha efectuado exitosamente";
                                txtMonto.Text = "";
                                ddnCuentaOrigen.SelectedIndex = 0;
                                ddnCuentaDestino.SelectedIndex = 0;
                            }
                        }
                    }
                }
            }
            catch
            {

            }
        }
        
        //Este proceso llama al metodo de cargar las cuentas de destino
        protected void ddnCuentaOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.CargarCuentasDestino();
            }
            catch
            {
                lblMensaje.Text = "Ha ocurrido un error";
            }
            
        }
    }
}