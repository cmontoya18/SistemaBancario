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
    public partial class CrearCuentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
           
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Almacena los datos de los valores del formulario
                string numeroCuenta = txtCuenta.Text;
                Usuario objUsuario = (Usuario)Session["Usuario"];
                int idPersona = objUsuario.idPersona;

                //Abre una conexion a la base de datos para  insertar la cuenta
                using (SistemaBancarioEntities bd = new SistemaBancarioEntities())
                {
                    var cuenta = (from c in bd.spConsultaCuentaPorNumero(numeroCuenta)
                                  select c).FirstOrDefault();

                    if (cuenta != null)
                    {
                        lblMensaje.Text = "La cuenta a crear ya existe en la base de datos";

                    }
                    else
                    {
                        bd.spCrearCuentas(idPersona, numeroCuenta, DateTime.Now);
                        bd.SaveChanges();
                        lblMensaje.Text = "Se ha creado la cuenta exitosamente";
                        txtCuenta.Text = " ";

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