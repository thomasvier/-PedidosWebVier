using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PedidosWeb
{
    public class PedidoProduto
    {
        public int ID { get; set; }
        public int ProdutoID { get; set; }
        public string Descricao { get; set; }
        public double Quantidade { get; set; }
        public double Total { get; set; }
        public double PrecoUnitario { get; set; }
    }
}