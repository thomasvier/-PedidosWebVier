using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PedidosWeb.Bll
{
    public class ProdutoBll
    {
        #region teste

        List<Produto> db = new List<Produto>(new List<Produto> 
                            { 
                                new Produto { ID = 1, Descricao = "Produto 1", PrecoUnitario = 12.50, Ativo = true },
                                new Produto { ID = 2, Descricao = "Produto ", PrecoUnitario = 21.50, Ativo = true },
                                new Produto { ID = 3, Descricao = "Produto 3", PrecoUnitario = 16.20, Ativo = true },
                                new Produto { ID = 4, Descricao = "Produto 4", PrecoUnitario = 14.00, Ativo = true },
                                new Produto { ID = 5, Descricao = "Produto 5", PrecoUnitario = 40.10, Ativo = true },
                                new Produto { ID = 6, Descricao = "Produto 6", PrecoUnitario = 13.50, Ativo = true },
                                new Produto { ID = 7, Descricao = "Produto 7", PrecoUnitario = 45.50, Ativo = true },
                                new Produto { ID = 8, Descricao = "Produto 8", PrecoUnitario = 13.50, Ativo = true },
                                new Produto { ID = 9, Descricao = "Produto 9", PrecoUnitario = 14.40, Ativo = true },
                                new Produto { ID = 10, Descricao = "Produto 10", PrecoUnitario = 21.50, Ativo = true },
                                new Produto { ID = 11, Descricao = "Produto 11", PrecoUnitario = 45.50, Ativo = true },
                                new Produto { ID = 12, Descricao = "Produto 12", PrecoUnitario = 29.90, Ativo = true },
                                new Produto { ID = 13, Descricao = "Produto 13", PrecoUnitario = 32.50, Ativo = true },
                                new Produto { ID = 14, Descricao = "Produto 14", PrecoUnitario = 45.50, Ativo = true },
                                new Produto { ID = 15, Descricao = "Produto 15", PrecoUnitario = 12.50, Ativo = true },
                                new Produto { ID = 16, Descricao = "Produto 16", PrecoUnitario = 16.50, Ativo = true },
                                new Produto { ID = 17, Descricao = "Produto 17", PrecoUnitario = 11.50, Ativo = true },
                                new Produto { ID = 18, Descricao = "Produto 18", PrecoUnitario = 18.60, Ativo = true },
                                new Produto { ID = 19, Descricao = "Produto 19", PrecoUnitario = 12.50, Ativo = true }

                            });
        #endregion

        public int RetornaNovoID()
        {
            int ID = (from p in db
                      orderby p.ID descending
                      select p.ID).FirstOrDefault();

            ID++;

            return ID;
        }

        public List<Produto> RetornaProdutos()
        {
            List<Produto> Produtos = (from p in db
                                      select p).ToList();

            return Produtos;
        }

        public Produto RetornaProduto(int ID)
        {
            Produto Produto = (from p in db
                               where p.ID.Equals(ID)
                               select p).FirstOrDefault();

            return Produto;
        }
    }
}