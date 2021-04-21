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
    public partial class CajeroAutomatico : System.Web.UI.Page
    {
        //Este proceso cargar las listas del formulario
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack == false)
            {
                Usuario objUsuario = (Usuario)Session["Usuario"];
                int idPersona = objUsuario.idPersona;

                using (SistemaBancarioEntities bd = new SistemaBancarioEntities())
                {
                    var listaTiposMovimientos = (from m in bd.spConsultaTiposCajero()
                                                 select m).ToList();
                    ddnTipoMovimiento.Items.Add(new ListItem("Seleccione un tipo"));

                    foreach( var tipos in listaTiposMovimientos)
                    {
                        var item = new ListItem(tipos.nombre,tipos.idTipoMovimiento.ToString());
                        ddnTipoMovimiento.Items.Add(item);
                    }
                    ddnTipoMovimiento.DataBind();

                    var listaCuentas = (from c in bd.spConsultaCuentas(idPersona)
                                        select c).ToList();
                    
                    ddnCuentas.Items.Add(new ListItem("Seleccione una cuenta"));
                    foreach (var cuentas in listaCuentas)
                    {
                        var item = new ListItem(cuentas.numeroCuenta , cuentas.idCuenta.ToString());
                        ddnCuentas.Items.Add(item);
                    }
                    ddnCuentas.DataBind();
                }
            }

            
        }

        // Este proceso ejecuta el proceso
        protected void btnEjecutar_Click(object sender, EventArgs e)
        {
            try
            {
                int idTipoMovimiento = int.Parse(ddnTipoMovimiento.SelectedValue);
                int idCuenta = int.Parse(ddnCuentas.SelectedValue);
                int monto = int.Parse(txtMonto.Text);
                string numeroCuenta = ddnCuentas.SelectedItem.Text;
                //Se define como 1 si es deposito o 2 si es retiro
                if(ddnTipoMovimiento.SelectedIndex == 0 || ddnCuentas.SelectedIndex == 0)
                {
                    lblMensaje.Text = "Debe seleccionar una opcion en ambas listas";
                }
                else
                {
                    //Valida si el tipo de movimiento es deposito
                    if (idTipoMovimiento == 1)
                    {
                        if (monto > 0 && monto <= 500000)
                        {
                            using (SistemaBancarioEntities bd = new SistemaBancarioEntities())
                            {
                                bd.spInsertaMovimiento(idCuenta, idTipoMovimiento, monto, DateTime.Now);
                                bd.spActualizaCuenta(monto, idCuenta, DateTime.Now);
                                bd.SaveChanges();
                            }
                            lblMensaje.Text = "Se ha realizado el deposito exitosamente";
                            txtMonto.Text = "";
                            ddnTipoMovimiento.SelectedIndex = 0;
                            ddnCuentas.SelectedIndex = 0;
                        }
                        else
                        {
                            lblMensaje.Text = "El monto no puede ser igual a cero o montos mayores a 500 mil colones.";
                        }
                    }
                    else
                    {//Realiza el proceso al no ser deposito, por ende es un retiro

                        using (SistemaBancarioEntities bd = new SistemaBancarioEntities())
                        {
                            var cuentas = (from c in bd.spConsultaCuentaPorNumero(numeroCuenta)
                                           select c).FirstOrDefault();

                            if (cuentas.saldo > monto)
                            {
                                monto = (monto * -1);
                                bd.spInsertaMovimiento(idCuenta, idTipoMovimiento, monto, DateTime.Now);
                                bd.spActualizaCuenta(monto, idCuenta, DateTime.Now);
                                bd.SaveChanges();
                                lblMensaje.Text = "Se ha realizado el retiro exitosamente";
                                txtMonto.Text = "";
                                ddnTipoMovimiento.SelectedIndex = 0;
                                ddnCuentas.SelectedIndex = 0;

                            }
                            else
                            {
                                lblMensaje.Text = "Saldo insuficiente para la transacción";
                            }

                        }

                    }
                }
                
            }
            catch
            {
                lblMensaje.Text = "Ha ocurrido un error";
            }
            
        }
    }
}