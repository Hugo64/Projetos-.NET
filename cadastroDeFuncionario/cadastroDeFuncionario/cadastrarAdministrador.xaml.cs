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
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

namespace cadastroDeFuncionario
{

    public partial class cadastrarAdministrador : Window
    {
        public static cadastrarAdministrador novoadmin; // Atributo do Form "novoAdmin".

        public cadastrarAdministrador() // Main.
        {
            InitializeComponent();
            novoadmin = this; // Instanciando o atributo.

            // Mensagem de alerta:
            MessageBox.Show("É importante inserir um email válido no cadastro.\nEsse email será importante para o administrador recuperar sua senha sem precisar procurar o desenvolvedor. "+
            "Caso contrário, você terá que alterar a senha manualmente caso o administrador não conseguir recuperar a senha pelo email.\n"+
            "Se informar um email incorreto, a senha será enviada para este email.");
        }

        private void ButtonCriarAdmin_Click(object sender, RoutedEventArgs e) // Butão responsável por criar um novo administrador ->
        {
            Regex validaEmail = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$"); // String de formatação de email.

            if (string.IsNullOrWhiteSpace(TextBoxNome.Text) && string.IsNullOrWhiteSpace(TextBoxEmail.Text)  // Verificando se os textBox disponíveis no fomulário estão vazios.
            && string.IsNullOrWhiteSpace(TextBoxLogin.Text) && string.IsNullOrWhiteSpace(TextBoxSenha.Password)) //
            {
                MessageBox.Show("Verifique se os dados foram inseridos."); // Caso estejam vazios será exibida esta mensagem.
            }
            else if (string.IsNullOrWhiteSpace(TextBoxNome.Text)) // Verificando se o "TextBoxNome" está vazio.
            {
                MessageBox.Show("O nome precisa ser preenchido!"); // Caso esteja vazio será exibida esta mensagem.
            }
            else if (string.IsNullOrWhiteSpace(TextBoxEmail.Text)) // Verificando se o "TextBoxEmail" está vazio.
            {
                MessageBox.Show("O Email precisa ser preenchido!"); // Caso esteja vazio será exibida esta mensagem.
            } 
            else if (!validaEmail.IsMatch(TextBoxEmail.Text)) // Verificando se o email inserido está no formato correto.
            {
                MessageBox.Show("O email está com formato incorreto! Por favor informe um email válido."); // Caso o email não estiver de acordo com a formatação de email. Será exibido esta mensagem.
            }
            else if (string.IsNullOrWhiteSpace(TextBoxLogin.Text)) // Verificando se o "TextBoxLogin" está vazio.
            {
                MessageBox.Show("O Login precisa ser preenchido!"); // Caso esteja vazio será exibida esta mensagem.
                MessageBox.Show("O Login pode ser o que quiser: seu nome, email, numero etc."); //
            }
            else if (string.IsNullOrWhiteSpace(TextBoxSenha.Password)) // Verificando se o "TextBoxSenha" está vazio.
            {
                MessageBox.Show("A senha precisa ser preenchida!"); // Caso esteja vazio será exibida esta mensagem.
            } 
            else if (TextBoxSenha.Password.Length < 4 || TextBoxSenha.Password.Length > 8) // Verificando se a senha inserida é menor que 4 ou maior que 8.
            {
                MessageBox.Show("Desculpe, a senha deve conter no minimo 4 digitos e no máximo 8."); // Se for menor que 4 digitos e maior que 8 digitos será exibido esta mensagem.
            }
            else if (TextBoxDigiteNovamenteASenha.Password != TextBoxSenha.Password) // Verificando se as senhas digitas correspondem (Feito para evitar erros na hora de escolher a senha).
            {
                MessageBox.Show("As senhas informadas não correpondem!"); // Se não correponderem (forem iguais) será exibido esta mensagem.
            }
            else // Se o formulário estiver sido preenchido...
            {

                var dataRegistrado = DateTime.Now; // Pegando a data e horario no qual foi registrado o cadastro.

                Administrador Adm  =  new Administrador(); // Criando um novo objeto (Novo administrador).
                Adm.Nome           =  TextBoxNome.Text; // Atribuindo ao objeto Administrador o Nome digitado no "TextBoxNome" para o atributo Nome.
                Adm.Email          =  TextBoxEmail.Text; // Atribuindo ao objeto Administrador o email digitado no "TextBoxEmail" para o atributo Email.
                Adm.Login          =  TextBoxLogin.Text; // Atribuindo ao objeto Administrador o login digitado no "TextBoxLogin" para o atributo Login.
                Adm.Senha          =  TextBoxSenha.Password; // Atribuindo ao objeto Administrador a senha digitada no "TextBoxSenha" para o atributo Senha.

                if (Adm.adicionarAdministrador(Adm, dataRegistrado)) // Enviando as informações digitadas para serem verificadas e cadastradas no servidor.
                {
                    MessageBox.Show("O Administrador foi criado com sucesso."); // Caso a verificação estiver tudo correto o método irá relizar o cadastro no servidor.

                    // Limpando o formulário do Form.
                    TextBoxNome.Text  = ""; 
                    TextBoxEmail.Text = "";
                    TextBoxLogin.Text = "";
                    TextBoxSenha.Password = "";
                    TextBoxDigiteNovamenteASenha.Password = "";
                }
                }
            }

        private void ButtonCancelar_Click(object sender, RoutedEventArgs e) // Butão responsável por cancelar.
        {
            novoadmin.Close(); // Fechando o Form atual.
        }

        private void ButtonLimpar_Click(object sender, RoutedEventArgs e) // Butão responsável por Limpar os formularios.
        {
            // Limpando o formulário do Form.
            TextBoxNome.Text = "";
            TextBoxEmail.Text = "";
            TextBoxLogin.Text = "";
            TextBoxSenha.Password = "";
            TextBoxDigiteNovamenteASenha.Password = "";
        }

    }
}
