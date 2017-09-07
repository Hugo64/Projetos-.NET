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

    public partial class buscarAdministrador : Window
    {
        public static buscarAdministrador buscarAdm; // Atributo dor Form "buscarAdministrador".
        public List<string> listNome = new List<string>(); // Criando a lista de nomes para receber os nomes cadastrados no servidor.

        public buscarAdministrador() // Main.
        {

            InitializeComponent();
            buscarAdm = this; // Instanciando o atributo.

            nomesAdministradores(); // Exibindo o método "nomesAdministradores".
            numeroDeRegistro(); // Exibindo o método "numeroDeRegistros".

        }

        private void TextBoxBuscar_TextChanged(object sender, TextChangedEventArgs e) // "TextBoxBuscar" responsavel por receber os digitos e fazer as seguintes operações...
        {

            var Nome = listNome.Where(it => (it ?? "").ToUpper().Contains(TextBoxBuscar.Text.ToUpper())); // Pegando o nome digitado e comparando com os armazenados na Lista.
            var Resultado = Nome.ToList(); // Pegando o nome digitado.

            listBoxExibindoNomeAdministrador.ItemsSource = Resultado; // Exibindo resultados de acordo com o nome digitado.
        }

        private void listBoxExibindoNomeAdministrador_SelectionChanged(object sender, SelectionChangedEventArgs e) // ListBox que estará exibindo o nome dos Administradores.
        {
            ListBox list = sender as ListBox; // Instanciando o listBox.

            if (list.SelectedIndex != -1) // Validando se o clique do mouse foi clicado fora das opções disponiveis. Caso esteja sendo clicado fora, nada irá acontecer. Caso contrario...
            {
                listBoxExibindoNomeAdministrador.SelectedIndex = list.SelectedIndex; // "Limpando o clique do mouse".
                Administrador Adm = new Administrador(); // Criando um novo objeto (Para usar o método para pegar o id do administrador selecionado).
                Adm.exibirAdm(listBoxExibindoNomeAdministrador.SelectedItem.ToString()); // Enviando o administrador (Nome) clicado no "listBoxExibindoNomeAdministrador" para ser validado...
                // e exibir os dados desse funcionário no Form "exibirFuncionario".
            }
        }

        private void ButtonBuscar_Click(object sender, RoutedEventArgs e) // Butão responsavel por fazer a buscar do funcionário pelo Email ->
        {
            Administrador Adm = new Administrador(); // Criando um objeto (Para buscar os dados do administrador pelo email digitado no "TextBoxBuscar").
            if (!Adm.exibirAdm(TextBoxBuscar.Text)) // Enviando o que foi digitado no "TextBoxBuscar" para verificação e exibição dos dados.
            {
                // Caso não encontre o administrador pelo email informado, será exibido esta mensagem...
                MessageBox.Show("O resgistro não foi encontrado. Por favor, verifique se colocou o Email corretamente e tente novamente.\nCaso não conseguir, aconselho a usar o método da busca pelo nome.");
                TextBoxBuscar.Text = ""; // Limpando o "TextBoxBuscar".
            }
        }

        private void nomesAdministradores() // Método que exibe os nomes dos administradores na busca ->
        {
            Administrador Adm = new Administrador(); // Criando um objeto do tipo Administrador para fazer a busca com atributos do servidor. Está classe "Administrador" herda os atributos da classe "conexaoMysql".

            try // Abrindo o tratador de exceções.
            {
                Adm.Conectando(MainWindow.senhaMysql); // Abrindo conexão com servidor.
                Adm.Comando.Connection = Adm.Conexao;
                Adm.Comando.CommandText = "select * from cadastro.administrador"; // Query do servidor.
                Adm.Reader = Adm.Comando.ExecuteReader(); // Executando a query.
                if (Adm.Reader.HasRows) // Verificando se há registros no servidor.
                {
                    while (Adm.Reader.Read()) // Carregando registros.
                    {
                        listNome.Add(Adm.Reader["Nome"].ToString()); // Enviando os nomes para a lista.
                    }
                }
                Adm.Reader.Close(); // Fechando a consulta.
                Adm.Conexao.Close(); // Fechando a conexão com servidor.
            }
            catch (Exception Ex) // Tratando as exceções.
            {
                MessageBox.Show("Erro no sistema! Por favor contate o desenvolvedor sobre o problema.");
                MessageBox.Show(Ex.ToString()); // Exibindo mensagem de erro.
            }
            listBoxExibindoNomeAdministrador.ItemsSource = listNome; // Pegando a lista e exibindo no "listBoxExibindoNomesAdministrador".
        }

        private void numeroDeRegistro() // Método que exibe a quantidade de resgistros dos administradores ->
        {
            conexaoMysql mysql = new conexaoMysql(); // Criando um objeto "conexaoMysl" para usar seus atributos de conexão.

            try // Abrindo o tratador de exceções.
            {
                mysql.Conectando(MainWindow.senhaMysql); // Abrindo conexão com servidor.
                mysql.Comando.Connection = mysql.Conexao;
                mysql.Comando.CommandText = "select count(*) from cadastro.administrador"; // Query do servidor.
                mysql.Reader = mysql.Comando.ExecuteReader(); // Executando a query.
                if (mysql.Reader.HasRows) // Verificando se há registros no servidor.
                {
                    mysql.Reader.Read(); // Carregando registros.
                    LabelNumeroDeRegistros.Content = "Existem " + mysql.Reader["count(*)"].ToString() + " registros cadastrados no sistema."; // Enviando a quantidade pega no servidor para o label.
                }
                mysql.Reader.Close(); // Fechando a consulta.
                mysql.Conexao.Close(); // Fechando a conexão com servidor.
            }
            catch (Exception Ex) // Tratando as exceções.
            {
                MessageBox.Show("Erro no sistema! Por favor contate o desenvolvedor sobre o problema.");
                MessageBox.Show(Ex.ToString()); // Exibindo mensagem de erro.
            }
        }

    }
}
