using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PedidosWeb.Bll
{
    public class LogBll
    {
        Contexto db;

        //Construtor
        public LogBll()
        {
            db = new Contexto();
        }

        /// <summary>
        /// Método que retorna um novo ID da tabela de Log
        /// </summary>
        /// <returns></returns>
        public static int RetornaNovoID()
        {
            Contexto db = new Contexto();

            int ID = (from l in db.Log
                      orderby l.ID descending
                      select l.ID).FirstOrDefault();

            ID++;

            return ID;
        }

        /// <summary>
        /// Método que Insere um novo Log na base de dados
        /// </summary>
        /// <param name="log">Objeto Log</param>
        public static void InserirLog(Log log)
        {
            Contexto db = new Contexto();

            log.ID = RetornaNovoID();
            log.Data = DateTime.Now;

            db.Log.Add(log);
            db.SaveChanges();
        }
    }
}