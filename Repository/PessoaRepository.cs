using System.Collections.Generic;
using ApiMySql.Model;
using MySql.Data.MySqlClient;
using Dapper;
using System.Linq;
using System.Linq.Expressions;

namespace ApiMySql.Repository
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly string _connectionString;

        public PessoaRepository(string connectionString)
        {
            _connectionString = connectionString;   // Injetando a string de conexão no construtor da classe
        }

        public IEnumerable<Pessoa> Busca()
        {
            using(MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                var commandText = "SELECT IdPessoa, RazaoSocial, CnpjCpf, Email, Telefone, Usuario, Senha ";
                commandText += "FROM Pessoas ";
                commandText += "ORDER BY RazaoSocial ASC ";

                return connection.Query<Pessoa>(commandText);
            }
        }
        public Pessoa BuscaPorId(int idpessoa)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                var commandText = "SELECT IdPessoa, RazaoSocial, CnpjCpf, Email, Telefone, Usuario, Senha ";
                commandText += "FROM Pessoas ";
                commandText += "WHERE IdPessoa ='" + idpessoa + "'";

                return connection.Query<Pessoa>(commandText).FirstOrDefault();
            }
        }

        public void Inserir(Pessoa Pessoa)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                var commandText = "INSERT INTO Pessoas ( ";
                commandText += "RazaoSocial, CnpjCpf, Email, Telefone, Usuario, Senha ) VALUES ( ";
                commandText += "'" + Pessoa.RazaoSocial + "','" + Pessoa.CnpjCpf + "','" + Pessoa.Email + "',";
                commandText += "'" + Pessoa.Telefone + "','" + Pessoa.Usuario + "','" + Pessoa.Senha + "')";

                connection.Query<Pessoa>(commandText);
            }
        }

        public void Alterar(int idpessoa, Pessoa Pessoa)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                var commandText = "UPDATE Pessoas SET ";
                commandText += " RazaoSocial = '" + Pessoa.RazaoSocial + "',";
                commandText += " CnpjCpf = '" + Pessoa.CnpjCpf + "',";
                commandText += " Email = '" + Pessoa.Email + "',";
                commandText += " Telefone = '" + Pessoa.Telefone + "',";
                commandText += " Usuario = '" + Pessoa.Usuario + "',";
                commandText += " Senha = '" + Pessoa.Senha + "'";
                commandText += " WHERE IdPessoa = " + idpessoa ;

                connection.Query<Pessoa>(commandText);
            }
        }

        public void Excluir(int idpessoa)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                var commandText = "DELETE FROM Pessoas WHERE IdPessoa ='" + idpessoa + "'";

                connection.Query<Pessoa>(commandText);
            }
        }
    }
}