using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PedidosWeb.Bll
{
    public class PedidoBll
    {
        #region teset
       
        public List<Pedido> db = new List<Pedido>(new List<Pedido> 
                                                {
                                                    new Pedido { ID = 1, ClienteID = 1, Cliente = "Cliente 1", Documento = "487965", DataEmissao =  DateTime.Parse(string.Format("{0:dd/MM/yyyy}", "01/05/2015"))},
                                                  new Pedido { ID = 2, ClienteID = 1, Cliente = "Cliente 2", Documento = "545234", DataEmissao =  DateTime.Parse(string.Format("{0:dd/MM/yyyy}", "13/04/2015"))},
                                                  new Pedido { ID = 3, ClienteID = 1, Cliente = "Cliente 2", Documento = "403648", DataEmissao =  DateTime.Parse(string.Format("{0:dd/MM/yyyy}", "22/12/2015"))},
                                                  new Pedido { ID = 4, ClienteID = 1, Cliente = "Cliente 3", Documento = "248796", DataEmissao =  DateTime.Parse(string.Format("{0:dd/MM/yyyy}", "14/01/2015"))},
                                                  new Pedido { ID = 5, ClienteID = 1, Cliente = "Cliente 4", Documento = "123648", DataEmissao =  DateTime.Parse(string.Format("{0:dd/MM/yyyy}", "19/05/2015"))},
                                                  new Pedido { ID = 6, ClienteID = 1, Cliente = "Cliente 5", Documento = "698034", DataEmissao =  DateTime.Parse(string.Format("{0:dd/MM/yyyy}", "26/06/2015"))},
                                                  new Pedido { ID = 7, ClienteID = 1, Cliente = "Cliente 6", Documento = "025789", DataEmissao =  DateTime.Parse(string.Format("{0:dd/MM/yyyy}", "05/10/2015"))},
                                                  new Pedido { ID = 8, ClienteID = 1, Cliente = "Cliente 7", Documento = "487993", DataEmissao =  DateTime.Parse(string.Format("{0:dd/MM/yyyy}", "09/12/2015"))},
                                                  new Pedido { ID = 9, ClienteID = 1, Cliente = "Cliente 9", Documento = "125789", DataEmissao =  DateTime.Parse(string.Format("{0:dd/MM/yyyy}", "29/06/2015"))},
                                                  new Pedido { ID = 10, ClienteID = 1, Cliente = "Cliente 10", Documento = "789964", DataEmissao =  DateTime.Parse(string.Format("{0:dd/MM/yyyy}", "30/08/2015"))},
                                                  new Pedido { ID = 12, ClienteID = 1, Cliente = "Cliente 11", Documento = "698723", DataEmissao =  DateTime.Parse(string.Format("{0:dd/MM/yyyy}", "12/10/2015"))},
                                                  new Pedido { ID = 13, ClienteID = 1, Cliente = "Cliente 12", Documento = "125778", DataEmissao =  DateTime.Parse(string.Format("{0:dd/MM/yyyy}", "03/11/2015"))},
                                                  new Pedido { ID = 14, ClienteID = 1, Cliente = "Cliente 13", Documento = "657234", DataEmissao =  DateTime.Parse(string.Format("{0:dd/MM/yyyy}", "07/01/2015"))},
                                                  new Pedido { ID = 15, ClienteID = 1, Cliente = "Cliente 14", Documento = "026879", DataEmissao =  DateTime.Parse(string.Format("{0:dd/MM/yyyy}", "15/02/2015"))},
                                                  new Pedido { ID = 16, ClienteID = 1, Cliente = "Cliente 15", Documento = "854687", DataEmissao =  DateTime.Parse(string.Format("{0:dd/MM/yyyy}", "18/02/2015"))},
                                                  new Pedido { ID = 17, ClienteID = 1, Cliente = "Cliente 16", Documento = "268789", DataEmissao =  DateTime.Parse(string.Format("{0:dd/MM/yyyy}", "28/06/2015"))},
                                                  new Pedido { ID = 18, ClienteID = 1, Cliente = "Cliente 17", Documento = "478893", DataEmissao =  DateTime.Parse(string.Format("{0:dd/MM/yyyy}", "25/04/2015"))},
                                                  new Pedido { ID = 19, ClienteID = 1, Cliente = "Cliente 18", Documento = "887931", DataEmissao =  DateTime.Parse(string.Format("{0:dd/MM/yyyy}", "02/09/2015"))},
                                                  new Pedido { ID = 20, ClienteID = 1, Cliente = "Cliente 19", Documento = "098746", DataEmissao =  DateTime.Parse(string.Format("{0:dd/MM/yyyy}", "07/08/2015"))}
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

        public IList<Pedido> BuscarPedidos(int ClienteID, DateTime Data, StatusPedido Status)
        {
            List<Pedido> Pedidos = (from p in db                                    
                                    select p).ToList();

            if (ClienteID > 0)
                Pedidos = Pedidos.Where(x => x.ClienteID.Equals(ClienteID)).ToList();

            if (Data != DateTime.MinValue)
                Pedidos = Pedidos.Where(x => x.DataEmissao.Date >= Data && x.DataEmissao.Date <= Data).ToList();

            if (Status != StatusPedido.Todos)
                Pedidos = Pedidos.Where(x => x.Status.Equals(Status.GetHashCode())).ToList();

            return Pedidos;
        }

        public List<Pedido> RetornaTodosPedidos()
        {
            List<Pedido> Pedidos = (from p in db
                                    select p).ToList();

            return Pedidos;
        }

        public List<Pedido> RetornarPedidosCliente(int ClienteID)
        {
            List<Pedido> Pedidos = (from p in db
                                    where p.ClienteID.Equals(ClienteID)
                                    select p).ToList();

            return Pedidos;
        }

        public Pedido RetornaPedido(int ID)
        {
            Pedido Pedido = (from p in db
                             where p.ID.Equals(ID)
                             select p).FirstOrDefault();

            return Pedido;
        }


    }
}