using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PedidosWeb.Bll
{
    public class PedidoBll
    {
        Contexto db;

        public PedidoBll()
        {
            db = new Contexto();
        }

        public int RetornaNovoID()
        {            
            int ID = (from p in db.Pedido
                      orderby p.ID descending
                      select p.ID).FirstOrDefault();

            ID++;

            return ID;
        }

        public IList<Pedido> BuscarPedidos(int ClienteID, DateTime Data, StatusPedido Status)
        {
            List<Pedido> Pedidos = (from p in db.Pedido                                   
                                    select p).ToList();

            if (ClienteID > 0)
                Pedidos = Pedidos.Where(x => x.ClienteID.Equals(ClienteID)).ToList();

            if (Data != DateTime.MinValue)
                Pedidos = Pedidos.Where(x => x.DataEmissao.Value.Date >= Data && x.DataEmissao.Value.Date <= Data).ToList();

            if (Status != StatusPedido.Todos)
                Pedidos = Pedidos.Where(x => x.Status.Equals(Status.GetHashCode())).ToList();

            return Pedidos;
        }

        public List<Pedido> RetornaTodosPedidos()
        {
            List<Pedido> Pedidos = (from p in db.Pedido
                                    select p).ToList();

            return Pedidos;
        }

        public List<Pedido> RetornarPedidosCliente(int ClienteID)
        {
            List<Pedido> Pedidos = (from p in db.Pedido
                                    where p.ClienteID.Equals(ClienteID)
                                    select p).ToList();

            return Pedidos;
        }

        public Pedido RetornaPedido(int ID)
        {
            Pedido Pedido = (from p in db.Pedido
                             where p.ID.Equals(ID)
                             select p).FirstOrDefault();

            return Pedido;
        }


    }
}