using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using Senai.Peoples.WebApi.Repositories;

namespace Senai.Peoples.WebApi.Controllers
{
    /// <summary>
    /// MAS Q M !!!jgggggggggggg
    /// </summary>

    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato domínio/api/NomeController
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto _generoRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private IFuncionariosRepository FuncionariosRepository { get; set; }

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public FuncionariosController()
        {
            FuncionariosRepository = new FuncionariosRepository();
        }

        /// <summary>
        /// Lista todos os funcionarios ID
        /// </summary>

        [HttpGet]
        public IEnumerable<FuncionariosDomain> Get()
        {
            // Faz a chamada para o método .Listar();
            return FuncionariosRepository.Listar();
        }

        /// <summary>
        /// cadastrar um novo funcionario
        /// </summary>
    
        [HttpPost]
        public IActionResult Post(FuncionariosDomain novoFuncionario)
        {
            // Faz a chamada para o método .Cadastrar();
            FuncionariosRepository.Cadastrar(novoFuncionario);

            // Retorna um status code 201 - Created
            return StatusCode(201);
        }

        /// <summary>
        /// Busca um gênero através do seu ID
        /// </summary>

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Cria um objeto generoBuscado que irá receber o gênero buscado no banco de dados
            FuncionariosDomain FuncionariosBuscado = FuncionariosRepository.BuscarPorId(id);

            // Verifica se nenhum gênero foi encontrado
            if (FuncionariosRepository == null)
            {
                // Caso não seja encontrado, retorna um status code 404 com a mensagem personalizada
                return NotFound("Nenhum gênero encontrado");
            }

            // Caso seja encontrado, retorna o gênero buscado
            return Ok(FuncionariosBuscado);
        }

        /// <summary>
        /// Atualiza um funcionario  ID 
        /// </summary>
   
        [HttpPut("{id}")]
        public IActionResult Put(FuncionariosDomain FuncionariosAtualizado, int id)
        {
            // Cria um objeto generoBuscado que irá receber o gênero buscado no banco de dados
            FuncionariosDomain FuncionariosBuscado = FuncionariosRepository.BuscarPorId(id);

            // Verifica se algum gênero foi encontrado
            if (FuncionariosBuscado != null)
            {
                // Tenta atualizar o registro
                try
                {
                    // Faz a chamada para o método .AtualizarIdCorpo();
                    FuncionariosRepository.AtualizarIdUrl(id, FuncionariosAtualizado);

                    // Retorna um status code 204 - No Content
                    return NoContent();
                }
                // Caso ocorra algum erro
                catch (Exception erro)
                {
                    // Retorna BadRequest e o erro
                    return BadRequest(erro);
                }
                
            }

            return NotFound
                (
                    new
                    {
                        mensagem = "Funcionario não encontrado",
                        erro = true
                    }
                );
        }

        
        /// <summary>
        /// Deleta um funcionario ID
        /// </summary>

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Faz a chamada para o método .Deletar();
            FuncionariosRepository.Deletar(id);

            // Retorna um status code com uma mensagem personalizada
            return Ok("Funcionarios deletado");
        }
    }
}