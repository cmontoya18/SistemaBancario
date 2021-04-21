using SistemaBancario.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaBancario.Pages
{
    public partial class ListaMovimientos : System.Web.UI.Page
    {
        // Este proceso se encarga de obtener la lista de cuentas del usuario de sesion que se recibe,
        protected void Page_Load(object sender, EventArgs e)
        {
            int idCuenta = int.Parse(Request.QueryString["id"]);
            using (SistemaBancarioEntities bd = new SistemaBancarioEntities())
            {
                var listaMovimientos = (from m in bd.spConsultaMovimientos(idCuenta)
                                        select m).ToList();

                grdListaMovimientos.DataSource = listaMovimientos;
                grdListaMovimientos.DataBind();
            }
        }
    }
}