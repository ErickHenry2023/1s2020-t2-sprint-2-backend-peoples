using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Senai.Peoples.WebApi.Repositories
{

    public class FuncionariosRepository : IFuncionariosRepository
    {
        
        private string stringConexao = "Data Source=WIN-T3EDO5059Q\\SQLEXPRESS; initial catalog=M_Peoples; integrated security=true";
        
   
   
   
        /// <summary>
        /// AtualizarIdUrl
        /// </summary>
   
        public void AtualizarIdUrl(int id, FuncionariosDomain funcionario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdate = "UPDATE Funcionarios SET Nome = @Nome, Sobrenome = @Sobrenome WHERE IdFuncionario = @ID";

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", funcionario.Sobrenome);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Busca um gênero pelo ID
        /// </summary>

        //public FuncionariosDomain BuscarPorId(int id)
        //{
        //    using (SqlConnection con = new SqlConnection(stringConexao))
        //    {
        //        string querySelectById = "SELECT IdFuncionario, Nome FROM Funcionarios WHERE IdFuncionario = @ID";
                
        //        con.Open();

        //        SqlDataReader rdr;

        //        using (SqlCommand cmd = new SqlCommand(querySelectById, con))
        //        {
                    
        //            cmd.Parameters.AddWithValue("@ID", id);

        //            rdr = cmd.ExecuteReader();
       
        //            if (rdr.Read())
        //            {
        //                // Cria um objeto genero
        //                FuncionariosDomain funcionarios = new FuncionariosDomain
        //                {
        //                    // Atribui à propriedade IdGenero o valor da coluna "IdGenero" da tabela do banco
        //                    IdFuncionario = Convert.ToInt32(rdr["IdFuncionario"])

        //                    // Atribui à propriedade Nome o valor da coluna "Nome" da tabela do banco
        //                    ,Nome = rdr["Nome"].ToString()
        //                };

        //                // Retorna o genero com os dados obtidos
        //                return funcionarios;
        //            }

        //            // Caso o resultado da query não possua registros, retorna null
        //            return null;
        //        }
        //    }
        //}

        /// <summary>
        /// Cadastra um novo gênero
        /// </summary>
 
        public void Cadastrar(FuncionariosDomain funcionarios)
        {
            // Declara a conexão passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada
                // string queryInsert = "INSERT INTO Generos(Nome) VALUES ('" + genero.Nome + "')";
                // Não usar dessa forma pois pode causar o efeito Joana D'arc
                // Além de permitir SQL Injection
                // Por exemplo
                // "nome" : "')DROP TABLE Filmes--'"
                // Ao tentar cadastrar o comando acima, irá deletar a tabela Filmes do banco de dados
                // https://www.devmedia.com.br/sql-injection/6102

                // Declara a query que será executada passando o valor como parâmetro, evitando assim os problemas acima
                string queryInsert = "INSERT INTO Funcionarios(Nome, Sobrenome) VALUES (@Nome, @Sobrenome)";

                // Declara o comando passando a query e a conexão
                SqlCommand cmd = new SqlCommand(queryInsert, con);

                // Passa o valor do parâmetro
                cmd.Parameters.AddWithValue("@Nome", funcionarios.Nome);
                cmd.Parameters.AddWithValue("@Sobrenome", funcionarios.Sobrenome);

                // Abre a conexão com o banco de dados
                con.Open();

                // Executa o comando
                cmd.ExecuteNonQuery();
            }
        }

        public void Cadastrar()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deleta um gênero através do seu ID
        /// </summary>

        public void Deletar(int id)
        {
            // Declara a conexão passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada passando o valor como parâmetro
                string queryDelete = "DELETE FROM Funcionarios WHERE IdFuncionario = @ID";

                // Declara o comando passando a query e a conexão
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    // Passa o valor do parâmetro
                    cmd.Parameters.AddWithValue("@ID",id);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Lista todos os gêneros
        /// </summary>
        /// <returns>Retorna uma lista de gêneros</returns>
        //public List<GeneroDomain> Listar()
        //{
        //    // Cria uma lista generos onde serão armazenados os dados
        //    List<GeneroDomain> generos = new List<GeneroDomain>();

        //    // Declara a SqlConnection passando a string de conexão
        //    using (SqlConnection con = new SqlConnection(stringConexao))
        //    {
        //        // Declara a instrução a ser executada
        //        string querySelectAll = "SELECT IdGenero, Nome from Generos";

        //        // Abre a conexão com o banco de dados
        //        con.Open();

        //        // Declara o SqlDataReader para percorrer a tabela do banco
        //        SqlDataReader rdr;

        //        // Declara o SqlCommand passando o comando a ser executado e a conexão
        //        using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
        //        {
        //            // Executa a query
        //            rdr = cmd.ExecuteReader();

        //            // Enquanto houver registros para ler, o laço se repete
        //            while (rdr.Read())
        //            {
        //                // Cria um objeto genero do tipo GeneroDomain
        //                GeneroDomain genero = new GeneroDomain
        //                {
        //                    // Atribui à propriedade IdGenero o valor da primeira coluna da tabela do banco
        //                    IdGenero = Convert.ToInt32(rdr[0]),

        //                    // Atribui à propriedade Nome o valor da coluna "Nome" da tabela do banco
        //                    Nome = rdr["Nome"].ToString()
        //                };

        //                // Adiciona o genero criado à tabela generos
        //                generos.Add(genero);
        //            }
        //        }
        //    }

        //    // Retorna a lista de generos
        //    return generos;
        //}

        public FuncionariosDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada
                string querySelectById = "SELECT IdFuncionario, Nome, Sobrenome FROM Funcionarios WHERE IdFuncionario = @ID";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader fazer a leitura no banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    // Passa o valor do parâmetro
                    cmd.Parameters.AddWithValue("@ID", id);

                    // Executa a query
                    rdr = cmd.ExecuteReader();

                    // Caso a o resultado da query possua registro
                    if (rdr.Read())
                    {
                        // Cria um objeto genero
                        FuncionariosDomain funcionario = new FuncionariosDomain
                        {
                            // Atribui à propriedade IdGenero o valor da coluna "IdGenero" da tabela do banco
                            IdFuncionario = Convert.ToInt32(rdr["IdFuncionario"])

                            // Atribui à propriedade Nome o valor da coluna "Nome" da tabela do banco
                            ,
                            Nome = rdr["Nome"].ToString(),
                            Sobrenome = rdr["Sobrenome"].ToString()
                        };

                        // Retorna o genero com os dados obtidos
                        return funcionario;
                    }

                    // Caso o resultado da query não possua registros, retorna null
                    return null;
                }
            }
        }

        public List<FuncionariosDomain> Listar()
        {
            List<FuncionariosDomain> funcionarios = new List<FuncionariosDomain>();

            // Declara a SqlConnection passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a instrução a ser executada
                string querySelectAll = "SELECT IdFuncionario, Nome, Sobrenome from Funcionarios";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader para percorrer a tabela do banco
                SqlDataReader rdr;

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    // Executa a query
                    rdr = cmd.ExecuteReader();

                    // Enquanto houver registros para ler, o laço se repete
                    while (rdr.Read())
                    {
                        // Cria um objeto genero do tipo FuncionariosDomain
                        FuncionariosDomain funcionario = new FuncionariosDomain
                        {
                            // Atribui à propriedade IdFilme o valor da primeira coluna da tabela do banco
                            IdFuncionario = Convert.ToInt32(rdr[0]),      ///chava primaria 

                            // Atribui à propriedade Nome o valor da coluna "Nome" da tabela do banco
                            Nome = rdr["Nome"].ToString(),
                            Sobrenome = rdr["Sobrenome"].ToString()

                        };

                        // Adiciona o genero criado à tabela generos
                        funcionarios.Add(funcionario);
                    }
                }
            }

            // Retorna a lista de generos
            return funcionarios;
        }
    }
}
