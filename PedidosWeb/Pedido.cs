using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PedidosWeb
{
    public class Pedido
    {
        public int ID { get; set; }
        public string Documento { get; set; }
        public string Cliente { get; set; }
        public DateTime DataEmissao { get; set; }
    }
}