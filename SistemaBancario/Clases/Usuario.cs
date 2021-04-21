using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


// Esta clase se encarga de almacenar los parametros necesarios para inicio de sesion.
namespace SistemaBancario.Clases
{
    public class Usuario
    {
        public string usuario { set; get; }
        public string clave { set; get; }

        public int idPersona { set; get; }

        public string  nombreCompleto { set; get; }

        public string cedula { set; get; }
    }
}