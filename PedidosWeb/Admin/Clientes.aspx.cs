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
    public partial class Clientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region metodos privados

        private void LimparFormulario()
        {
            try
            {
                txtID.Text = string.Format("{0:000000}", ClienteBll.RetornaNovoID());
            }
            catch (Exception ex)
            {
                LogBll.InserirLog(new Log
                {
                    Login = User.Identity.Name,
                    Mensagem = ex.Message,
                    Operacao = TipoOperacao.Read.ToString(),
                    Tabela = "Cliente"
                });
                Msg.Erro(Resource.ContateAdminstrador, this);
            }

            txtBairro.Text = string.Empty;
            txtCelular.Text = string.Empty;
            txtCep.Text = string.Empty;
            txtCidade.Text = string.Empty;
            txtComplemento.Text = string.Empty;
            txtCPFCNPJ.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtEndereco.Text = string.Empty;
            txtInscricaoEstadual.Text = string.Empty;
            txtNomeFantasia.Text = string.Empty;
            txtNumero.Text = string.Empty;
            txtRazaoSocial.Text = string.Empty;
            txtTelefone.Text = string.Empty;
            cbAtivo.Checked = true;

            hfTipoOperacao.Value = TipoOperacao.Create.ToString();
        }

        private void BindarGrid()
        {
            try
            {
                ClienteBll clienteBll = new ClienteBll();

                gvClientes.DataSource = clienteBll.BuscaClientes(txtFiltro.Text);
                gvClientes.DataBind();
            }
            catch (Exception ex)
            {
                LogBll.InserirLog(new Log
                {
                    Login = User.Identity.Name,
                    Mensagem = ex.Message,
                    Operacao = TipoOperacao.Read.ToString(),
                    Tabela = "Cliente"
                });
                Msg.Erro(Resource.ContateAdminstrador, this);
            }
        }

        private void InserirCliente()
        {
            Cliente cliente = new Cliente();

            try
            {
                ClienteBll clienteBll = new ClienteBll();

                cliente.Ativo = cbAtivo.Checked;
                cliente.Bairro = txtBairro.Text;
                cliente.Celular = txtCelular.Text;
                cliente.Cep = txtCep.Text;
                cliente.Cidade = txtCidade.Text;
                cliente.Complemento = txtComplemento.Text;
                cliente.CPFCNPJ = txtCPFCNPJ.Text;
                cliente.Email = txtEmail.Text;
                //TODO: desenvolver conceito de empresa
                //cliente.EmpresaID
                cliente.Endereco = txtEndereco.Text;
                //TODO: Inserir campo estado
                //cliente.Estado = 
                cliente.InscricaoEstadual = txtInscricaoEstadual.Text;
                cliente.NomeFantasia = txtNomeFantasia.Text;
                cliente.Numero = txtNumero.Text;
                cliente.RazaoSocial = txtRazaoSocial.Text;
                cliente.Telefone = txtTelefone.Text;

                clienteBll.InserirCliente(cliente);

                LimparFormulario();

                LogBll.InserirLog(new Log
                {
                    ItemID = cliente.ID,
                    Login = Context.User.Identity.Name,
                    Operacao = TipoOperacao.Create.ToString(),
                    Tabela = "Cliente"
                });

                Msg.Sucesso(Resource.ItemSalvoSucesso, this);
            }
            catch (Exception ex)
            {
                LogBll.InserirLog(new Log
                {
                    ItemID = cliente.ID,
                    Login = Context.User.Identity.Name,
                    Mensagem = ex.Message,
                    Operacao = TipoOperacao.Update.ToString(),
                    Tabela = "Cliente"
                });

                Msg.Erro(Resource.ContateAdminstrador, this);
            }
        }

        private void AlterarCliente()
        {
            int ID = int.TryParse(txtID.Text, out ID) ? ID : 0;

            try
            {
                ClienteBll clienteBll = new ClienteBll();
                Cliente cliente = clienteBll.RetornarCliente(ID);

                cliente.Ativo = cbAtivo.Checked;
                cliente.Bairro = txtBairro.Text;
                cliente.Celular = txtCelular.Text;
                cliente.Cep = txtCep.Text;
                cliente.Cidade = txtCidade.Text;
                cliente.Complemento = txtComplemento.Text;
                cliente.CPFCNPJ = txtCPFCNPJ.Text;
                cliente.Email = txtEmail.Text;
                //TODO: desenvolver conceito de empresa
                //cliente.EmpresaID
                cliente.Endereco = txtEndereco.Text;
                //TODO: Inserir campo estado
                //cliente.Estado = 
                cliente.InscricaoEstadual = txtInscricaoEstadual.Text;
                cliente.NomeFantasia = txtNomeFantasia.Text;
                cliente.Numero = txtNumero.Text;
                cliente.RazaoSocial = txtRazaoSocial.Text;
                cliente.Telefone = txtTelefone.Text;

                clienteBll.AlterarCliente(cliente);

                LimparFormulario();

                LogBll.InserirLog(new Log
                {
                    ItemID = ID,
                    Login = Context.User.Identity.Name,
                    Operacao = TipoOperacao.Update.ToString(),
                    Tabela = "Cliente"
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
                    Tabela = "Cliente"
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
                InserirCliente();
            }
            else if (hfTipoOperacao.Value.Equals(TipoOperacao.Update.ToString()))
            {
                AlterarCliente();
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

        protected void gvClientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvClientes.PageIndex = e.NewPageIndex;
            BindarGrid();
        }

        #endregion

        #region grid

        protected void gvClientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Alterar"))
            {
                int index = int.Parse(e.CommandArgument.ToString());
                int ID = int.TryParse(gvClientes.Rows[index].Cells[1].Text, out ID) ? ID : 0;

                try
                {
                    ClienteBll clienteBll = new ClienteBll();
                    Cliente cliente = clienteBll.RetornarCliente(ID);

                    txtID.Text = string.Format("{0:000000}", cliente.ID);
                    txtBairro.Text = cliente.Bairro;
                    txtCelular.Text = cliente.Celular;
                    txtCep.Text = cliente.Cep;
                    txtCidade.Text = cliente.Cidade;
                    txtComplemento.Text = cliente.Complemento;
                    txtCPFCNPJ.Text = cliente.CPFCNPJ;
                    txtEmail.Text = cliente.Email;
                    txtEndereco.Text = cliente.Endereco;
                    txtInscricaoEstadual.Text = cliente.InscricaoEstadual;
                    txtNomeFantasia.Text = cliente.NomeFantasia;
                    txtNumero.Text = cliente.Numero;
                    txtRazaoSocial.Text = cliente.RazaoSocial;
                    txtTelefone.Text = cliente.Telefone;
                    cbAtivo.Checked = cliente.Ativo;

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
                        Tabela = "Cliente"
                    });

                    Msg.Erro(Resource.ContateAdminstrador, this);
                }
            }
        }

        protected void gvClientes_Sorting(object sender, GridViewSortEventArgs e)
        {

        }

        #endregion
    }
}