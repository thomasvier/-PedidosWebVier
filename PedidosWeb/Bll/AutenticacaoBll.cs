using System.Web;
using System.Web.UI;
using System.Data.Entity;
using System.Linq;
using System.Web.UI.WebControls;
using System.Collections.Generic;

namespace PedidosWeb.Bll
{
    public class AutenticacaoBll
    {
        Contexto db;

        //Construtor
        public AutenticacaoBll()
        {
            db = new Contexto();
        }

        /// <summary>
        /// Método que retorna o Login do atual usuário
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public static string RetornaLogin(Page page)
        {
            string login = string.Empty;
            HttpCookie cookie = page.Request.Cookies["Login"];

            if (cookie.Value != null)
                login = cookie.Value;

            return login;
        }

        /// <summary>
        /// Faz a autenticação do usuário 
        /// </summary>
        /// <param name="page"></param>
        /// <returns>Retorna true se existir usuário cadastrado na base</returns>
        public static bool UsuarioAutenticado(Page page)
        {
            string login = string.Empty;
            HttpCookie cookie = page.Request.Cookies["Login"];

            if (cookie != null)
            {
                login = HttpContext.Current.User.Identity.Name;
                login.Trim();

                Contexto db = new Contexto();

                var usuario = (from u in db.Usuario
                               where u.Login.Equals(login)
                               select u).FirstOrDefault();

                if (usuario == null)
                    return false;
                else
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Método que autentica o Login
        /// </summary>
        /// <returns>Caso o usuário tenha permissão retorna true, se não retorna false.</returns>
        public static bool Login(string login, string senha)
        {
            Contexto db = new Contexto();

            var usuario = (from u in db.Usuario
                           where u.Login.Equals(login) && u.Senha.Equals(senha)
                           select u).FirstOrDefault();

            if (usuario != null)
                return true;

            return false;
        }

        /// <summary>
        /// Método que grava as credenciais do usuário em cookies
        /// </summary>
        /// <param name="login"></param>
        public static void GravarCredenciais(string login, Page page)
        {
            HttpCookie cookie = new HttpCookie("Login");

            cookie.Value = login;

            page.Response.Cookies.Add(cookie);
        }
    }
}