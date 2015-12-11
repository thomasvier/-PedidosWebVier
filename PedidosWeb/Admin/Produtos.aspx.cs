using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Framework;
using PedidosWeb.Bll;

namespace PedidosWeb.Admin
{
    public partial class Produtos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region métodos privados

        private void LimparFormulario()
        {
            try
            {
                txtID.Text = string.Format("{0:000000}", ProdutoBll.RetornaNovoID());
            }
            catch (Exception ex)
            {
                LogBll.InserirLog(new Log
                {
                    Login = User.Identity.Name,
                    Mensagem = ex.Message,
                    Operacao = TipoOperacao.Read.ToString(),
                    Tabela = "Produto"
                });
                Msg.Erro(Resource.ContateAdminstrador, this);
            }

            ddlFornecedor.SelectedValue = "0";
            txtDescricao.Text = string.Empty;
            txtPrecoQuantidade.Text = string.Empty;
            txtPrecoUnitario.Text = string.Empty;
            txtQuantidadeReposicao.Text = string.Empty;
            cbAtivo.Checked = true;

            hfTipoOperacao.Value = TipoOperacao.Create.ToString();
        }

        private void BindarGrid()
        {
            try
            {
                ProdutoBll produtoBll = new ProdutoBll();

                gvProdutos.DataSource = produtoBll.BuscarProdutos(txtFiltro.Text);
                gvProdutos.DataBind();
            }
            catch (Exception ex)
            {
                LogBll.InserirLog(new Log
                {
                    Login = User.Identity.Name,
                    Mensagem = ex.Message,
                    Operacao = TipoOperacao.Read.ToString(),
                    Tabela = "Produto"
                });
                Msg.Erro(Resource.ContateAdminstrador, this);
            }
        }

        private void InserirProduto()
        {
            Produto produto = new Produto();

            try
            {
                ProdutoBll produtoBll = new ProdutoBll();
                int fornecedorID = int.TryParse(ddlFornecedor.SelectedValue, out fornecedorID) ? fornecedorID : 0;
                decimal precoUnitario = decimal.TryParse(txtPrecoUnitario.Text, out precoUnitario) ? precoUnitario : 0;
                decimal precoQuantidade = decimal.TryParse(txtPrecoQuantidade.Text, out precoQuantidade) ? precoQuantidade : 0;
                decimal quantidadeReposicao = decimal.TryParse(txtQuantidadeReposicao.Text, out quantidadeReposicao) ? quantidadeReposicao : 0;

                produto.Ativo = cbAtivo.Checked;
                produto.Descricao = txtDescricao.Text;
                //TODO: IMPLEMENTAR
                //produto.EmpresaID
                //produto.FornecedorID = fornecedorID;
                produto.PrecoQuantidade = precoQuantidade;
                produto.PrecoUnitario = precoUnitario;

                produtoBll.InserirProduto(produto);

                LimparFormulario();

                LogBll.InserirLog(new Log
                {
                    ItemID = produto.ID,
                    Login = Context.User.Identity.Name,
                    Operacao = TipoOperacao.Create.ToString(),
                    Tabela = "Produto"
                });

                Msg.Sucesso(Resource.ItemSalvoSucesso, this);
            }
            catch (Exception ex)
            {
                LogBll.InserirLog(new Log
                {
                    ItemID = produto.ID,
                    Login = Context.User.Identity.Name,
                    Mensagem = ex.Message,
                    Operacao = TipoOperacao.Update.ToString(),
                    Tabela = "Produto"
                });

                Msg.Erro(Resource.ContateAdminstrador, this);
            }
        }

        private void AlterarProduto()
        {
            int ID = int.TryParse(txtID.Text, out ID) ? ID : 0;

            try
            {
                ProdutoBll produtoBll = new ProdutoBll();
                Produto produto = produtoBll.RetornaProduto(ID);
                int fornecedorID = int.TryParse(ddlFornecedor.SelectedValue, out fornecedorID) ? fornecedorID : 0;
                decimal precoUnitario = decimal.TryParse(txtPrecoUnitario.Text, out precoUnitario) ? precoUnitario : 0;
                decimal precoQuantidade = decimal.TryParse(txtPrecoQuantidade.Text, out precoQuantidade) ? precoQuantidade : 0;
                decimal quantidadeReposicao = decimal.TryParse(txtQuantidadeReposicao.Text, out quantidadeReposicao) ? quantidadeReposicao : 0;

                produto.Ativo = cbAtivo.Checked;
                produto.Ativo = cbAtivo.Checked;
                produto.Descricao = txtDescricao.Text;
                //TODO: IMPLEMENTAR
                //produto.EmpresaID
                //produto.FornecedorID = fornecedorID;
                produto.PrecoQuantidade = precoQuantidade;
                produto.PrecoUnitario = precoUnitario;

                produtoBll.AlterarProduto(produto);

                LimparFormulario();

                LogBll.InserirLog(new Log
                {
                    ItemID = ID,
                    Login = Context.User.Identity.Name,
                    Operacao = TipoOperacao.Update.ToString(),
                    Tabela = "Produto"
                });

                Msg.Sucesso(Resource.ItemSalvoSucesso, this);
            }
            catch (Exception ex)
            {
                LogBll.InserirLog(new Log
                {
                    ItemID = ID,
                    Login = Context.User.Identity.Name,
                    Mensagem = ex.Message,
                    Operacao = TipoOperacao.Update.ToString(),
                    Tabela = "Produto"
                });

                Msg.Erro(Resource.ContateAdminstrador, this);
            }
        }

        #endregion

        #region buttons

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (hfTipoOperacao.Value.Equals(TipoOperacao.Create.ToString()))
            {
                InserirProduto();
            }
            else if (hfTipoOperacao.Value.Equals(TipoOperacao.Update.ToString()))
            {
                AlterarProduto();
            }

            BindarGrid();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparFormulario();
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            BindarGrid();
        }

        #endregion

        protected void gvProdutos_Sorting(object sender, GridViewSortEventArgs e)
        {

        }

        protected void gvProdutos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProdutos.PageIndex = e.NewPageIndex;
            BindarGrid();
        }

        protected void gvProdutos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Alterar"))
            {
                int index = int.Parse(e.CommandArgument.ToString());
                int ID = int.TryParse(gvProdutos.Rows[index].Cells[1].Text, out ID) ? ID : 0;

                try
                {
                    ProdutoBll produtoBll = new ProdutoBll();
                    Produto produto = produtoBll.RetornaProduto(ID);

                    txtID.Text = string.Format("{0:000000}", produto.ID);
                    txtDescricao.Text = produto.Descricao;
                    txtPrecoQuantidade.Text = string.Format("{0:C}", produto.PrecoQuantidade);
                    txtPrecoUnitario.Text = string.Format("{0:C}", produto.PrecoUnitario);
                    cbAtivo.Checked = produto.Ativo.Equals(1) ? true : false;

                    hfTipoOperacao.Value = TipoOperacao.Update.ToString();
                }
                catch (Exception ex)
                {
                    LogBll.InserirLog(new Log
                    {
                        ItemID = ID,
                        Login = User.Identity.Name,
                        Mensagem = ex.Message,
                        Operacao = TipoOperacao.Read.ToString(),
                        Tabela = "Produto"
                    });

                    Msg.Erro(Resource.ContateAdminstrador, this);
                }
            }
        }        
    }
}