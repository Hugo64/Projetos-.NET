using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace cadastroDeFuncionario
{
    public class Departamento : conexaoMysql
    {

        // Atributos.
        public static string idDepartamento { get; set; } // Para editar.

        public string        Area           { get; set; }
        public double        Salario        { get; set; }
        public string        Funcao         { get; set; }
        public string        Local          { get; set; }
        public string        Matricula      { get; set; }
        public string        Observacao     { get; set; }

        // Métodos.

        public void addDepartamento(Departamento D, DateTime dataRegistrado) // Adicionando o objeto Departamento para o funcionário cadastrado (1º parametro recebendo o objeto). (2º parametro) Recebendo a data e hora do cadastro automaticamente.
        {
            try // Abrindo o tratamento de exceções.
            {
                Conectando(MainWindow.senhaMysql); // Abrindo conexão com servidor.
                Comando.Connection = Conexao;
                Comando.CommandText = "insert into cadastro.departamento (Area, Salario, Funcao, Locall, Matricula, dataInicio, dataFim, Observacoes, dataRegistrado, Funcionario_id)" +
                "values (?,?,?,?,?,?,?,?,?,?)"; // Query do servidor.
                Comando.Parameters.Clear(); // Limpando os parametros para receberem os atributos do objeto.
                Comando.Parameters.AddWithValue("@Area", D.Area); // Enviando a área digitada pelo administrador para o servidor.
                Comando.Parameters.AddWithValue("@Salario", D.Salario); // Enviando o salário digitado pelo administrador para o servidor.
                Comando.Parameters.AddWithValue("@Funcao", D.Funcao); // Enviando a função digitada pelo administrador para o servidor.
                Comando.Parameters.AddWithValue("@Locall", D.Local); // Enviando o local digitado pelo administrador para o servidor.
                Comando.Parameters.AddWithValue("@Matricula", D.Matricula); // Enviando a matricula digitada pelo administrador para o servidor.
                Comando.Parameters.AddWithValue("@dataInicio", cadastrarFuncionario.Cadastrar.DatePickerInicio.SelectedDate.Value.ToString("yyyy/MM/dd")); // Enviando a data de inicio digitada pelo administrador para o servidor.
                Comando.Parameters.AddWithValue("@dataFim", cadastrarFuncionario.Cadastrar.DatePickerFim.SelectedDate.Value.ToString("yyyy/MM/dd")); // Enviando a data de fim digitada pelo administrador para o servidor.
                Comando.Parameters.AddWithValue("@Observacoes", D.Observacao); // Enviando a observação digitada pelo administrador para o servidor.
                Comando.Parameters.AddWithValue("@dataRegistrado", dataRegistrado); // // Enviando a data e hora de cadastro para o servidor.
                Comando.Parameters.AddWithValue("@Funcionario_id", Funcionario.IdFuncionario); // Inserindo id do funcionário que foi cadastrado
                Comando.ExecuteNonQuery(); // Executando a query.
                Conexao.Close(); // Fechando conexão
            }
            catch (Exception Ex) // Tratando as exceções.
            {
                MessageBox.Show("Erro no sistema! Por favor contate o desenvolvedor sobre o problema.");
                MessageBox.Show(Ex.ToString()); // Exibindo mensagem com o erro.
            }
        }

        private void pegandoIdDoDepartamentoParaEditar() // Método responsável por pegar o id do Departamento do funcionário que será editado.
        {
            try // Abrindo o tratamento de exceções.
            {
                Conectando(MainWindow.senhaMysql); // Abrindo conexão com servidor.
                Comando.Connection = Conexao;
                Comando.CommandText = "select * from cadastro.departamento where Funcionario_id = ?"; // Query do servidor.
                Comando.Parameters.Clear(); // Limpando os parametros para receberem os atributos dos objetos.
                Comando.Parameters.AddWithValue("@Funcionario_id", Funcionario.idFuncionarioParaEditar); // Inserindo o id do funcionário pego na classe "Funcionario" para que possa ser usado no parametro para pegar o id do departamento do funcionário que será editado.
                Reader = Comando.ExecuteReader(); // Executando a query.
                if (Reader.HasRows) // Se tiver registros no servidor será executado a busca ->
                {
                    Reader.Read(); // Carregando registros.
                    idDepartamento = Reader["id"].ToString(); // Pegando o id do departamento.
                }
                Reader.Close(); // Fechando consulta.
                Conexao.Close(); // Fechando conexão com servidor.
            }
            catch (Exception Ex) // Tratando as exceções.
            {
                MessageBox.Show("Erro no sistema! Por favor contate o desenvolvedor sobre o problema.");
                MessageBox.Show(Ex.ToString()); // Exibindo mensagem de erro.
            }
        }

        public void editaDepartamento(Departamento D) // Editando o departamento do funcionário.
        {
            pegandoIdDoDepartamentoParaEditar(); // Método para pegar o id do Departamento do funcionário.

            try // Abrindo o tratamento de exceções.
            {
                Conectando(MainWindow.senhaMysql); // Abrindo conexão
                Comando.Connection = Conexao;
                Comando.CommandText = "update cadastro.departamento set Area = ?, Salario = ?, Funcao = ?, Locall = ?, Matricula = ?, dataInicio = ?, dataFim = ?, Observacoes = ? "
                + " where id = ? and Funcionario_id = ?"; // Query do servidor.
                Comando.Parameters.Clear(); // Limpando os parametros para receberam os atributos dos objetos.
                Comando.Parameters.AddWithValue("@Area", D.Area); // Enviando a área alterada pelo administrador para o servidor.
                Comando.Parameters.AddWithValue("@Salario", D.Salario); // Enviando o salário alterado pelo administrador para o servidor.
                Comando.Parameters.AddWithValue("@Funcao", D.Funcao); // Enviando a funcao alterada pelo administrador para o servidor.
                Comando.Parameters.AddWithValue("@Locall", D.Local); // Enviando o local alterado pelo administrador para o servidor.
                Comando.Parameters.AddWithValue("@Matricula", D.Matricula); // Enviando a matrícula alterada pelo administrador para o servidor.
                Comando.Parameters.AddWithValue("@dataInicio", exibirDadosFuncionario.exibirF.DatePickerInicio.SelectedDate.Value.ToString("yyyy/MM/dd")); // Enviando a data de inicio alterada pelo administrador para o servidor.
                Comando.Parameters.AddWithValue("@dataFim", exibirDadosFuncionario.exibirF.DatePickerFim.SelectedDate.Value.ToString("yyyy/MM/dd")); // Enviando a data de fim alterada pelo administrador para o servidor.
                Comando.Parameters.AddWithValue("@Observacoes", D.Observacao); // Enviando a observação alterada pelo administrador para o servidor.
                Comando.Parameters.AddWithValue("@id", idDepartamento); // Inserindo o id do departamento.
                Comando.Parameters.AddWithValue("@Funcionario_id", Funcionario.idFuncionarioParaEditar); // Inserindo o id do funcionário que será alterado.
                Comando.ExecuteNonQuery();// Executando a query.
                Conexao.Close(); // Fechando conexão com servidor.
            }
            catch (Exception Ex) // Tratando as exceções.
            {
                MessageBox.Show("Erro no sistema! Por favor contate o desenvolvedor sobre o problema.");
                MessageBox.Show(Ex.ToString()); // Exibindo uma mensagem com o erro.
            }
        }
    }
}
