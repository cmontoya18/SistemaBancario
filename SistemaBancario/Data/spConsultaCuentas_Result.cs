//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SistemaBancario.Data
{
    using System;
    
    public partial class spConsultaCuentas_Result
    {
        public int idCuenta { get; set; }
        public int idPersona { get; set; }
        public string numeroCuenta { get; set; }
        public decimal saldo { get; set; }
        public System.DateTime fechaCreacion { get; set; }
        public Nullable<System.DateTime> fechaModificacion { get; set; }
    }
}