using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.UI.WebControls;

namespace PedidosWeb.Bll
{
    public class ClienteBll
    {
        Contexto db;

        //Construtor
        public ClienteBll()
        {
            db = new Contexto();
        }

        /// <summary>
        /// Retorna um novo ID
        /// </summary>
        /// <returns></returns>
        public static int RetornaNovoID()
        {
            Contexto db = new Contexto();

            int ID = (from cf in db.Cliente
                      orderby cf.ID descending
                      select cf.ID).FirstOrDefault();

            ID++;

            return ID;
        }

        /// <summary>
        /// Método que busca clientes/fornecedores
        /// </summary>
        /// <param name="gvSortEventArgs"></param>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public List<Cliente> BuscaClientes(string filtro)
        {
            var Clientes = (from cf in db.Cliente
                            select cf);

            if (!string.IsNullOrEmpty(filtro))
                Clientes = Clientes.Where(x => x.RazaoSocial.Contains(filtro) || x.NomeFantasia.Contains(filtro));

            return Clientes.ToList();
        }

        /// <summary>
        /// Método que retorna um cliente/fornecedor
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Cliente RetornarCliente(int ID)
        {
            Cliente Cliente = (from cf in db.Cliente
                               where cf.ID.Equals(ID)
                               select cf).FirstOrDefault();

            return Cliente;
        }

        public List<Cliente> RetornarClientes()
        {
            List<Cliente> Clientes = (from c in db.Cliente
                                      where c.Ativo.Equals(true)
                                      select c).ToList();

            return Clientes;
        }
        /// <summary>
        /// Insere um novo cliente/fornecedor
        /// </summary>
        /// <param name="Cliente"></param>
        public void InserirCliente(Cliente Cliente)
        {
            Cliente.ID = RetornaNovoID();

            db.Cliente.Add(Cliente);
            db.SaveChanges();
        }

        /// <summary>
        /// Método que altera uma client/fornecedor existente
        /// </summary>
        /// <param name="Cliente"></param>
        public void AlterarCliente(Cliente Cliente)
        {
            db.Cliente.Attach(Cliente);
            db.Entry(Cliente).State = EntityState.Modified;
            db.SaveChanges();
        }

        /// <summary>
        /// Método que remove uma cliente/fornecedor
        /// </summary>
        /// <param name="empresa"></param>
        public void RemoverCliente(Cliente Cliente)
        {
            db.Cliente.Remove(Cliente);
            db.SaveChanges();
        }
    }
}