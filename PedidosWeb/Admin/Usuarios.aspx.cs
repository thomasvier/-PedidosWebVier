using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PedidosWeb.Bll;
using Framework;

namespace PedidosWeb.Admin
{
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region metodos privados       

        private void InserirUsuario()
        {
            Usuario usuario = new Usuario();

            try
            {
                UsuarioBll usuarioBll = new UsuarioBll();

                usuario.ID = int.Parse(txtID.Text);
                usuario.Login = txtLogin.Text;

                if (!usuarioBll.VerificaUsuarioExistente(usuario, TipoOperacao.Create))
                {
                    usuario.Nome = txtNome.Text;
                    usuario.Senha = txtSenha.Text;
                    usuario.Email = txtEmail.Text;
                    usuario.Ativo = cbAtivo.Checked;
                                        
                    usuarioBll.InserirUsuario(usuario);
                    LimparFormulario();

                    LogBll.InserirLog(new Log
                    {
                        ItemID = usuario.ID,
                        Data = DateTime.Now,
                        Login = Context.User.Identity.Name,
                        Operacao = hfTipoOperacao.Value,
                        Tabela = "Usuario"
                    });
                    Msg.Sucesso(Resource.ItemSalvoSucesso, this);
                }
                else
                {
                    Msg.Info(string.Format(Resource.UsuarioExistente, usuario.Login), this);
                }
            }
            catch (Exception ex)
            {
                LogBll.InserirLog(new Log
                {
                    ItemID = usuario.ID,
                    Data = DateTime.Now,
                    Mensagem = ex.Message,
                    Operacao = hfTipoOperacao.Value,
                    Tabela = "Usuario",
                    Login = Context.User.Identity.Name
                });
                Msg.Erro(Resource.ContateAdminstrador, this);
            }
        }

        private void AlterarUsuario()
        {
            int ID = int.TryParse(txtID.Text, out ID) ? ID : 0;

            try
            {
                UsuarioBll usuarioBll = new UsuarioBll();
                Usuario usuario = usuarioBll.RetornaUsuario(ID);

                usuario.Login = txtLogin.Text;

                if (!usuarioBll.VerificaUsuarioExistente(usuario, TipoOperacao.Update))
                {
                    usuario.Nome = txtNome.Text;
                    usuario.Senha = txtSenha.Text;
                    usuario.Email = txtEmail.Text;
                    usuario.Ativo = cbAtivo.Checked;
                    
                    usuarioBll.AlterarUsuario(usuario);
                    LimparFormulario();

                    LogBll.InserirLog(new Log
                    {
                        ItemID = usuario.ID,
                        Data = DateTime.Now,
                        Login = Context.User.Identity.Name,
                        Operacao = hfTipoOperacao.Value,
                        Tabela = "Usuario"
                    });
                    Msg.Sucesso(Resource.ItemSalvoSucesso, this);
                }
                else
                {
                    Msg.Info(string.Format(Resource.UsuarioExistente, usuario.Login), this);
                }
            }
            catch (Exception ex)
            {
                LogBll.InserirLog(new Log
                {
                    ItemID = ID,
                    Data = DateTime.Now,
                    Mensagem = ex.Message,
                    Operacao = hfTipoOperacao.Value,
                    Tabela = "Usuario",
                    Login = Context.User.Identity.Name
                });
                Msg.Erro(Resource.ContateAdminstrador, this);
            }
        }

