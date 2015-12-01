using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PedidosWeb.Bll
{
    public enum StatusPedido
    {
        Pendente = 0,
        Confirmado = 1,
        Entregue = 2,
        Cancelado = 3,
        Todos = 999
    }
}