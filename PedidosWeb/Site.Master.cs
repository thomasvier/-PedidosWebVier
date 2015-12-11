using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PedidosWeb.Bll;
using System.Web.Security;
using Framework;

namespace PedidosWeb
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    if (!AutenticacaoBll.UsuarioAutenticado(this.Page))
                    {
                        FormsAuthentication.SignOut();
                        FormsAuthentication.RedirectToLoginPage();
                        //Response.Redirect("~/Acesso/Login.aspx");
                    }
                }
                catch (Exception ex)
                {
                    Msg.Erro(ex.Message, this);
                }
            }
        }
    }
}