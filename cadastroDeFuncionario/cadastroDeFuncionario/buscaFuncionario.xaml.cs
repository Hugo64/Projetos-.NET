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
    public partial class buscaFuncionario : Window
    {
        public static buscaFuncionario buscarF; // Atributo do Form "BuscarFuncionario".
        public List<string> listNome = new List<string>(); // Criando a lista de nomes para receber os nomes cadastrados no servidor.
        

        public buscaFuncionario() // Main.
        {
            InitializeComponent();
            buscarF = this; // Instanciando o atributo.

            numeroDeRegistros(); // Exibindo método.
            nomesFuncionarios(); // Exibindo método.
            
        }

        private void TextBoxBuscar_TextChanged(object sender, TextChangedEventArgs e) // "TextBoxBuscar" responsável por receber os digitos e fazer as seguintes operações...
        {

            var Nome = listNome.Where(it => (it ?? "").ToUpper().Contains(TextBoxBuscar.Text.ToUpper())); // Pegando o nome digitado e comparando com os armazenados na Lista.
            var Resultado = Nome.ToList(); // Pegando o nome digitado.

            listBoxExibindoNomeFuncionario.ItemsSource = Resultado; // Exibindo resultados de acordo com o nome digitado.

        }

        private void listBoxExibindoNomeFuncionario_SelectionChanged(object sender, SelectionChangedEventArgs e) // ListBox que estará exibindo o nome dos funcionários.
        {
            ListBox list = sender as ListBox; // Instanciando o listBox.

            if (list.SelectedIndex != -1) // Validando se o clique do mouse foi clicado fora das opções disponíveis. Caso esteja sendo clicado fora, nada irá acontecer. Caso contrario...
            {
                listBoxExibindoNomeFuncionario.SelectedIndex = list.SelectedIndex; // "Limpando o clique do mouse".
                Funcionario F = new Funcionario(); // Criando um novo objeto (Para usar o método para pegar o id do funcionário selecionado).
                F.exibirFuncionario(listBoxExibindoNomeFuncionario.SelectedItem.ToString()); // Enviando o funcionário (Nome) clicado no "listBoxExibindoNomeFuncionario" para ser validado...
                // e exibir os dados desse funcionário no Form "exibirFuncionario".
            }
        }

        private void ButtonBuscar_Click(object sender, RoutedEventArgs e) // Butão responsavel por fazer a buscar do funcionário pelo Cpf.
        {
                Funcionario F = new Funcionario(); // Criando um objeto (Para buscar os dados do funcionário pelo Cpf digitado no "TextBoxBuscar").
                if (!F.exibirFuncionario(TextBoxBuscar.Text)) // Enviando o que foi digitado no "TextBoxBuscar" para verificação e exibição dos dados.
                {
                    // Caso não encontre o funcionário pelo Cpf informado, será exibido esta mensagem...
                    MessageBox.Show("O resgistro não foi encontrado. Por favor, verifique se colocou o CPF corretamente e tente novamente.\nCaso não consiga, aconselho a usar o método da busca pelo nome.");
                    TextBoxBuscar.Text = ""; // Limpando o "TextBoxBuscar".
                }
        }

        private void nomesFuncionarios() // Método para exibir os nomes dos funcionários cadastrado no servidor ->
        {
            Funcionario F = new Funcionario(); // Criando um objeto do tipo Funcionário para fazer a busca com atributos do servidor. Está classe "Funcionario" herda os atributos da classe "conexaoMysql".

            try // Abrindo tratador de exceções.
            {
                F.Conectando(MainWindow.senhaMysql); // Abrindo conexão com servidor.
                F.Comando.Connection = F.Conexao;
                F.Comando.CommandText = "select * from cadastro.funcionario order by Nome asc"; // Query do servidor.
                F.Reader = F.Comando.ExecuteReader(); // Executando a query.
                if (F.Reader.HasRows) // Verificando se há registros no servidor.
                {
                    while (F.Reader.Read()) // Carregando registros.
                    {
                        listNome.Add(F.Reader["Nome"].ToString()); // Enviando os nomes para a lista.
                    }
                }
                F.Reader.Close(); // Fechando a consulta.
                F.Conexao.Close(); // Fechando a conexão com servidor.
            }
            catch (Exception Ex) // Tratando as exceções.
            {
                MessageBox.Show("Erro no sistema! Por favor contate o desenvolvedor sobre o problema.");
                MessageBox.Show(Ex.ToString()); // Exibindo mensagem de erro.
            }
            listBoxExibindoNomeFuncionario.ItemsSource = listNome; // Pegando a lista e exibindo no "listBoxExibindoNomesFuncionario".
        }

        private void numeroDeRegistros() // Método para exibir a quantidade de funcionários registrados ->
        {
            conexaoMysql mysql = new conexaoMysql(); // Criando um objeto "conexaoMysql" apenas para utilizar os atributos de conexão.

            try // Abrindo o tratador de exceções.
            {
                mysql.Conectando(MainWindow.senhaMysql); // Abrindo conexão com servidor.
                mysql.Comando.Connection = mysql.Conexao;
                mysql.Comando.CommandText = "select count(*) from cadastro.funcionario"; // Query do servidor.
                mysql.Reader = mysql.Comando.ExecuteReader(); // Executando a query.
                if (mysql.Reader.HasRows) // Verificando se existe registros no servidor.
                {
                    mysql.Reader.Read(); // Carregando registros.
                    LabelNumeroDeRegistros.Content = "Existem " + mysql.Reader["count(*)"].ToString() + " registros cadastrados no sistema."; // Inserindo a quantidade de funcionários no label.
                }
                mysql.Reader.Close(); // Fechando consulta.
                mysql.Conexao.Close(); // Fechando conexão com servidor.
            }
            catch (Exception Ex) // Tratando exceções.
            {
                MessageBox.Show("Erro no sistema! Por favor contate o desenvolvedor sobre o problema.");
                MessageBox.Show(Ex.ToString());
            }
        }
    }
}
