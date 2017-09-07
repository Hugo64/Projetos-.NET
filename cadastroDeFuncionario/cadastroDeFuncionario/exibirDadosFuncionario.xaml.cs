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

    public partial class exibirDadosFuncionario : Window
    {
        public static exibirDadosFuncionario exibirF; // Atributo do Form "exibirDadosFuncionario".

        public exibirDadosFuncionario() // Main.
        {
            InitializeComponent();
            exibirF = this; // Instanciando o atributo.

            Funcionario F = new Funcionario();
            ComboBoxEstado.Items.Clear(); // Limpando o item selecionado no "comboBoxEstado" para que possa receber outra seleção.

            try // Abrindo o tratamento de exceções.
            {
                F.Conectando(MainWindow.senhaMysql); // Abrindo conexão com servidor.
                F.Comando.Connection = F.Conexao;
                F.Comando.CommandText = "select Estados from cadastro.tabela"; // Query do servidor.
                F.Reader = F.Comando.ExecuteReader(); // Executando a query.
                if (F.Reader.HasRows) // Se existir registros no servidor será executado a busca ->
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
                MessageBox.Show("Erro no sistema! Por favor contate o desenvolvedor sobre o problema.");
                MessageBox.Show(Ex.ToString()); // Exibindo uma mensagem com o erro.
            }
        }

        private void ButtonVoltar_Click(object sender, RoutedEventArgs e) // Butão para voltar ao Form anterior "BuscaFuncionario".
        {
            exibirF.Close(); // Fechando Form atual.
        }

        private void ButtonEditar_Click(object sender, RoutedEventArgs e) // Butão para edição dos dados do funcionário.
        {
            Funcionario F = new Funcionario(); // Criando um novo objeto (Novo Funcionario). Esse apenas para capturar o nome escrito no "textBoxNome" para ser enviado para verificação e pegar o id deste funcionário. 
            F.pegadoIdParaEditarFuncionario(TextBoxNome.Text); // Pegando o nome escrito no "textBoxNome" e enviando para verificação.
            TextBoxNome.IsEnabled = true; // Habilitando o "TextBoxNome" para edição.
            TextBoxIdentidade.IsEnabled = true; // Habilitando o "TextBoxIdentidade" para edição.
            TextBoxCPF.IsEnabled = true; // Habilitando o "TextBoxCpf" para edição.
            DatePickerDataNascimento.IsEnabled = true; // Habilitando o "DatePickerDataNascimento" para edição.
            TextBoxCidade.IsEnabled = true; // Habilitando o "TextBoxCidade" para edição.
            ComboBoxEstado.IsEnabled = true; // Habilitando o "TextBoxEstado" para edição.
            TextBoxEndereco.IsEnabled = true; // Habilitando o "TextBoxEndereco" para edição.
            TextBoxEmail.IsEnabled = true; // Habilitando o "TextBoxEmail" para edição.
            TextBoxTelefone.IsEnabled = true; // Habilitando o "TextBoxTelefone" para edição.
            TextBoxCelular.IsEnabled = true; // Habilitando o "TextBoxCelular" para edição.
            TextBoxArea.IsEnabled = true; // Habilitando o "TextBoxArea" para edição.
            TextBoxSalario.IsEnabled = true; // Habilitando o "TextBoxSalario" para edição.
            TextBoxFuncao.IsEnabled = true; // Habilitando o "TextBoxFuncao" para edição.
            TextBoxLocal.IsEnabled = true; // Habilitando o "TextBoxLocal" para edição.
            TextBoxMatricula.IsEnabled = true; // Habilitando o "TextBoxMatricula" para edição.
            DatePickerInicio.IsEnabled = true; // Habilitando o "TextBoxInicio" para edição.
            DatePickerFim.IsEnabled = true; // Habilitando o "DatePickerFim" para edição.
            TextBoxObservacao.IsEnabled = true; // Habilitando o "TextBoxObservacao" para edição.
            ButtonLimpar.IsEnabled = true; // Habilitando o butão "Limpar".
            ButtonConfirmar.IsEnabled = true; // Habilitando o butão "Confirmar".
            ButtonDeletar.IsEnabled = false; // Desabilitando o butão "Deletar".
        }

        private void ButtonConfirmar_Click(object sender, RoutedEventArgs e) // Botão responsável por confirmar as alterações feitas no cadastro.
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
                MessageBox.Show("Informe o telefene!"); // Caso esteja vazio será exibida esta mensagem.
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
                MessageBox.Show("Não informe letras no salário, apenas numero."); // Caso contem letras será exibida esta mensagem.
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
            else
            {

                Funcionario F = new Funcionario(); // Criando um novo objeto (Novo funcionario).
                F.Nome = TextBoxNome.Text; // Atribuindo ao objeto Funcionário o Nome alterado no "TextBoxNome" para o atributo Nome.
                F.Identidade = TextBoxIdentidade.Text; // Atribuindo ao objeto Funcionário a Identidade alterada no "TextBoxIdentidade" para o atributo Identidade.
                F.CPF = TextBoxCPF.Text; // Atribuindo ao objeto Funcionario o Cpf alterado no "TextBoxCpf" para o atributo Cpf.
                F.Endereco = TextBoxEndereco.Text; // Atribuindo ao objeto Endereco o Endereço alterado no "TextBoxEndereco" para o atributo Endereco.
                F.Cidade = TextBoxCidade.Text; // Atribuindo ao objeto Funcionário a cidade alterada no "TextBoxCidade" para o atributo Cidade.
                F.Estado = ComboBoxEstado.SelectedItem.ToString(); // Atribuindo ao objeto Funcionário o Estado alterado no "ComboBoxEstado" para o atributo Estado.
                F.Telefone = TextBoxTelefone.Text; // Atribuindo ao objeto Funcionário o Telefone alterado no "TextBoxTelefone" para o atributo Telefone.
                F.Celular = TextBoxCelular.Text; // Atribuindo ao objeto Funcionário o Celular alterado no "TextBoxCelular" para o atributo Celular.
                F.Email = TextBoxEmail.Text; // Atribuindo ao objeto Funcionário o Email alterado no "TextBoxEmail" para o atributo Email.

                if (F.editarFuncionario(F)) // Enviando os dados alterados do objeto para serem alterados no servidor na classe "Funcionario".
                {
                    Departamento D = new Departamento(); // Criando um novo objeto (Novo Departamento).
                    D.Area = TextBoxArea.Text; // Atribuindo ao objeto Departamento a Area alterada no "TextBoxArea" para o atributo Area.
                    D.Salario = Convert.ToDouble(TextBoxSalario.Text); // Atribuindo ao objeto Departamento o Salario alterado no "TextBoxSalario" (Convertido para double) para o atributo Salário.
                    D.Funcao = TextBoxFuncao.Text;  // Atribuindo ao objeto Departamento a Funcao alterada no "TextBoxFuncao" para o atributo Funcão.
                    D.Local = TextBoxLocal.Text;  // Atribuindo ao objeto Departamento o local alterado no "TextBoxLocal" para o atributo Local.
                    D.Matricula = TextBoxMatricula.Text;  // Atribuindo ao objeto Departamento a Matricula alterada no "TextBoxMatricula" para o atributo Matrícula.
                    D.Observacao = TextBoxObservacao.Text;  // Atribuindo ao objeto Departamento a Observação alterada no "TextBoxObservacao" para o atributo Observacao.
                    D.editaDepartamento(D); // Enviando os dados alterados do objeto para serem alterados no servidor na classe "Departamento".
                    MessageBox.Show("Funcionario alterado com sucesso."); // Exibindo a mensagem de cadastro.
                }
                else // Caso houver algum erro...
                {
                    MessageBox.Show("Houve um erro na alteração! Por favor, contate ao desenvolvedor sobre este problema.");
                }
            }
        }

        private void ButtonDeletar_Click(object sender, RoutedEventArgs e) // Butão para deletar o registro.
        {
            Funcionario F = new Funcionario(); // Criando um objeto (Novo Objeto). Apenas para pegar o nome escrito no "TextBoxNome" e enviar para a verificação e assim ser deletado.
            if (F.deletarFuncionario(TextBoxNome.Text)) // Enviando nome para verificação para ser deletado.
            {
                // Limpando o formulário que contia os dados do funcionário deletado.
                TextBoxNome.Text = "";
                TextBoxIdentidade.Text = "";
                TextBoxCPF.Text = "";
                DatePickerDataNascimento.Text = "";
                TextBoxCidade.Text = "";
                ComboBoxEstado.Text = "";
                TextBoxEndereco.Text = "";
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
                TextBoxDataRegistrado.Text = "";

                // Desabilitando o seguintes butões...
                ButtonEditar.IsEnabled = false;
                ButtonDeletar.IsEnabled = false;
                ButtonConfirmar.IsEnabled = false;
                MessageBox.Show("Funcionário deletado com sucesso."); // Mensagem exibida após o funcionário ser deletado do servidor.
            }
            else // Caso houver algum erro quando deletar um funcionário a seguinte mensagem será exibida...
            {
                MessageBox.Show("Não foi possivel deletar, talvez o cadastro já foi deletado. Informe o problema ao desenvolvedor.");
            }

        }

        private void ButtonLimpar_Click(object sender, RoutedEventArgs e) // Butão responsavel por limpar o "TextBoxObservacao".
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
