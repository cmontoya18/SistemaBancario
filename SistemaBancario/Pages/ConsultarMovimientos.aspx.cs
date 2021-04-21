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
    //Este proceso se encarga de consultar los movimientos de un usuario
    public partial class ConsultarMovimientos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario objUsuario = (Usuario)Session["Usuario"];
            using (SistemaBancarioEntities bd = new SistemaBancarioEntities())
            {
                var detalleCuentas = (from c in bd.spConsultaCuentas(objUsuario.idPersona)
                                      select c).ToList();

                grdMovimientos.DataSource = detalleCuentas;
                grdMovimientos.DataBind();
            }

        }
    }
}