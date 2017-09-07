using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace cadastroDeFuncionario
{
    public class Funcionario : conexaoMysql
    {

        // Atributos.

        public static string   IdFuncionario    { get; set; }
        public string          Nome             { get; set; }
        public string          Identidade       { get; set; }
        public string          CPF              { get; set; }
        public string          Endereco         { get; set; }
        public string          Cidade           { get; set; }
        public string          Estado           { get; set; }
        public string          Telefone         { get; set; }
        public string          Celular          { get; set; }
        public string          Email            { get; set; }
        public int             Foto             { get; set; }

        // Atributos para Deletar.

        public string          idFuncionarioParaDeletar    { get; set; } // Para deletar.

        // Atributos para alterar.

        public static string   idFuncionarioParaEditar     { get; set; } // Para Editar.


        // Métodos.
        

        private bool verificarFuncionario(string Cpf) // Verificando se o funcionário já esta cadastrado no sistema (pelo cpf informado no parametro).
        {
            try // Abrindo o tratamento de exceções.
            {
                Conectando(MainWindow.senhaMysql); // Abrindo conexão com servidor.
                Comando.Connection = Conexao;
                Comando.CommandText = "select * from cadastro.funcionario"; // Query do servidor.
                Reader = Comando.ExecuteReader(); // Executando query.
                if (Reader.HasRows) // Se tiver registros no servidor será executado a busca ->
                {
                    while (Reader.Read()) // Carregando registros.
                    {
                        if (Reader["Cpf"].Equals(Cpf)) // Verificando pelo Cpf inserido no parametro do método se o Cpf já existe no servidor.
                        {
                            return true; // Se o funcionário já existe, será retornado um valor verdadeiro.
                        }
                    }
                }
                Reader.Close(); // Fechando consulta.
                Conexao.Close(); // Fechando conexão.
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Erro no sistema! Por favor contate o desenvolvedor sobre o problema.");
                MessageBox.Show(Ex.ToString()); // Exibindo mensagem de erro.
            }
            return false; // Se o funcionário não existe, será retornado um false
        }

        public bool  addFuncionario(Funcionario F) // Cadastrando o funcionário no servidor.
        {
            if (verificarFuncionario(F.CPF)) // Enviando o Cpf do funcionário para verificação.
            {
                return false; // Se o funcionário já foi cadastrado, será retornado um valor falso informando que o funcionario já existe.
            }
            try // Abrindo o tratamento de exceções.
            {

                Conectando(MainWindow.senhaMysql); // Abrindo conexão com servidor.
                Comando.Connection = Conexao;
                Comando.CommandText = "insert into cadastro.funcionario (Nome, Identidade, Cpf, dataNascimento, Endereco, Cidade, Estado, Telefone, Celular, Email)" +
                "values (?,?,?,?,?,?,?,?,?,?)"; // Query do servidor.
                Comando.Parameters.Clear(); // Limpando os parametros para receberam os atributos do objeto.
                Comando.Parameters.AddWithValue("@Nome", F.Nome); // Enviando o Nome digitado pelo administrador para o servidor.
                Comando.Parameters.AddWithValue("@Identidade", F.Identidade); // Enviando a identidade digitada pelo administrador para o servidor.
                Comando.Parameters.AddWithValue("@Cpf", F.CPF); // Enviando o Cpf digitado pelo administrador para o servidor.
                Comando.Parameters.AddWithValue("@dataNascimento", cadastrarFuncionario.Cadastrar.DatePickerDataNascimento.SelectedDate.Value.ToString("yyyy/MM/dd")); // Enviando a data de inicio digitada pelo administrador para o servidor.
                Comando.Parameters.AddWithValue("@Endereco", F.Endereco); // Enviando o endereço digitado pelo administrador para o servidor.
                Comando.Parameters.AddWithValue("@Cidade", F.Cidade); // Enviando a cidade digitada pelo administrador para o servidor.
                Comando.Parameters.AddWithValue("@Estado", F.Estado); // Enviando o estado selecionado pelo administrador para o servidor.
                Comando.Parameters.AddWithValue("@Telefone", F.Telefone); // Enviando o telefone digitado pelo administrador para o servidor.
                Comando.Parameters.AddWithValue("@Celular", F.Celular); // Enviando o celular digitado pelo administrador para o servidor.
                Comando.Parameters.AddWithValue("@Email", F.Email); // Enviando o email digitado pelo administrador para o servidor.
                Comando.ExecuteNonQuery(); // Executando query.
                Conexao.Close(); // Fechando conexão com servidor.

                Conectando(MainWindow.senhaMysql); // Abrindo conexão com servidor.
                Comando.Connection = Conexao;
                Comando.CommandText = "select * from cadastro.funcionario"; // Query do servidor.
                Reader = Comando.ExecuteReader(); // Executando query.
                if (Reader.HasRows) // Se tiver resgistros no servidor será executado a busca ->
                {
                    while (Reader.Read()) // Carregando registros.
                    {
                        if (Reader["Nome"].ToString().Equals(F.Nome)) // Verificando o nome do funcionário cadastrado.
                        {
                            IdFuncionario = Reader["id"].ToString(); // Pegando o id do funcionário cadastrado.
                        }
                    }
                }
                Reader.Close(); // Fechando consulta.
                Conexao.Close(); // Fechando conexão

            }
            catch (Exception Ex) // Tratando as exceções. 
            {
                MessageBox.Show("Erro no sistema! Por favor contate o desenvolvedor sobre o problema.");
                MessageBox.Show(Ex.ToString()); // Exibindo mensagem de erro.
            }
                return true; // Retornando um valor verdadeiro informando que o funcionário foi cadastrado no servidor.
        }

        public void  pegadoIdParaEditarFuncionario(string Nome) // Pegando o id pelo nome que será fornecido pelo parametro do método. Nome que será fornecido no botão "ButtonEditar" do Form "exibirDadosFuncionario".
        {
            try // Abrindo o tratador de exceções.
            {
                Conectando(MainWindow.senhaMysql); // Abrindo conexão com servidor.
                Comando.Connection = Conexao;
                Comando.CommandText = "select * from cadastro.funcionario"; // Query do servidor.
                Reader = Comando.ExecuteReader(); // Executando query.
                if (Reader.HasRows) // Se tiver registros no servidor será executado a busca ->
                {
                    while (Reader.Read()) // Carregando registros.
                    {
                        if (Reader["Nome"].ToString().Equals(Nome)) // Verificando o funcionário pelo nome e pegando os dados dele.
                        {
                            idFuncionarioParaEditar = Reader["id"].ToString(); // Pegando o id do funcionário escolhido para ser editado.
                        }
                    }
                }
                Reader.Close(); // Fechando consulta.
                Conexao.Close(); // Fechando conexão.
            }
            catch (Exception Ex) // Tratando exceções.
            {
                MessageBox.Show("Erro no sistema! Por favor contate o desenvolvedor sobre o problema.");
                MessageBox.Show(Ex.ToString());
            }
        }

        public bool  editarFuncionario(Funcionario F) // Editando o registro.
        {
            try // Abrindo o tratamento de exceções.
            {
                Conectando(MainWindow.senhaMysql); // Abrindo conexão com servidor.
                Comando.Connection = Conexao;
                Comando.CommandText = "update cadastro.funcionario set Nome = ?, Identidade = ?, Cpf = ?, dataNascimento = ?, Endereco = ?, Cidade = ?, "
                + "Estado = ?, Telefone = ?, Celular = ?, Email = ? where id = ?"; // Query do servidor.
                Comando.Parameters.Clear(); // Limpando os parametros para receberem os atributos do objeto.
                Comando.Parameters.AddWithValue("@Nome", F.Nome); // Enviando o Nome editado pelo administrador para o servidor.
                Comando.Parameters.AddWithValue("@Identidade", F.Identidade); // Enviando a Identidade editada pelo administrador para o servidor.
                Comando.Parameters.AddWithValue("@Cpf", F.CPF); // Enviando o Cpf digitado pelo administrador para o servidor.
                Comando.Parameters.AddWithValue("@dataNascimento", exibirDadosFuncionario.exibirF.DatePickerDataNascimento.SelectedDate.Value.ToString("yyyy/MM/dd")); // Enviando a data de nascimento editada pelo administrador para o servidor.
                Comando.Parameters.AddWithValue("@Endereco", F.Endereco); // Enviando o endereço editado pelo administrador para o servidor.
                Comando.Parameters.AddWithValue("@Cidade", F.Cidade); // Enviando a cidade editada pelo administrador para o servidor.
                Comando.Parameters.AddWithValue("@Estado", F.Estado); // Enviando o estado editado pelo administrador para o servidor.
                Comando.Parameters.AddWithValue("@Telefone", F.Telefone); // Enviando o telefone editado pelo administrador para o servidor.
                Comando.Parameters.AddWithValue("@Celular", F.Celular); // Enviando o celular editado pelo administrador para o servidor.
                Comando.Parameters.AddWithValue("@Email", F.Email); // Enviando o email editado pelo administrador para o servidor.
                Comando.Parameters.AddWithValue("@id", idFuncionarioParaEditar); // Inserindo o id do funcionário pego no método "pegadoIdParaEditarFuncionario".
                Comando.ExecuteNonQuery(); // Executando query.
                Conexao.Close(); // Fechando conexão com servidor.
            }
            catch (Exception Ex) // Tratando as exceções. 
            {
                MessageBox.Show("Erro no sistema! Por favor contate o desenvolvedor sobre o problema.");
                MessageBox.Show(Ex.ToString()); // Exibindo mensagem de erro.
            }
            return true; // Retornando um valor verdadeiro informando que a editagem ocorreu perfeitamente.
        }

        public bool  exibirFuncionario(string nomeOuCpf) // Exibindo dados do funcionário.
        {
            try // Abrindo o tratamento de exceções.
            {
                Conectando(MainWindow.senhaMysql); // Abrindo conexão com servidor
                Comando.Connection = Conexao;
                Comando.CommandText = "select * from cadastro.funcionario as F inner join cadastro.departamento as D on F.id = D.Funcionario_id";
                Reader = Comando.ExecuteReader(); // Executando query.
                if (Reader.HasRows) // Se tiver registros no servidor será executado a busca ->
                {
                    while (Reader.Read()) // Carregando registros.
                    {
                        if (Reader["Nome"].ToString().Equals(nomeOuCpf) || Reader["Cpf"].ToString().Equals(nomeOuCpf)) // Verificando se o nome passado no parametro ou o Cpf está registrado no servidor.
                        {

                            exibirDadosFuncionario Exibir = new exibirDadosFuncionario(); // Criando um objeto para serem inseridos os dados do funcionário no formulario.
                            Exibir.TextBoxNome.Text = Reader["Nome"].ToString(); // Inserindo o nome do funcionário no "TextBoxNome" ... TextBox do Form "exibirDadosFuncionario".
                            Exibir.TextBoxIdentidade.Text = Reader["Identidade"].ToString(); // Inserindo a identidade do funcionário no "TextBoxIdentidade" ... TextBox do Form "exibirDadosFuncionario".
                            Exibir.TextBoxCPF.Text = Reader["Cpf"].ToString(); // Inserindo o Cpf do funcionário no "TextBoxCpf" ... TextBox do Form "exibirDadosFuncionario".
                            Exibir.DatePickerDataNascimento.Text = Reader["dataNascimento"].ToString(); // Inserindo a data de nascimento do funcionário no "DatePickerDataNascimento" ... DatePickerData do Form "exibirDadosFuncionario".
                            Exibir.TextBoxCidade.Text = Reader["Cidade"].ToString(); // Inserindo a cidade do funcionário no "TextBoxCidade" ... TextBox do Form "exibirDadosFuncionario".
                            Exibir.ComboBoxEstado.Text = Reader["Estado"].ToString(); // Inserindo o estado do funcionário no "ComboBoxEstado" ... ComboBox do Form "exibirDadosFuncionario".
                            Exibir.TextBoxEndereco.Text = Reader["Endereco"].ToString(); // Inserindo o endereço do funcionário no "TextBoxEndereço" ... TextBox do Form "exibirDadosFuncionario".
                            Exibir.TextBoxEmail.Text = Reader["Email"].ToString(); // Inserindo o email do funcionário no "TextBoxEmail" ... TextBox do Form "exibirDadosFuncionario".
                            Exibir.TextBoxTelefone.Text = Reader["Telefone"].ToString(); // Inserindo o telefone do funcionário no "TextBoxTelefone" ... TextBox do Form "exibirDadosFuncionario".
                            Exibir.TextBoxCelular.Text = Reader["Celular"].ToString(); // Inserindo o celular do funcionário no "TextBoxCelular" ... TextBox do Form "exibirDadosFuncionario".
                            Exibir.TextBoxArea.Text = Reader["Area"].ToString(); // Inserindo a area do funcionário no "TextBoxAre" ... TextBox do Form "exibirDadosFuncionario".
                            Exibir.TextBoxSalario.Text = Reader["Salario"].ToString(); // Inserindo o salario do funcionário no "TextBoxSalario" ... TextBox do Form "exibirDadosFuncionario".
                            Exibir.TextBoxFuncao.Text = Reader["Funcao"].ToString(); // Inserindo a funcao do funcionário no "TextBoxFuncao" ... TextBox do Form "exibirDadosFuncionario".
                            Exibir.TextBoxLocal.Text = Reader["Locall"].ToString(); // Inserindo o local do funcionário no "TextBoxLocal" ... TextBox do Form "exibirDadosFuncionario".
                            Exibir.TextBoxMatricula.Text = Reader["Matricula"].ToString(); // Inserindo a matricula do funcionário no "TextBoxMatricula" ... TextBox do Form "exibirDadosFuncionario".
                            Exibir.DatePickerInicio.Text = Reader["dataInicio"].ToString(); // Inserindo a data de inicio do funcionário no "DatePickerInicio" ... DatePicker do Form "exibirDadosFuncionario".
                            Exibir.DatePickerFim.Text = Reader["dataFim"].ToString(); // Inserindo a data de fim do funcionário no "DatePickerFim" ... DatePicker do Form "exibirDadosFuncionario".
                            Exibir.TextBoxObservacao.Text = Reader["Observacoes"].ToString(); // Inserindo a observação do funcionário no "TextBoxObservação" ... TextBox do Form "exibirDadosFuncionario".
                            Exibir.TextBoxDataRegistrado.Text = Reader["dataRegistrado"].ToString(); // Inserindo a data de registro do funcionário no "TextBoxRegistrado" ... TextBox do Form "exibirDadosFuncionario".
                            Exibir.ShowDialog();  // Abrindo o Form "exibirDadosFuncionario".
                            buscaFuncionario.buscarF.Close(); // Fechando o Form "buscarFuncionario".
                            buscaFuncionario Buscar = new buscaFuncionario(); // Instanciando um novo Form "buscarFuncionario".
                            Buscar.ShowDialog(); // Abrindo o Form "buscarFuncionario".
                            // Obs: O porque fechar o Form "buscarFuncionario" e abri-lo novamente, é para atualizar os funcionários no listBox, caso seja deletado ou alterado.
                            return true; // Retornando um verdadeiro informando que o funcionário foi encontrado. (Consulta pelo Cpf).
                        }
                    }
                }
                Reader.Close(); // Fechando consulta.
                Conexao.Close(); // Fechando conexão com servidor.
            }
            catch (Exception Ex) // Tratando as exceções. 
            {
                MessageBox.Show("Erro no sistema! Por favor contate o desenvolvedor sobre o problema.");
                MessageBox.Show(Ex.ToString()); // Exibindo mensagem de erro.
            }
            return false; // Retornando um falso informando que o funcionário foi encontrado. (Consulta pelo Cpf).
        }

        public bool  deletarFuncionario(string Nome) // Deletando funcionário e os dados ligados a ele.
        {
            try // Abrindo o tratamento de exceções.
            {
                Conectando(MainWindow.senhaMysql); // Abrindo conexão com servidor.
                Comando.Connection = Conexao;
                Comando.CommandText = "select * from cadastro.funcionario"; // Query do servidor.
                Reader = Comando.ExecuteReader(); // Executanto query.
                if (Reader.HasRows) // Se tiver registros no servidor será executado a busca ->
                {
                    while (Reader.Read()) // Carregando registros.
                    {
                        if (Reader["Nome"].ToString().Equals(Nome)) // Verificando o funcionário pelo nome fornecido pelo parametro do método.
                        {
                            idFuncionarioParaDeletar = Reader["id"].ToString(); // Pegando o id do funcionário.
                        }
                    }
                }
                Reader.Close(); // Fechando consulta.
                Conexao.Close(); // Fechando conexão com servidor.

                Conectando(MainWindow.senhaMysql); // Abrindo conexão com servidor.
                Comando.Connection = Conexao;
                Comando.CommandText = "delete from cadastro.departamento where Funcionario_id = ?"; // Query do servidor.
                Comando.Parameters.Clear(); // Limpando os parametros para receber um novo parametro.
                Comando.Parameters.AddWithValue("@Funcionario_id", idFuncionarioParaDeletar); // Inserindo o id do funcionário para deletar o seu departamento.
                Comando.ExecuteNonQuery(); // Executando query.
                Conexao.Close();  // fechando conexão com servidor.

                Conectando(MainWindow.senhaMysql); // Abrindo conexão com servidor.
                Comando.Connection = Conexao;
                Comando.CommandText = "delete from cadastro.funcionario where id = ?"; // Query do servidor.
                Comando.Parameters.AddWithValue("@id", idFuncionarioParaDeletar); // Inserindo o id do funcionário para deletar seu registro.
                Comando.ExecuteNonQuery(); // Executando query.
                Conexao.Close(); // Fechando conexão com servidor.

                return true; // Retornando um valor verdadeiro informando que ocorreu tudo bem com a exclusão do registro
            }
            catch (Exception Ex) // Tratando as exceções. 
            {
                MessageBox.Show("Erro no sistema! Por favor contate o desenvolvedor sobre o problema.");
                MessageBox.Show(Ex.ToString()); // Exibindo mensagem de erro.
            }
               return false; // Retornando um falso informando que houve um erro na exclusão do resgistro.
        }

    }
}
