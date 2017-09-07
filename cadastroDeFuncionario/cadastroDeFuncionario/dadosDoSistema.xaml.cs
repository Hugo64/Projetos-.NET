using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace cadastroDeFuncionario
{

    public partial class dadosDoSistema : Window
    {
        public static dadosDoSistema dadosSistema; // Atributo do Form atual "dadosDoSistema".

        public dadosDoSistema() // Main.
        {
            InitializeComponent();
            dadosSistema = this; // Instanciando o atributo.

            quantidadeFuncionariosCadastrado(); // Executando o método.
            quantidadeAdministradoresCadastrado(); // Executando o método.
            totalSalarioDeFuncionarios(); // Executando o método.
            mediaSalarioDeFuncionarios(); // Executando o método.
        }

        private void quantidadeFuncionariosCadastrado() // Método que exibe a quantidade de funcionários cadastrados.
        {
            conexaoMysql mysql = new conexaoMysql(); // Criando um objeto "conexaoMysql".

            try // Abrindo o tratador de exceções.
            {
                mysql.Conectando(MainWindow.senhaMysql); // abrindo conexão com servidor.
                mysql.Comando.Connection = mysql.Conexao;
                mysql.Comando.CommandText = "select count(*) from cadastro.funcionario"; // Query do servidor.
                mysql.Reader = mysql.Comando.ExecuteReader(); // Executando query.
                if (mysql.Reader.HasRows) // Verificando se existe registros  no servidor.
                {
                    mysql.Reader.Read(); // Carregando registros.
                    LabelnumeroDeRegistroDoFuncionario.Content = "Existem   " + mysql.Reader["count(*)"].ToString() + "   funcionários registrados no sistema."; // Inserindo a quantidade de registros no label.
                }
                mysql.Reader.Close(); // Fechando consulta.
                mysql.Conexao.Close(); // Fechando conexão.
            }
            catch (Exception Ex) // Tratando exceções.
            {
                MessageBox.Show("Erro no sistema! Por favor contate o desenvolvedor sobre o problema.");
                MessageBox.Show(Ex.ToString()); // Exibindo mensagem de erro.
            }
        }

        private void quantidadeAdministradoresCadastrado() // Método que exibe a quantidade de administradores cadastrados.
        {
            conexaoMysql mysql = new conexaoMysql(); // Criando um objeto "conexaoMysql".

            try // Abrindo o tratador de exceções.
            {
                mysql.Conectando(MainWindow.senhaMysql); // abrindo conexão com servidor.
                mysql.Comando.Connection = mysql.Conexao;
                mysql.Comando.CommandText = "select count(*) from cadastro.administrador"; // Query do servidor.
                mysql.Reader = mysql.Comando.ExecuteReader(); // Executando query.
                if (mysql.Reader.HasRows) // Verificando se existe registros  no servidor.
                {
                    mysql.Reader.Read(); // Carregando registros.
                    LabelnumerodeRegistroDoAdministrador.Content = "Existem   " + mysql.Reader["count(*)"].ToString() + "   administradores registrados no sistema."; // Inserindo a quantidade de registros no label.
                }
                mysql.Reader.Close(); // Fechando consulta.
                mysql.Conexao.Close(); // Fechando conexão.
            }
            catch (Exception Ex) // Tratando exceções.
            {
                MessageBox.Show("Erro no sistema! Por favor contate o desenvolvedor sobre o problema.");
                MessageBox.Show(Ex.ToString()); // Exibindo mensagem de erro.
            }
        }

        private void totalSalarioDeFuncionarios() // Método que exibe o total soma de todos os salarios dos funcionários cadastrados.
        {
            conexaoMysql mysql = new conexaoMysql(); // Criando um objeto "conexaoMysql".

            try // Abrindo o tratador de exceções.
            {
                mysql.Conectando(MainWindow.senhaMysql); // abrindo conexão com servidor.
                mysql.Comando.Connection = mysql.Conexao;
                mysql.Comando.CommandText = "select sum(salario) from cadastro.departamento"; // Query do servidor.
                mysql.Reader = mysql.Comando.ExecuteReader(); // Executando query.
                if (mysql.Reader.HasRows) // Verificando se existe registros  no servidor.
                {
                    mysql.Reader.Read(); // Carregando registros.
                    LabeltotalDeSalarioDetodosFuncionarios.Content = "Valor total de salarios somados:   " + mysql.Reader["sum(salario)"].ToString() + "   dos funcionários registrados no sistema."; // Inserindo o resultado da soma dos salarios no label.
                }
                mysql.Reader.Close(); // Fechando consulta.
                mysql.Conexao.Close(); // Fechando conexão.
            }
            catch (Exception Ex) // Tratando exceções.
            {
                MessageBox.Show("Erro no sistema! Por favor contate o desenvolvedor sobre o problema.");
                MessageBox.Show(Ex.ToString()); // Exibindo mensagem de erro.
            }
        }

        private void mediaSalarioDeFuncionarios() // Método que mostra a média dos salarios somados.
        {
            conexaoMysql mysql = new conexaoMysql(); // Criando um objeto "conexaoMysql".

            try // Abrindo o tratador de exceções.
            {
                mysql.Conectando(MainWindow.senhaMysql); // abrindo conexão com servidor.
                mysql.Comando.Connection = mysql.Conexao;
                mysql.Comando.CommandText = "select avg(salario) from cadastro.departamento;"; // Query do servidor.
                mysql.Reader = mysql.Comando.ExecuteReader(); // Executando query.
                if (mysql.Reader.HasRows) // Verificando se existe registros no servidor.
                {
                    mysql.Reader.Read(); // Carregando registros.
                    LabelMediaDeTodosSalariosFuncionario.Content = "Média total de salarios somados:   " + mysql.Reader["avg(salario)"].ToString() + "   dos funcionários registrados no sistema."; // Inserindo a média de todos os salarios no label.
                }
                mysql.Reader.Close(); // Fechando consulta.
                mysql.Conexao.Close(); // Fechando conexão com servidor.
            }
            catch (Exception Ex) // Tratando exceções.
            {
                MessageBox.Show("Erro no sistema! Por favor contate o desenvolvedor sobre o problema.");
                MessageBox.Show(Ex.ToString()); // Exibindo mensagem de erro.
            }
        }

        private void ButtonFazerBackup_Click(object sender, RoutedEventArgs e) // Botão para fazer o backup.
        {
            //exemplo do path
            string path ="D:";

            MysqlBackup(path);

            try // Abrindo tratador de exceções.
            {
                //corre uma thread com o processo que faz o backup ou restore
                Thread t = new Thread(delegate() { MySqlProcess(path); });
                t.Start();
            }
            catch (Exception Ex) // Tratando exceções.
            {
                MessageBox.Show(Ex.ToString()); // Exibindo mensagem com erro.
            }
            MessageBox.Show("Backup realizado com sucesso!");
        }

        private static void MysqlBackup(string path) // Método para fazer backup do banco de dados.
        {   
            //caminho onde o mysql esta instalado.
            string cmd = "C:\\xampp\\mysql\\bin";

            try { // Abrindo tratador de exceções.
            // Criar um arquivo de lote para executar o banco de dados de script.
            StreamWriter sw = File.CreateText(path + "\\MySqlbackup.cmd");
            sw.WriteLine("c:");
            sw.WriteLine ("cd " + cmd);

            // Fazendo backup
            sw.WriteLine("mysqldump --host=192.168.2.101 --user=root --password=hdvirus1712 cadastro > C:\\MEGA\\File.sql");

            sw.Close(); 
            } catch (Exception Ex) // tratando exceções.
            {
                MessageBox.Show(Ex.ToString()); // Exibindo mensagem com erro.
            }
        }

        private static void MySqlProcess(string Path) // Processando o código do backup.
        {
            try // Abrindo tratador de exceções.
            {
                // cria o processo a correr o MySqlbackup.cmd 
                Process.Start(Path + "\\MySqlbackup.cmd");
            }
            catch (Exception Ex) // Tratando exceções.
            {
                MessageBox.Show(Ex.ToString()); // Exibindo mensagem de erro.
            }
        }

    }
}
