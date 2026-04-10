using System.Collections.Generic;
using ApiMySql.Model;

namespace ApiMySql.Repository
{
    public interface IPessoaRepository
    {
        IEnumerable<Pessoa> Busca();
        Pessoa BuscaPorId(int idpessoa);
        void Inserir(Pessoa Pessoas);
        void Excluir(int idpessoa);
        void Alterar(int idpessoa, Pessoa Pessoas);
    }
}