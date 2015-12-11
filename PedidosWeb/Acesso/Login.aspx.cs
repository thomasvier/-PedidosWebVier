using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using PedidosWeb.Bll;

namespace PedidosWeb.Acesso
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtLogin.Focus();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text;
            string senha = txtSenha.Text;

            try
            {
                bool permissao = AutenticacaoBll.Login(login, senha);

                if (permissao)
                {
                    FormsAuthentication.RedirectFromLoginPage(login, false);
                }
                else
                {

                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}