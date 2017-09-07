using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace cadastroDeFuncionario
{
    public partial class MainWindow : Window
    {
        public static MainWindow mainwindows; // Atributo do Form atual "MainWindows".
        public static string senhaMysql; // Senha de conexão do servidor Mysql Workbench no qual foi validado e confirmado.
        int i; // Atributo para contar o numero de vezes que o administrador errou a senha.

        public MainWindow() // Main.
        {
            InitializeComponent();
            mainwindows = this; // Instanciando o atributo do Form atual.
        }

        private void ButtonConectaBanco_Click(object sender, RoutedEventArgs e) // Butão responsável para conectar ao servidor.
        {
            conexaoMysql ConexaoMysql = new conexaoMysql(); // Criando um objeto (nova conexão ao servidor).
            ConexaoMysql.Conectando(TextBoxSenhaMysql.Password); // Enviando o que está no "TextBoxSenhaMysql" para validação na classe "conexaoMysql".
            // Obs: Se a verificação da senha não retonar nenhum erro, a senha será enviada para o atributo "senhaMysql". Caso contrário exibirá o erro, mas o atributo não receberá nada
            // e o erro persistirá até que informem a senha correta, ou usem o meio da string padrão do mysql (clicando apenas no botão, sem inserir nada no "TextBoxSenhaMysql"), ou ativem o servidor (caso esteja desativado).
            senhaMysql = TextBoxSenhaMysql.Password; // passando a senha digitada no "TextBoxSenhaMysql" para o atributo statico global "senhaMysql" para ser usado em vários pontos do código.
            if (ConexaoMysql.conexaoAceita) // Se o atributo bool da classe "conexaoMysql" retornar um verdadeiro será atribuido os seguintes resultados...
            {
                ImagemVermelho.Visibility = System.Windows.Visibility.Hidden; // Deixando a imagem que informa "conexão desativada" oculto.
                ImagemVerde.Visibility = System.Windows.Visibility.Visible; // Deixando a imagem que informa "conexão ativa" visivel.
                ButtonConectaBanco.Background = new SolidColorBrush(Colors.Aqua); // Mudando a cor do botão caso a conexão estiver ativa.
                TextBoxSenhaMysql.Password = ""; // Limpando o "TextBoxSenhaMysql" caso esteja algo digitado. 
                TextBoxSenha.IsEnabled = false; // Deixando o "TextBoxSenhaMysql" inacessivel.
                TextBoxLogin.IsEnabled = true; // Deixando o " TextBoxLogin" visivel.
                TextBoxSenha.IsEnabled = true; // Deixando o " TextBoxSenha" visivel.
                ButtonConectaBanco.IsEnabled = false; // Deixando o botão que conecta o banco inacessivel.
                TextBoxSenhaMysql.IsEnabled = false;
                ButtonEsqueciMinhaSenha.IsEnabled = true; // Deixando o botão "EsqueciMinhaSenha" acessivel.
                ButtonEntrar.IsEnabled = true; // Deixando o botão "Entrar" acessivel.
                ButtonCancelar.IsEnabled = true; // Deixando o botão "Cancelar" acessivel.
            }
        }

        private void ButtonEntrar_Click(object sender, RoutedEventArgs e) // Butão responsável para entrar no sistema.
        {
            if (string.IsNullOrWhiteSpace(TextBoxLogin.Text) && string.IsNullOrWhiteSpace(TextBoxSenha.Password)) // Verificando se o "TextBoxLogin" e "TextBoxSenha" estão vazios.
            {
                MessageBox.Show("Verifique se preencheu o login e senha."); // Se estiverem vazios será exibido está mensagem.
            }
            else if (string.IsNullOrWhiteSpace(TextBoxLogin.Text)) // Verificando se o "TextBoxLogin" está vazio.
            {
                MessageBox.Show("Informe o login!"); // Se estiver vazios será exibido esta mensagem.
            }
            else if (string.IsNullOrWhiteSpace(TextBoxSenha.Password)) // Verificando se o "TextBoxSenha" está vazio.
            {
                MessageBox.Show("Informe a senha!"); // Se estiver vazio será exibido esta mensagem.
            }
            else // Caso estiverem sido digitado algo neles serão atribuido os seguintes resultados...
            {
                Administrador Adm = new Administrador(); // Criando um novo objeto (Nova autenticação).
                Adm.Login = TextBoxLogin.Text; // Enviando o login digitado no "TextBoxLogin" para o objeto Administrador que tem o atributo "Login".
                Adm.Senha = TextBoxSenha.Password; // Enviando a senha digitada no "TextBoxSenha" para o objeto Administrador que tem o atributo "Senha".

                if (Adm.validarAdministrador(Adm)) // Enviando os dados digitados para validação disponível na classe "Administrador".
                {
                    mainwindows.Visibility = System.Windows.Visibility.Hidden; // Caso a validação retornar que o login e senha estão corretos o Form atual ficará oculto.
                    Sistema sistema = new Sistema(); // Instanciando o Form "Sistema".
                    sistema.ShowDialog(); // Abrindo o Form "Sistema".
                    TextBoxLogin.Text = ""; // Limpando o "TextBoxLogin".
                    TextBoxSenha.Password = ""; // Limpando o "TextBoxSenha".
                    mainwindows.ShowDialog(); // Quando o Form "Sistema" for fechado o Form atual será aberto novamente.

                    // -- Processo de backup automatico após o form "MainWindow" ser fechado.

                    //exemplo do path
                    string path = "D:";

                    MysqlRestore(path);

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

                   // --

                }
                else // Caso contrario...
                {
                    MessageBox.Show("Login ou Senha incorretos"); // Caso o login e senha estiverem incorretos exibirá uma mensagem de erro
                    TextBoxLogin.Text = ""; // Limpando o "TextBoxLogin".
                    TextBoxSenha.Password = ""; // Limpando o "TextBoxSenha".
                    i++;
                }
                if (i.Equals(3)) // Verificando se o numero de tentativas de entrar no sistema foi alcançado.
                {
                    MessageBox.Show("Obs: Procure o desenvolvedor sobre o problema. Talvez ele possa ter alterado seu cadastro."); // Mensagem de ajuda.
                    i = 0; // Zerando a contagem.
                }
            }

        }

        private void ButtonCancelar_Click(object sender, RoutedEventArgs e) // Butão responsável para cancelar" ->
        {
            //exemplo do path
            string path = "D:";

            MysqlRestore(path);

            //corre uma thread com o processo que faz o backup ou restore
            Thread t = new Thread(delegate() { MySqlProcess(path); });
            t.Start();

            mainwindows.Close(); // Fechando o Form atual.
        }

        private void ButtonEsqueciMinhaSenha_Click(object sender, RoutedEventArgs e) // Butão responsável por 
        {
            mainwindows.Visibility = System.Windows.Visibility.Hidden; // Deixando o Form atual "MainWindow" oculto.
            esqueciMinhaSenha Esqueci = new esqueciMinhaSenha(); // Instanciando o Form "esqueciMinhaSenha".
            Esqueci.ShowDialog(); // Abrindo o Form "esqueciMinhaSenha".
            mainwindows.ShowDialog(); // Caso o Form "esqueciMinhaSenha" for fechado, o Form atual voltará a ser aberto.
        }

        private static void MysqlRestore(string path) // Método para fazer o backup.
        {
            //caminho onde o mysql esta instalado
            string cmd = "C:\\xampp\\mysql\\bin";

            try // Abrindo o tratador de exceções.
            {
                //criar um arquivo de lote para executar o banco de dados de script.
                StreamWriter sw = File.CreateText(path + "\\MySqlbackup.cmd");
                sw.WriteLine("c:");
                sw.WriteLine("cd " + cmd);

                // se for backup
                sw.WriteLine("mysqldump --host=192.168.2.101 --user=root --password=hdvirus1712 cadastro > C:\\MEGA\\File.sql");

                sw.Close();
            }
            catch (Exception Ex) // Tratando exceções.
            {
                MessageBox.Show(Ex.ToString()); // Exibindo mensagem com o erro.
            }
        }

        private static void MySqlProcess(string Path) // Método para processar o comando.
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
