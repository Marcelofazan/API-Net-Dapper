using ApiMySql.Model;
using ApiMySql.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiMySql.Controller
{
    [ApiController]
    [Route("/api/[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaRepository _pessoaRepository;

        /*
        Construtor com a dependência de uma interface de repositório. Esta interface terá sua instância injetada pelo contexto
        de injeção do .net core, configurado no arquivo startup.cs na linha 46
         */
        public PessoaController(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        [HttpGet]
        public IEnumerable<Pessoa> Busca()
        {
            var pessoas = _pessoaRepository.Busca();
            return pessoas;
        }

        [HttpGet("{idpessoa}")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult<Pessoa> BuscaPorId(int idpessoa)
        {
            var pessoa = _pessoaRepository.BuscaPorId(idpessoa);
            if (pessoa != null)
                return pessoa;

            return NotFound();
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult<Pessoa> Inserir([FromForm] Pessoa pessoa)
        {
            try
            {
                _pessoaRepository.Inserir(pessoa);
                return pessoa;
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{idpessoa}")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult<Pessoa> Alterar(int idpessoa, [FromForm] Pessoa pessoa)
        {
            try
            {
                pessoa.IdPessoa = idpessoa;
                _pessoaRepository.Alterar(idpessoa, pessoa);

                return pessoa;
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{idpessoa}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult Excluir(int idpessoa)
        {
            try
            {
                _pessoaRepository.Excluir(idpessoa);
                return Ok(new { Description = "Item removido" });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}