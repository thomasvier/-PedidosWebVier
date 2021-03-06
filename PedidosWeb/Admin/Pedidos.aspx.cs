﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PedidosWeb.Bll;
using Framework;

namespace PedidosWeb.Admin
{
    public partial class Pedidos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindarGrid();
                BindarProdutos();

                gvProdutos.DataSource = new DataTable();
                gvProdutos.DataBind();
            }
        }

        #region metodos privados

        private void LimparFormularioProduto()
        {
            ddlProdutos.SelectedIndex = 0;
            txtQuantidadeProduto.Text = "0,000";
            txtPrecoProduto.Text = "0,00";
        }

        private void BindarGrid()
        {
            try
            {
                PedidoBll PedidoBll = new PedidoBll();
                List<Pedido> Pedidos = PedidoBll.RetornaTodosPedidos();

                gvPedidos.DataSource = Pedidos;
                gvPedidos.DataBind();
                ViewState["Produtos"] = Pedidos.ToDataTable();
            }
            catch(Exception ex)
            {
                Msg.Erro(Resource.ContateAdminstrador, this);
            }
        }

        public void BindarClientes()
        {
            try
            {
                ClienteBll ClienteBll = new ClienteBll();
                List<Cliente> Clientes = ClienteBll.RetornarClientes();

                ddlCliente.DataSource = Clientes;
                ddlCliente.DataTextField = "NomeFantasia";
                ddlCliente.DataValueField = "ID";
                ddlCliente.DataBind();
                ddlCliente.Items.Insert(0, "Selecione");
                ddlCliente.Items[0].Value = "0";
            }
            catch(Exception ex)
            {
                Msg.Erro(Resource.ContateAdminstrador, this);
            }
        }

        private void BindarProdutos()
        {
            try
            {
                ProdutoBll ProdutoBll = new ProdutoBll();

                ddlProdutos.DataSource = ProdutoBll.RetornaProdutos();
                ddlProdutos.DataTextField = "Descricao";
                ddlProdutos.DataValueField = "ID";
                ddlProdutos.DataBind();
                ddlProdutos.Items.Insert(0, "Selecione");
                ddlProdutos.Items[0].Value = "0";
            }
            catch(Exception ex)
            {
                Msg.Erro(Resource.ContateAdminstrador, this);
            }
        }

        #endregion
        
        protected void btnProduto_Click(object sender, EventArgs e)
        {
            if (!ddlProdutos.SelectedValue.Equals("0"))
            {
                ProdutoBll ProdutoBll = new ProdutoBll();
                DataTable ProdutosTable = new DataTable();

                if (ViewState["Produtos"] != null)
                {
                    ProdutosTable = (DataTable)ViewState["Produtos"];
                }
                else
                {
                    ProdutosTable.Columns.Add("ID");
                    ProdutosTable.Columns.Add("produtoID");
                    ProdutosTable.Columns.Add("descricao");
                    ProdutosTable.Columns.Add("quantidade");
                    ProdutosTable.Columns.Add("total");
                    ProdutosTable.Columns.Add("precounitario");
                }

                int ID = int.Parse(ddlProdutos.SelectedValue);
                double Quantidade = double.TryParse(txtQuantidadeProduto.Text, out Quantidade) ? Quantidade : 0;
                double PrecoUnitario = double.TryParse(txtPrecoProduto.Text, out PrecoUnitario) ? PrecoUnitario : 0;

                Produto Produto = ProdutoBll.RetornaProduto(ID);

                double Total = Quantidade * PrecoUnitario;

                ProdutosTable.NewRow();

                ProdutosTable.Rows.Add(0, Produto.ID, Produto.Descricao, string.Format("{0:N3}", Quantidade), string.Format("{0:N}", Total), PrecoUnitario);

                ViewState["Produtos"] = ProdutosTable;

                gvProdutos.DataSource = ProdutosTable;
                gvProdutos.DataBind();

                LimparFormularioProduto();
            }
            else
            {
                Msg.Info("Selecione um produto", this);
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (gvProdutos.Rows.Count < 1)
                Msg.Info(Resource.SelecioneProduto, this);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            BindarGrid();
        }

        #region grid

        protected void gvPedidos_Sorting(object sender, GridViewSortEventArgs e)
        {

        }

        protected void gvPedidos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPedidos.PageIndex = e.NewPageIndex;
            BindarGrid();
        }

        protected void gvPedidos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName.Equals("Alterar"))
            {
                int Linha = int.Parse(e.CommandArgument.ToString());
                int ID = int.TryParse(gvPedidos.Rows[Linha].Cells[0].Text, out ID) ? ID : 0;

                try
                {
                    PedidoBll PedidoBll = new PedidoBll();
                    ProdutoBll ProdutoBll = new ProdutoBll();
                    Pedido Pedido = PedidoBll.RetornarPedido(ID);

                    txtID.Text = string.Format("{0:000000}", Pedido.ID);
                    txtDocumento.Text = Pedido.Documento;
                    txtDataEmissao.Text = string.Format("{0:dd/MM/yyyy}", Pedido.DataEmissao);
                    txtDataEntrega.Text = string.Format("{0:dd/MM/yyyy}", Pedido.DataEntrega);

                    var Produtos = ProdutoBll.RetornarPedidoProdutos(Pedido.ID);

                    gvProdutos.DataSource = Produtos;
                    gvProdutos.DataBind();
                    ViewState["Produtos"] = Produtos.ToDataTable();
                }
                catch(Exception ex)
                {
                    Msg.Erro(Resource.ContateAdminstrador, this);
                }
            }
        }

        #endregion

        protected void ddlProdutos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {                
                ProdutoBll ProdutoBll = new ProdutoBll();
                int ID = int.Parse(ddlProdutos.SelectedValue);

                if (!ID.Equals(0))
                {
                    Produto Produto = ProdutoBll.RetornaProduto(ID);

                    txtPrecoProduto.Text = string.Format("{0:N}", Produto.PrecoUnitario);
                }
            }
            catch(Exception ex)
            {
                Msg.Erro(Resource.ContateAdminstrador, this);
            }
        }

        protected void gvProdutos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Alterar"))
            {
                int Linha = int.Parse(e.CommandArgument.ToString());

                DataTable dtProdutos = (DataTable)ViewState["Produtos"];

                double Quantidade = double.TryParse(dtProdutos.Rows[Linha][3].ToString(), out Quantidade) ? Quantidade : 0;
                double PrecoProduto = double.TryParse(dtProdutos.Rows[Linha][5].ToString(), out PrecoProduto) ? PrecoProduto : 0;

                ddlProdutos.SelectedValue = dtProdutos.Rows[Linha][1].ToString();
                txtQuantidadeProduto.Text = string.Format("{0:N3}", Quantidade);
                txtPrecoProduto.Text = string.Format("{0:N}", PrecoProduto);

                dtProdutos.Rows.RemoveAt(Linha);

                ViewState["Produtos"] = dtProdutos;
                gvProdutos.DataSource = dtProdutos;
                gvProdutos.DataBind();
            }
            else if(e.CommandName.Equals("Remover"))
            {
                int Linha = int.Parse(e.CommandArgument.ToString());

                DataTable dtProdutos = (DataTable)ViewState["Produtos"];

                dtProdutos.Rows.RemoveAt(Linha);

                ViewState["Produtos"] = dtProdutos;

                gvProdutos.DataSource = dtProdutos;
                gvProdutos.DataBind();
            }
        }
    }
}