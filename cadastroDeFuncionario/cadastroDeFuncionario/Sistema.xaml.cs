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

namespace cadastroDeFuncionario
{
    public partial class Sistema : Window
    {
        public static Sistema sistema; // Atributo do Form "Sistema".
        public static bool sistemaCompleto; // Atributo para ser verificado se o administrador que está entrando sistema tem privelegios.

        public Sistema() // Main.
        {
            InitializeComponent();
            sistema = this; // Instanciando o atributo.
            LabelExibirNome.Content = "Olá "+Administrador.nomeAdministrador; // Exibindo o nome do administrador longado no sistema da classe "Administrador" para ser exibido no topo do Form.
            
            if (sistemaCompleto) // Verificando se o valor do atributo é verdadeiro.
            {
                OpcaoAdministrador.IsEnabled = true; // Caso seja verdadeiro a opção de administrador do menu do sistema será acessivel.
            }
        }

        // < Menu Funcionário:
        private void menuCadastrarFuncionario_Click(object sender, RoutedEventArgs e)  // Abrindo o Form "cadastrarFuncionario" ->
        {
            sistema.Visibility = System.Windows.Visibility.Hidden; // Deixando o Form atual oculto.
            cadastrarFuncionario cadastrar = new cadastrarFuncionario(); // Instanciando o Form "cadastrarFuncionario".
            cadastrar.ShowDialog(); // Abrindo o Form "cadastrarFuncionario"
            sistema.ShowDialog(); // Abrindo novamente o Form atual caso o Form "cadastrarFuncionario" for fechado.
        }

        private void menuPesquisarFuncionario_Click(object sender, RoutedEventArgs e) // Abrindo o Form "BuscarFuncionario" ->
        {
            sistema.Visibility = System.Windows.Visibility.Hidden; // Deixando o Form atual oculto.
            buscaFuncionario Buscar = new buscaFuncionario(); // Instanciando o Form "BuscarFuncionario".
            Buscar.ShowDialog(); // Abrindo o Form "BuscarFuncionario".
            sistema.ShowDialog(); // Abrindo novamente o Form atual caso o Form "BuscarFuncionario" for fechado.
        }
        // >


        // < Menu Administrador:
        private void menuNovoAdministrador_Click(object sender, RoutedEventArgs e) // Abrindo o Form "novoAdmin" ->
        {
            sistema.Visibility = System.Windows.Visibility.Hidden; // Deixando o Form atual oculto.
            cadastrarAdministrador novoadmin = new cadastrarAdministrador(); // Instanciando o Form "novoAdmin".
            novoadmin.ShowDialog(); // Abrindo o Form "novoAdmin".
            sistema.ShowDialog(); // Abrindo novamente o Form atual caso o Form "novoAdmin" for fechado.
        }

        private void menuBuscarAdministrador_Click(object sender, RoutedEventArgs e) // FALTA IMPLEMENTAR
        {
            sistema.Visibility = System.Windows.Visibility.Hidden; // Deixando o Form atual oculto.
            buscarAdministrador Buscar = new buscarAdministrador(); // Instanciando o Form "BuscarAdministrador".
            Buscar.ShowDialog(); // Abrindo o Form "BuscarAdministrador".
            sistema.ShowDialog(); // Abrindo novamente o Form atual caso o Form "BuscarAdministrador" for fechado.
        }
        // >


        // < Menu Exibir dados do servidor:
        private void menuDadosDoServidor_Click(object sender, RoutedEventArgs e) // Abrindo o Form "dadosDoSistema" ->
        {
            sistema.Visibility = System.Windows.Visibility.Hidden; // Deixando o Form atual oculto.
            dadosDoSistema Dados = new dadosDoSistema(); // Instanciando o Form "dadosDoSistema".
            Dados.ShowDialog(); // Abrindo o Form "dadosDoSistema".
            sistema.ShowDialog(); // Abrindo novamente o Form atual caso o Form "dadosDoSistema" for fechado.
        }
        // >
    }
}
