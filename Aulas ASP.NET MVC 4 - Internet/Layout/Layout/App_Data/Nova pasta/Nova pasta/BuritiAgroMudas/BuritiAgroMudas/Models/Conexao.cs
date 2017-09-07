using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace BuritiAgroMudas.Models
{
    public class Conexao
    {
        //Atributos para conexão com servidor MySQL:
        public MySqlConnection Conectado { get; private set; }
        public MySqlCommand Comando = new MySqlCommand();
        public MySqlDataReader Reader { get; set; }


        public string abrirConexao()
        {
            try
            {
                this.Conectado = new MySqlConnection("server=bdprodutos.mysql.dbaas.com.br;user id=bdprodutos;password=android94;database=bdprodutos");
                //this.Conectado = new MySqlConnection("server=localhost;user id=root;password=android.com;database=produtos");
                this.Conectado.Open();
            }
            catch (Exception Ex)
            {
                return Ex.ToString();
            }
            return null;
        }

        public void fecharConexao()
        {
            this.Conectado.Close();
        }
    }
}