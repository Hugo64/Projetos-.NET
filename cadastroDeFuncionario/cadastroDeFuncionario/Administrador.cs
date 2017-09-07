using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace cadastroDeFuncionario
{
    public class Administrador : conexaoMysql
    {
        // Atributos do Administrador.
        public static string   nomeAdministrador   { get; set; } // Atributo que estará exibindo o nome do administrador autenticado no Form "Sistema".

        public string          Nome                { get; set; }
        public string          Email               { get; set; }
        public string          Login               { get; set; }
        public string          Senha               { get; set; }

        // Atributos para editar.

        public static string idAdministradorParaEditar { get; set; }

        // Atributos para bloquear.
        public static string idAdministradorParaBloquear { get; set; } // Para bloquear ou desbloquear.

        // Atributos para deletar.
        public static string idAdministradorParaDeletar { get; set; }

        // Métodos.

        public bool  validarAdministrador(Administrador Adm) // Validando o objeto que possui os atributos Login e Senha passado no parametro para ser validando no servidor.
        {
            try // Abrindo o tratamento de exceções.
            {
                Conectando(MainWindow.senhaMysql); // Abrindo conexão com servidor.
                Comando.Connection = Conexao;
                Comando.CommandText = "select * from cadastro.administrador"; // Query do servidor.
                Reader = Comando.ExecuteReader(); // Executando a query.
                if (Reader.HasRows) // Se tiver resgistros no servidor será executado a busca ->
                {
                    while (Reader.Read()) // Carregando registros.
                    {

                        if (Reader["Login"].ToString().Equals(Adm.Login) && Reader["Senha"].ToString().Equals(Adm.Senha)) // Verificando se o Login e Senha pertence algum registro no servidor.
                        {
                            if (Reader["Bloqueado"].Equals(true)) // Verificando se o administrador esta bloqueado.
                            {
                                MessageBox.Show("Você esta bloqueado! Para ser desbloqueado contate ao desenvolvedor sobre o problema."); // Mensagem de bloqueio para o administrador.
                                break; // Parando o while.
                            }
                            if (Reader["Privilegio"].Equals(true)) // Verificando se o administrador tem privilegios avançados.
                            {
                                Sistema.sistemaCompleto = true; // Abrindo as opções avançadas do sistema.
                            }
                            else // Caso contrario...
                            {
                                Sistema.sistemaCompleto = false; // Deixando as opções avançadas incaessiveis.
                            }
                            nomeAdministrador = Reader["Nome"].ToString(); // Pegando o nome do Administrador autenticado para ser exibido no topo do Form "Sistema".
                            return true; // Retornando um true informando que a autenticação foi realizada com sucesso.
                        }
                    }
                }

                Reader.Close(); // Fechando a consulta.
                Conexao.Close(); // Fechando conexão com o servidor.
            }
            catch (Exception Ex) // Tratando as exceções.
            {
                MessageBox.Show("Erro no sistema! Por favor contate o desenvolvedor sobre o problema.");
                MessageBox.Show(Ex.ToString()); // Exibindo uma mensagem com o erro.
            }
            return false; // Retornando um false caso o login e senha estejam incorretos.
        }

        private bool verificarAdministrador(string loginOuEmail)  // Método responsável por verificar se já existe o login registrado no servidor.
        {
            try // Abrindo o tratamento de exceções.
            {
                Conectando(MainWindow.senhaMysql); // Abrindo conexão com servidor.
                Comando.Connection = Conexao;
                Comando.CommandText = "select * from cadastro.administrador"; // Query do servidor.
                Reader = Comando.ExecuteReader(); // Executando a query.
                if (Reader.HasRows) // Se tiver resgistros no servidor será executado a busca ->
                {
                    while (Reader.Read()) // Carregando registros.
                    {
                        if (Reader["Login"].ToString().Equals(loginOuEmail) || Reader["Email"].ToString().Equals(loginOuEmail)) // Verificando se o login digitado no formulário existe.
                        {
                            return true; // Se o login já existe no servidor, será retornado um valor verdadeiro informando que o login já existe.
                        }
                    }
                }
                Reader.Close(); // Fechando a consulta.
                Conexao.Close(); // Fechando conexão com servidor.
            }
            catch (Exception Ex) // Tratando as exceções.
            {
                MessageBox.Show("Erro no sistema! Por favor contate o desenvolvedor sobre o problema.");
                MessageBox.Show(Ex.ToString()); // Exibindo uma mensagem com o erro.
            }
            return false; // Retornando um falso caso o login não exista no servidor.
        }

        public bool  adicionarAdministrador(Administrador Adm, DateTime dataRegistrado) // Cadastrando um novo Administrador.
        {
            if (verificarAdministrador(Adm.Email))
            {
                MessageBox.Show("Constamos um cadastro com este email no servidor. Por favor, escolha outro."); // Caso a verificação encontrar um cadastro já realizado, o sistema informará uma mensagem.
                return false;
            }
            else if (verificarAdministrador(Adm.Login)) // Enviando o login escolhido pelo novo administrador para ser verificado se já existe no servidor.
            {
                MessageBox.Show("Este login já existe. Por favor, escolha outro."); // Caso a verificação encontrar um cadastro já realizado, o sistema informará uma mensagem.
                return false; // Se o login existe no servidor, será retornado um falso informando que já existe.
            }
            try // Abrindo o tratamento de exceções.
            {

                Conectando(MainWindow.senhaMysql); // Abrindo a conexão com servidor.
                Comando.Connection = Conexao;
                Comando.CommandText = "insert into cadastro.administrador (Nome, Email, Login, Senha, Privilegio, Bloqueado, dataRegistrado) values (?,?,?,?,?,?,?)"; // Query do servidor.
                Comando.Parameters.Clear(); // Limpando os parametros para receberem os atributos do objeto.
                Comando.Parameters.AddWithValue("@Nome", Adm.Nome); // Enviando o nome digitado pelo novo administrador para o servidor.
                Comando.Parameters.AddWithValue("@Email", Adm.Email); // Enviando o email digitado pelo novo administrador para o servidor.
                Comando.Parameters.AddWithValue("@Login", Adm.Login); // Enviando o login digitado pelo novo administrador para o servidor.
                Comando.Parameters.AddWithValue("@Senha", Adm.Senha); // Enviando a senha digitada pelo novo administrador para o servidor.
                Comando.Parameters.AddWithValue("@Privilegio", 0); // Inserindo um valor falso no administrador, informando que ele não possui privilegios avançados.
                Comando.Parameters.AddWithValue("@Bloqueado", 0); // Inserindo um valor falso no administrador informando que ele não esta bloqueado.
                Comando.Parameters.AddWithValue("@dataRegistrado", dataRegistrado); // Inserindo a data que o administrador foi criado.
                Comando.ExecuteNonQuery(); // Executando a query.
                Conexao.Close(); // Fechando a conexão com servidor.
            }
            catch (Exception Ex) // Tratando as exceções.
            {
                MessageBox.Show("Erro no sistema! Por favor contate o desenvolvedor sobre o problema.");
                MessageBox.Show(Ex.ToString()); // Exibindo uma mensagem com o erro.
            }
           return true; // Retornando um valor verdadeiro caso a execução da query ocorreu tudo bem com o cadastro no servidor.
        }

        public bool  exibirAdm(string nomeOuEmail) // Exibindo dados do administrador.
        {
            try // Abrindo o tratamento de exceções.
            {
                Conectando(MainWindow.senhaMysql); // Abrindo conexão com servidor.
                Comando.Connection = Conexao;
                Comando.CommandText = "select * from cadastro.administrador"; // Query do servidor.
                Reader = Comando.ExecuteReader(); // Executando query.
                if (Reader.HasRows) // Se tiver registros no servidor será executado a busca ->
                {
                    while (Reader.Read()) // Carregando registros.
                    {
                        if (Reader["Nome"].ToString().Equals(nomeOuEmail) || Reader["Email"].ToString().Equals(nomeOuEmail)) // Verificando se o nome passado no parametro ou o Email está registrado no servidor.
                        {
                            exibirDadosAdministrador Exibir = new exibirDadosAdministrador(); // Criando um objeto para serem inseridos os dados do administrador no formulario.
                            Exibir.TextBoxNome.Text = Reader["Nome"].ToString(); // Inserindo o nome do administrador no "TextBoxNome" ... TextBox do Form "exibirDadosAdministrador".
                            Exibir.TextBoxEmail.Text = Reader["Email"].ToString(); // Inserindo o Email do administrador no "TextBoxEmail" ... TextBox do Form "exibirDadosAdministrador".
                            Exibir.TextBoxLogin.Text = Reader["Login"].ToString(); // Inserindo o Login do administrador no "TextBoxLogin" ... TextBox do Form "exibirDadosAdministrador".
                            Exibir.TextBoxSenha.Text = Reader["Senha"].ToString(); // Inserindo o nome do administrador no "TextBoxSenha" ... TextBox do Form "exibirDadosAdministrador".
                            if (Reader["Bloqueado"].Equals(true)) // Verificando se o administrador esta bloqueado.
                            {
                                Exibir.imagemAdministradorAtivo.Visibility = Visibility.Hidden; // Deixando a imagem oculta.
                                Exibir.imagemAdministradorBloqueado.Visibility = Visibility.Visible; // Deixando a imagem visivel.
                                Exibir.bloquearAdministrador.Content = "Desbloquear"; // Mudando o texto do botão.
                            }
                            Exibir.TextBoxDataRegistrado.Text = Reader["dataRegistrado"].ToString(); // Inserindo a data registrado do administrador no "TextBoxDataRegistrado" ... TextBox do Form "exibirDadosAdministrador".
                            Exibir.ShowDialog();  // Abrindo o Form "exibirDadosAdministrador".
                            buscarAdministrador.buscarAdm.Close(); // Fechando o Form "buscarAdministrador".
                            buscarAdministrador Buscar = new buscarAdministrador(); // Instanciando um novo Form "buscarAdministrador".
                            Buscar.ShowDialog(); // Abrindo o Form "buscarAdministrador".
                            // Obs: O porque fechar o Form "buscarAdministrador" e abri-lo novamente, é para atualizar os administradores no listBox, caso seja alterado.
                            return true; // Retornando um valor verdadeiro informando que o administrador foi encontrado. (Consulta pelo Email).
                        }
                    }
                }
                Reader.Close(); // Fechando consulta.
                Conexao.Close(); // Fechando conexão com servidor.
            }
            catch (Exception Ex) // Trantando exceções.
            {
                MessageBox.Show("Erro no sistema! Por favor contate o desenvolvedor sobre o problema.");
                MessageBox.Show(Ex.ToString()); // Exibindo mensagem com o erro.
            }
            return false; // Retornando um valor falso informando que o administrador não foi encontrado. (Consulta pelo Email).
        }

        public void  pegandoIdDoAdministradorParaEditar(string Nome) // Método para pegar o id do administrador que será editado. O nome dele foi pego no botão "Editar" fo Form "exibirAdministrador".
        {
            try // Abrindo o tratamento de exceções.
            {
                Conectando(MainWindow.senhaMysql); // Abrindo conexão com servidor.
                Comando.Connection = Conexao;
                Comando.CommandText = "select * from cadastro.administrador"; // Query do servidor.
                Reader = Comando.ExecuteReader(); // Executando query;
                if (Reader.HasRows)  // Verificando se tem registros no servidor.
                {
                    while (Reader.Read()) // Carregando registros.
                    {
                        if (Reader["Nome"].ToString().Equals(Nome)) // Verificando o nome informado no servidor.
                        {
                            idAdministradorParaEditar = Reader["id"].ToString(); // Pegando o id do administrador no qual o nome foi fornecido.
                        }
                    }
                }
                Reader.Close(); // Fechando consulta.
                Conexao.Close(); // Fechando conexão com servidor.
            }
            catch (Exception Ex) // Tratando exceções.
            {
                MessageBox.Show("Erro no sistema! Por favor contate o desenvolvedor sobre o problema.");
                MessageBox.Show(Ex.ToString()); // Exibindo mensagem com erro.
            }

        }

        public bool  editarAdministrador(Administrador Adm) // Inserindo dados alterados no servidor.
        {
            try // Abrindo o tratamento de exceções.
            {
                Conectando(MainWindow.senhaMysql); // Abrindo conexão com servidor.
                Comando.Connection = Conexao;
                Comando.CommandText = "update cadastro.administrador set Nome = ?, Email = ?, Login = ?, Senha = ? where id = ?"; // Query do servidor.
                Comando.Parameters.Clear(); // Limpando os parametros para receberem dados do objeto.
                Comando.Parameters.AddWithValue("@Nome", Adm.Nome); // Enviando o Nome editado pelo administrador para o servidor.
                Comando.Parameters.AddWithValue("@Email", Adm.Email); // Enviando o Email editado pelo administrador para o servidor.
                Comando.Parameters.AddWithValue("@Login", Adm.Login); // Enviando o Login para o servidor.
                Comando.Parameters.AddWithValue("@Senha", Adm.Senha); // Enviando a senha editado pelo administrador para o servidor.
                Comando.Parameters.AddWithValue("@id", idAdministradorParaEditar); // Inserindo o id do administrador que será editado.
                Comando.ExecuteNonQuery(); // Executando query.
                Conexao.Close(); // Fechando conexão com servidor.
            }
            catch (Exception Ex) // Tratando exceções.
            {
                MessageBox.Show("Erro no sistema! Por favor contate o desenvolvedor sobre o problema.");
                MessageBox.Show(Ex.ToString()); // Exibindo mensagem com erro.
            }
            return true; // Retornando um falso, caso a alteração não foi feita no servidor.
        }

        public bool bloquearAdministrador(string Nome) // Método para bloquear o administrador.
        {
            try // Abrindo o tratador de exceções.
            {
                Conectando(MainWindow.senhaMysql); // Abrindo conexão com servidor.
                Comando.Connection = Conexao;
                Comando.CommandText = "select * from cadastro.administrador"; // Query do servidor.
                Reader = Comando.ExecuteReader(); // Executando query.
                if (Reader.HasRows) // Verificando se esxiste registros no servidor.
                {
                    while (Reader.Read()) // Carregando registros.
                    {
                        if (Reader["Nome"].ToString().Equals(Nome)) // Verificando pelo nome se o administrador existe no servidor.
                        {
                            idAdministradorParaBloquear = Reader["id"].ToString(); // Caso exista será pego o id dele.
                        }
                    }
                }
                Reader.Close(); // Fechando consulta.
                Conexao.Close(); // fechando conexão com servidor.

                Conectando(MainWindow.senhaMysql); // Abrindo conexão com servidor.
                Comando.Connection = Conexao;
                Comando.CommandText = "update cadastro.administrador set Bloqueado = ? where id = ?"; // Query do servidor.
                Comando.Parameters.Clear(); // Limpando parametros para receber novos valores.
                Comando.Parameters.AddWithValue("@Bloqueado", true); // Enviando um valor verdadeiro na coluna "Bloqueado" do administrador. Fazendo o administrador está bloqueado.
                Comando.Parameters.AddWithValue("id", idAdministradorParaBloquear); // Inserindo id do administardor.
                Comando.ExecuteNonQuery(); // Execuntando query.
                Conexao.Close(); // Fechando conexão com servidor.
                exibirDadosAdministrador.exibirAdm.bloquearAdministrador.Content = "Desbloquear"; // Mudando o que está escrito no botão que foi clicado para bloquear o administrador para "Desbloquear".
                exibirDadosAdministrador.exibirAdm.imagemAdministradorBloqueado.Visibility = Visibility.Visible; // Deixando a imagem que informava que o administrador estava desbloqueado para oculto.
                exibirDadosAdministrador.exibirAdm.imagemAdministradorAtivo.Visibility = Visibility.Hidden; // Exibindo a imagem que informa que está bloqueado.
                return true; // Retornando um valor verdadeiro informando que o administrador foi bloqueado.
            }
            catch (Exception Ex) // Tratando a exceções.
            {
                MessageBox.Show("Erro no sistema! Por favor contate o desenvolvedor sobre o problema.");
                MessageBox.Show(Ex.ToString()); // Exibindo mensagem com erro.
            }
            return false; // Retonando um falso informando que houve algum erro.
        }

        public bool desbloquearAdministrador(string Nome) // Método para desbloquear o administrador.
        {
            try // Abrindo o tratador de exceções.
            {
                Conectando(MainWindow.senhaMysql); // Abrindo conexão com servidor.
                Comando.Connection = Conexao;
                Comando.CommandText = "select * from cadastro.administrador"; // Query do servidor.
                Reader = Comando.ExecuteReader(); // Executando query.
                if (Reader.HasRows) // Verificando se existe registros no servidor.
                {
                    while (Reader.Read()) // Carregando registros
                    {
                        if (Reader["Nome"].ToString().Equals(Nome)) // Verificando pelo nome se o administrador existe no servidor.
                        {
                            idAdministradorParaBloquear = Reader["id"].ToString(); // Caso exista, será pego o id dele.
                        }
                    }
                }
                Reader.Close(); // Fechando consulta.
                Conexao.Close(); // Fechando conexão com servidor.

                Conectando(MainWindow.senhaMysql); // Abrindo conexão com servidor.
                Comando.Connection = Conexao;
                Comando.CommandText = "update cadastro.administrador set Bloqueado = ? where id = ?"; // Query do servidor.
                Comando.Parameters.Clear(); // Limpando parametros para receber novos valores.
                Comando.Parameters.AddWithValue("@Bloqueado", false); // Enviando um valor falso para a coluna "Bloqueado" do administrador, fazendo ele esta desbloqueado.
                Comando.Parameters.AddWithValue("id", idAdministradorParaBloquear); // Inserindo o id do administrador.
                Comando.ExecuteNonQuery(); // Executando query.
                Conexao.Close(); // Fechando conexão com servidor.
                exibirDadosAdministrador.exibirAdm.bloquearAdministrador.Content = "Bloquear"; // Mudando o que está escrito no botão que foi clicado para bloquear o administrador para "Bloquear".
                exibirDadosAdministrador.exibirAdm.imagemAdministradorBloqueado.Visibility = Visibility.Hidden; // Deixando a imagem que informava que o administrador estava bloqueado para oculto.
                exibirDadosAdministrador.exibirAdm.imagemAdministradorAtivo.Visibility = Visibility.Visible; // Exibindo a imagem que informa que esta desbloqueado.
                return true; // Retornando um valor verdadeiro informando que ocorreu tudo bem com desbloqueio.
            }
            catch (Exception Ex) // Tratando exceções.
            {
                MessageBox.Show("Erro no sistema! Por favor contate o desenvolvedor sobre o problema.");
                MessageBox.Show(Ex.ToString()); // Exibindo mensagem com erro.
            }
            return false; // Retornando um valor falso, informando que houve algum erro.
        }

        public bool deletarAdministrador(string Nome) // Método para deletar um administrador.
        {
            try // Abrindo o tratamento de exceções.
            {
                Conectando(MainWindow.senhaMysql); // Abrindo conexão com servidor.
                Comando.Connection = Conexao;
                Comando.CommandText = "select * from cadastro.administrador"; // Query do servidor.
                Reader = Comando.ExecuteReader(); // Executanto query.
                if (Reader.HasRows) // Se tiver registros no servidor será executado a busca.
                {
                    while (Reader.Read()) // Carregando registros.
                    {
                        if (Reader["Nome"].ToString().Equals(Nome)) // Verificando o administrador pelo nome fornecido pelo parametro do método.
                        {
                            idAdministradorParaDeletar = Reader["id"].ToString(); // Pegando o id do funcionário.
                        }
                    }
                }
                Reader.Close(); // Fechando consulta.
                Conexao.Close(); // Fechando conexão com servidor.

                Conectando(MainWindow.senhaMysql); // Abrindo conexão com servidor.
                Comando.Connection = Conexao;
                Comando.CommandText = "delete from cadastro.administrador where id = ?"; // Query do servidor.
                Comando.Parameters.AddWithValue("@id", idAdministradorParaDeletar); // Inserindo o id do administrador para deletar seu registro.
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
