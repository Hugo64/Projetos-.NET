using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace cadastroDeFuncionario
{
    public class conexaoMysql
    {

        public bool conexaoAceita { get; set; } // Atributo para retornar o valor verdadeiro ou falso informando se o servidor está ativo ou desativado.

        //Atributos de conexão ao servidor Mysql Workbench.

        public MySqlConnection  Conexao      { get; set; }
        public MySqlCommand     Comando  =   new MySqlCommand();
        public MySqlDataReader  Reader       { get; set; }

        
        public void Conectando(string Senha) // Método para abrir conexão ao servidor.
        {
            if (string.IsNullOrWhiteSpace(Senha)) // Primeiramente será verificado se o campo ("textBoxSenhaMysql" disponível na interface "MainWindow") senha de conexão foi inserida algum digito, 
            {                                     // se o campo estiver null será validado a string de conexão padrão do mysql. ->
                try
                {
                    MySqlConnection Connection = new MySqlConnection("server=192.168.6.35;user id=root;password=hdvirus1712;database=cadastro"); // String padrão de conexão mysql.
                    Conexao = Connection;
                    Conexao.Open(); // Abrindo conexão ao servidor.
                    this.conexaoAceita = true; // Se o banco estiver conectado pela string de conexão, será retornado um valor verdadeiro.
                }
                catch (Exception ex) // Caso contrario o catch (tratador de exceções) vai informar um erro na string informando se a senha está incorreta ou se
                {                    // o servidor está desativado.

                    MessageBox.Show("Não foi possivel fazer a conexão com banco de dados\nPor favor, contantar ao desenvolvedor sobre o problema.\nErro #ConexãoMysql #1");
                    MessageBox.Show(ex.ToString());
                    MainWindow.mainwindows.TextBoxSenhaMysql.Password = "";
                }
            }
            else // Se o campo ("textBoxSenhaMysql" disponível na interface "MainWindow") senha de conexão estiver sido inserido alguma digito, esse digito será inserido dentro da string de conexão do mysql.
            {
                try
                {
                    MySqlConnection Connection = new MySqlConnection("server=192.168.6.35;user id=root;password='" + Senha + "';database=cadastro"); // Senha inserida.
                    Conexao = Connection;
                    Conexao.Open();
                    this.conexaoAceita = true; // Se a senha inserida estiver de acordo com a string de conexão, será retornado um valor verdadeiro.
                }
                catch (Exception ex) // Se a senha estiver incorreta ou o servidor estiver desativado, o catch (tratador de exceções) exibirá um erro de conexão ao servidor.
                {
                    MessageBox.Show("Não foi possivel fazer a conexão com banco de dados\nPor favor, contantar ao desenvolvedor sobre o problema.\nErro #ConexãoMysql #1");
                    MessageBox.Show(ex.ToString());
                    MainWindow.mainwindows.TextBoxSenhaMysql.Password = "";
                }
            }
        }

    }

}