        private void ExcluirUsuario()
        {
            int contador = 0;

            try
            {
                foreach (GridViewRow row in gvUsuarios.Rows)
                {
                    CheckBox chkSelecionado = (CheckBox)row.FindControl("chkSelecionar");

                    if (chkSelecionado.Checked.Equals(true))
                    {
                        int ID = int.TryParse(row.Cells[1].Text, out ID) ? ID : 0;

                        Usuario usuario = new Usuario();
                        UsuarioBll usuarioBll = new UsuarioBll();

                        usuario = usuarioBll.RetornaUsuario(ID);

                        usuarioBll.RemoverUsuario(usuario);

                        contador++;

                        LogBll.InserirLog(new Log
                        {
                            ItemID = usuario.ID,
                            Login = Context.User.Identity.Name,
                            Operacao = TipoOperacao.Delete.ToString(),
                            Tabela = "Usuario",
                            Data = DateTime.Now
                        });
                    }
                }

                if (contador > 0)
                    Msg.Sucesso(string.Format(Resource.ItemExcluidoSucesso, contador), this);
                else
                    Msg.Warning(Resource.ItemSelecioneExclusao, this);

                LimparFormulario();
                BindarGrid();
            }
            catch (Exception ex)
            {
                LogBll.InserirLog(new Log
                {
                    Data = DateTime.Now,
                    Login = Context.User.Identity.Name,
                    Mensagem = ex.Message,
                    Operacao = TipoOperacao.Delete.ToString(),
                    Tabela = "Usuario"
                });

                Msg.Erro(Resource.ContateAdminstrador, this);
            }
        }

        private void BindarGrid()
        {
            try
            {
                UsuarioBll usuarioBll = new UsuarioBll();

                string[] filtro = new string[2];

                filtro[0] = txtFiltro.Text;
                filtro[1] = ddlAtivoFiltro.SelectedValue;

                gvUsuarios.DataSource = usuarioBll.BuscarUsuarios(filtro);
                gvUsuarios.DataBind();
            }
            catch (Exception ex)
            {
                LogBll.InserirLog(new Log
                {
                    Data = DateTime.Today,
                    Mensagem = ex.Message,
                    Login = this.Context.User.Identity.Name,
                    Operacao = TipoOperacao.Read.ToString(),
                    Tabela = "Usuarios"
                });
                Msg.Erro(Resource.ContateAdminstrador, this);
            }
        }

        private void LimparFormulario()
        {
            try
            {
                txtID.Text = string.Format("{0:000000}", UsuarioBll.RetornaNovoID());
                txtNome.Text = string.Empty;
                txtLogin.Text = string.Empty;
                txtSenha.Text = string.Empty;
                txtEmail.Text = string.Empty;
                ddlAtivoFiltro.SelectedValue = "1";
                cbAtivo.Checked = true;
                hfTipoOperacao.Value = TipoOperacao.Create.ToString();
            }
            catch (Exception ex)
            {
                LogBll.InserirLog(new Log
                {
                    Data = DateTime.Today,
                    Mensagem = ex.Message,
                    Login = this.Context.User.Identity.Name,
                    Operacao = TipoOperacao.Create.ToString(),
                    Tabela = "Usuarios"
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
                InserirUsuario();
            }
            else if (hfTipoOperacao.Value.Equals(TipoOperacao.Update.ToString()))
            {
                AlterarUsuario();
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

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            ExcluirUsuario();
        }

        #endregion

        #region grid

        protected void gvUsuarios_Sorting(object sender, GridViewSortEventArgs e)
        {

        }

        protected void gvUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUsuarios.PageIndex = e.NewPageIndex;
            BindarGrid();
        }

        protected void gvUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Alterar"))
            {
                int index = int.Parse(e.CommandArgument.ToString());
                int ID = int.TryParse(gvUsuarios.Rows[index].Cells[1].Text, out ID) ? ID : 0;

                try
                {
                    UsuarioBll usuarioBll = new UsuarioBll();
                    Usuario usuario = usuarioBll.RetornaUsuario(ID);

                    txtID.Text = string.Format("{0:000000}", usuario.ID);
                    txtNome.Text = usuario.Nome;
                    txtLogin.Text = usuario.Login;
                    txtSenha.Text = usuario.Senha;
                    txtEmail.Text = usuario.Email;
                    cbAtivo.Checked = usuario.Ativo;

                    hfTipoOperacao.Value = TipoOperacao.Update.ToString();
                }
                catch (Exception ex)
                {
                    LogBll.InserirLog(new Log
                    {
                        Data = DateTime.Now,
                        ItemID = ID,
                        Login = Context.User.Identity.Name,
                        Mensagem = ex.Message,
                        Operacao = TipoOperacao.Read.ToString(),
                        Tabela = "Usuario"
                    });
                    Msg.Erro(Resource.ContateAdminstrador, this);
                }
            }
        }

        #endregion
    }
}