using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PedidosWeb.Bll
{
    public class ClienteBll
    {
        Contexto db;

        public ClienteBll()
        {
            db = new Contexto();
        }

        /// <summary>
        /// Retorna novo ID de cliente
        /// </summary>
        /// <returns></returns>
        public int RetornarNovoID()
        {
            int ID = (from c in db.Cliente
                      orderby c.ID descending
                      select c.ID).FirstOrDefault();

            ID++;

            return ID;
        }

        public Cliente RetornarCliente(int ID)
        {
            Cliente Cliente = (from c in db.Cliente
                               where c.ID.Equals(ID)
                               select c).FirstOrDefault();

            return Cliente;
        }


        /// <summary>
        /// Retorna todos os clientes ativos
        /// </summary>
        /// <returns></returns>
        public List<Cliente> RetornarClientes()
        {
            List<Cliente> Clientes = (from c in db.Cliente
                                      where c.Ativo.Equals(true)
                                      select c).ToList();

            return Clientes;
        }
    }
}