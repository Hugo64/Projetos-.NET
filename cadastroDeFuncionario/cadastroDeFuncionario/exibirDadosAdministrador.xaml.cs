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

namespace cadastroDeFuncionario
{

    public partial class exibirDadosAdministrador : Window
    {
        public static exibirDadosAdministrador exibirAdm; // Atributo do Form "exibirAdministrador".

        public exibirDadosAdministrador() // Main.
        {
            InitializeComponent();
            exibirAdm = this; // Instanciando o atributo;
        }

        private void ButtonEditar_Click(object sender, RoutedEventArgs e) // Butão para edição dos dados do administrador.
        {
            Administrador Adm = new Administrador(); // Criando um objeto (Para pegar o nome que será editado e enviar para analise e pegar o id).
            Adm.pegandoIdDoAdministradorParaEditar(TextBoxNome.Text); // Enviando o nome que está no "TextBoxNome".
            TextBoxNome.IsEnabled  = true; // Habilitando o "TextBoxNome" para ser editado.
            TextBoxEmail.IsEnabled = true; // Habilitando o "TextBoxEmail" para ser editado.
            TextBoxLogin.IsEnabled = false; // desabilitando o "TextBoxLogin". O motivo por impedir a alteração, porque caso o login que for escolhido for igual a outro já cadastrado, causará inconsistência de dados no servidor.
            TextBoxSenha.IsEnabled = true; // Habilitando o "TextBoxSenha" para ser editado.
            TextBoxDigiteNovamenteASenha.IsEnabled = true; // Habilitando o "TextBoxDigiteNovamenteASenha".
            ButtonConfirmar.IsEnabled = true; // Habilitando o botão "Confirmar."
            ButtonDeletar.IsEnabled = false; // Desabilitando o butão de deletar o administrador.
        }

        private void ButtonDeletar_Click(object sender, RoutedEventArgs e) // Proíbido a criação deste botão.
        {
            Administrador Adm = new Administrador();
            if (Adm.deletarAdministrador(TextBoxNome.Text))
            {
                // Limpando o formulário que contia os dados do administrador deletado.
                TextBoxNome.Text = "";
                TextBoxEmail.Text = "";
                TextBoxLogin.Text = "";
                TextBoxSenha.Text = "";
                TextBoxDigiteNovamenteASenha.Text = "";
                TextBoxDataRegistrado.Text = "";

                ButtonEditar.IsEnabled = false;
                ButtonDeletar.IsEnabled = false;
                ButtonConfirmar.IsEnabled = false;
                bloquearAdministrador.IsEnabled = false;
                MessageBox.Show("Administrador deletado com sucesso."); // Mensagem exibida após o administrador ser deletado do servidor.
            }
        }

        private void ButtonConfirmar_Click(object sender, RoutedEventArgs e) // Botão responsável por confirmar as alterações feitas no cadastro.
        {

            if (string.IsNullOrWhiteSpace(TextBoxNome.Text) && string.IsNullOrWhiteSpace(TextBoxEmail.Text)  // Verificando se os textBox disponíveis no fomulário estão vazios.
            && string.IsNullOrWhiteSpace(TextBoxLogin.Text) && string.IsNullOrWhiteSpace(TextBoxSenha.Text)) //
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
            else if (string.IsNullOrWhiteSpace(TextBoxLogin.Text)) // Verificando se o "TextBoxLogin" está vazio.
            {
                MessageBox.Show("O Login precisa ser preenchido!"); // Caso esteja vazio será exibida esta mensagem.
                MessageBox.Show("O Login pode ser o que quiser: seu nome, email, numero etc."); //
            }
            else if (string.IsNullOrWhiteSpace(TextBoxSenha.Text)) // Verificando se o "TextBoxSenha" está vazio.
            {
                MessageBox.Show("A senha precisa ser preenchida!"); // Caso esteja vazio será exibida esta mensagem.
            }
            else if (TextBoxSenha.Text.Length < 4 || TextBoxSenha.Text.Length > 8) // Verificando se a senha inserida é menor que 4 ou maior que 8.
            {
                MessageBox.Show("Desculpe, a senha deve conter no minimo 4 digitos e no máximo 8."); // Se for menor que 4 digitos e maior que 8 digitos será exibido esta mensagem.
            }
            else if (TextBoxDigiteNovamenteASenha.Text != TextBoxSenha.Text) // Verificando se as senhas digitas correspondem (Feito para evitar erros na hora de escolher a senha).
            {
                MessageBox.Show("As senhas informadas não correpondem!"); // Se não correponderem (forem iguais) será exibido esta mensagem.
            }
            else
            {

                Administrador Adm = new Administrador(); // Criando um objeto (Novo Administrador).
                Adm.Nome = TextBoxNome.Text; // Atribuindo ao objeto Administrador o Nome alterado no "TextBoxNome" para o atributo Nome.
                Adm.Email = TextBoxEmail.Text; // Atribuindo ao objeto Administrador o Email alterado no "TextBoxNome" para o atributo Email.
                Adm.Login = TextBoxLogin.Text; // Atribuindo ao objeto Administrador o Login do "TextBoxLogin" para o atributo Login.
                Adm.Senha = TextBoxSenha.Text;// Atribuindo ao objeto Administrador a Senha alterada no "TextBoxSenha" para o atributo Senha.
                if (Adm.editarAdministrador(Adm)) // Enviando os dados alterados do objeto para serem alterados no servidor na classe "Administrador".
                {
                    MessageBox.Show("Administrador editado com sucesso."); // Exibindo mensagem de cadastro.
                }
                else
                {
                    // Caso houver algum erro a mensagem será exibida...
                    MessageBox.Show("Houve algum erro ao editar este administrador. Por favor, contate ao desenvolvedor sobre este erro.");
                }
            }
        }

