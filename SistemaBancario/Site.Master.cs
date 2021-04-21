using SistemaBancario.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaBancario
{
    public partial class SiteMaster : MasterPage
    {
        //Crea ua variable de sesion y la inserta  en un objeto

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack == false)
            {
                // Si la variable de sesion no es nula muestra todas las opciones del menú
                if (Session["Usuario"] != null)
                {
                    Usuario objUsuario2 = (Usuario)Session["Usuario"];
                    lblUsuario.Text = objUsuario2.nombreCompleto;
                    lnkCerrarSesion.Visible = true;
                    lnkCajero.Visible = true;
                    lnkConsultarMovimientos.Visible = true;
                    lnkTransferencias.Visible = true;
                    lblTituloUsuario.Visible = true;
                    lblUsuario.Visible = true;
                }
                else
                {
                    lblTituloUsuario.Visible = false;
                    lblUsuario.Visible = false;

                }
                
            }
        }

        //Este proceso limpia las variables de sesion y regresa al menu inicial de login.
        protected void lnkCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("~/Pages/Login.aspx");
        }
    }
}