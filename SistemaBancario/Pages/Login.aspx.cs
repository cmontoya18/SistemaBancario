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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         

        }

        // En este proceso se crear la variable de entorno para iniciar sesion y validarla con la base de datos.
        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            Usuario objUsuario = new Usuario();
            objUsuario.usuario = txtUsuario.Text;
            objUsuario.clave = txtClave.Text;

            Session["Login"] = objUsuario;

            Usuario objUsuario2 = (Usuario)Session["Login"];
           
            try
            {
                using (SistemaBancarioEntities db = new SistemaBancarioEntities())
                {
                    var usuario = (from u in db.spConsultaUsuarios(objUsuario2.usuario, objUsuario2.clave)
                                   select u).FirstOrDefault();

                    if (usuario.idPersona != 0)
                    {
                        Usuario objUsuario3 = new Usuario();
                        objUsuario3.idPersona = usuario.idPersona;
                        objUsuario3.nombreCompleto = usuario.nombreCompleto;
                        objUsuario3.cedula = usuario.cedula;
                        Session["Usuario"] = objUsuario3;
                        Response.Redirect("~/Pages/ConsultarMovimientos.aspx");
                    }
                    else
                    {
                        lblMensaje.Text = "Los datos digitados no son los correctos";
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