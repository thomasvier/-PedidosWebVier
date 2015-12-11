using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace PedidosWeb.Bll
{
    public class ProdutoBll
    {
        Contexto db;

        public ProdutoBll()
        {
            db = new Contexto();
        }

        public static int RetornaNovoID()
        {
            Contexto db = new Contexto();

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

        public List<Produto> BuscarProdutos(string Filto)
        {
            var Produtos = (from cf in db.Produto
                            select cf);

            if (!string.IsNullOrEmpty(Filto))
                Produtos = Produtos.Where(x => x.Descricao.Contains(Filto));

            return Produtos.ToList();
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

        /// <summary>
        /// Insere um novo produto
        /// </summary>
        /// <param name="Produto"></param>
        public void InserirProduto(Produto Produto)
        {
            Produto.ID = RetornaNovoID();

            db.Produto.Add(Produto);
            db.SaveChanges();
        }

        /// <summary>
        /// Método que altera uma produto existente
        /// </summary>
        /// <param name="Produto"></param>
        public void AlterarProduto(Produto Produto)
        {
            db.Produto.Attach(Produto);
            db.Entry(Produto).State = EntityState.Modified;
            db.SaveChanges();
        }

        /// <summary>
        /// Método que remove uma produto
        /// </summary>
        /// <param name="empresa"></param>
        public void RemoverProduto(Produto Produto)
        {
            db.Produto.Remove(Produto);
            db.SaveChanges();
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