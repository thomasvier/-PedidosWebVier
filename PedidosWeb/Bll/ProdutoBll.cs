using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PedidosWeb.Bll
{
    public class ProdutoBll
    {
        Contexto db;

        public ProdutoBll()
        {
            db = new Contexto();
        }

        public int RetornaNovoID()
        {
            int ID = (from p in db.Produto
                      orderby p.ID descending
                      select p.ID).FirstOrDefault();

            ID++;

            return ID;
        }

        public List<Produto> RetornaProdutos()
        {
            List<Produto> Produtos = (from p in db.Produto
                                      select p).ToList();

            return Produtos;
        }

        public Produto RetornaProduto(int ID)
        {
            Produto Produto = (from p in db.Produto
                               where p.ID.Equals(ID)
                               select p).FirstOrDefault();

            return Produto;
        }

        public List<ProdutosPedido> RetornarPedidoProdutos(int PedidoID)
        {
            var PedidosProduto = (from p in db.Produto
                                  join pp in db.PedidoProduto on p.ID equals pp.ProdutoID
                                  where pp.PedidoID.Equals(PedidoID)
                                  select new ProdutosPedido
                                  {
                                      ProdutoID = p.ID,
                                      Descricao = p.Descricao,
                                      Quantidade = pp.Quantidade,
                                      PrecoUnitario = pp.PrecoUnitario,
                                      Total = pp.Total
                                  }).ToList();

            return PedidosProduto;
        }

        public class ProdutosPedido
        {
            public int ProdutoID { get; set; }
            public string Descricao { get; set; }
            public decimal? Quantidade { get; set; }
            public decimal? PrecoUnitario { get; set; }
            public decimal? Total { get; set; }
        }
    }
}