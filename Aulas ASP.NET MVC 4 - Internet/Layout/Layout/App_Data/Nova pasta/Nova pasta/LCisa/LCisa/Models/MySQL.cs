using LCisa.App_Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LCisa.Models
{
    public class MySQL // Classe criada para instanciar o banco de dados.
    {
        public static EntidadeLojaCisa db = new EntidadeLojaCisa(); // Instancia do banco de dados.
    }
}