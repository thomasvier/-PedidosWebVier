using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace PedidosWeb.Bll
{
    public class UsuarioBll
    {
        Contexto db;

        //Construtor
        public UsuarioBll()
        {
            db = new Contexto();
        }

        /// <summary>
        /// Método que retorna um novo ID
        /// </summary>
        /// <returns></returns>
        public static int RetornaNovoID()
        {
            Contexto db = new Contexto();

            int ID = (from u in db.Usuario
                      orderby u.ID descending
                      select u.ID).FirstOrDefault();

            ID++;

            return ID;
        }

        /// <summary>
        /// Método que busca usuários
        /// </summary>
        /// <param name="gvSortEventArgs"></param>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public List<Usuario> BuscarUsuarios(GridViewSortEventArgs gvSortEventArgs, string[] filtro)
        {
            int ID = 0;
            string descricao = filtro[0];
            bool ativo = filtro[1].Equals("0") ? false : true;

            var usuarios = (from u in db.Usuario
                            select u);

            if (int.TryParse(filtro[0], out ID))
                usuarios = usuarios.Where(p => p.ID.Equals(ID));
            else if (!string.IsNullOrEmpty(descricao))
                usuarios = usuarios.Where(p => p.Nome.Contains(descricao) || p.Login.Contains(descricao));

            if (!filtro[1].Equals("2"))
                usuarios = usuarios.Where(p => p.Ativo == ativo);            

            return usuarios.ToList();
        }

        /// <summary>
        /// Retorna usuario passando o ID como parâmetro
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Usuario RetornaUsuario(int ID)
        {
            Usuario usuario = (from u in db.Usuario
                               where u.ID.Equals(ID)
                               select u).FirstOrDefault();

            return usuario;
        }

        /// <summary>
        /// Método que insere um novo usuário na base de dados
        /// </summary>
        /// <param name="usuario"></param>
        public void InserirUsuario(Usuario usuario)
        {
            usuario.ID = RetornaNovoID();

            db.Usuario.Add(usuario);
            db.SaveChanges();
        }

        /// <summary>
        /// Método que altera um usuário recebido por parâmetro
        /// </summary>
        /// <param name="usuario"></param>
        public void AlterarUsuario(Usuario usuario)
        {
            db.Usuario.Attach(usuario);
            db.Entry(usuario).State = EntityState.Modified;
            db.SaveChanges();
        }

        /// <summary>
        /// Método que remove um usuário recebido por parâmetro
        /// </summary>
        /// <param name="usuario"></param>
        public void RemoverUsuario(Usuario usuario)
        {
            db.Usuario.Remove(usuario);
            db.SaveChanges();
        }

        /// <summary>
        /// Método que verifica se usuário já existe
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="tipoOperacao"></param>
        /// <returns></returns>
        public bool VerificaUsuarioExistente(Usuario usuario, TipoOperacao tipoOperacao)
        {
            Contexto db = new Contexto();

            List<Usuario> usuarios = (from u in db.Usuario
                                      where u.Login.Equals(usuario.Login)
                                      select u).ToList();

            if (tipoOperacao.Equals(TipoOperacao.Create))
            {
                if (usuarios.Count > 0)
                    return true;
            }
            else if (tipoOperacao.Equals(TipoOperacao.Update))
            {
                if (usuarios.Count > 0)
                {
                    foreach (var item in usuarios)
                    {
                        if (item.Login.Equals(usuario.Login) && item.ID != usuario.ID)
                            return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Retorna o usuário pelo login
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public static Usuario RetornaUsuario(string login)
        {
            Contexto db = new Contexto();

            Usuario usuario = (from u in db.Usuario
                               where u.Login.Equals(login)
                               select u).FirstOrDefault();

            return usuario;
        }        
    }
}