        private void ButtonVoltar_Click(object sender, RoutedEventArgs e) // Cancelando.
        {
            exibirAdm.Close(); // Fechando o Form atual.
        }

        private void bloquearAdministrador_Click(object sender, RoutedEventArgs e)// Botão responsável por bloquear e desbloquear o administrador.
        {
            Administrador Adm = new Administrador(); // Criando um objeto Administrador.

            if (bloquearOuDesbloquearAdministrador(TextBoxNome.Text)) // Enviando o nome pego no "textBoxNome.Text" para verificar se ele está bloqueado.
            {
                if (Adm.desbloquearAdministrador(TextBoxNome.Text)) // Se ele estiver bloqueado enviará o nome para verificação e desbloqueio.
                {
                    MessageBox.Show("Administrador desbloqueado com sucesso!"); // Exibindo mensagem se tudo ocorrer perfeitamente.
                }
            }
            else // Caso contrario se ele não estiver bloqueado...
            {
                if (Adm.bloquearAdministrador(TextBoxNome.Text)) // Enviando o nome pego no "textBoxNome.Text" para ser desbloqueado.
                {
                    MessageBox.Show("Administrador bloqueado com sucesso!"); // Exibindo mnesagem se tudo ocorrer perfeitamente.
                }
            }
        }

        private bool bloquearOuDesbloquearAdministrador(string Nome) // Método responsável por verficar se o administrador esta bloqueado ->
        {
            Administrador Adm = new Administrador(); // Criando um objeto Administrador.

            try // Abrindo o tratador de exceções.
            {
                Adm.Conectando(MainWindow.senhaMysql); // Abrindo conexão com servidor.
                Adm.Comando.Connection = Adm.Conexao;
                Adm.Comando.CommandText = "select * from cadastro.administrador"; // Query do servidor.
                Adm.Reader = Adm.Comando.ExecuteReader(); // Executando query.
                if (Adm.Reader.HasRows) // Verificando se existe registros no servidor.
                {
                    while (Adm.Reader.Read()) // Carregando registros.
                    {
                        if (Adm.Reader["Nome"].ToString().Equals(Nome)) // Verificando pelo nome se existe esse administrador no sistema.
                        {
                            if (Adm.Reader["Bloqueado"].Equals(true)) // Se existir o administrador no servidor, será verificado se ele está bloqueado.
                            {
                                return true; // Se ele estiver bloqueado será retornado um valor verdadeiro informando que ele está bloqueado.
                            }
                        }
                    }
                }
                Adm.Reader.Close(); // Fechando consulta com servidor.
                Adm.Conexao.Close(); // Fechando conexão com servidor.
            }
            catch (Exception Ex) // Tratando exceção.
            {
                MessageBox.Show("Erro no sistema! Por favor contate o desenvolvedor sobre o problema.");
                MessageBox.Show(Ex.ToString()); // Exibindo mensagem com o erro.
            }
            return false; // Retornando um valor falso caso o administrador não esteja bloqueado.
        }
    }
}
