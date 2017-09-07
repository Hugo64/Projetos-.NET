using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
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

    public partial class esqueciMinhaSenha : Window
    {
        public static esqueciMinhaSenha Esqueci; // Atributo do Form "esqueciMinhaSenha".
        private string Nome; // Atributo para pegar o nome do administrador que esqueceu a senha.
        private string Login; // Atributo para pegar o login do administrador que esqueceu a senha.
        private string Senha; // Atributo para pegar a senha do administrador que esqueceu a senha.

        public esqueciMinhaSenha() // Main.
        {
            InitializeComponent();
            Esqueci = this; // Instanciando o atributo.

            // Mensagem de alerta:
            MessageBox.Show("É importante que tenha informado o email correto no momento do cadastro.\nO email que você terá que informar neste momento tem que ser\n"+
            "o que foi cadastrado. Será verificado o email cadastrado no servidor.\n"+
            "Se você informou um email inválido no momento do cadastro, o certo é procurar o desenvolvedor e pedir para que ele altere seu email para que possa recuperar a senha. "+
            "Caso contrario, a senha será enviado para outro email."); // Mensagem de alerta antes de recuperar a senha por email.
        }

        private void ButtonEnviar_Click(object sender, RoutedEventArgs e) // Butão responsavel por enviar a login e senha para o email do adiministrador.
        {
            Regex validaEmail = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$"); // String de formatação de email.

            if (string.IsNullOrWhiteSpace(TextBoxEmail.Text)) // Verificando se "TextBoxEmail" está vazio.
            {
                MessageBox.Show("É preciso inserir o email."); // Caso esteja vazio será exibido esta mensagem.
            }
            else if (!validaEmail.IsMatch(TextBoxEmail.Text)) // Verificando se o email inserido está no formato correto.
            {
                MessageBox.Show("O email está com formato incorreto! Por favor informe um email válido."); // Caso o email não estiver de acordo com a formatação de email. Será exibido esta mensagem.
            }
            else // Caso o preenchido...
            {
                if (recuperarMinhaSenha(TextBoxEmail.Text)) // verificando se o email passado está cadastrado no servidor.
                {
                    string Mensagem = "Olá "+Nome+"! seu Login é: "+Login+" e sua senha é: "+Senha; // Mensagem que será enviado para o email do administrador.
                    string Assunto = "Secretaria: Esqueci minha senha."; // Assunto do email.

                    try // Abrindo o tratador de exceções.
                    {
                        MailMessage mail = new MailMessage(); // Criando um email.
                        mail.From = new System.Net.Mail.MailAddress("secretariaeducacao64@gmail.com"); // Email que será responsavel por enviar a mensagem.
                        mail.To.Add(new System.Net.Mail.MailAddress(TextBoxEmail.Text)); // Email que receberá a mensagem.
                        mail.Subject = Assunto; // Enviando o assunto.
                        mail.Body = Mensagem; // Enviando a mensagem.


                        using (System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient())
                        {
                            smtp.Host = "smtp.gmail.com"; // Adicionando o host do Gmail.
                            smtp.Port = 587; // Adicionando a porta de envio da mensagem.
                            smtp.EnableSsl = true; // Ativando o EnableSsl.
                            smtp.UseDefaultCredentials = false;
                            smtp.Credentials = new System.Net.NetworkCredential("secretariaeducacao64@gmail.com", "android.com"); // Autenticação da conta. Email e Senha.
                            smtp.Send(mail); // Enviando o Email.
                            MessageBox.Show("O login e senha foi enviado para seu email."); // Mensagem informando que o envio foi efetuado com sucesso.
                            TextBoxEmail.Text = ""; // Limpando o "TextBoxEmail".
                        }
                    }
                    catch (Exception Ex) // Tratando exceções.
                    {
                        MessageBox.Show("Erro na conexão. Obs: Você pode estar sem conexão com a internet, ou sua internet pode estar muito lenta.");
                        MessageBox.Show(Ex.ToString()); // Exibindo mensagem de erro.
                    }

                }
                else // Caso o email esteja incorreto, será exibido a seguinte mensagem...
                {
                    MessageBox.Show("Email incorreto! O email inserido não foi encontrado no servidor.");
                    TextBoxEmail.Text = ""; // Limpando o "TextBoxEmail".
                }
            }
        }

        private bool recuperarMinhaSenha(string Email) // Método para validar o email inserido no "TextBoxEmail" ->
        {
            Administrador Adm = new Administrador(); // Criando um novo objeto (Apenas para usar os atributos da classe "conexaoMysql") -> a classe "Administrador herda da classe "conexaoMysql".

            try // Abrindo o tratador e exceções.
            {
                Adm.Conectando(MainWindow.senhaMysql); // Abrindo conexão com o servidor.
                Adm.Comando.Connection = Adm.Conexao;
                Adm.Comando.CommandText = "select * from cadastro.administrador"; // Query do servidor.
                Adm.Reader = Adm.Comando.ExecuteReader(); // Executando a query.
                if (Adm.Reader.HasRows) // Verificando se existe registros no servidor.
                {
                    while (Adm.Reader.Read()) // Carregando registros.
                    {
                        if (Adm.Reader["Email"].ToString().Equals(Email)) // Verificando se o email passado pelo parametro existe no servidor.
                        {
                            Nome = Adm.Reader["Nome"].ToString(); // Pegando o nome do administrador.
                            Login = Adm.Reader["Login"].ToString(); // Pegando o login do administrador.
                            Senha = Adm.Reader["Senha"].ToString(); // Pegando a senha do administrador.
                            return true; // Retornando um valor verdadeiro informando que o email consta no servidor.
                        }
                    }
                }
                Adm.Reader.Close(); // Fechando consulta.
                Adm.Conexao.Close(); // Fechando conexão com servidor.
            }
            catch (Exception Ex) // Tratando exceções.
            {
                MessageBox.Show("Erro no sistema! Por favor contate o desenvolvedor sobre o problema.");
                MessageBox.Show(Ex.ToString()); // Exibindo mensagem de erro.
            }
            return false; // Retornando um valor falso, informando que o email não consta no servidor.
        }
    }
}
