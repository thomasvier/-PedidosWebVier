using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PedidosWeb.Admin
{
    public partial class Pedidos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                BindarGrid();
        }

        private void BindarGrid()
        {
            List<Pedido> Pedidos = new List<Pedido>();

            Pedidos.Add(new Pedido { ID = 1, Cliente = "Cliente 1", DataEmissao = DateTime.Parse("01/05/2015"), Documento = "254863" });
            Pedidos.Add(new Pedido { ID = 2, Cliente = "Cliente 2", DataEmissao = DateTime.Parse("23/07/2015"), Documento = "878934" });
            Pedidos.Add(new Pedido { ID = 3, Cliente = "Cliente 3", DataEmissao = DateTime.Parse("05/03/2015"), Documento = "458731" });
            Pedidos.Add(new Pedido { ID = 4, Cliente = "Cliente 4", DataEmissao = DateTime.Parse("12/04/2015"), Documento = "155879" });
            Pedidos.Add(new Pedido { ID = 5, Cliente = "Cliente 5", DataEmissao = DateTime.Parse("21/06/2015"), Documento = "365248" });

            gvProdutos.DataSource = Pedidos;
            gvProdutos.DataBind();

            gvPedidos.DataSource = Pedidos;
            gvPedidos.DataBind();
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {

        }

        protected void gvPedidos_Sorting(object sender, GridViewSortEventArgs e)
        {

        }

        protected void gvPedidos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvPedidos_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}