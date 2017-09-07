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

    public partial class cadastrarFuncionario : Window
    {
        public static cadastrarFuncionario Cadastrar; // Atributo do Form "cadastrarFuncionario".

        public cadastrarFuncionario() // Main.
        {
            InitializeComponent();
            Cadastrar = this; // Instanciando o atributo.

            Funcionario F = new Funcionario();
            ComboBoxEstado.Items.Clear(); // Limpando o item selecionado no "comboBoxEstado" para que possa receber outra seleção.

            try // Abrindo o tratamento de exceções.
            {
                F.Conectando(MainWindow.senhaMysql); // Abrindo conexão com servidor.
                F.Comando.Connection = F.Conexao;
                F.Comando.CommandText = "select Estados from cadastro.tabela"; // Query do servidor.
                F.Reader = F.Comando.ExecuteReader(); // Executando a query.
                if (F.Reader.HasRows) // Se tiver registros no servidor será executado a busca ->
                {
                    while (F.Reader.Read()) // Carregando registros.
                    {
                        ComboBoxEstado.Items.Add(F.Reader["Estados"].ToString()); // Inserindo no "ComboBoxEstado" todos os "Estados" cadastrados no servidor.
                    }
                }
                F.Reader.Close(); // Fechando a consulta.
                F.Conexao.Close(); // Fechando conexão com servidor.
            }
            catch (Exception Ex) // Tratando as exceções.
            {
                MessageBox.Show(Ex.ToString()); // Exibindo uma mensagem com o erro.
            }

        }

        private void ButtonCadastrar_Click(object sender, RoutedEventArgs e) // Butão responsável por cadastrar um novo Funcionário.
        {

            if (string.IsNullOrWhiteSpace(TextBoxNome.Text) && string.IsNullOrWhiteSpace(TextBoxIdentidade.Text) && string.IsNullOrWhiteSpace(TextBoxCPF.Text) // Verificando se os textBox disponíveis no fomulário estão vazios.
            && string.IsNullOrWhiteSpace(DatePickerDataNascimento.Text) && string.IsNullOrWhiteSpace(TextBoxCidade.Text) && string.IsNullOrWhiteSpace(ComboBoxEstado.Text) //
            && string.IsNullOrWhiteSpace(TextBoxEndereco.Text) && string.IsNullOrWhiteSpace(TextBoxTelefone.Text) //
            && string.IsNullOrWhiteSpace(TextBoxCelular.Text) && string.IsNullOrWhiteSpace(TextBoxArea.Text) && string.IsNullOrWhiteSpace(TextBoxSalario.Text) //
            && string.IsNullOrWhiteSpace(TextBoxFuncao.Text) && string.IsNullOrWhiteSpace(TextBoxLocal.Text) && string.IsNullOrWhiteSpace(TextBoxMatricula.Text) //
            && string.IsNullOrWhiteSpace(DatePickerInicio.Text) && string.IsNullOrWhiteSpace(DatePickerFim.Text)) //
            {
                MessageBox.Show("É preciso inserir dados do funcionário no formulário!"); // Caso estejam vazios será exibida esta mensagem.
            }
            else if (string.IsNullOrWhiteSpace(TextBoxNome.Text)) // Verificando se o "TextBoxNome" está vazio.
            {
                MessageBox.Show("Informe o nome!"); // Caso esteja vazio será exibida esta mensagem.
            }
            else if (string.IsNullOrWhiteSpace(TextBoxIdentidade.Text)) // Verificando se o "TextBoxIdentidade" está vazio.
            {
                MessageBox.Show("Informe a identidade!"); // Caso esteja vazio será exibida esta mensagem.
            }
            else if (string.IsNullOrWhiteSpace(TextBoxCPF.Text)) // Verificando se o "TextBoxCpf" está vazio.
            {
                MessageBox.Show("Informe o CPF!"); // Caso esteja vazio será exibida esta mensagem.
            }
            else if (string.IsNullOrWhiteSpace(DatePickerDataNascimento.Text)) // Verificando se o "DatePickerDataNascimento" está vazio.
            {
                MessageBox.Show("Informe a data de nascimento!"); // Caso esteja vazio será exibida esta mensagem.
            }
            else if (string.IsNullOrWhiteSpace(TextBoxCidade.Text)) // Verificando se o "TextBoxCidade" está vazio.
            {
                MessageBox.Show("Informe a cidade!"); // Caso esteja vazio será exibida esta mensagem.
            }
            else if (string.IsNullOrWhiteSpace(ComboBoxEstado.Text)) // Verificando se o "ComboBoxEstado" está vazio.
            {
                MessageBox.Show("Informe o estado!"); // Caso esteja vazio será exibida esta mensagem.
            }
            else if (string.IsNullOrWhiteSpace(TextBoxEndereco.Text)) // Verificando se o "TextBoxEndereco" está vazio.
            {
                MessageBox.Show("Informe o endereço!"); // Caso esteja vazio será exibida esta mensagem.
            }
            else if (string.IsNullOrWhiteSpace(TextBoxTelefone.Text)) // Verificando se o "TextBoxTelefone" está vazio.
            {
                MessageBox.Show("Informe o telefone!"); // Caso esteja vazio será exibida esta mensagem.
            }
            else if (string.IsNullOrWhiteSpace(TextBoxCelular.Text)) // Verificando se o "TextBoxCelular" está vazio.
            {
                MessageBox.Show("Informe o celular!"); // Caso esteja vazio será exibida esta mensagem.
            }
            else if (string.IsNullOrWhiteSpace(TextBoxArea.Text)) // Verificando se o "TextBoxArea" está vazio.
            {
                MessageBox.Show("Informe a área!"); // Caso esteja vazio será exibida esta mensagem.
            }
            else if (string.IsNullOrWhiteSpace(TextBoxSalario.Text)) // Verificando se o "TextBoxSalario" está vazio.
            {
                MessageBox.Show("Informe o salário!"); // Caso esteja vazio será exibida esta mensagem.
            }
            else if (verificaTextBoxSalario(TextBoxSalario.Text)) // Verificando se o "TextBoxSalario" possui letras digitadas.
            {
                MessageBox.Show("Não informe letras ou caracteres especiais no salário, apenas numeros."); // Caso contem letras, será exibida esta mensagem.
            }
            else if (string.IsNullOrWhiteSpace(TextBoxFuncao.Text)) // Verificando se o "TextBoxFuncao" esta vazio.
            {
                MessageBox.Show("Informe a função!"); // Caso esteja vazio será exibida esta mensagem.
            }
            else if (string.IsNullOrWhiteSpace(TextBoxLocal.Text)) // Verificando se o "TextBoxLocal" esta vazio.
            {
                MessageBox.Show("Informe o local!"); // Caso esteja vazio será exibida esta mensagem.
            }
            else if (string.IsNullOrWhiteSpace(TextBoxMatricula.Text)) // Verificando se o "TextBoxMatricula" esta vazio.
            {
                MessageBox.Show("Informe a matricula!"); // Caso esteja vazio será exibida esta mensagem.
            }
            else if (string.IsNullOrWhiteSpace(DatePickerInicio.Text)) // Verificando se o "DatePickerInicio" esta vazio.
            {
                MessageBox.Show("Informe a data de início!"); // Caso esteja vazio será exibida esta mensagem.
            }
            else if (string.IsNullOrWhiteSpace(DatePickerFim.Text)) // Verificando se o "DatePickerFim" esta vazio.
            {
                MessageBox.Show("Informe a data de fim!"); // Caso esteja vazio será exibida esta mensagem.
            }
            else // Caso o formulário foi todo preenchido...
            {
                var dataRegistrado = DateTime.Now; // Pegando a data e hora no qual foi registrado o cadastro.

                Funcionario F = new Funcionario(); // Criando um novo objeto (Novo funcionário).
                F.Nome        = TextBoxNome.Text; // Atribuindo ao objeto Funcionário o Nome digitado no "TextBoxNome" para o atributo Nome.
                F.Identidade  = TextBoxIdentidade.Text; // Atribuindo ao objeto Funcionário a Identidade digitada no "TextBoxIdentidade" para o atributo Identidade.
                F.CPF         = TextBoxCPF.Text; // Atribuindo ao objeto Funcionário o Cpf digitado no "TextBoxCpf" para o atributo Cpf.
                F.Endereco    = TextBoxEndereco.Text; // Atribuindo ao objeto Endereco o Endereço digitado no "TextBoxEndereco" para o atributo Endereco.
                F.Cidade      = TextBoxCidade.Text; // Atribuindo ao objeto Funcionário a cidade digitada no "TextBoxCidade" para o atributo Cidade.
                F.Estado      = ComboBoxEstado.SelectedItem.ToString(); // Atribuindo ao objeto Funcionário o Estado selecionádo no "ComboBoxEstado" para o atributo Estado.
                F.Telefone    = TextBoxTelefone.Text; // Atribuindo ao objeto Funcionário o Telefone digitado no "TextBoxTelefone" para o atributo Telefone.
                F.Celular     = TextBoxCelular.Text; // Atribuindo ao objeto Funcionário o Celular digitado no "TextBoxCelular" para o atributo Celular.
                F.Email       = TextBoxEmail.Text; // Atribuindo ao objeto Funcionário o Email digitado no "TextBoxEmail" para o atributo Email.

                if (F.addFuncionario(F)) // Enviando os dados do objeto para verificação e cadastro no servidor na classe "Funcionário".
                {
                    Departamento D = new Departamento(); // Criando um novo objeto (Novo Departamento).
                    D.Area         = TextBoxArea.Text; // Atribuindo ao objeto Departamento a Area digitada no "TextBoxArea" para o atributo Area.
                    D.Salario      = Convert.ToDouble(TextBoxSalario.Text); // Atribuindo ao objeto Departamento o Salario digitado no "TextBoxSalario" (Convertido para double) para o atributo Salario.
                    D.Funcao       = TextBoxFuncao.Text;  // Atribuindo ao objeto Departamento a Funcao digitada no "TextBoxFuncao" para o atributo Funcão.
                    D.Local        = TextBoxLocal.Text;  // Atribuindo ao objeto Departamento o local digitado no "TextBoxLocal" para o atributo Local.
                    D.Matricula    = TextBoxMatricula.Text;  // Atribuindo ao objeto Departamento a Matrícula digitada no "TextBoxMatricula" para o atributo Matrícula.
                    D.Observacao   = TextBoxObservacao.Text;  // Atribuindo ao objeto Departamento a Observação digitada no "TextBoxObservacao" para o atributo Observacão.
                    D.addDepartamento(D, dataRegistrado); // Enviando os dados do objeto para serem cadastrados no servidor na classe "Departamento".
                    MessageBox.Show("Funcionário cadastrado com sucesso."); // Exibindo a mensagem de cadastro.
                }
                else // Caso o funcionário já esteja cadastrado, será exibida a seguinte mensagem...
                {
                    MessageBox.Show("Este funcionário já está cadastrado. A verificação foi feita pelo Cpf.");
                }
            }
        }

        private void ButtonCancelar_Click(object sender, RoutedEventArgs e) // Cancelando.
        {
            Cadastrar.Close(); // Fechando o Form atual.
        }

        private void ButtonLimpar_Click(object sender, RoutedEventArgs e)  // Limpando o formulário.
        {
            // Limpando os textBox's
            TextBoxNome.Text = "";
            TextBoxIdentidade.Text = "";
            TextBoxCPF.Text = "";
            DatePickerDataNascimento.Text = "";
            TextBoxEndereco.Text = "";
            TextBoxCidade.Text = "";
            ComboBoxEstado.Text = "";
            TextBoxEmail.Text = "";
            TextBoxTelefone.Text = "";
            TextBoxCelular.Text = "";
            TextBoxArea.Text = "";
            TextBoxSalario.Text = "";
            TextBoxFuncao.Text = "";
            TextBoxLocal.Text = "";
            TextBoxMatricula.Text = "";
            DatePickerInicio.Text = "";
            DatePickerFim.Text = "";
            TextBoxObservacao.Text = "";
        }

        private void ButtonLimparObservacao_Click(object sender, RoutedEventArgs e) // Limpando o "TextBoxObservcao".
        {
            TextBoxObservacao.Text = "";
        }

        private bool verificaTextBoxSalario(string valorSalario) // Verificando se o valor do "textBoxSalario" possui letras ou caracteres especiais.
        {
            try // Abrindo o tratador de exceções.
            {
                Convert.ToDouble(valorSalario); // Verificando se tem letras ou caracteres especiais no "TextBoxSalario".
            }
            catch (Exception) // Tratando exceções.
            {
                return true; // Retornando um valor verdadeiro informando que existe letras ou caracteres especiais no "TextBoxSalario".
            }

            for (int i = 0; i < TextBoxSalario.Text.Length; i++) // Verificando posições.
            {
                if (char.IsPunctuation(valorSalario, i)) // Verificando...
                {
                    return true; // Caso possui alguma pontuação será retornado um valor verdadeiro informando que possui.
                }
            }
            return false; // Caso contrario será retornado um valor falso, permitindo assim a continuação das outras validações.
        }


    }
}
