//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PedidosWeb
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pedido
    {
        public int ID { get; set; }
        public string Documento { get; set; }
        public Nullable<int> ClienteID { get; set; }
        public Nullable<System.DateTime> DataEmissao { get; set; }
        public Nullable<System.DateTime> DataEntrega { get; set; }
        public Nullable<int> Status { get; set; }
        public string Login { get; set; }
    }
}
