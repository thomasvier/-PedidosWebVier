using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PedidosWeb
{
    public class Produto
    {
        public int ID { get; set; }
        public string Descricao { get; set; }
        public double PrecoUnitario { get; set; }
        public decimal PrecoQuantidade { get; set; }
        public bool Ativo { get; set; }
    }
}