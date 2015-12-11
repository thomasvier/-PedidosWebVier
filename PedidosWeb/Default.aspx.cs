using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PedidosWeb.Bll;

namespace PedidosWeb
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                string Login = Page.User.Identity.Name;

                UsuarioBll UsuarioBll = new UsuarioBll();
                Usuario Usuario = UsuarioBll.RetornaUsuario(Login);

                if(Usuario.Tipo.Equals(TipoUsuario.Admin.GetHashCode()))
                {
                    Response.Redirect("~/Admin/Pedidos.aspx");
                }
                else if(Usuario.Tipo.Equals(TipoUsuario.Cli.GetHashCode()))
                {
                    Response.Redirect("~/Cli/Pedidos.aspx");
                }
            }
        }
    }
}